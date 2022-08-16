using Dayana.Shared.Domains.Identity.Roles;

namespace Dayana.Shared.Domains.Identity.Permissions;

internal class Permission: BaseDomain
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Value { get; set; }

    #region Navigations

    public ICollection<RolePermission> Roles { get; set; }

    #endregion
}
