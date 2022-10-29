using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Queries;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.QueryValidators;

public class GetPermissionsByFilterQueryValidator : AbstractValidator<GetPermissionsByFilterQuery>
{
    public GetPermissionsByFilterQueryValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<Permission>.InvalidVariableError("filter"));
    }
}