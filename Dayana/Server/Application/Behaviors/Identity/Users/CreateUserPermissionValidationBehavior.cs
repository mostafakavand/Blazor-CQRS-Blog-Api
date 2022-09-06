using Dayana.Server.Application.Validators.Identity.Users;
using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity.Users;

public class CreateUserPermissionValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<CreateUserPermissionCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreateUserPermissionCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreateUserPermissionCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}