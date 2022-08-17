namespace Dayana.Shared.Basic.ConfigAndConstants.Configs;
public class RedisCacheConfig
{
    public const string Key = "RedisCache";

    public string SingleNode { get; set; } = "";
    public string[] ClusterNodes { get; set; } = new string[1];
    public bool IsClusterEnabled { get; set; }
    public string[] Connections => IsClusterEnabled ? ClusterNodes : new[] { SingleNode };
}