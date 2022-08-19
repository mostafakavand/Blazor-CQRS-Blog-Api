using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Persistence.Models.Identity.Base.Claims;

namespace Dayana.Shared.Persistence.Models.Identity.Base.Users;

public class UserModel
{

    public int Id { get; set; }
    public string Username { get; set; }

    public string Mobile { get; set; }
    public bool IsMobileConfirmed { get; set; }

    public string Email { get; set; }
    public bool IsEmailConfirmed { get; set; }

    public string PasswordHash { get; set; }
    public DateTime? LastPasswordChangeTime { get; set; }

    public int FailedLoginCount { get; set; }
    public DateTime? LockoutEndTime { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public UserState State { get; set; }

    public string SecurityStamp { get; set; }
    public string ConcurrencyStamp { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsLockedOut { get; set; }

    public ICollection<ClaimModel> Claims { get; set; }
    public ICollection<UserRoleModel> UserRoles { get; set; }
}