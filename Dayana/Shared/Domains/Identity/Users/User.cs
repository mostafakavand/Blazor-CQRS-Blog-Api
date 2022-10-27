using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Domains.Identity.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dayana.Shared.Domains.Identity.Users;

public class User : BaseDomain, IEntity
{
    #region Identity

    public string Username { get; set; }

    public string Mobile { get; set; }
    public bool IsMobileConfirmed { get; set; }

    public string Email { get; set; }
    public bool IsEmailConfirmed { get; set; }

    #endregion

    #region Login

    public string PasswordHash { get; set; }
    public DateTime? LastPasswordChangeTime { get; set; }

    public int FailedLoginCount { get; set; }
    public DateTime? LockoutEndTime { get; set; }

    public DateTime? LastLoginDate { get; set; }

    #endregion

    #region Profile
    public UserState State { get; set; }

    #endregion

    #region Management

    public string SecurityStamp { get; set; }
    public string ConcurrencyStamp { get; set; }
    public bool IsLockedOut { get; set; }
    #endregion

    #region Navigations

    public ICollection<Claim> Claims { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<Post> UserPosts { get; set; }
    public ICollection<PostCategoryIssueComment> PostCategoryIssueComments { get; set; }
    public ICollection<PostComment> PostComments { get; set; }
    public ICollection<PostIssueComment> PostIssueComments { get; set; }
    public ICollection<PostCategoryIssue> PostCategoryIssues { get; set; }
    public ICollection<PostIssue> PostIssues { get; set; }
    #endregion
}

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(b => b.Username).IsUnique();

        #region Mappings

        builder.Property(b => b.Username)
            .HasMaxLength(Defaults.UsernameMaxLength)
            .IsRequired();

        builder.Property(b => b.Mobile)
            .HasMaxLength(Defaults.MobileNumberMaxLength);

        builder.Property(b => b.Email)
            .HasMaxLength(Defaults.EmailLength);

        builder.Property(b => b.PasswordHash)
            .HasMaxLength(Defaults.PasswordHashLength);

        builder.Property(b => b.SecurityStamp)
            .IsConcurrencyToken()
            .HasMaxLength(Defaults.SecurityStampLength)
            .IsFixedLength();

        builder.Property(b => b.ConcurrencyStamp)
            .IsConcurrencyToken()
            .HasMaxLength(Defaults.SecurityStampLength);

        #endregion

        #region Conversions

        builder.Property(x => x.State)
            .HasConversion(new EnumToStringConverter<UserState>())
            .HasMaxLength(UserState.Active.GetMaxLength());

        #endregion

        #region Navigations


        builder
            .HasMany(x => x.Claims)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(x => x.UserRoles)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion


    }
}