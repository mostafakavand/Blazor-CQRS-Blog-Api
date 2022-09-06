using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Blog.PostCategoryResults;

public class GetPostCategoryByFilterResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<PostCategoryModel> value)
            result.Value = new
            {
                value.Page,
                value.PageSize,
                value.TotalCount,
                Data = value.Data.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    x.CategoryTitle,
                    x.CategoryIcon
                })
            };

        await next();
    }
}