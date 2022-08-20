using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity.Users;

public class CreateUserValidationBehavior<TRequest, TResponse> : IPipelineBehavior<CreateUserCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreateUserCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreateUserCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}