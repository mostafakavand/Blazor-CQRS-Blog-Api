using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Commands.Users;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Users;

public class UpdateUserPasswordHandler : IRequestHandler<UpdateUserPasswordCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public UpdateUserPasswordHandler(IUnitOfWorkIdentity unitOfWork)
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