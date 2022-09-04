using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Queries.Auth;
using Dayana.Shared.Persistence.Models.Identity.Queries.Permissions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.QueryValidators;

public class GetPermissionsByFilterQueryValidator : AbstractValidator<GetPermissionsByFilterQuery>
{
    public GetPermissionsByFilterQueryValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}