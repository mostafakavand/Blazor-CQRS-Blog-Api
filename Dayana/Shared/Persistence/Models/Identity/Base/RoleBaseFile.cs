namespace Dayana.Shared.Persistence.Models.Identity.Base;
public record RoleModel
{
    public int Id { get; set; }
    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<UserRoleModel> UserRoles { get; set; }
    public ICollection<RolePermissionModel> RolePermission { get; set; }
    public List<PermissionModel> Permissions { get; set; }
}


public record RolePermissionModel
{
    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public PermissionModel Permission { get; set; }
    public RoleModel Role { get; set; }
}