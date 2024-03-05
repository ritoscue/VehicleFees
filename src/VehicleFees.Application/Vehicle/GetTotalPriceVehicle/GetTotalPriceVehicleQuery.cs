using MediatR;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Application.Vehicle.GetTotalPriceVehicle;

public record GetTotalPriceVehicleQuery(decimal? BasePrice, string VehicleType) 
    : IRequest<TotalPriceResult>;
