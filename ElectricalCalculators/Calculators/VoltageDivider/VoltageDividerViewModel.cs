﻿using ElectricalCalculators.Models;
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
      private double? _vcc = null;
      private double? _topRes = null;
      private double? _botRes = null;

      private double? _outputVoltage = null;
      private double? _outputCurrent = null;

      private double? _ratio = null;
      private double? _reciprocal = null;

      #region Commands
      public Command CalcCmd { get; init; }
      public Command CalcRatioCmd { get; init; }
      public Command ClearCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public VoltageDividerViewModel()
      {
         CalcCmd = new(CalcOutput);
         CalcRatioCmd = new(CalcResistor);
         ClearCmd = new(Clear);
      }
      #endregion

      #region Methods
      private void CalcOutput()
      {
         if (VCC is null || TopResistor is null || BottomResistor is null) return;
         OutputVoltage = DividerCalculator.CalcVoltageDivider((double)VCC!, (double)TopResistor!, (double)BottomResistor!);
         OutputCurrent = OhmsLawCalculator.CalcCurr(VCC, TopResistor + BottomResistor, 0);

         if (TopResistor is null || BottomResistor is null) return;
         DividerRatio = BottomResistor / (BottomResistor + TopResistor);
         ReciprocalRatio = 1 / DividerRatio;
      }

      private void CalcResistor()
      {
         if (VCC is null || TopResistor is null || OutputVoltage is null) return;
         BottomResistor = (OutputVoltage * TopResistor) / (VCC - OutputVoltage);
         OutputCurrent = OhmsLawCalculator.CalcCurr(VCC, TopResistor + BottomResistor, 0);

         if (TopResistor is null || BottomResistor is null) return;
         DividerRatio = BottomResistor / (BottomResistor + TopResistor);
         ReciprocalRatio = 1 / DividerRatio;
      }

      private void Clear()
      {
         VCC = null;
         TopResistor = null;
         BottomResistor = null;
         OutputVoltage = null;
         OutputCurrent = null;
         DividerRatio = null;
         ReciprocalRatio = null;
      }
      #endregion

      #region Full Props
      public double? VCC
      {
         get => _vcc;
         set
         {
            _vcc = value;
            OnPropertyChanged();
         }
      }

      public double? TopResistor
      {
         get => _topRes;
         set
         {
            _topRes = value;
            OnPropertyChanged();
         }
      }

      public double? BottomResistor
      {
         get => _botRes;
         set
         {
            _botRes = value;
            OnPropertyChanged();
         }
      }

      public double? OutputVoltage
      {
         get => _outputVoltage;
         set
         {
            _outputVoltage = value;
            OnPropertyChanged();
         }
      }

      public double? OutputCurrent
      {
         get => _outputCurrent;
         set
         {
            _outputCurrent = value;
            OnPropertyChanged();
         }
      }

      public double? DividerRatio
      {
         get => _ratio;
         set
         {
            _ratio = value;
            OnPropertyChanged();
         }
      }

      public double? ReciprocalRatio
      {
         get => _reciprocal;
         set
         {
            _reciprocal = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
