using Microsoft.OpenApi.Models;

namespace TransactionService.Api;

public static class Extensions
{
    public static WebApplicationBuilder AddConfiguration(this WebApplicationBuilder builder)
    {
        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddUserSecrets<Program>(optional: true);

        return builder;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transaction Service API", Version = "v1" });
            });

        return services;
    }
}

public static class EnvironmentExtension
{
    public static bool IsUat(this IHostEnvironment hostEnvironment)
        => hostEnvironment.IsEnvironment("uat");

    public static bool IsLocal(this IHostEnvironment hostEnvironment)
    => hostEnvironment.IsEnvironment("local");
}


