using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Domains.Identity.Users;

namespace Dayana.Shared.Domains.Blog.Comments;
internal class PostCategoryIssueComment:BaseDomain
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostCategoryIssueId { get; set; }
    public PostCategoryIssue PostCategoryIssue { get; set; }

    public int CommentOwnerId { get; set; }
    public User CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    public PostCategoryIssueComment ReplyToComment { get; set; }
    #endregion
}
