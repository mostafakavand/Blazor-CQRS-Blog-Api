using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Users;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user name"));

        RuleFor(x => x.Username)
            .Length(min: Defaults.UsernameMinLength, max: Defaults.UsernameMaxLength)
            .WithState(_ => GenericErrors<User>.IntervalError(min: Defaults.UsernameMinLength, max: Defaults.UsernameMaxLength, variableName: "user name"));

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(Defaults.MinPasswordLength)
            .WithState(_ => GenericErrors<User>
            .CustomError(causeOfError: $"password can not be empty. password minimum lenth is" +
            $" {Defaults.MinPasswordLength}", variableName: "password"));

        RuleFor(x => x.Mobile)
            .NotEmpty()
            .Length(Defaults.MobileNumberMinLength, Defaults.MobileNumberMaxLength)
            .WithState(_ => GenericErrors<User>
            .IntervalError(min: Defaults.MobileNumberMinLength, max: Defaults.MobileNumberMaxLength, "mobile"));

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithState(_ => GenericErrors<User>.NotFoundError("user Id"));
    }
}