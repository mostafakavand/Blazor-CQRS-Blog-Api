using Dayana.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Server.Api.Extensions.DependencyInjection;

public static class DatabaseInjection
{
    public static IServiceCollection AddConfiguredDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ServerDbConnection")));

        return services;
    }
}