using Dayana.Server.Application.Specifications.Identity.Roles;
using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Commands.Roles;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Roles;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public CreateRoleHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.Roles
            .ExistsAsync(new DuplicateRoleSpecification(request.Title).ToExpression());

        if (isExist)
            return new OperationResult(OperationResultStatus.UnProcessable, value: RoleErrors.DuplicateTitleError);

        var entity = RoleHelper.CreateRole(request);

        _unitOfWork.Roles.Add(entity);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}