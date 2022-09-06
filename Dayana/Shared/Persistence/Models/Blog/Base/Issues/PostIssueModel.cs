using Dayana.Shared.Persistence.Models.Blog.Base.BlogPosts;
using Dayana.Shared.Persistence.Models.Blog.Base.Comments;

namespace Dayana.Shared.Persistence.Models.Blog.Base.Issues;
public class PostIssueModel : BaseModel
{
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }

    #region Navigation
    public int PostId { get; set; }
    public PostModel Post { get; set; }

    public int IssueWriterId { get; set; }
    public UserModel IssueWriter { get; set; }
    public ICollection<PostIssueCommentModel> PostIssueComments { get; set; }
    #endregion
}
