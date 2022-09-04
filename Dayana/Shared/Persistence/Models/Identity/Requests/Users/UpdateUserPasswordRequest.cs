namespace Dayana.Shared.Persistence.Models.Identity.Requests.Users;

public class UpdateUserPasswordRequest
{
    public string NewPassword { get; set; }
    public string LastPassword { get; set; }
}