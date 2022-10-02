using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Users;

public class CreateUserPermissionCommandValidator : AbstractValidator<CreateUserPermissionCommand>
{
    public CreateUserPermissionCommandValidator()
    {

        RuleFor(x => x.PermissionId)
            .NotEmpty()
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.PermissionId)
            .GreaterThan(0)
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidUserIdValidationError);

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => UserErrors.InvalidUserIdValidationError);

    }
}