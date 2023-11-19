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
      public event EventHandler ClearEvent = (s, e) => { };
      private double? _resistance = null;
      private double? _voltage = null;
      private double? _current = null;
      private double? _power = null;

      /// <summary>
      /// Used to identify what value to calculate
      /// <para/>
      /// <list type="table">
      ///   <item>
      ///      <term>1</term>
      ///      <description>Voltage</description>
      ///   </item>
      ///   <item>
      ///      <term>2</term>
      ///      <description>Resistance</description>
      ///   </item>
      ///   <item>
      ///      <term>3</term>
      ///      <description>Current</description>
      ///   </item>
      ///   <item>
      ///      <term>4</term>
      ///      <description>Power</description>
      ///   </item>
      /// </list>
      /// </summary>
      private Stack<int> TextBoxHistory { get; set; } = new();

      private bool? _voltageInput = null;
      private bool? _resistanceInput = null;
      private bool? _currentInput = null;
      private bool? _powerInput = null;

      private int[] _history = new int[4];
      private int _count = 1;

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

         TextBoxHistory.Clear();
      }
      #endregion

      #region Methods
      private void Calculate()
      {
         try
         {
            if (Voltage is null && Resistance is null && Current is null && Power is null) return;

            int min = _history.Min();
            List<int> calcList = new();
            for (int i = 0; i < 4; i++)
            {
               if (_history[i] == min)
                  calcList.Add(i);
            }
            if (calcList.Count >= 2)
            {
               (Voltage, Resistance, Current, Power) = OhmsLawCalculator.Calculate2(
                  calcList.ToArray(),
                  Voltage,
                  Resistance,
                  Current,
                  Power
               );
               //_count = 1;
               //_history = new int[4];
            }
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

      private bool RemoveRecent()
      {
         if (TextBoxHistory.Count < 2)
         {
            return false;
         }
         while (TextBoxHistory.Count > 2)
         {
            TextBoxHistory.Pop();
         }
         return true;
      }

      private void Clear()
      {
         _count = 1;
         _history = new int[4];
         Voltage = null;
         //VoltageInput = null;
         Resistance = null;
         //ResistanceInput = null;
         Current = null;
         //CurrentInput = null;
         Power = null;
         //PowerInput = null;
         ClearEvent?.Invoke(this, new());
      }

      public void UpdateTextBoxHistory(int index)
      {
         _history[index] = _count;
         _count++;
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
