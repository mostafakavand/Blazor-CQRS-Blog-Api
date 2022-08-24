using Dayana.Shared.Persistence.Models.Blog.Base.Comments;
using Dayana.Shared.Persistence.Models.Blog.Base.Issues;

namespace Dayana.Shared.Persistence.Models.Blog.Base.BlogPosts;

public class PostCategoryModel : BaseModel
{
    public string CategoryTitle { get; set; }
    public string CategorySubject { get; set; }
    public string CategoryIcon { get; set; }

    #region Navigation
    public ICollection<PostModel> CategoryPosts { get; set; }
    public ICollection<PostCategoryCommentModel> PostCategoryComments { get; set; }
    public ICollection<PostCategoryIssueModel> PostCategoryIssues { get; set; }
    #endregion
}