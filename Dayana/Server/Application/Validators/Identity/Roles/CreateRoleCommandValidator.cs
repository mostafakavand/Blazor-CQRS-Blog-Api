using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Commands.Roles;
using FluentValidation;

namespace Dayana.Server.Application.Validators.Identity.Roles;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.PermissionIds)
            .NotEmpty()
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.Title)
            .MaximumLength(Defaults.NameLength)
            .WithState(_ => CommonErrors.InvalidTitleValidationError);

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithState(_ => CommonErrors.InvalidTitleValidationError);

    }
}