using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Api_2;

public static class DbContextConfiguration
{
    public static void ConfigureDbContextServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("DefaultConnections")));
    }
}
