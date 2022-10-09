using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;
using StackExchange.Redis;

namespace Dayana.Server.Application.Validators.Identity.Roles;

public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(x => x.RoleId)
            .GreaterThan(0)
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("role id"));
    }
}