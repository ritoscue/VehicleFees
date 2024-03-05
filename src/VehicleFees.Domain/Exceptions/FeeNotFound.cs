namespace VehicleFees.Domain.Exceptions;

public class FeeNotFound : Exception
{
    public FeeNotFound(string message)
        :base(message)
    {
        
    }
}
