using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Persistence.Models.Identity.Commands;

namespace Dayana.Shared.Basic.MethodsAndObjects.Helpers;

public static class RoleHelper
{

    public static Role CreateRole(CreateRoleCommand command) => new Role
    {
        Title = command.Title,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
    };

    public static RolePermission CreateRolePermission(int permissionId, int creatorId, int roleId)
    {
        return new RolePermission
        {
            RoleId = roleId,
            PermissionId = permissionId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

}