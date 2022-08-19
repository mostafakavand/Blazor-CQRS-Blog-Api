using Dayana.Shared.Persistence;
using Dayana.Shared.Persistence.Interfaces;

namespace Dayana.Server.Api.Extensions.DependencyInjection;

public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}