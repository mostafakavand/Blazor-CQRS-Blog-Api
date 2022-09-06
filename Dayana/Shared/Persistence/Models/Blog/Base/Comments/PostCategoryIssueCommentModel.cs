using Dayana.Shared.Persistence.Models.Blog.Base.Issues;
using Dayana.Shared.Persistence.Models.Identity.Base;

namespace Dayana.Shared.Persistence.Models.Blog.Base.Comments;
public class PostCategoryIssueCommentModel : BaseModel
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostCategoryIssueId { get; set; }
    public PostCategoryIssueModel PostCategoryIssue { get; set; }

    public int CommentOwnerId { get; set; }
    public UserModel CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    #endregion
}
