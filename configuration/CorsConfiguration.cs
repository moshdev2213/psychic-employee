using Microsoft.Extensions.DependencyInjection;

public static class CorsConfiguration
{
    public static void ConfigureCorsServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });
    }
}
