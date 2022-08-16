using Dayana.Shared.Domains.Identity.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
