using Dayana.Shared.Domains.Identity.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Domains.Identity.Users;

internal class UserRole: BaseDomain
{
    #region Navigations

    public int RoleId { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }
    public Role Role { get; set; }

    #endregion
}
