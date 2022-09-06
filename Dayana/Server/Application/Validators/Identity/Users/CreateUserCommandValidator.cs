using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Users;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidUsernameValidationError);

        RuleFor(x => x.Username)
            .Length(Defaults.UsernameLength)
            .WithState(_ => UserErrors.InvalidUsernameValidationError);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(Defaults.MinPasswordLength)
            .WithState(_ => UserErrors.InvalidPasswordValidationError);

        RuleFor(x => x.Mobile)
            .MaximumLength(Defaults.MobileNumberLength)
            .WithState(_ => UserErrors.InvalidPhoneNumberValidationError);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidEmailValidationError);
    }
}