using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFees.Domain.Vehicle;

public sealed record ValidationError(string code, List<string> messages)
{
}
