using Dayana.Shared.Basic.ConfigAndConstants.Configs;
using Dayana.Shared.Basic.ConfigAndConstants.DependencyInjection;

namespace Dayana.Server.Api.Extensions.DependencyInjection;

public static class RedisCacheInjection
{
    public static IServiceCollection AddConfiguredRedisCache(this IServiceCollection services, IConfiguration configuration)
    {
        var config = configuration.GetSection(RedisCacheConfig.Key).Get<RedisCacheConfig>();

        services.AddStackExchangeRedis("server", config);

        return services;
    }
}