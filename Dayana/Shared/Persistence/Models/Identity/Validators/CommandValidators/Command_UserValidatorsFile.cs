using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.CommandValidators;


public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user name"));

        RuleFor(x => x.Username)
            .Length(Defaults.UsernameMinLength, Defaults.UsernameMaxLength)
            .WithState(_ => GenericErrors<User>.IntervalError(min: Defaults.UsernameMinLength, max: Defaults.UsernameMaxLength, "user name"));

        RuleFor(x => x.Password)
            .NotEmpty()
            .Length(Defaults.MinPasswordLength, Defaults.MaxPasswordLength)
            .WithState(_ => GenericErrors<User>.IntervalError(Defaults.MobileNumberMinLength, Defaults.MobileNumberMaxLength, "mobile number length"));

        RuleFor(x => x.Mobile)
            .Length(Defaults.MobileNumberMinLength, Defaults.MobileNumberMaxLength)
            .WithState(_ => GenericErrors<User>.IntervalError(Defaults.MinPasswordLength, Defaults.MaxPasswordLength, "password length"));

        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("email"));
    }
}


public class CreateUserPermissionCommandValidator : AbstractValidator<CreateUserPermissionCommand>
{
    public CreateUserPermissionCommandValidator()
    {

        RuleFor(x => x.PermissionId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<User>.InvalidVariableError("premission id"));

        RuleFor(x => x.UserId)
            .NotEmpty()
            .GreaterThan(0)
            .NotNull()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user id"));
    }
}


public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user id"));
    }
}


public class DeleteUserPermissionCommandValidator : AbstractValidator<DeleteUserPermissionCommand>
{
    public DeleteUserPermissionCommandValidator()
    {
        RuleFor(x => x.ClaimId)
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<User>.InvalidVariableError("claim id"));
    }
}


public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotNull()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user id"));
    }
}

public class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
{
    public UpdateUserPasswordCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user id"));

        RuleFor(x => x.NewPassword)
          .NotEmpty()
          .WithState(_ => GenericErrors<User>.InvalidVariableError("new password"));
    }
}

public class UpdateUserRolesCommandValidator : AbstractValidator<UpdateUserRolesCommand>
{
    public UpdateUserRolesCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("user id"));
    }
}