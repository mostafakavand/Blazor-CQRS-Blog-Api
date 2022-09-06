using Dayana.Shared.Persistence.Models.Identity.Base;

namespace Dayana.Shared.Persistence.Models.Blog.Base;
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