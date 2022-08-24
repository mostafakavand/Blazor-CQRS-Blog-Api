using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Domains.Identity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dayana.Shared.Domains.Blog.Comments;
public class PostCategoryIssueComment : BaseDomain, IEntity
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostCategoryIssueId { get; set; }
    public PostCategoryIssue PostCategoryIssue { get; set; }

    public int CommentOwnerId { get; set; }
    public User CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    #endregion
}

public class PostCategoryIssueCommentEntityConfiguration : IEntityTypeConfiguration<PostCategoryIssueComment>
{
    public void Configure(EntityTypeBuilder<PostCategoryIssueComment> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.CommentText).IsRequired().HasMaxLength(Defaults.LongLength1);

        #endregion

        #region Navigations

        builder.HasOne(e => e.PostCategoryIssue).WithMany(e => e.PostCategoryIssueComments).HasForeignKey(e => e.PostCategoryIssueId);
        builder.HasOne(e => e.CommentOwner).WithMany(e => e.PostCategoryIssueComments)
            .HasForeignKey(e => e.CommentOwnerId).OnDelete(DeleteBehavior.NoAction); ;
        #endregion
    }
}