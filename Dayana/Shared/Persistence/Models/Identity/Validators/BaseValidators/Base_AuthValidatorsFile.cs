using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Base;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.BaseValidators;

public class LoginResultValidator : AbstractValidator<LoginResult>
{
    public LoginResultValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user name"));

        RuleFor(x => x.FullName)
            .EmailAddress()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("full name"));

        RuleFor(x => x.AccessToken)
            .NotEmpty()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("access token"));
    }
}

public class TokenResultValidator : AbstractValidator<TokenResult>
{
    public TokenResultValidator()
    {
        RuleFor(x => x.AccessToken)
            .NotEmpty()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("access token"));
    }
}