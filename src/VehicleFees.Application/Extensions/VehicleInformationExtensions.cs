
using VehicleFees.Application.Vehicle.GetTotalPriceVehicle;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Application.Extensions;

internal static class VehicleInformationExtensions
{
    public static VehicleInformation ToVehicleInformation(this GetTotalPriceVehicleQuery getTotalPriceVehicleQuery) =>
        new VehicleInformation((decimal)getTotalPriceVehicleQuery.BasePrice,
            ToVehicleType(getTotalPriceVehicleQuery.VehicleType));

    public static VehicleType ToVehicleType(string vehicleType) => vehicleType switch
    {
        "Common" => VehicleType.Common,
        "Luxury" => VehicleType.Luxury,
        _ => throw new NotImplementedException(),
    };
}
