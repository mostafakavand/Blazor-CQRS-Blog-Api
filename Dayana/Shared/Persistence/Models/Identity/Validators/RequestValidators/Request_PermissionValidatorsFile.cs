using Dayana.Shared.Persistence.Models.Identity.Requests.Permissions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.RequestValidators;

public class GetPermissionsByFilterRequestValidator : AbstractValidator<GetPermissionsByFilterRequest>
{
    public GetPermissionsByFilterRequestValidator()
    {
        // every thing is nullable man
    }
}