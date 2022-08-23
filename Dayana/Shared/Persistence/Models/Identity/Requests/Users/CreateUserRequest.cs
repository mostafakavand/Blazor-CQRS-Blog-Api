namespace Dayana.Shared.Persistence.Models.Identity.Requests.Users;

public class CreateUserRequest
{
    public string Username { get; set; }
    public string Mobile { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}