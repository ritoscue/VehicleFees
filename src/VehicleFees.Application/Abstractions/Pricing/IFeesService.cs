using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Application.Abstractions.Pricing;

public interface IFeesService
{
    Task<VehicleResponse> CalculateTotalPrice(VehicleInformation vehicleInformation, CancellationToken cancellationToken);
}
