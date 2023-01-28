using ElectricalCalculators.Models;
using ElectricalCalculators.Models.OhmsLaw;
using ElectricalCalculators.Models.Prefixes.Enums;

using MVVMLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.VoltageDivider
{
   public class VoltageDividerViewModel : ViewModel
   {
      #region Local Props
      private double _vcc = 0;
      private NumberDisplay _topRes = new(PrefixType.Resisitor);
      private NumberDisplay _botRes = new(PrefixType.Resisitor);

      private double _outputVoltage = 0;
      //private NumberDisplay _botResOutput = new(PrefixType.Resisitor);
      private NumberDisplay _outputCurrent = new(PrefixType.All);

      #region Commands
      public Command CalcCmd { get; init; }
      public Command CalcRatioCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public VoltageDividerViewModel()
      {
         CalcCmd = new(CalcOutput);
         CalcRatioCmd = new(CalcResistor);
      }
      #endregion

      #region Methods
      private void CalcOutput()
      {
         OutputVoltage = DividerCalculator.CalcVoltageDivider(VCC, TopResistor.Raw, BottomResistor.Raw);
         OutputCurrent.Raw = OhmsLawCalculator.CalcCurr(VCC, TopResistor.Raw + BottomResistor.Raw, 0);
         OutputCurrent.CalcBase();
      }

      private void CalcResistor()
      {
         // RBOT = (VOUT * RTOP) / (VIN - VOUT)
         BottomResistor.Raw = (OutputVoltage * TopResistor.Raw) / (VCC - OutputVoltage);
         BottomResistor.CalcBase();
      }
      #endregion

      #region Full Props
      public double VCC
      {
         get => _vcc;
         set
         {
            _vcc = value;
            OnPropertyChanged();
         }
      }

      public NumberDisplay TopResistor
      {
         get => _topRes;
         set
         {
            _topRes = value;
            OnPropertyChanged();
         }
      }

      public NumberDisplay BottomResistor
      {
         get => _botRes;
         set
         {
            _botRes = value;
            OnPropertyChanged();
         }
      }

      //public NumberDisplay BottomResistorOutput
      //{
      //    get => _botResOutput;
      //    set
      //    {
      //        _botResOutput = value;
      //        OnPropertyChanged();
      //    }
      //}

      public double OutputVoltage
      {
         get => _outputVoltage;
         set
         {
            _outputVoltage = value;
            OnPropertyChanged();
         }
      }

      public NumberDisplay OutputCurrent
      {
         get => _outputCurrent;
         set
         {
            _outputCurrent = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
