using Dayana.Shared.Domains.Identity.Claims;
using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Base;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.BaseValidators;


public class ClaimModelValidator : AbstractValidator<ClaimModel>
{
    public ClaimModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(0)
            .WithState(_ => GenericErrors<Claim>.InvalidVariableError("id"));

        RuleFor(x => x.UserId)
          .NotEqual(0)
          .WithState(_ => GenericErrors<Claim>.InvalidVariableError("user id"));

        RuleFor(x => x.Value)
           .NotEmpty()
           .WithState(_ => GenericErrors<Claim>.InvalidVariableError("access token"));
    }
}


public class PermissionModelValidator : AbstractValidator<PermissionModel>
{
    public PermissionModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(0)
            .WithState(_ => GenericErrors<Permission>.InvalidVariableError("id"));

        RuleFor(x => x.Value)
           .NotEmpty()
           .WithState(_ => GenericErrors<Permission>.InvalidVariableError("value"));
    }
}