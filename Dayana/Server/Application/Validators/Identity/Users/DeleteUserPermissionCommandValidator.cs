using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Users;

public class DeleteUserPermissionCommandValidator : AbstractValidator<DeleteUserPermissionCommand>
{
    public DeleteUserPermissionCommandValidator()
    {
        RuleFor(x => x.ClaimId)
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<Permission>.InvalidVariableError("claim Id"));
    }
}