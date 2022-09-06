using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Base;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.BaseValidators;

public class LoginResultValidator : AbstractValidator<LoginResult>
{
    public LoginResultValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidUsernameValidationError);

        RuleFor(x => x.FullName)
            .EmailAddress()
            .WithState(_ => UserErrors.InvalidFullNameValidationError);

        RuleFor(x => x.AccessToken)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidAccessTokenValidationError);
    }
}


public class TokenResultValidator : AbstractValidator<TokenResult>
{
    public TokenResultValidator()
    {
        RuleFor(x => x.AccessToken)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidAccessTokenValidationError);
    }
}