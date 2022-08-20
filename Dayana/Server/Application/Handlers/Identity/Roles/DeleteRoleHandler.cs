using Dayana.Server.Application.Errors.Identity;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Roles;

public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoleHandler(IUnitOfWork unitOfWork)
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