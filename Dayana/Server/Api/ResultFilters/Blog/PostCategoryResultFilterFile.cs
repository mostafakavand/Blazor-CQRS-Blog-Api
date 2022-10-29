using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Blog;

public class CreatePostCategoryResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategory value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.CategoryTitle,
                value.CategoryIcon,
            };

        await next();
    }
}


public class DeletePostCategoryResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategory value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.CategoryTitle
            };

        await next();
    }
}

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

public class UpdatePostCategoryResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategory value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.CategoryTitle
            };

        await next();
    }
}