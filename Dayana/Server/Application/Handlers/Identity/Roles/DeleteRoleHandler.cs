using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Commands.Roles;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Roles;

public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public DeleteRoleHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Roles.GetRoleByIdAsync(request.RoleId);

        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: RoleErrors.RoleNotFoundError);

        entity.UpdatedAt = DateTime.Now;
        _unitOfWork.Roles.Update(entity); ;

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}