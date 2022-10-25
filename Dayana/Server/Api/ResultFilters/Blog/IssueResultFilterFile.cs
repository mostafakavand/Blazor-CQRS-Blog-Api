using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;

namespace Dayana.Server.Api.ResultFilters.Blog;

#region post issue


public class CreatePostIssueResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostIssue value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostId = value.PostId.EncodeInt(),
                EWriterId = value.IssueWriterId.EncodeInt(),
                value.IssueDescription,
                value.IssueTitle,
                value.PostIssueComments,
            };

        await next();
    }
}

public class DeletePostIssueResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostIssue value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostId = value.PostId.EncodeInt(),
            };

        await next();
    }
}

public class GetPostIssueByFilterResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<PostIssueModel> value)
            result.Value = new
            {
                value.Page,
                value.PageSize,
                value.TotalCount,
                Data = value.Data.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    EPostId = x.PostId.EncodeInt(),
                    x.IssueDescription,
                    x.IssueTitle,
                    x.PostIssueComments

                })
            };

        await next();
    }
}


public class GetPostIssueByIdResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostIssueModel value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostId = value.PostId.EncodeInt(),
                value.IssueDescription,
                value.IssueTitle,
                value.PostIssueComments
            };

        await next();
    }
}

public class UpdatePostIssueResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostIssue value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostId = value.PostId.EncodeInt(),
            };

        await next();
    }
}

#endregion