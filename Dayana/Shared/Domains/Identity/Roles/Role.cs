using Dayana.Shared.Domains.Identity.Users;

namespace Dayana.Shared.Domains.Identity.Roles;

internal class Role: BaseDomain
{
    public string Title { get; set; }

    #region Navigations

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RolePermission> RolePermission { get; set; }

    #endregion
}
