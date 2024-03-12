namespace VehicleFees.Domain.Vehicle;

public class TotalPriceResult
{
    
    private Dictionary<string, List<string>>? _validationErrors;
    private VehicleResponse? _response;
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

    public VehicleResponse GetResult()
    {
        if (IsSuccess)
            return _response;
        else
            throw new InvalidOperationException("No result available because the operation was not successful.");
    }

    public List<string> GetAllErrors()
    {
        return _validationErrors?.SelectMany(pair => pair.Value).ToList() ?? new List<string>();
    }
}

