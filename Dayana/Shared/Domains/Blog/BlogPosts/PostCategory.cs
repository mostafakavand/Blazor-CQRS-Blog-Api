using Dayana.Shared.Domains.Blog.Issues;

namespace Dayana.Shared.Domains.Blog.BlogPosts;
internal class PostCategory: BaseDomain
{
    public string CategoryTitle { get; set; }
    public string CategorySubject { get; set; }
    public string CategoryIcon { get; set; }

    #region Navigation

    public List<Post> CategoryPosts { get; set; }

    public List<PostCategoryIssue> BlogPostCategoryIssues { get; set; }

    #endregion
}
