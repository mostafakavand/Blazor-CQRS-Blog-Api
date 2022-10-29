using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Roles;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(x => x.RoleId)
            .GreaterThan(0)
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("role Id"));

        RuleFor(x => x.PermissionIds)
            .NotEmpty()
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("permission Ids"));

        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(min: Defaults.MinTitleLength, max: Defaults.MaxTitleLength)
            .WithState(_ => GenericErrors<Role>.IntervalError(min: Defaults.MinTitleLength, max: Defaults.MaxTitleLength, "title"));

    }
}