using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Domains.Identity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dayana.Shared.Domains.Blog.Issues;
public class PostIssue : BaseDomain, IEntity
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

public class PostIssueEntityConfiguration : IEntityTypeConfiguration<PostIssue>
{
    public void Configure(EntityTypeBuilder<PostIssue> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.IssueTitle).IsRequired().HasMaxLength(Defaults.ShortLength5);
        builder.Property(e => e.IssueDescription).IsRequired().HasMaxLength(Defaults.LongLength9);

        #endregion

        #region Navigations
        builder.HasOne(e => e.Post).WithMany(e => e.PostIssues).HasForeignKey(e => e.PostId);
        builder.HasOne(e => e.IssueWriter).WithMany(e => e.PostIssues)
            .HasForeignKey(e => e.IssueWriterId).OnDelete(DeleteBehavior.NoAction); ;
        #endregion
    }
}