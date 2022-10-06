using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Queries;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.QueryValidators;

public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
{
    public GetRoleByIdQueryValidator()
    {
        RuleFor(x => x.RoleId)
            .NotEqual(0)
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("role id"));
    }
}


public class GetRolesByFilterQueryValidator : AbstractValidator<GetRolesByFilterQuery>
{
    public GetRolesByFilterQueryValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<Role>.InvalidVariableError("title"));
    }
}