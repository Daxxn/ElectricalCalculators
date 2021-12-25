using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models
{
    public static class DividerCalculator
    {
        #region Methods
        public static double CalcVoltageDivider(double vcc, double topRes, double botRes)
        {
            return vcc * botRes / (topRes + botRes);
        }

        public static double CalcResistance(double vcc, double topRes, double vOut)
        {
            return vOut * topRes / (vcc - vOut);
        }
        #endregion
    }
}
