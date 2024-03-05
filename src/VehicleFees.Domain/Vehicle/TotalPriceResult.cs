namespace VehicleFees.Domain.Vehicle;

public class TotalPriceResult
{
    
    public Dictionary<string, List<string>>? _validationErrors;
    public VehicleResponse? _response;
    public bool IsSuccess { get; }

    public TotalPriceResult()
    {

    }
    public TotalPriceResult(Dictionary<string, List<string>> validationErrors)
    {
        _validationErrors = validationErrors;
        IsSuccess = false;
    }

    public TotalPriceResult(VehicleResponse response)
    {
        _response = response;
        IsSuccess = true;
    }
}
