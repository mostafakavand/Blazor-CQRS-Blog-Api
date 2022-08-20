using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity.Users;

public class UpdateUserRolesValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<UpdateUserRolesCommand, OperationResult>
{
    public async Task<OperationResult> Handle(UpdateUserRolesCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new UpdateUserRolesCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}