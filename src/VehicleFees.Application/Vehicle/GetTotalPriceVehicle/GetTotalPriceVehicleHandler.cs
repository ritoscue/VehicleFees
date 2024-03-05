using MediatR;
using VehicleFees.Application.Abstractions.Pricing;
using VehicleFees.Application.Extensions;
using VehicleFees.Domain.Exceptions;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Application.Vehicle.GetTotalPriceVehicle
{
    public class GetTotalPriceVehicleHandler(
        GetTotalPriceVehicleValidator validationRules
        , IFeesService pricingService) : IRequestHandler<GetTotalPriceVehicleQuery, TotalPriceResult>
    {
        private readonly GetTotalPriceVehicleValidator _validationRules = validationRules;
        private readonly IFeesService _pricingService = pricingService;
        public async Task<TotalPriceResult> Handle(GetTotalPriceVehicleQuery request, CancellationToken cancellationToken)
        {
            if (_validationRules is null)
            {
                throw new ValidatorException("Validator service not found for GetTotalPriceVehicleQuery");
            }
            var validationResult = await validationRules.ValidateAsync(request);            
            if (!validationResult.IsValid)
            {
                var errors = validationResult.ToErrorDictionary();
                return new TotalPriceResult(errors);
            }
            var vehicleInformation = request.ToVehicleInformation();
            var response = await _pricingService.CalculateTotalPrice(vehicleInformation, cancellationToken);
            return new TotalPriceResult(response);
        }
    }
}
