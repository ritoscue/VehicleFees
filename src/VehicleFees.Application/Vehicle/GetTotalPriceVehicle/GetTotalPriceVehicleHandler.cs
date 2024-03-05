using MediatR;
using VehicleFees.Application.Extensions;
using VehicleFees.Domain.Exceptions;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Application.Vehicle.GetTotalPriceVehicle
{
    public class GetTotalPriceVehicleHandler(GetTotalPriceVehicleValidator validationRules) : IRequestHandler<GetTotalPriceVehicleQuery, TotalPriceResult>
    {
        private readonly GetTotalPriceVehicleValidator _validationRules = validationRules;
        public async Task<TotalPriceResult> Handle(GetTotalPriceVehicleQuery request, CancellationToken cancellationToken)
        {
          
            var validationResult = await validationRules.ValidateAsync(request);
            if(_validationRules is null)
            {
                throw new ValidatorException("Validator service not found for GetTotalPriceVehicleQuery");
            }
            if (!validationResult.IsValid)
            {
                var errors = validationResult.ToErrorDictionary();
                return new TotalPriceResult(errors);
            }
            var response = new  VehicleResponse(200, Domain.Vehicle.VehicleType.Common, 100, 200, 4, 10, 23);
            return new TotalPriceResult(response);
        }
    }
}
