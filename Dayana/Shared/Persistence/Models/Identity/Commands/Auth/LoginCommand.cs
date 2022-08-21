using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using FluentValidation;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Commands.Auth;

public class LoginCommand : IRequestInfo, IRequest<OperationResult>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .When(x => string.IsNullOrEmpty(x.Email))
            .WithState(_ => UserErrors.InvalidEmailValidationError);

        RuleFor(x => x.UserName)
            .EmailAddress()
            .When(x => string.IsNullOrEmpty(x.UserName))
            .WithState(_ => UserErrors.InvalidUsernameValidationError);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidPasswordValidationError);
    }
}