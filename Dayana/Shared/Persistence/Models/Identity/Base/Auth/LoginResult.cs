namespace Dayana.Shared.Persistence.Models.Identity.Results.Auth;

public class LoginResult
{
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}