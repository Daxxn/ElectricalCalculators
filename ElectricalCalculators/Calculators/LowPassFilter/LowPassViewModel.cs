using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace ElectricalCalculators.Calculators.LowPassFilter
{
   public class LowPassViewModel : ViewModel
   {
      #region Local Props
      private static readonly double TimeConst = 2.197;
      private double? _res = null;
      private double? _cap = null;
      private double? _rise = null;
      #region Commands
      public Command CalcCmd { get; init; }
      public Command ClearCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public LowPassViewModel()
      {
         CalcCmd = new(Calc);
         ClearCmd = new(Clear);
      }
      #endregion

      #region Methods
      private void Calc()
      {
         if (Res is null && Cap is null && Rise is null) return;

         if (Rise is null)
         {
            Rise = CalcRise(Res, Cap);
         }
         else if (Res is null)
         {
            Res = CalcRes(Rise, Cap);
         }
         else if (Cap is null)
         {
            Cap = CalcCap(Rise, Res);
         }
      }

      private void Clear()
      {
         Res = null;
         Cap = null;
         Rise = null;
      }

      private double? CalcRise(double? res, double? cap)
      {
         return TimeConst * res * Cap;
      }

      private double? CalcRes(double? rise, double? cap)
      {
         return rise / (TimeConst * cap);
      }

      private double? CalcCap(double? rise, double? res)
      {
         return rise / (TimeConst * res);
      }
      #region Events

      #endregion
      #endregion

      #region Full Props
      public double? Res
      {
         get => _res;
         set
         {
            _res = value;
            OnPropertyChanged();
         }
      }

      public double? Cap
      {
         get => _cap;
         set
         {
            _cap = value;
            OnPropertyChanged();
         }
      }

      public double? Rise
      {
         get => _rise;
         set
         {
            _rise = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Freq));
         }
      }

      public double? Freq
      {
         get => 1 / Rise;
         set
         {
            _rise = 1 / value;
            OnPropertyChanged(nameof(Rise));
         }
      }
      #endregion
   }
}
