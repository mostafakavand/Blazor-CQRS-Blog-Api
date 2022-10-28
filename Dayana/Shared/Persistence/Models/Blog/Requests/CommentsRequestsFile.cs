using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Blog.Requests;

#region post comment

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

#region post issue comment


public record CreatePostIssueCommentRequest
{
    public string CommentOwnerEid { get; set; }
    public string CommentPostIssueEid { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public string? ReplyToCommentEid { get; set; }
}

public record GetPostIssueCommentByFilterRequest : DefaultPaginationFilter
{
    protected GetPostIssueCommentByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetPostIssueCommentByFilterRequest()
    {
    }
}

public record UpdatePostIssueCommentRequest
{
    public string CommentOwnerEid { get; set; }
    public string CommentPostIssueEid { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public string? ReplyToCommentEid { get; set; }
}


#endregion

#region post category issue comment

public record CreatePostCategoryIssueCommentRequest
{
    public string CommentOwnerEid { get; set; }
    public string CommentPostCategoryIssueEid { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public string? ReplyToCommentEid { get; set; }
}
public record GetPostCategoryIssueCommentByFilterRequest : DefaultPaginationFilter
{
    protected GetPostCategoryIssueCommentByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetPostCategoryIssueCommentByFilterRequest()
    {
    }
}

public record UpdatePostCategoryIssueCommentRequest
{
    public string CommentOwnerEid { get; set; }
    public string CommentPostCategoryIssueEid { get; set; }
    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public string? ReplyToCommentEid { get; set; }
}

#endregion