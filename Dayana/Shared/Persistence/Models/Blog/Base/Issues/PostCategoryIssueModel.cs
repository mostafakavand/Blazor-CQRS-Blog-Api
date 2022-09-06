using Dayana.Shared.Persistence.Models.Blog.Base.BlogPosts;
using Dayana.Shared.Persistence.Models.Blog.Base.Comments;

namespace Dayana.Shared.Persistence.Models.Blog.Base.Issues;
public class PostCategoryIssueModel : BaseModel
{
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }

    #region Navigation
    public int PostCategoryId { get; set; }
    public PostCategoryModel PostCategory { get; set; }

    public int IssueWriterId { get; set; }
    public UserModel IssueWriter { get; set; }
    public ICollection<PostCategoryIssueCommentModel> PostCategoryIssueComments { get; set; }
    #endregion
}
