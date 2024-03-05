using FluentValidation;
using VehicleFees.Domain.Vehicle;

namespace VehicleFees.Application.Vehicle.GetTotalPriceVehicle;

public class GetTotalPriceVehicleValidator : AbstractValidator<GetTotalPriceVehicleQuery>
{
    public GetTotalPriceVehicleValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Continue;
        RuleLevelCascadeMode = CascadeMode.Continue;
        RuleFor(w => w.BasePrice)
           .NotNull()
           .WithMessage("The Base Price field is required.")
           .GreaterThan(0)
           .WithMessage("The Base Price should be greater than 0.");

        RuleFor(w => w.VehicleType)
       .NotNull()
       .WithMessage("The State field is required.")
       .Custom((state, context) =>
       {
           VehicleType stateValues;
           if (!Enum.TryParse(state, out stateValues))
           {
               context.AddFailure("The state should have an acceptable value, please refer to request schema for acceptable values");
           }
       });
    }
}
