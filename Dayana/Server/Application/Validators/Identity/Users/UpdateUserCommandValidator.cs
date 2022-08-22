using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Commands.Users;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Users;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}