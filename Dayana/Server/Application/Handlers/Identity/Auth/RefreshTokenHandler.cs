using Dayana.Server.Application.Errors.Identity;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Auth;

internal class RefreshTokenHandler : IRequestHandler<RefreshTokenQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public RefreshTokenHandler(IUnitOfWork unitOfWork)
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