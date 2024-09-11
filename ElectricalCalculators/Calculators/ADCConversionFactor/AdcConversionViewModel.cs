using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using MVVMLibrary;

namespace ElectricalCalculators.Calculators.ADCConversionFactor
{
   public class AdcConversionViewModel : ViewModel
   {
      #region Local Props
      private double? _bitDepth = null;
      private double? _adcRefVoltage;
      private double _conversionFactor = 0;
      #region Commands
      public Command CalcCmd { get; init; }
      public Command CopyFactorCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public AdcConversionViewModel()
      {
         CalcCmd = new(Calc);
         CopyFactorCmd = new(CopyFactor);
      }
      #endregion

      #region Methods
      private void Calc()
      {
         if (BitDepth is null || AdcRefVoltage is null) return;
         AdcConversionFactor = (double)AdcRefVoltage / (Math.Pow(2, (double)BitDepth) - 1);
      }

      private void CopyFactor()
      {
         Clipboard.SetText($"{AdcConversionFactor:F18}f");
      }
      #region Events

      #endregion
      #endregion

      #region Full Props
      public double? BitDepth
      {
         get => _bitDepth;
         set
         {
            _bitDepth = value;
            OnPropertyChanged();
         }
      }

      public double? AdcRefVoltage
      {
         get => _adcRefVoltage;
         set
         {
            _adcRefVoltage = value;
            OnPropertyChanged();
         }
      }

      public double AdcConversionFactor
      {
         get => _conversionFactor;
         set
         {
            _conversionFactor = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
