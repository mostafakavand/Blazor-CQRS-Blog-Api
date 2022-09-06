using Dayana.Shared.Persistence.Models.Blog.Base.BlogPosts;

namespace Dayana.Shared.Persistence.Models.Blog.Base.Comments;
public class PostCategoryCommentModel : BaseModel
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostCategoryId { get; set; }
    public PostCategoryModel PostCategory { get; set; }

    public int CommentOwnerId { get; set; }
    public UserModel CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    #endregion
}
