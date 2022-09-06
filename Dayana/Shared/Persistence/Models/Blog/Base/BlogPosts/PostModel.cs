using Dayana.Shared.Persistence.Models.Blog.Base.Comments;
using Dayana.Shared.Persistence.Models.Blog.Base.Issues;

namespace Dayana.Shared.Persistence.Models.Blog.Base.BlogPosts;

public class PostModel : BaseModel
{
    public string PostTitle { get; set; }
    public string Subject { get; set; }
    public string Summery { get; set; }
    public string PostBody { get; set; }

    #region Navigation
    public int PostWriterId { get; set; }
    public UserModel PostWriter { get; set; }

    public int PostCategoryId { get; set; }
    public PostCategoryModel PostCategory { get; set; }

    public ICollection<PostIssueModel> PostIssues { get; set; }
    public ICollection<PostCommentModel> PostComments { get; set; }
    #endregion
}