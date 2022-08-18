using Dayana.Shared.Basic.MethodsAndObjects.HealthChecks;

namespace Dayana.Server.Api.Extensions.DependencyInjection;

public static class HealthCheckInjection
{
    public static IServiceCollection AddConfiguredHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<GeneralHealthCheck>("general-check");

        return services;
    }
}