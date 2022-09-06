using Dayana.Shared.Persistence.Models.Blog.Base.Issues;

namespace Dayana.Shared.Persistence.Models.Blog.Base.Comments;
public class PostIssueCommentModel : BaseModel
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostIssueId { get; set; }
    public PostIssueModel PostIssue { get; set; }

    public int CommentOwnerId { get; set; }
    public UserModel CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }

    #endregion
}
