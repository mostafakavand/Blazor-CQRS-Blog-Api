namespace Dayana.Shared.Basic.ConfigAndConstants.Configs;

public class LockoutConfig
{
    public const string Key = "Lockout";

    public int FailedLoginLimit { get; set; }
    public TimeSpan Duration { get; set; }
}