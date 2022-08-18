using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Domains.Identity.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Domains.Blog.Comments;
internal class PostIssueComment:BaseDomain
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostIssueId { get; set; }
    public PostIssue PostIssue { get; set; }

    public int CommentOwnerId { get; set; }
    public User CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    public PostIssueComment ReplyToComment { get; set; }

    #endregion
}

internal class PostIssueCommentEntityConfiguration : IEntityTypeConfiguration<PostIssueComment>
{
    public void Configure(EntityTypeBuilder<PostIssueComment> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.CommentText).IsRequired().HasMaxLength(Defaults.LongLength1);

        #endregion

        #region Navigations

        builder.HasOne(e => e.PostIssue).WithMany(e => e.PostIssueComments).HasForeignKey(e => e.PostIssueId);
        builder.HasOne(e => e.CommentOwner).WithMany(e => e.PostIssueComments).HasForeignKey(e => e.CommentOwnerId);
        builder.HasOne(e => e.ReplyToComment).WithOne(e => e.ReplyToComment).HasForeignKey<PostIssueComment>(x => x.ReplyToCommentId);
        #endregion
    }
}