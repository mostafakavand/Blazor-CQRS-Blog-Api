using Dayana.Shared.Infrastructure.Errors.Identity;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Users;

public class UpdateUserPasswordHandler : IRequestHandler<UpdateUserPasswordCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserPasswordHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);
        if (user == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.UserNotFoundError);

        user.PasswordHash = PasswordHasher.Hash(request.NewPassword);

        user.UpdatedAt = DateTime.Now;

        _unitOfWork.Users.Update(user);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: user);
    }
}