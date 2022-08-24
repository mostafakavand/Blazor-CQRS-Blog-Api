using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Commands.Users;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Users;

public class DeleteUserPermissionHandler : IRequestHandler<DeleteUserPermissionCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public DeleteUserPermissionHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeleteUserPermissionCommand request, CancellationToken cancellationToken)
    {

        var entity = await _unitOfWork.Claims.GetClaimByIdAsync(request.ClaimId);

        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: PermissionErrors.ClaimNotFoundError);

        entity.UpdatedAt = DateTime.UtcNow;
        _unitOfWork.Claims.Update(entity);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}