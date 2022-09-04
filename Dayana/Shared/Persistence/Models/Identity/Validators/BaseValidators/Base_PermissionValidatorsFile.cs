using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Base.Claims;
using Dayana.Shared.Persistence.Models.Identity.Base.Permissions;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.BaseValidators;


public class ClaimModelValidator : AbstractValidator<ClaimModel>
{
    public ClaimModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(0)
            .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);

        RuleFor(x => x.UserId)
          .NotEqual(0)
          .WithState(_ => UserErrors.UserNotFoundError);

        RuleFor(x => x.Value)
           .NotEmpty()
           .WithState(_ => PermissionErrors.ClaimNotFoundError);
    }
}


public class PermissionModelValidator : AbstractValidator<PermissionModel>
{
    public PermissionModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(0)
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.Value)
           .NotEmpty()
           .WithState(_ => PermissionErrors.ClaimNotFoundError);
    }
}