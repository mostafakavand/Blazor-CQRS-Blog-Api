namespace Dayana.Shared.Persistence.Models.Identity.Requests.Roles;

public class UpdateRoleRequest
{
    public string Title { get; set; }
    public IList<string> PermissionEids { get; set; }
}