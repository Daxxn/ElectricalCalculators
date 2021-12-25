using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models.Prefixes.Enums
{
    public enum PrefixType
    {
        All       = 0,
        Resisitor = 1,
        Cap_Ind   = 2,
    }
    public enum PrefixOption
    {
        Lowest = -1,
        Highest = 1,
        Exact = 0
    };
}
