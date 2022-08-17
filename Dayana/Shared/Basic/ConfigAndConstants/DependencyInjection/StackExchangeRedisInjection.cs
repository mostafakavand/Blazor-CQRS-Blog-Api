using Dayana.Shared.Basic.ConfigAndConstants.Configs;
using Dayana.Shared.Basic.MethodsAndObjects.BaseServices.Caching;
using Dayana.Shared.Basic.MethodsAndObjects.BaseServices.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Dayana.Shared.Basic.ConfigAndConstants.DependencyInjection;
public static class StackExchangeRedisInjection
{
    public static IServiceCollection AddStackExchangeRedis(this IServiceCollection services,
        string instancePrefix, RedisCacheConfig config)
    {
        var options = new ConfigurationOptions();
        foreach (var connection in config.Connections)
            options.EndPoints.Add(connection);

        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(options));

        services.AddScoped<ICache>(x =>
            new StackExchangeRedisCache(x.GetRequiredService<IConnectionMultiplexer>(),
                instancePrefix: instancePrefix));

        return services;
    }
}