using Dayana.Shared.Persistence.Models.Identity.Base;

namespace Dayana.Shared.Persistence.Models.Blog.Base;
public record PostCategoryIssueModel : BaseModel
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

public record PostIssueModel : BaseModel
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
