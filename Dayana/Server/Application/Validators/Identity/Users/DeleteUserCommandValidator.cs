using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Commands.Users;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Users;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);
    }
}