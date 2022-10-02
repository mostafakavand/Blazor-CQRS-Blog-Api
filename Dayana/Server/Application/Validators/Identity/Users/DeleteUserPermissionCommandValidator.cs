using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Users;

public class DeleteUserPermissionCommandValidator : AbstractValidator<DeleteUserPermissionCommand>
{
    public DeleteUserPermissionCommandValidator()
    {
        RuleFor(x => x.ClaimId)
            .NotEmpty()
            .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);

        RuleFor(x => x.ClaimId)
            .GreaterThan(0)
            .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);

    }
}