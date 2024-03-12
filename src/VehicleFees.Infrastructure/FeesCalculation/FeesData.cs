using VehicleFees.Domain.Fees;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Infrastructure.FeesCalculation;

internal class FeesData
{
    public static List<FeesCost> FeeCostData { get;} =
    [
        new FeesCost
        {
            MinimumBasicFee = 10,
            MaximumBasicFee = 50,
            BaseFeePercentage = 0.1m,
            SpecialFeePercentage = 0.02m,
            StorageFee = 100,
            VehicleType = VehicleType.Common,
            AssociatedFee = 
            {
                { 500, 5 },
                { 1000, 10 },
                { 3000, 15 },
                { decimal.MaxValue, 20 }
            }

        },
        new FeesCost
        {
            MinimumBasicFee = 25,
            MaximumBasicFee = 200,
            BaseFeePercentage = 0.1m,
            SpecialFeePercentage = 0.04m,
            StorageFee = 100,
            VehicleType = VehicleType.Luxury,
            AssociatedFee = new()
            {
                { 500, 5 },
                { 1000, 10 },
                { 3000, 15 },
                { decimal.MaxValue, 20 }
            }
        }
    ];
}
