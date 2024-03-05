namespace VehicleFees.Domain.Vehicle;

public sealed record VehicleInformation
(
    decimal BasePrice,
    VehicleType VehicleType
);
