using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Domains.Blog.Issues;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Dayana.Shared.Domains.Blog.Comments;

namespace Dayana.Shared.Domains.Blog.BlogPosts;
public class PostCategory: BaseDomain
{
    public string CategoryTitle { get; set; }
    public string CategorySubject { get; set; }
    public string CategoryIcon { get; set; }

    #region Navigation

    public ICollection<Post> CategoryPosts { get; set; }
    public ICollection<PostCategoryIssue> BlogPostCategoryIssues { get; set; }
    public ICollection<PostCategoryComment> PostCategoryComments { get; set; }
    public ICollection<PostCategoryIssue> PostCategoryIssues { get; set; }
    #endregion
}

public class PostCategoryEntityConfiguration : IEntityTypeConfiguration<PostCategory>
{
    public void Configure(EntityTypeBuilder<PostCategory> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.CategoryTitle).IsRequired().HasMaxLength(Defaults.ShortLength3);

        builder.Property(e => e.CategorySubject).IsRequired().HasMaxLength(Defaults.ShortLength5);

        builder.Property(e => e.CategoryIcon).IsRequired();

        #endregion
    }
}