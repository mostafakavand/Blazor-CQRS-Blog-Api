using Dayana.Shared.Domains.Identity.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Identity.Users;

public class CreateUserResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is User value)
            result.Value = new
            {
                Eid = value.Id,
                value.Username
            };

        await next();
    }
}