using Dayana.Shared.Persistence.Models.Base.Permissions;

namespace Dayana.Shared.Persistence.Models.Base.Roles;

public class RolePermissionModel
{
    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public PermissionModel Permission { get; set; }
    public RoleModel Role { get; set; }
}