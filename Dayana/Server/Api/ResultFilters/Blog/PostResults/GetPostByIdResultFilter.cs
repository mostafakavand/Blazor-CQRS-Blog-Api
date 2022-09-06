using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Blog.PostResults;

public class GetPostByIdResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostModel value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.PostTitle,
                value.PostBody,
                value.Summery
            };

        await next();
    }
}