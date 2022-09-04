using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Persistence.Models.Identity.Queries.Permissions;
using Dayana.Shared.Persistence.Models.Identity.Queries.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.QueryValidators;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEqual(0)
            .WithState(_ => UserErrors.InvalidUserIdValidationError);
    }
}


public class GetUsersByFilterQueryValidator : AbstractValidator<GetUsersByFilterQuery>
{
    public GetUsersByFilterQueryValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}