using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.CommandValidators;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.PermissionIds)
            .NotEmpty()
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("permission id's"));

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(Defaults.NameLength)
            .WithState(_ => GenericErrors<Role>.CustomError(causeOfError: $"the title can not be empty and its the maximum length is {Defaults.NameLength} character", variableName: "title"));
    }
}

public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(x => x.RoleId)
            .GreaterThan(0)
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("role id"));
    }
}


public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(x => x.RoleId)
            .GreaterThan(0)
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("role id"));

        RuleFor(x => x.PermissionIds)
            .NotEmpty()
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("permissions id's"));

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(Defaults.NameLength)
            .WithState(_ => GenericErrors<Role>.CustomError(causeOfError: $"the title can not be empty and its the maximum length is {Defaults.NameLength} character", variableName: "title"));

    }
}