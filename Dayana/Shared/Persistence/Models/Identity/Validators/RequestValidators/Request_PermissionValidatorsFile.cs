using Dayana.Shared.Persistence.Models.Identity.Requests;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.RequestValidators;

public class GetPermissionsByFilterRequestValidator : AbstractValidator<GetPermissionsByFilterRequest>
{
    public GetPermissionsByFilterRequestValidator()
    {
        // every thing is nullable man
    }
}