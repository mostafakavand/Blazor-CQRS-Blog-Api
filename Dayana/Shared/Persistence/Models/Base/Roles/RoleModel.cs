using Dayana.Shared.Persistence.Models.Base.Permissions;
using Dayana.Shared.Persistence.Models.Base.Users;

namespace Dayana.Shared.Persistence.Models.Base.Roles;

public class RoleModel
{
    public int Id { get; set; }
    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<UserRoleModel> UserRoles { get; set; }
    public ICollection<RolePermissionModel> RolePermission { get; set; }
    public List<PermissionModel> Permissions { get; public set; }
}