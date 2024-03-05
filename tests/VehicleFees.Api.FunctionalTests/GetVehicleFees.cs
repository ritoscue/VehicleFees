using FluentAssertions;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Api.FunctionalTests;

public class GetVehicleFees
{
    [Theory]
    [InlineData(398.00, VehicleType.Common, 39.80, 7.96, 5, 100, 550.76)]
    [InlineData(1800.00, VehicleType.Luxury, 180.00, 72.00, 15, 100, 2167.00)]
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
