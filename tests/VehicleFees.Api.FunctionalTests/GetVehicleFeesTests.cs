using FluentAssertions;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Api.FunctionalTests;

public class GetVehicleFeesTests
{
    [Theory]
    [InlineData(398.00, VehicleType.Common, 39.80, 7.96, 5, 100, 550.76)]
    [InlineData(501.00, VehicleType.Common, 50.00, 10.02, 10, 100, 671.02)]
    [InlineData(57.00, VehicleType.Common, 10.00, 1.14, 5, 100, 173.14)]
    [InlineData(1800.00, VehicleType.Luxury, 180.00, 72.00, 15, 100, 2167.00)]
    [InlineData(1100.00, VehicleType.Common, 50.00, 22.00, 15, 100, 1287.00)]
    [InlineData(1000000.00, VehicleType.Luxury, 200.00, 40000.00, 20, 100, 1040320.00)]
    public async Task Get_ShouldReturnFees_WhenSendCorrectParameters(
        decimal basePrice, 
        VehicleType vehicleType, 
        decimal basic, 
        decimal special, 
        decimal assocition, 
        decimal storage, 
        decimal total)
    {
        var app = new AppFactory();
        var client = app.CreateClient();
        var baseUrl = $"VehicleInformation?basePrice={basePrice}&type={vehicleType}";
        var response = await client.GetAsync(baseUrl);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        var result = await response.Content.ReadFromJsonAsync<VehicleResponse>();
        result.Should().NotBeNull();
        result.Fees.Should().NotBeNull();
        result.BasePrice.Should().Be(basePrice);
        result.VehicleType.Should().Be(vehicleType);
        result.Fees.Basic.Should().Be(basic);
        result.Fees.Special.Should().Be(special);
        result.Fees.Association.Should().Be(assocition);
        result.Fees.Storage.Should().Be(storage);
        result.TotalPrice.Should().Be(total);
    }

    [Theory]
    [InlineData(0.00, "Any")]
    public async Task Get_ShouldReturnError_WhenSendWrongParameters(
        decimal basePrice,
        string vehicleType)
    {
        var app = new AppFactory();
        var client = app.CreateClient();
        var baseUrl = $"VehicleInformation?basePrice={basePrice}&type={vehicleType}";
        var response = await client.GetAsync(baseUrl);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

        var result = await response.Content.ReadAsStringAsync();
        var errorResults = JObject.Parse(result);
        errorResults.Should().NotBeNull();
        errorResults.Should().HaveCount(2);
        
    }
}
