using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Domains.Identity.Users;
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
            .WithState(_ => GenericErrors<User>.InvalidVariableError("id"));

        RuleFor(x => x.Username)
           .NotEmpty()
           .WithState(_ => GenericErrors<User>.InvalidVariableError("user name"));

        RuleFor(x => x.Email)
           .NotEmpty()
           .WithState(_ => GenericErrors<User>.InvalidVariableError("email"));

        RuleFor(x => x.PasswordHash)
         .NotEmpty()
         .WithState(_ => GenericErrors<User>.InvalidVariableError("password hash"));
    }
}

public class UserRoleModelValidator : AbstractValidator<UserRoleModel>
{
    public UserRoleModelValidator()
    {
        RuleFor(x => x.UserId)
            .NotEqual(0)
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("user id"));

        RuleFor(x => x.RoleId)
           .NotEmpty()
           .WithState(_ => GenericErrors<Role>.InvalidVariableError("role id"));
    }
}