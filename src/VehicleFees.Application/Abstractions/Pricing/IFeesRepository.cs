using VehicleFees.Domain.Fees;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Application.Abstractions.Pricing;

public interface IFeesRepository
{
    public Task<FeesCost> GetFeesByVehicleType(VehicleType vehicleType, CancellationToken cancellationToken);
}
