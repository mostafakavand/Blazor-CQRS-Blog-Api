using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Roles;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.PermissionIds)
            .NotEmpty()
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("permission Ids"));

        RuleFor(x => x.Title)
           .NotEmpty()
           .Length(min: Defaults.MinTitleLength, max: Defaults.MaxTitleLength)
           .WithState(_ => GenericErrors<Role>.IntervalError(min: Defaults.MinTitleLength, max: Defaults.MaxTitleLength, "title"));

    }
}