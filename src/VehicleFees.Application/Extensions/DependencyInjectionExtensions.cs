using Microsoft.Extensions.DependencyInjection;
using VehicleFees.Application.Vehicle.GetTotalPriceVehicle;

namespace VehicleFees.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly);
        });
        services.AddTransient<GetTotalPriceVehicleValidator>();

        return services;
    }
}
