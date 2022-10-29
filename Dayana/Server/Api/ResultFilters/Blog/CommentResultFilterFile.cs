using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Blog;

#region post Comment


public class CreatePostCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostId = value.PostId.EncodeInt(),
                ECommentOwnerId = value.CommentOwnerId.EncodeInt(),
                EReplyTOCommentId = value.ReplyToCommentId?.EncodeInt(),
                value.CommentText,
                value.CreatedAt,
                value.UpdatedAt,
            };

        await next();
    }
}

public class DeletePostCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostId = value.PostId.EncodeInt(),
            };

        await next();
    }
}

public class GetPostCommentByFilterResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<PostCommentModel> value)
            result.Value = new
            {
                value.Page,
                value.PageSize,
                value.TotalCount,
                Data = value.Data.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    EPostId = x.PostId.EncodeInt(),
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

public class GetPostCommentByIdResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCommentModel value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostId = value.PostId.EncodeInt(),
                ECommentOwnerId = value.CommentOwnerId.EncodeInt(),
                EReplyTOCommentId = value.ReplyToCommentId?.EncodeInt(),
                value.CommentText,
                value.CreatedAt,
                value.UpdatedAt,
            };

        await next();
    }
}

public class UpdatePostCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostId = value.PostId.EncodeInt(),
            };

        await next();
    }
}

#endregion

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