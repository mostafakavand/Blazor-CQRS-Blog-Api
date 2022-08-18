using Dayana.Shared.Basic.ConfigAndConstants.Configs;

namespace Dayana.Server.Api.Extensions.DependencyInjection;

public static class ConfigurationInjection
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RedisCacheConfig>(configuration.GetSection(RedisCacheConfig.Key));
        services.Configure<RabbitMQConfig>(configuration.GetSection(RabbitMQConfig.Key));

        return services;
    }
}