using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.OhmsLaw.Models
{
    public static class OhmsLawCalculator
    {
        #region Local Props

        #endregion

        #region Methods
        public static (double, double, double, double) Calculate(double voltage, double resistance, double current, double power)
        {
            var vOut = voltage;
            var rOut = resistance;
            var cOut = current;
            var pOut = power;
            if (CheckInputs(voltage, resistance, current, power))
            {
                if (voltage == 0)
                {
                    vOut = CalcVolt(resistance, current, power);
                }
                if (resistance == 0)
                {
                    rOut = CalcRes(voltage, current, power);
                }
                if (current == 0)
                {
                    cOut = CalcCurr(voltage, resistance, power);
                }
                if (power == 0)
                {
                    pOut = CalcPwr(voltage, resistance, current);
                }
                return (vOut, rOut, cOut, pOut);
            }
            else
            {
                throw new ArgumentException("Not enough input data. atleast");
            }
        }

        public static double CalcVolt(double res, double curr, double pwr)
        {
            if (res != 0)
            {
                if (curr != 0)
                {
                    return res * curr;
                }
                else
                {
                    return Math.Sqrt(pwr * res);
                }
            }
            else
            {
                return pwr / curr;
            }
        }

        private static double CalcRes(double voltage, double current, double power)
        {
            if (voltage != 0)
            {
                if (current != 0)
                {
                    return voltage / current;
                }
                else
                {
                    return Math.Pow(voltage, 2) / power;
                }
            }
            else
            {
                return power / Math.Pow(current, 2);
            }
        }

        private static double CalcCurr(double voltage, double resist, double pwr)
        {
            if (voltage != 0)
            {
                if (resist != 0)
                {
                    return voltage / resist;
                }
                else
                {
                    return pwr / voltage;
                }
            }
            else
            {
                return Math.Sqrt(pwr / resist);
            }
        }

        private static double CalcPwr(double voltage, double resist, double curr)
        {
            if (voltage != 0)
            {
                if (curr != 0)
                {
                    return voltage * curr;
                }
                else
                {
                    return Math.Pow(voltage, 2) / resist;
                }
            }
            else
            {
                return Math.Pow(curr, 2) * resist;
            }
        }

        private static bool CheckInputs(double voltage, double resistance, double current, double power)
        {
            int v = voltage != 0 ? 1 : 0;
            int r = resistance != 0 ? 1 : 0;
            int c = current != 0 ? 1 : 0;
            int p = power != 0 ? 1 : 0;
            int total = v + r + c + p;
            return total >= 2;
        }
        #endregion

        #region Full Props

        #endregion
    }
}
