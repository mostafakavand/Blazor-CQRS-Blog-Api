using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Identity.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Domains.Blog.Comments;

internal class PostComment: BaseDomain
{
    public string CommentText { get; set; }
    public bool IsReply { get; set; }

    #region Navigations

    public int PostId { get; set; }
    public Post Post { get; set; }

    public int CommentOwnerId { get; set; }
    public User CommentOwner { get; set; }

    public int? ReplyToCommentId { get; set; }
    public PostComment ReplyToComment { get; set; }
    #endregion
}


internal class PostCommentEntityConfiguration : IEntityTypeConfiguration<PostComment>
{
    public void Configure(EntityTypeBuilder<PostComment> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.CommentText).IsRequired().HasMaxLength(Defaults.LongLength1);

        #endregion

        #region Navigations

        builder.HasOne(e => e.Post).WithMany(e => e.PostComments).HasForeignKey(e => e.PostId);
        builder.HasOne(e => e.CommentOwner).WithMany(e => e.PostComments).HasForeignKey(e => e.CommentOwnerId);
        builder.HasOne(e => e.ReplyToComment).WithOne(e => e.ReplyToComment).HasForeignKey<PostComment>(x => x.ReplyToCommentId);
        #endregion
    }
}