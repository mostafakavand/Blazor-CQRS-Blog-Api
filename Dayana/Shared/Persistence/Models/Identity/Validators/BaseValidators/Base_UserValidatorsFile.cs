using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Base;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.BaseValidators;
public class UserModelValidator : AbstractValidator<UserModel>
{
    public UserModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(0)
            .WithState(_ => GenericErrors<UserModel>.InvalidVariableError("id"));

        RuleFor(x => x.Username)
           .NotEmpty()
           .WithState(_ => GenericErrors<UserModel>.InvalidVariableError("user name"));

        RuleFor(x => x.Email)
           .NotEmpty()
           .WithState(_ => GenericErrors<UserModel>.InvalidVariableError("email"));

        RuleFor(x => x.PasswordHash)
         .NotEmpty()
         .WithState(_ => GenericErrors<UserModel>.InvalidVariableError("password hash"));
    }
}

public class UserRoleModelValidator : AbstractValidator<UserRoleModel>
{
    public UserRoleModelValidator()
    {
        RuleFor(x => x.UserId)
            .NotEqual(0)
            .WithState(_ => UserErrors.InvalidUserIdValidationError);

        RuleFor(x => x.RoleId)
           .NotEmpty()
           .WithState(_ => RoleErrors.InvalidRoleIdError);
    }
}