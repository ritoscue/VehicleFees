using VehicleFees.Application.Abstractions.Pricing;
using VehicleFees.Domain.Fees;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Infrastructure.Pricing;

public class FeesService (IFeesRepository feesRepository) : IFeesService
{
    private readonly IFeesRepository _feesRepository = feesRepository;
    public async Task<VehicleResponse> CalculateTotalPrice(VehicleInformation vehicleInformation, CancellationToken cancellationToken)
    {
        var feesCost = await _feesRepository.GetFeesByVehicleType(vehicleInformation.VehicleType, cancellationToken);

        var basicFee = CalculateBasicFee(vehicleInformation.BasePrice, feesCost);
        var specialFee = CalculateSpecialFee(vehicleInformation.BasePrice, feesCost);
        var associationFee = CalculatedAssociatedFee(vehicleInformation.BasePrice, feesCost.AssociatedFee);
        var storageFee = feesCost.StorageFee;
        var totalPrice = vehicleInformation.BasePrice + basicFee + specialFee + associationFee + storageFee;

        var vehicleResponse = new VehicleResponse
        {
            BasePrice = vehicleInformation.BasePrice,
            VehicleType = vehicleInformation.VehicleType,
            Fees = new Fees
            {
                Basic = basicFee,
                Special = specialFee,
                Association = associationFee,
                Storage = storageFee,
            },
            TotalPrice = totalPrice
        };
        
        return vehicleResponse;
    }

    public decimal CalculateBasicFee(decimal basePrice, FeesCost fee)
    {
        return Math.Min(Math.Max(basePrice * fee.BaseFeePercentage, fee.MinimumBasicFee), fee.MaximumBasicFee);
    }

    public decimal CalculateSpecialFee(decimal basePrice, FeesCost fee)
    {
        return basePrice * fee.SpecialFeePercentage;
    }

    public decimal CalculatedAssociatedFee(decimal basePrice, Dictionary<decimal, decimal> associated)
    {
        decimal associatedFeeValue = 0;
        foreach (var kvp in associated)
        {
            if (basePrice <= kvp.Key)
            {
                associatedFeeValue = kvp.Value;
                break;
            }
        }
        return associatedFeeValue;
    }
}
