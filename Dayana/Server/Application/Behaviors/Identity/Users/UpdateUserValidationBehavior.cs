using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity.Users;

public class UpdateUserValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<UpdateUserCommand, OperationResult>
{
    public async Task<OperationResult> Handle(UpdateUserCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new UpdateUserCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}