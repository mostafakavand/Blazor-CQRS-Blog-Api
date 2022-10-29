using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Users;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user id"));
    }
}