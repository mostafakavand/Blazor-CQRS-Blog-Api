using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Queries;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.QueryValidators;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEqual(0)
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user id"));
    }
}


public class GetUsersByFilterQueryValidator : AbstractValidator<GetUsersByFilterQuery>
{
    public GetUsersByFilterQueryValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("Filter"));
    }
}