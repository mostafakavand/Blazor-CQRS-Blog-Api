using Dayana.Shared.Persistence.Models.Identity.Queries;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.QueryValidators;
public class GetUserProfileQueryValidator : AbstractValidator<GetUserProfileQuery>
{
    public GetUserProfileQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidUserIdValidationError);
    }
}

public class RefreshTokenQueryValidator : AbstractValidator<RefreshTokenQuery>
{
    public RefreshTokenQueryValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}