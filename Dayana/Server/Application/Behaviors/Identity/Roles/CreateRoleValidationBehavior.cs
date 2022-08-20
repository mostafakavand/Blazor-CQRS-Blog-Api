using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity.Roles;

public class CreateRoleValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<CreateRoleCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreateRoleCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreateRoleCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}