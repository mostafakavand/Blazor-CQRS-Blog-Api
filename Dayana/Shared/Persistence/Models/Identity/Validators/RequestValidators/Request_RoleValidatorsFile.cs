using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Requests;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.RequestValidators;

public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
{
    public CreateRoleRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("title"));

        RuleFor(x => x.PermissionEids)
         .NotEmpty()
         .WithState(_ => GenericErrors<Role>.InvalidVariableError("permission eids"));
    }
}

public class GetRolesByFilterRequestValidator : AbstractValidator<GetRolesByFilterRequest>
{
    public GetRolesByFilterRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("title"));

        RuleFor(x => x.PermissionEids)
         .NotEmpty()
         .WithState(_ => GenericErrors<Role>.InvalidVariableError("title"));
    }
}

public class UpdateRoleRequestValidator : AbstractValidator<UpdateRoleRequest>
{
    public UpdateRoleRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("title"));

        RuleFor(x => x.PermissionEids)
         .NotEmpty()
         .WithState(_ => GenericErrors<Role>.InvalidVariableError("permission eids"));
    }
}