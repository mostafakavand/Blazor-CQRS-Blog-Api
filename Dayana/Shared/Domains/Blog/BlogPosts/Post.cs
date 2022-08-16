using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Domains.Identity.Users;

namespace Dayana.Shared.Domains.Blog.BlogPosts;
internal class Post: BaseDomain
{
    public string PostTitle { get; set; }
    public string Subject { get; set; }
    public string Summary { get; set; }
    public string PostBody { get; set; }

    #region Navigation

    public int PostWriterId { get; set; }
    public User PostWriter { get; set; }

    public int PostCategoryId { get; set; }
    public PostCategory PostCategory { get; set; }

    public List<PostIssue> BlogPostIssues { get; set; }

    #endregion
}
