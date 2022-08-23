using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Persistence.Models.Identity.Base.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Identity.Roles;

public class GetRoleByIdResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is RoleModel value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.Title,
                value.CreatedAt,
                value.UpdatedAt,
                Permissions = value.Permissions.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    x.Title,
                    x.Name,
                    x.Value
                })
            };

        await next();
    }
}