using ElectricalCalculators.Models;
using ElectricalCalculators.Models.Prefixes;
using ElectricalCalculators.Models.Prefixes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models.LEDCurrent
{
   public static class LEDCurrentCalculator
   {
      #region Local Props

      #endregion

      #region Methods
      public static Number Calc(Number vcc, Number fVolt, Number fCurr)
      {
         var num = new Number(PrefixType.Resisitor);
         num.ParseNumber((vcc.Raw - fVolt.Raw) / fCurr.Raw);
         return num;
      }

      //public static Number Calc(double vcc, double fVolt, double fCurr)
      //{
      //   var num = new Number(PrefixType.Resisitor);
      //   num.ParseNumber((vcc - fVolt) / (fCurr * 0.001));
      //   return num;
      //}

      public static double? Calc(double? vcc, double? fVolt, double? fCurr)
      {
         return (vcc - fVolt) / (fCurr * 0.001);
      }

      //public static Number CalcPower(double vcc, double fCurr)
      //{
      //   var num = new Number(PrefixType.All);
      //   num.ParseNumber(vcc * fCurr);
      //   return num;
      //}

      public static double? CalcPower(double? vcc, double? fCurr) => vcc * fCurr;
      #endregion

      #region Full Props

      #endregion
   }
}
