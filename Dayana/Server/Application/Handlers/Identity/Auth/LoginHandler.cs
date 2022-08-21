using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Commands.Auth;
using Dayana.Shared.Persistence.Models.Identity.Results.Auth;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Auth;

internal class LoginHandler : IRequestHandler<LoginCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity  _unitOfWork;

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