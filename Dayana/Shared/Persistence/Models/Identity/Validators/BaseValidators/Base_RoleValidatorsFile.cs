using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Base;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.BaseValidators;

public class RoleModelValidator : AbstractValidator<RoleModel>
{
    public RoleModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(0)
            .WithState(_ => RoleErrors.InvalidRoleIdError);

        RuleFor(x => x.Title)
           .NotEmpty()
           .WithState(_ => RoleErrors.InvalidRoleTitleError);
    }
}

public class RolePermissionModelValidator : AbstractValidator<RolePermissionModel>
{
    public RolePermissionModelValidator()
    {
        RuleFor(x => x.RoleId)
            .NotEqual(0)
            .WithState(_ => RoleErrors.InvalidRoleIdError);

        RuleFor(x => x.PermissionId)
             .NotEqual(0)
             .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);
    }
}