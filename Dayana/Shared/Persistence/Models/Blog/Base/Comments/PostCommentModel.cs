using Dayana.Shared.Persistence.Models.Blog.Base.BlogPosts;
using Dayana.Shared.Persistence.Models.Identity.Base;

namespace Dayana.Shared.Persistence.Models.Blog.Base.Comments;
public class PostCommentModel : BaseModel
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostId { get; set; }
    public PostModel Post { get; set; }

    public int CommentOwnerId { get; set; }
    public UserModel CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    #endregion
}
