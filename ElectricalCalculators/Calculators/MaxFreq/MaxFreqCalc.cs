using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.MaxFreq
{
   public static class MaxFreqCalc
   {
      #region Local Props
      public const double c = 300;
      #endregion

      #region Methods

      public static double Calc(double riseFall)
      {
         return CalcMaxFreq(CalcFullRiseFallTime(riseFall));
      }

      public static double CalcMaxFreq(double riseFall)
      {
         return 0.5 / riseFall;
      }

      public static double CalcFullRiseFallTime(double approxRiseFall)
      {
         return approxRiseFall * (90 - 10) / (80 - 20);
      }

      public static double CalcCriticalLength(double riseFall, double dialectric)
      {
         return (0.25 * riseFall * c) / Math.Sqrt(dialectric);
      }
      #endregion

      #region Full Props

      #endregion
   }
}
