using MVVMLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models.OhmsLaw
{
   public static class OhmsLawCalculator
   {
      #region Local Props

      #endregion

      #region Methods
      public static (double? v, double? r, double? i, double? p) Calculate(double? voltage, double? resistance, double? current, double? power)
      {
         double? v = voltage;
         double? r = resistance;
         double? i = current;
         double? p = power;

         if (CheckInputs(voltage, resistance, current, power))
         {
            if (voltage == null)
            {
               v = CalcVolt(resistance, current, power);
            }
            if (resistance == null)
            {
               r = CalcRes(voltage, current, power);
            }
            if (current == null)
            {
               i = CalcCurr(voltage, resistance, power);
            }
            if (power == null)
            {
               p = CalcPwr(voltage, resistance, current);
            }
            return (v, r, i, p);
         }
         else
         {
            throw new ArgumentException("Not enough input data. atleast");
         }
      }

      public static (double? v, double? r, double? i, double? p) Calculate2(double? voltage, double? resistance, double? current, double? power)
      {
         throw new NotImplementedException();
      }

      //public static (double, double, double, double) Calculate(double voltage, double resistance, double current, double power)
      //{
      //   var vOut = voltage;
      //   var rOut = resistance;
      //   var cOut = current;
      //   var pOut = power;
      //   if (CheckInputs(voltage, resistance, current, power))
      //   {
      //      if (voltage == 0)
      //      {
      //         vOut = CalcVolt(resistance, current, power);
      //      }
      //      if (resistance == 0)
      //      {
      //         rOut = CalcRes(voltage, current, power);
      //      }
      //      if (current == 0)
      //      {
      //         cOut = CalcCurr(voltage, resistance, power);
      //      }
      //      if (power == 0)
      //      {
      //         pOut = CalcPwr(voltage, resistance, current);
      //      }
      //      return (vOut, rOut, cOut, pOut);
      //   }
      //   else
      //   {
      //      throw new ArgumentException("Not enough input data. atleast");
      //   }
      //}

      public static double? CalcVolt(double? res, double? curr, double? pwr)
      {
         if (res != null)
         {
            if (curr != null)
            {
               return res * curr;
            }
            else
            {
               return Math.Sqrt((double)pwr! * (double)res);
            }
         }
         else
         {
            return pwr / curr;
         }
      }

      public static double? CalcRes(double? voltage, double? current, double? power)
      {
         if (voltage != null)
         {
            if (current != null)
            {
               return voltage / current;
            }
            else
            {
               return Math.Pow((double)voltage, 2) / power;
            }
         }
         else
         {
            return power / Math.Pow((double)current!, 2);
         }
      }

      public static double? CalcCurr(double? voltage, double? resist, double? pwr)
      {
         if (voltage != null)
         {
            if (resist != null)
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
            return Math.Sqrt((double)pwr! / (double)resist!);
         }
      }

      public static double? CalcPwr(double? voltage, double? resist, double? curr)
      {
         if (voltage != null)
         {
            if (curr != null)
            {
               return voltage * curr;
            }
            else
            {
               return Math.Pow((double)voltage, 2) / resist;
            }
         }
         else
         {
            return Math.Pow((double)curr!, 2) * resist;
         }
      }

      private static bool CheckInputs(double? voltage, double? resistance, double? current, double? power)
      {
         int v = voltage != null ? 1 : 0;
         int r = resistance != null ? 1 : 0;
         int c = current != null ? 1 : 0;
         int p = power != null ? 1 : 0;
         int total = v + r + c + p;
         return total >= 2;
      }
      #endregion

      #region Full Props

      #endregion
   }
}
