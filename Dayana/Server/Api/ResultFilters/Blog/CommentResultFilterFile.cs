using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;

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

#region post category Comment

public class CreatePostCategoryCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostCategoryId = value.PostCategoryId.EncodeInt(),
                ECommentOwnerId = value.CommentOwnerId.EncodeInt(),
                EReplyTOCommentId = value.ReplyToCommentId?.EncodeInt(),
                value.CommentText,
                value.CreatedAt,
                value.UpdatedAt,
            };

        await next();
    }
}

public class DeletePostCategoryCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostCategoryId = value.PostCategoryId.EncodeInt(),
            };

        await next();
    }
}

public class GetPostCategoryCommentByFilterResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<PostCategoryCommentModel> value)
            result.Value = new
            {
                value.Page,
                value.PageSize,
                value.TotalCount,
                Data = value.Data.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    EPostCategoryId = x.PostCategoryId.EncodeInt(),
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

public class GetPostCategoryCommentByIdResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryCommentModel value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostCategoryId = value.PostCategoryId.EncodeInt(),
                ECommentOwnerId = value.CommentOwnerId.EncodeInt(),
                EReplyTOCommentId = value.ReplyToCommentId?.EncodeInt(),
                value.CommentText,
                value.CreatedAt,
                value.UpdatedAt,
            };

        await next();
    }
}

public class UpdatePostCategoryCommentResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PostCategoryComment value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                EPostCategoryId = value.PostCategoryId.EncodeInt(),
            };

        await next();
    }
}

#endregion
