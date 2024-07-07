using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Api_2._0;
using Api_2;

public static class IdentityConfiguration
{
    public static void ConfigureIdentityServices(IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<AppDbContext>();
    }
}
