using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using VehicleFees.Application.Vehicle.GetTotalPriceVehicle;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleInformationController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;
      
        [HttpGet]
        [OutputCache]
        [ProducesResponseType(typeof(VehicleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, List<string>>), StatusCodes.Status400BadRequest)]
        /// <summary>
        /// Get the total price by the vehicle type and base price
        /// </summary>
        /// <param name="sender"></param>
        public async Task<IActionResult> GetTotalPriceByBaseAndType(decimal? basePrice, string? type, CancellationToken cancellationToken)
        {
            var query = new GetTotalPriceVehicleQuery(basePrice, type);
            var response = await _sender.Send(query, cancellationToken);
            if(!response.IsSuccess)
            {
                return BadRequest(response.GetAllErrors());
            }
            return Ok(response.GetResult());
        }
    }
}
