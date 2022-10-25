using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Domains.Blog.Comments;

namespace Dayana.Server.Api.ResultFilters.Blog;

#region post issue Comment


public class CreatePostIssueCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostIssueComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostIssueId = value.PostIssueId.EncodeInt(),
                ECommentOwnerId = value.CommentOwnerId.EncodeInt(),
                EReplyTOCommentId = value.ReplyToCommentId?.EncodeInt(),
                value.CommentText,
                value.CreatedAt,
                value.UpdatedAt,
            };  

        await next();
    }
}

public class DeletePostIssueCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostIssueComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostIssueId = value.PostIssueId.EncodeInt(),
            };

        await next();
    }
}

public class GetPostIssueCommentByFilterResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<PostIssueCommentModel> value)
            result.Value = new
            {
                value.Page,
                value.PageSize,
                value.TotalCount,
                Data = value.Data.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    EPostIssueId = x.PostIssueId.EncodeInt(),
                    ECommentOwnerId = x.CommentOwnerId.EncodeInt(),
                    EReplyTOCommentId = x.ReplyToCommentId?.EncodeInt(),
                    x.CommentText,
                    x.CreatedAt,
                    x.UpdatedAt,
                })
            };

        await next();
    }
}

public class GetPostIssueCommentByIdResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostIssueCommentModel value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostIssueId = value.PostIssueId.EncodeInt(),
                ECommentOwnerId = value.CommentOwnerId.EncodeInt(),
                EReplyTOCommentId = value.ReplyToCommentId?.EncodeInt(),
                value.CommentText,
                value.CreatedAt,
                value.UpdatedAt,
            };

        await next();
    }
}

public class UpdatePostIssueCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostIssueComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostIssueId = value.PostIssueId.EncodeInt(),
            };

        await next();
    }
}

#endregion

#region post category issue Comment


public class CreatePostCategoryIssueCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryIssueComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostCategoryIssueId = value.PostCategoryIssueId.EncodeInt(),
                ECommentOwnerId = value.CommentOwnerId.EncodeInt(),
                EReplyTOCommentId = value.ReplyToCommentId?.EncodeInt(),
                value.CommentText,
                value.CreatedAt,
                value.UpdatedAt,
            };

        await next();
    }
}

public class DeletePostCategoryIssueCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryIssueComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostCAtegoryIssueId = value.PostCategoryIssueId.EncodeInt(),
            };

        await next();
    }
}

public class GetPostCategoryIssueCommentByFilterResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<PostCategoryIssueCommentModel> value)
            result.Value = new
            {
                value.Page,
                value.PageSize,
                value.TotalCount,
                Data = value.Data.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    EPostCategoryIssueId = x.PostCategoryIssueId.EncodeInt(),
                    ECommentOwnerId = x.CommentOwnerId.EncodeInt(),
                    EReplyTOCommentId = x.ReplyToCommentId?.EncodeInt(),
                    x.CommentText,
                    x.CreatedAt,
                    x.UpdatedAt,
                })
            };

        await next();
    }
}

public class GetPostCategoryIssueCommentByIdResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryIssueCommentModel value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostCategoryIssueId = value.PostCategoryIssueId.EncodeInt(),
                ECommentOwnerId = value.CommentOwnerId.EncodeInt(),
                EReplyTOCommentId = value.ReplyToCommentId?.EncodeInt(),
                value.CommentText,
                value.CreatedAt,
                value.UpdatedAt,
            };

        await next();
    }
}

public class UpdatePostCategoryIssueCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryIssueComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostCategoryIssueId = value.PostCategoryIssueId.EncodeInt(),
            };

        await next();
    }
}

#endregion

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

#region post category issue


public class CreatePostCategoryIssueResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryIssue value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostCategoryId = value.PostCategoryId.EncodeInt(),
                EWriterId = value.IssueWriterId.EncodeInt(),
                value.IssueDescription,
                value.IssueTitle,
                value.PostCategoryIssueComments,
            };

        await next();
    }
}

public class DeletePostCategoryIssueResultFilter : ResultFilterAttribute
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

public class GetPostCategoryIssueByFilterResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<PostCategoryIssueModel> value)
            result.Value = new
            {
                value.Page,
                value.PageSize,
                value.TotalCount,
                Data = value.Data.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    EPostId = x.PostCategoryId.EncodeInt(),
                    x.IssueDescription,
                    x.IssueTitle,
                    x.PostCategoryIssueComments

                })
            };

        await next();
    }
}


public class GetPostCategoryIssueByIdResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryIssueModel value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostId = value.PostCategoryId.EncodeInt(),
                value.IssueDescription,
                value.IssueTitle,
                value.PostCategoryIssueComments
            };

        await next();
    }
}

public class UpdatePostCategoryIssueResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryIssue value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostId = value.PostCategoryId.EncodeInt(),
            };

        await next();
    }
}

#endregion
