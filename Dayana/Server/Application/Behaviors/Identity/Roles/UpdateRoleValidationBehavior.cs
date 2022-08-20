using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity.Roles;

public class UpdateRoleValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<UpdateRoleCommand, OperationResult>
{
    public async Task<OperationResult> Handle(UpdateRoleCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new UpdateRoleCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}