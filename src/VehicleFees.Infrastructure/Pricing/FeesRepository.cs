using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFees.Application.Abstractions.Pricing;
using VehicleFees.Domain.Fees;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Infrastructure.Pricing;

public class FeesRepository : IFeesRepository
{
    private List<FeesCost> _feesList;
    public FeesRepository()
    {
        _feesList = FeesData.GetDefaultFees();
    }
    public FeesCost GetFeesByVehicleType(VehicleType vehicleType)
    {
        return _feesList.FirstOrDefault(fee => fee.VehicleType == vehicleType);
    }
}
