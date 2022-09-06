using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Persistence.Models.Identity.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Identity.Auth;

public class GetProfileResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is UserModel value)
            result.Value = new
            {
                value.Id,
                value.Username,
                Roles = value.UserRoles.Select(x => new
                {
                    Id = x.RoleId.EncodeInt(),
                }),
                value.Email,
                value.CreatedAt,
                value.UpdatedAt
            };

        await next();
    }
}