using VehicleFees.Application.Abstractions.Fees;
using VehicleFees.Domain.Exceptions;
using VehicleFees.Domain.Fees;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Infrastructure.FeesCalculation;

public class FeesRepository : IFeesRepository
{
    public async Task<FeesCost> GetFeesByVehicleType(VehicleType vehicleType, CancellationToken cancellationToken)
    {
        await Task.Delay(2000);  //Simulate any IO process.
        
        var feesCost = FeesData.FeeCostData.FirstOrDefault(fee => fee.VehicleType == vehicleType);
        if (feesCost is null) 
        {
            throw new FeeNotFound($"Fees not found for the '{vehicleType}' vehicle type in the FeesRepository repository.");
        }
        return feesCost;
    }
}
