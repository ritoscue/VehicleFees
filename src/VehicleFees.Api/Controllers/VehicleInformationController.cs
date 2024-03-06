using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using VehicleFees.Application.Vehicle.GetTotalPriceVehicle;

namespace VehicleFees.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleInformationController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        [OutputCache]
        public async Task<IActionResult> GetTotalPriceByBaseAndType(decimal? basePrice, string? type, CancellationToken cancellationToken)
        {
            var query = new GetTotalPriceVehicleQuery(basePrice, type);
            var response = await _sender.Send(query, cancellationToken);
            if(!response.IsSuccess)
            {
                return BadRequest(response._validationErrors);
            }
            return Ok(response._response);
        }
    }
}
