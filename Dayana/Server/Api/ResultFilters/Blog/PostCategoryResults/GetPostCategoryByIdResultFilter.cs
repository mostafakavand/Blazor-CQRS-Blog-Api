using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Blog.PostCategoryResults;

public class GetPostCategoryByIdResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryModel value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.CategoryTitle,
                value.CategoryIcon
            };

        await next();
    }

}