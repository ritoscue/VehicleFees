using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Domain.Fees;

public interface IFees
{
    public decimal MinimumBasicFee { get; set; }
    public decimal MaximumBasicFee { get; set; }
    public decimal BaseFeePercentage { get; set; }
    public decimal SpecialFeePercentage { get; set; }
    public decimal StorageFee { get; set; }
    public VehicleType VehicleType { get; set; }    
}
