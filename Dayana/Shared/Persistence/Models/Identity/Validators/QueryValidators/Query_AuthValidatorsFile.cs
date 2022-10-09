using Dayana.Shared.Domains.Identity.Claims;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Queries;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.QueryValidators;
public class GetUserProfileQueryValidator : AbstractValidator<GetUserProfileQuery>
{
    public GetUserProfileQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithState(_ => GenericErrors<User>.InvalidVariableError("user id"));
    }
}

public class RefreshTokenQueryValidator : AbstractValidator<RefreshTokenQuery>
{
    public RefreshTokenQueryValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithState(_ => GenericErrors<Claim>.InvalidVariableError("refresh token"));
    }
}