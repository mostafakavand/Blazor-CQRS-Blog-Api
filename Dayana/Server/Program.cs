using Dayana.Server.Api.Extensions.DependencyInjection;
using Dayana.Server.Api.Extensions.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
var appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

builder.Configuration.AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();
builder.Host.UseSerilog().
    ConfigureLogging(loggingConfiguration => loggingConfiguration.ClearProviders());


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
try
{
    Log.Information("Configuring web host ({ApplicationContext})...", appName);
    ConfigurationManager configuration = builder.Configuration;
    IWebHostEnvironment environment = builder.Environment;
    string address = configuration.GetValue<string>("urls");

    #region builder
    // Add services to the container.
    builder.Services.AddServices(configuration);
    builder.Services.AddConfiguredMediatR();

    builder.Services.AddMvc();

    #endregion

    var app = builder.Build();

    #region app


    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }


    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.UseDeveloperExceptionPage();
    app.UseConfiguredExceptionHandler(environment);

    Log.Information($"Starting {appName}[{env}] on {address}");

    app.UseHttpsRedirection();

    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.MapRazorPages();
    app.MapControllers();
    app.UseRouting();
    app.MapHealthChecks("/health");
    app.MapRazorPages(); // <- Add this (for prerendering)
    app.MapFallbackToPage("/_Host"); // <- Change method + file (for prerendering)

    app.Run();

    #endregion

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", appName);
    return 1;
}
finally
{
    Log.CloseAndFlush();
}