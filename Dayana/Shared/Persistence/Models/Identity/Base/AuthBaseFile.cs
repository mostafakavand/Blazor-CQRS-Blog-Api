namespace Dayana.Shared.Persistence.Models.Identity.Base;

public record LoginResult
{
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

public record TokenResult
{
    public string AccessToken { get; set; }
}