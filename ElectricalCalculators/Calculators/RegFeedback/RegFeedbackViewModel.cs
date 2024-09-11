using MVVMLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.RegFeedback
{
   public class RegFeedbackViewModel : ViewModel
   {
      #region Local Props
      private double? _vout = null;
      private double? _vfb = null;
      private double? _r1 = null;
      private double? _r2 = null;

      private bool _calcOption = false;
      #region Commands
      public Command CalcCmd { get; init; }
      public Command ClearCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public RegFeedbackViewModel()
      {
         CalcCmd = new(Calc);
         ClearCmd = new(Clear);
      }
      #endregion

      #region Methods
      private void Calc()
      {
         switch (CalcOption)
         {
            case true:
               CalcResistor1();
               break;
            case false:
               CalcVout();
               break;
         }
      }

      private void Clear()
      {
         R1 = null;
         R2 = null;
         Vfb = null;
         Vout = null;
      }

      private void CalcResistor1()
      {
         if (Vfb is null || Vout is null || R2 is null) return;

         R1 = R2 * (Vout / Vfb - 1);
      }

      private void CalcVout()
      {
         if (Vfb is null || R1 is null || R2 is null) return;

         Vout = Vfb * (1 + R1 / R2);
      }
      #region Events

      #endregion
      #endregion

      #region Full Props
      public double? Vout
      {
         get => _vout;
         set
         {
            _vout = value;
            OnPropertyChanged();
         }
      }

      public double? Vfb
      {
         get => _vfb;
         set
         {
            _vfb = value;
            OnPropertyChanged();
         }
      }

      public double? R1
      {
         get => _r1;
         set
         {
            _r1 = value;
            OnPropertyChanged();
         }
      }

      public double? R2
      {
         get => _r2;
         set
         {
            _r2 = value;
            OnPropertyChanged();
         }
      }

      public bool CalcOption
      {
         get => _calcOption;
         set
         {
            _calcOption = value;
            //OnPropertyChanged();
         }
      }
      #endregion
   }
}
