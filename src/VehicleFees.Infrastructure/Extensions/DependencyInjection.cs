using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VehicleFees.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services, 
    IConfiguration configuration)
    {
        services.AddStackExchangeRedisOutputCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("RedisConn");
            options.InstanceName = "VehicleFee";
        });
        services.AddOutputCache(options =>
        {
            options.AddBasePolicy(policy => policy
                .Expire(TimeSpan.FromMinutes(10)));

            options.AddPolicy("CarPolicy", policy => policy
                .Expire(TimeSpan.FromMinutes(5)));
        });
        
        return services;
    }

    public static void UseInfrastructure(this WebApplication app)
    {
        app.UseOutputCache();
    }
}


