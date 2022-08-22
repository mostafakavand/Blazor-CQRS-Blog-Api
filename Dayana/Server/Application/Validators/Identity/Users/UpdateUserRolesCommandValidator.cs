using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Commands.Users;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Users;

public class UpdateUserRolesCommandValidator : AbstractValidator<UpdateUserRolesCommand>
{
    public UpdateUserRolesCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}