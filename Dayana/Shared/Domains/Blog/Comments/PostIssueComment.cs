using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Domains.Identity.Users;

namespace Dayana.Shared.Domains.Blog.Comments;
internal class PostIssueComment:BaseDomain
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostIssueId { get; set; }
    public PostIssue PostIssue { get; set; }

    public int CommentOwnerId { get; set; }
    public User CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    public PostIssueComment ReplyToComment { get; set; }

    #endregion
}
