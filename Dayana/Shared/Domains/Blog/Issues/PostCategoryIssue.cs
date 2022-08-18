using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Domains.Identity.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
    public ICollection<PostCategoryIssueComment> PostCategoryIssueComments { get; set; }
    #endregion
}


internal class PostCategoryIssueEntityConfiguration : IEntityTypeConfiguration<PostCategoryIssue>
{
    public void Configure(EntityTypeBuilder<PostCategoryIssue> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.IssueTitle).IsRequired().HasMaxLength(Defaults.ShortLength5);
        builder.Property(e => e.IssueDescription).IsRequired().HasMaxLength(Defaults.LongLength9);

        #endregion

        #region Navigations
        builder.HasOne(e => e.PostCategory).WithMany(e => e.PostCategoryIssues).HasForeignKey(e => e.PostCategoryId);
        builder.HasOne(e => e.IssueWriter).WithMany(e => e.PostCategoryIssues).HasForeignKey(e => e.IssueWriterId);
        #endregion
    }
}