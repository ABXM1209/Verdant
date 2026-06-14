using Api.Config;
using Api.Hubs;
using DotNetEnv;

namespace Api;

public static class Program
{
    private const string AppSettingsPath = "Config/Json";

    private static WebApplication BuildApp()
    {
        Env.TraversePath().Load();

        var builder = WebApplication.CreateBuilder();
        
        builder.Configuration
            .AddJsonFile($"{AppSettingsPath}/appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"{AppSettingsPath}/appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        var appSettings = AppSettingsFactory.Create(builder.Configuration);
        var serviceManager = new ServiceManager(builder.Services, appSettings, builder.Environment);
        serviceManager.ConfigureAndInitializeServices();
        
        Console.WriteLine("Build Complete");
        return builder.Build();
    }

    public static async Task Main(string[] args)
    {
        var app = BuildApp();

        if (app.Environment.IsDevelopment())
        {
            Console.WriteLine("Starting in development mode");
            app.UseOpenApi();
            app.UseSwaggerUi();
        }
        else if (app.Environment.IsProduction())
        {
            Console.WriteLine("Starting in production mode");
        }
        else if (app.Environment.IsStaging())
        {
            Console.WriteLine("Starting in staging mode");
        }
        
        app.UseCors("AllowFrontend");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.MapHealthChecks("/health");
        app.MapHub<GameHub>("/hubs/game");
        
        await app.RunAsync();
    }
}