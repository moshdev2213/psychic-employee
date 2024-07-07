using Api_2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceConfiguration
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        // Add controllers
        services.AddControllers();

        // Configure Swagger
        SwaggerConfiguration.ConfigureSwaggerServices(services);

        // Configure DbContext
        DbContextConfiguration.ConfigureDbContextServices(services, configuration);

        // Configure Identity and Authorization
        IdentityConfiguration.ConfigureIdentityServices(services);

        // Register services
        services.AddScoped<IEmpService, EmpService>();

        // Configure CORS
        CorsConfiguration.ConfigureCorsServices(services);
    }
}
