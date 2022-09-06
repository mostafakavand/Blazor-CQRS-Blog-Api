using Dayana.Server.Application.Validators.Identity.Roles;
using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity.Roles;

public class DeleteRoleValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<DeleteRoleCommand, OperationResult>
{
    public async Task<OperationResult> Handle(DeleteRoleCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new DeleteRoleCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}