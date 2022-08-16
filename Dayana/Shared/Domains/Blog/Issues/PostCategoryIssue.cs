using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Identity.Users;

namespace Dayana.Shared.Domains.Blog.Issues;
internal class PostCategoryIssue: BaseDomain
{
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }


    #region Navigation

    public int PostCategoryId { get; set; }
    public PostCategory PostCategory { get; set; }

    public int IssueWriterId { get; set; }
    public User IssueWriter { get; set; }

    #endregion
}
