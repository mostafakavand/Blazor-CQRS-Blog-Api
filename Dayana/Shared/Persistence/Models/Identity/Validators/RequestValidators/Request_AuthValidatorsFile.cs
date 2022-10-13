using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Requests;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.RequestValidators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user name"));

        RuleFor(x => x.Password)
         .NotEmpty()
         .WithState(_ => GenericErrors<User>.InvalidVariableError("password"));
    }
}