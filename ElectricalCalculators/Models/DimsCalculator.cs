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
      public static (double? inner, double? outer, double? pads) Calc(double? innerDim, double? outerDim, double? padWidth)
      {
         //if (innerDim is null && outerDim is null && padWidth is null) return null;

         if (padWidth != null)
         {
            if (outerDim != null)
            {
               return (CalcInnerDim(outerDim, padWidth), outerDim, padWidth);
            }
            else if (innerDim != null)
            {
               return (innerDim, CalcOuterDim(innerDim, padWidth), padWidth);
            }
         }
         else if (outerDim != null && innerDim != null)
         {
            return (innerDim, outerDim, CalcPadSize(innerDim, outerDim));
         }
         return (innerDim, outerDim, padWidth);
      }

      public static double? CalcPadSize(double? innerDim, double? outerDim)
      {
         return (outerDim - innerDim) / 2;
      }

      public static double? CalcPadHalfCoordinate(double? innerDim, double? padWidth)
      {
         if (innerDim is null || padWidth is null) return null;
         return Math.Abs((double)((padWidth + innerDim) / 2)!);
      }

      public static double? CalcInnerDim(double? outerDim, double? padWidth)
      {
         return outerDim - (padWidth * 2);
      }

      public static double? CalcOuterDim(double? innerDim, double? padWidth)
      {
         return (padWidth * 2) + innerDim;
      }
      #endregion

      #region Full Props

      #endregion
   }
}
