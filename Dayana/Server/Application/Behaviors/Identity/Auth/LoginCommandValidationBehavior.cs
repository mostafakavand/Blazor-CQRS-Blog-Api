using Dayana.Server.Application.Validators.Identity.Auth;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity.Auth;

public class LoginCommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<LoginCommand, OperationResult>
{
    public async Task<OperationResult> Handle(LoginCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        // Validation
        var validation = new LoginCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.Errors[0].CustomState);

        return await next();
    }
}