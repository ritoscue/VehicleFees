using System.Text.Json.Serialization;

namespace VehicleFees.Domain.Vehicle;

public sealed class VehicleResponse
{
    public decimal BasePrice { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public VehicleType VehicleType { get; set; }

    public Fees Fees { get; set; }
    public decimal TotalPrice { get; set; }
}
    
