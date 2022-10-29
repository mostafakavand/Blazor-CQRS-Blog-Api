using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Blog;

public class CreatePostResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is Post value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.PostTitle,
                value.Summary,
                PostBody = value.PostBody
            };

        await next();
    }
}

public class DeletePostResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is Post value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.PostTitle
            };

        await next();
    }
}

public class GetPostByFilterResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<PostModel> value)
            result.Value = new
            {
                value.Page,
                value.PageSize,
                value.TotalCount,
                Data = value.Data.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    x.PostTitle,
                    x.Summery,
                    x.PostBody,

                })
            };

        await next();
    }
}


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

public class UpdatePostResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is Post value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.PostTitle,
            };

        await next();
    }
}