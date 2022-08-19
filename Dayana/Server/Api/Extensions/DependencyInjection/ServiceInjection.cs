using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories.UnitOfWorks;

namespace Dayana.Server.Api.Extensions.DependencyInjection;

public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWorkIdentity, UnitOfWorkIdentity>();

        return services;
    }
}