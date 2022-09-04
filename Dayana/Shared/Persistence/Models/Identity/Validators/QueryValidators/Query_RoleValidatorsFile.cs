using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Queries.Permissions;
using Dayana.Shared.Persistence.Models.Identity.Queries.Roles;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.QueryValidators;

public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
{
    public GetRoleByIdQueryValidator()
    {
        RuleFor(x => x.RoleId)
            .NotEqual(0)
            .WithState(_ => RoleErrors.InvalidRoleIdError);
    }
}


public class GetRolesByFilterQueryValidator : AbstractValidator<GetRolesByFilterQuery>
{
    public GetRolesByFilterQueryValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}