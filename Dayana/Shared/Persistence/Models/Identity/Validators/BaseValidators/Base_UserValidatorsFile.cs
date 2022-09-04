using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Base.Users;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.BaseValidators;
public class UserModelValidator : AbstractValidator<UserModel>
{
    public UserModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(0)
            .WithState(_ => UserErrors.InvalidUserIdValidationError);

        RuleFor(x => x.Username)
           .NotEmpty()
           .WithState(_ => UserErrors.InvalidLastNameValidationError);

        RuleFor(x => x.Email)
           .NotEmpty()
           .WithState(_ => UserErrors.InvalidEmailValidationError);

        RuleFor(x => x.PasswordHash)
         .NotEmpty()
         .WithState(_ => UserErrors.InvalidPasswordValidationError);
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