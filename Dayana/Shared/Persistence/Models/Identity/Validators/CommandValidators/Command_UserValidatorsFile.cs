﻿using Dayana.Shared.Basic.ConfigAndConstants.Constants;
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
            .Length(2, Defaults.UsernameLength)
            .WithState(_ => GenericErrors<User>.CustomError(variableName:"user name", 
            causeOfError:$"user name length should be greater than 2 and less than {Defaults.UsernameLength}"));

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(Defaults.MinPasswordLength)
            .WithState(_ => GenericErrors<User>.);

        RuleFor(x => x.Mobile)
            .MaximumLength(Defaults.MobileNumberLength)
            .WithState(_ => UserErrors.InvalidPhoneNumberValidationError);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidEmailValidationError);
    }
}


public class CreateUserPermissionCommandValidator : AbstractValidator<CreateUserPermissionCommand>
{
    public CreateUserPermissionCommandValidator()
    {

        RuleFor(x => x.PermissionId)
            .NotEmpty()
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.PermissionId)
            .GreaterThan(0)
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidUserIdValidationError);

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => UserErrors.InvalidUserIdValidationError);

    }
}


public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);
    }
}


public class DeleteUserPermissionCommandValidator : AbstractValidator<DeleteUserPermissionCommand>
{
    public DeleteUserPermissionCommandValidator()
    {
        RuleFor(x => x.ClaimId)
            .NotEmpty()
            .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);

        RuleFor(x => x.ClaimId)
            .GreaterThan(0)
            .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);

    }
}


public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => CommonErrors.InvalidInputValidationError);
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
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user id"));
    }
}