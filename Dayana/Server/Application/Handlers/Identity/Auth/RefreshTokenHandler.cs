using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Queries.Auth;
using Dayana.Shared.Persistence.Models.Identity.Results.Auth;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Auth;

internal class RefreshTokenHandler : IRequestHandler<RefreshTokenQuery, OperationResult>
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