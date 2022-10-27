using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Blog.Requests;

#region post

public record CreatePostCommentRequest
{
    public string CommentOwnerEid { get; set; }
    public string CommentPostEid { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public string? ReplyToCommentEid { get; set; }
}

public record GetPostCommentByFilterRequest : DefaultPaginationFilter
{
    protected GetPostCommentByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetPostCommentByFilterRequest()
    {
    }
}

public record UpdatePostCommentRequest
{
    public string CommentOwnerEid { get; set; }
    public string CommentPostEid { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public string? ReplyToCommentEid { get; set; }
}

#endregion

#region post category

public record CreatePostCategoryCommentRequest
{
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }
}
public record GetPostCategoryCommentByFilterRequst : DefaultPaginationFilter
{
    protected GetPostCategoryCommentByFilterRequst(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetPostCategoryCommentByFilterRequst()
    {
    }
}

public record UpdatPostCategoryeCommentRequest
{
    public string CommentTitle { get; set; }
    public string CommentDescription { get; set; }
}

#endregion