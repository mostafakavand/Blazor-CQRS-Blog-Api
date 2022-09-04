using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Requests.Auth;
using Dayana.Shared.Persistence.Models.Identity.Requests.Roles;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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