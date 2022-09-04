using AutoMapper;
using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Base.Users;
using Dayana.Shared.Persistence.Models.Identity.Commands.Auth;
using Dayana.Shared.Persistence.Models.Identity.Queries.Auth;
using Dayana.Shared.Persistence.Models.Identity.Results.Auth;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity;

public class GetUserProfileHandler : IRequestHandler<GetUserProfileQuery, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserProfileHandler(IUnitOfWorkIdentity unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);
        if (user == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.UserNotFoundError);

        var model = _mapper.Map<UserModel>(user);

        return new OperationResult(OperationResultStatus.Ok, value: model);
    }
}


public class LoginHandler : IRequestHandler<LoginCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public LoginHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByUsernameAsync(request.UserName);

        if (user == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.UserNotFoundError);

        // Lockout check
        if (!user.CanLogin())
            return new OperationResult(OperationResultStatus.UnProcessable, value: AuthErrors.InvalidLoginError);

        // Login check via password
        var isLogin = PasswordHasher.Check(user.PasswordHash, request.Password);

        // Lockout history
        if (!isLogin)
        {
            user.TryToLockout();
            _unitOfWork.Users.Update(user);
            await _unitOfWork.CommitAsync();
            return new OperationResult(OperationResultStatus.UnProcessable, value: AuthErrors.InvalidLoginError);
        }

        /* Here user is authenticated */
        // Other updates
        if (user.State == UserState.InActive)
            user.Activate();

        user.LastLoginDate = DateTime.UtcNow;
        user.ResetLockoutHistory();
        _unitOfWork.Users.Update(user);


        var result = new LoginResult
        {
            UserName = user.Username,
            AccessToken = user.CreateJwtAccessToken(),
            RefreshToken = user.CreateJwtRefreshToken()
        };

        return new OperationResult(OperationResultStatus.Ok, value: result);
    }
}


public class RefreshTokenHandler : IRequestHandler<RefreshTokenQuery, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public RefreshTokenHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var username = JwtHelper.GetUsername(request.RefreshToken);

        var user = await _unitOfWork.Users.GetUserByUsernameAsync(username);
        if (user == null)
            return new OperationResult(OperationResultStatus.Unauthorized, value: UserErrors.UserNotFoundError);

        // Lockout check
        if (!user.CanLogin())
            return new OperationResult(OperationResultStatus.Unauthorized, value: AuthErrors.InvalidLoginError);

        var result = new TokenResult
        {
            AccessToken = user.CreateJwtAccessToken(),
        };

        return new OperationResult(OperationResultStatus.Ok, value: result);
    }
}