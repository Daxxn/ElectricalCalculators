using ElectricalCalculators.Models;
using ElectricalCalculators.Models.LEDCurrent;
using ElectricalCalculators.Models.Prefixes;
using ElectricalCalculators.Models.Prefixes.Enums;

using MVVMLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.LEDCurrent;

public class LEDCurrentViewModel : ViewModel
{
   #region Local Props

   private double? _vcc = null;
   private double? _forwardVoltage = null;
   private double? _forwardCurrent = null;

   private double? _resistor = null;
   private double? _power = null;

   #region Commands
   public Command CalculateCmd { get; init; }
   #endregion
   #endregion

   #region Constructors
   public LEDCurrentViewModel()
   {
      CalculateCmd = new(Calculate);
   }
   #endregion

   #region Methods
   private void Calculate()
   {
      if (VCC is null || ForwardVoltage is null || ForwardCurrent is null)
         return;
      Resistor = LEDCurrentCalculator.Calc(VCC, ForwardVoltage, ForwardCurrent);
      Power = LEDCurrentCalculator.CalcPower(VCC, ForwardCurrent);
   }

   public void ColorSelected(double value)
   {
      ForwardVoltage = value;
   }

   public void UpdateCalc(object sender, EventArgs e)
   {
      Calculate();
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

   public double? ForwardCurrent
   {
      get => _forwardCurrent;
      set
      {
         _forwardCurrent = value;
         OnPropertyChanged();
      }
   }

   public double? ForwardVoltage
   {
      get => _forwardVoltage;
      set
      {
         _forwardVoltage = value;
         OnPropertyChanged();
      }
   }

   public double? Resistor
   {
      get => _resistor;
      set
      {
         _resistor = value;
         OnPropertyChanged();
      }
   }

   public double? Power
   {
      get => _power;
      set
      {
         _power = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
