using Dayana.Server.Application.Specifications.Identity.Roles;
using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Commands.Roles;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Roles;

public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public UpdateRoleHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _unitOfWork.Roles.GetRoleByIdAsync(request.RoleId);

        if (role == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: RoleErrors.RoleNotFoundError);

        var isExist = await _unitOfWork.Roles
            .ExistsAsync(new DuplicateRoleSpecification(request.Title).ToExpression());

        if (isExist && role.Title != request.Title)
            return new OperationResult(OperationResultStatus.UnProcessable, value: RoleErrors.DuplicateTitleError);

        // Update
        role.Title = request.Title;
        role.RolePermission = request.PermissionIds.Distinct()
            .Select(x => RoleHelper.CreateRolePermission(x, request.RequestInfo.UserId, request.RoleId)).ToList();

        role.UpdatedAt = DateTime.Now;

        _unitOfWork.Roles.Update(role);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: role);
    }
}