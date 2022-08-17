using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Comments;
using System.Security.Claims;

namespace Dayana.Shared.Domains.Identity.Users;

internal class User: BaseDomain
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
    public ICollection<PostCategoryComment> PostCategoryComments { get; set; }
    public ICollection<PostCategoryIssueComment> PostCategoryIssueComments { get; set; }
    #endregion
}
