using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Application.Abstractions.Fees;

public interface IFeesService
{
    Task<VehicleResponse> CalculateTotalPrice(VehicleInformation vehicleInformation, CancellationToken cancellationToken);
}
