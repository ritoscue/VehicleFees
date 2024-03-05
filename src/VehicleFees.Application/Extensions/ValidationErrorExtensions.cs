
using FluentValidation.Results;

namespace VehicleFees.Application.Extensions;

public static class ValidationErrorExtensions
{
    public static Dictionary<string, List<string>> ToErrorDictionary(this ValidationResult result)
    {
        return result.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(group => group.Key, group => group.Select(e => e.ErrorMessage).ToList());
    }
}
