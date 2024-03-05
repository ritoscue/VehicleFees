namespace VehicleFees.Domain.Vehicle;

public sealed record VehicleResponse(
    decimal BasePrice,
    VehicleType VehicleType,
    decimal BasicFees,
    decimal SpecialFees,
    decimal Association,
    decimal Storage,
    decimal TotalPrice
    );
