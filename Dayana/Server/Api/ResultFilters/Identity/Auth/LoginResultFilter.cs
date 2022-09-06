using Dayana.Shared.Persistence.Models.Identity.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Identity.Auth;

public class LoginResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is LoginResult value)
            result.Value = new
            {
                Username = value.UserName,
                value.FullName,
                value.AccessToken,
                value.RefreshToken,
            };

        await next();
    }
}