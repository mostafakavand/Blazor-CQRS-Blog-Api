using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Users;

public class CreateUserPermissionCommandValidator : AbstractValidator<CreateUserPermissionCommand>
{
    public CreateUserPermissionCommandValidator()
    {

        RuleFor(x => x.PermissionId)
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<Permission>.InvalidVariableError("permission id"));

        RuleFor(x => x.UserId)
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<Permission>.InvalidVariableError("user Id"));

    }
}