using Dayana.Shared.Domains.Identity.Users;

namespace Dayana.Shared.Persistence.Seeding.Seeds;

public static class UserRoleSeed
{
    public static List<UserRole> All => new List<UserRole>
    {
        new UserRole()
        {
            RoleId = 1,
            UserId = 1,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }
    };
}