using Dayana.Shared.Basic.ConfigAndConstants.Configs;
using Dayana.Shared.Persistence.EntityFrameWorkObjects;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories.UnitOfWorks;
using Dayana.Shared.Persistence.HttpObjects;
using MassTransit;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Server.Api.Extensions.DependencyInjection;

public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {

        // Add services to the container.
        services.AddControllersWithViews();
        services.AddRazorPages();
        // register an HttpClient that points to itself
        services.AddSingleton(sp =>
        {
            // Get the address that the app is currently running at
            var server = sp.GetRequiredService<IServer>();
            var addressFeature = server.Features.Get<IServerAddressesFeature>();
            var baseAddress = addressFeature.Addresses.First();
            return new HttpClient { BaseAddress = new Uri(baseAddress) };
        });

        #region cache redis todo
        // todo  todo todo todo todo todo todo todo todo todo todo todo todo todo todo todo todo todo todo todo todo
        //services.Configure<RedisCacheConfig>(configuration.GetSection(RedisCacheConfig.Key));
        //var config = configuration.GetSection(RedisCacheConfig.Key).Get<RedisCacheConfig>();
        //services.AddStackExchangeRedis("server", config);
        #endregion

        services.AddScoped<IHttpService, HttpService>();

        services.Configure<RabbitMQConfig>(configuration.GetSection(RabbitMQConfig.Key));

        services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("ServerDbConnection"))
          .EnableDetailedErrors());
        var rabbitConfig = configuration.GetSection(RabbitMQConfig.Key).Get<RabbitMQConfig>();
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            x.UsingRabbitMq((context, config) =>
            {
                config.Host(new Uri(rabbitConfig.Host), h =>
                {
                    h.Username(rabbitConfig.Username);
                    h.Password(rabbitConfig.Password);
                }
                );
                config.ConfigureEndpoints(context);
            });
        });
        //services.AddMassTransitHostedService();

        services.AddScoped<IUnitOfWorkIdentity, UnitOfWorkIdentity>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}