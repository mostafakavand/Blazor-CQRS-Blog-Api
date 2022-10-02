using Dayana.Shared.Persistence.Models.Identity.Requests;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.RequestValidators;

public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
{
    public CreateRoleRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithState(_ => RoleErrors.InvalidRoleTitleError);

        RuleFor(x => x.PermissionEids)
         .NotEmpty()
         .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}

public class GetRolesByFilterRequestValidator : AbstractValidator<GetRolesByFilterRequest>
{
    public GetRolesByFilterRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithState(_ => RoleErrors.InvalidRoleTitleError);

        RuleFor(x => x.PermissionEids)
         .NotEmpty()
         .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}

public class UpdateRoleRequestValidator : AbstractValidator<UpdateRoleRequest>
{
    public UpdateRoleRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithState(_ => RoleErrors.InvalidRoleTitleError);

        RuleFor(x => x.PermissionEids)
         .NotEmpty()
         .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}