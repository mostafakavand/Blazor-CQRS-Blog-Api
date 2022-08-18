using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Domains.Identity.Users;

namespace Dayana.Shared.Domains.Blog.Issues;
internal class PostIssue: BaseDomain
{
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }


    #region Navigation

    public int PostId { get; set; }
    public Post Post { get; set; }

    public int IssueWriterId { get; set; }
    public User IssueWriter { get; set; }
    public ICollection<PostIssueComment> PostIssueComments { get; set; }
    #endregion
}
