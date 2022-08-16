using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Identity.Users;

namespace Dayana.Shared.Domains.Blog.Comments;
internal class PostCategoryComment:BaseDomain
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostCategoryId { get; set; }
    public PostCategory PostCategory { get; set; }

    public int CommentOwnerId { get; set; }
    public User CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    public PostCategoryComment ReplyToComment { get; set; }
    #endregion
}
