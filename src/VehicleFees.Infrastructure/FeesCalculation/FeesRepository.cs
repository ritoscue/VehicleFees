using VehicleFees.Application.Abstractions.Fees;
using VehicleFees.Domain.Exceptions;
using VehicleFees.Domain.Fees;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Infrastructure.FeesCalculation;

public class FeesRepository : IFeesRepository
{
    private List<FeesCost> _feesList;
    public FeesRepository()
    {
        _feesList = FeesData.GetDefaultFees();
    }
    public async Task<FeesCost> GetFeesByVehicleType(VehicleType vehicleType, CancellationToken cancellationToken)
    {
        await Task.Delay(2000);  //Simulate any IO process.
        
        var feesCost = _feesList.FirstOrDefault(fee => fee.VehicleType == vehicleType);
        if (feesCost is null) 
        {
            throw new FeeNotFound($"Fees not found for the '{vehicleType}' vehicle type in the FeesRepository repository.");
        }
        return feesCost;
    }
}
