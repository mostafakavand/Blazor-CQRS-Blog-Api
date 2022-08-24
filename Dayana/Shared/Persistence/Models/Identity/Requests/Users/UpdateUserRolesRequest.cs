namespace Dayana.Shared.Persistence.Models.Identity.Requests.Users;

public class UpdateUserRolesRequest
{
    public IEnumerable<string> RoleEids { get; set; }
}