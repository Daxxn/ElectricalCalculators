using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectricalCalculators.Models;
using System.Windows;
using ElectricalCalculators.Models.Prefixes;
using ElectricalCalculators.Models.OhmsLaw;

namespace ElectricalCalculators.Calculators.OhmsLaw
{
   public class OhmsLawViewModel : ViewModel
   {
      #region Local Props
      public event EventHandler ClearEvent = (s,e) => { };
      //public Dictionary<int, string> PrefixesDict = ElectricalCalculators.Models.Prefixes.AllPrefixes;
      private double? _resistance = null;
      private double? _voltage = null;
      private double? _current = null;
      private double? _power = null;

      private bool? _voltageInput = null;
      private bool? _resistanceInput = null;
      private bool? _currentInput = null;
      private bool? _powerInput = null;

      #region Commands
      public Command CalculateCmd { get; init; }
      public Command ClearCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public OhmsLawViewModel()
      {
         CalculateCmd = new(Calculate);
         ClearCmd = new(Clear);
      }
      #endregion

      #region Methods
      private void Calculate()
      {
         try
         {
            if (Voltage is null && Resistance is null && Current is null && Power is null) return;
            VoltageInput = Voltage != 0 && Voltage is not null;
            ResistanceInput = Resistance != 0 && Resistance is not null;
            CurrentInput = Current != 0 && Current is not null;
            PowerInput = Power != 0 && Power is not null;

            (Voltage, Resistance, Current, Power) = OhmsLawCalculator.Calculate(
                Voltage,
                Resistance,
                Current,
                Power
            );
         }
         catch (ArgumentException)
         {
            MessageBox.Show("Not enough data to calculate.");
         }
         catch (Exception e)
         {
            MessageBox.Show($"Unable to calculate: {e.Message}");
         }
      }

      private void Clear()
      {
         Voltage = null;
         VoltageInput = null;
         Resistance = null;
         ResistanceInput = null;
         Current = null;
         CurrentInput = null;
         Power = null;
         PowerInput = null;
         ClearEvent?.Invoke(this, new());
      }
      #endregion

      #region Full Props
      public double? Voltage
      {
         get => _voltage;
         set
         {
            _voltage = value;
            OnPropertyChanged();
         }
      }

      public double? Resistance
      {
         get => _resistance;
         set
         {
            _resistance = value;
            OnPropertyChanged();
         }
      }

      public double? Current
      {
         get => _current;
         set
         {
            _current = value;
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

      public bool? VoltageInput
      {
         get => _voltageInput;
         set
         {
            _voltageInput = value;
            OnPropertyChanged();
         }
      }

      public bool? ResistanceInput
      {
         get => _resistanceInput;
         set
         {
            _resistanceInput = value;
            OnPropertyChanged();
         }
      }

      public bool? CurrentInput
      {
         get => _currentInput;
         set
         {
            _currentInput = value;
            OnPropertyChanged();
         }
      }

      public bool? PowerInput
      {
         get => _powerInput;
         set
         {
            _powerInput = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
