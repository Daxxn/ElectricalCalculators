using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models
{
   public static class DimsCalculator
   {
      #region Local Props

      #endregion

      #region Methods
      public static double CalcPadSize(double innerDim, double outerDim)
      {
         return (outerDim - innerDim) / 2;
      }

      public static double CalcPadHalfCoordinate(double innerDim, double padWidth)
      {
         return Math.Abs((padWidth + innerDim) / 2);
      }
      #endregion

      #region Full Props

      #endregion
   }
}
