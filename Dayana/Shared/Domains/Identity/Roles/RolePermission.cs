using Dayana.Shared.Domains.Identity.Permissions;

namespace Dayana.Shared.Domains.Identity.Roles;

internal class RolePermission: BaseDomain
{
    #region Navigations

    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    public Permission Permission { get; set; }
    public Role Role { get; set; }

    #endregion
}
