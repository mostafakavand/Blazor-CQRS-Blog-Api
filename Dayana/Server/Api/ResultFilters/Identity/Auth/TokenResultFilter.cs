using Dayana.Shared.Persistence.Models.Identity.Results.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Identity.Auth;

public class TokenResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is TokenResult value)
            result.Value = new
            {
                value.AccessToken
            };

        await next();
    }
}