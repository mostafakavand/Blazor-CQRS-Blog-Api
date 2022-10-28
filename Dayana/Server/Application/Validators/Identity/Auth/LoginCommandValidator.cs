using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Auth;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .When(x => string.IsNullOrEmpty(x.Email))
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user name"));

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => string.IsNullOrEmpty(x.UserName))
            .WithState(_ => GenericErrors<User>.InvalidVariableError("email"));

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("password"));
    }
}