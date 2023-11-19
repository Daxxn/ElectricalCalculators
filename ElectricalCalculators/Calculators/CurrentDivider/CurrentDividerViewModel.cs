using ElectricalCalculators.Models;

using MVVMLibrary;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.CurrentDivider
{
   public class CurrentDividerViewModel : ViewModel
   {
      #region Local Props
      private double? _vcc = null;
      private double? _totalCurrent = null;
      private double? _totalResistance = null;
      private int _round = 4;
      private ObservableCollection<Resistor> _resistors = new();
      private Resistor? _selectedResistor = null;
      private double _numberTest = 0;

      #region Commands
      public Command NewResistorCmd { get; init; }
      public Command RemoveResistorCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public CurrentDividerViewModel()
      {
         NewResistorCmd = new(NewResistor);
         RemoveResistorCmd = new(RemoveResistor);
      }
      #endregion

      #region Methods
      public void NewResistor()
      {
         SelectedResistor = new();
         ResistorCollection.Add(SelectedResistor);
         ReorderResistors();
      }

      public void RemoveResistor()
      {
         if (SelectedResistor != null)
         {
            ResistorCollection.Remove(SelectedResistor);
            SelectedResistor = null;
            ReorderResistors();
         }
      }

      private void ReorderResistors()
      {
         for (int i = 0; i < ResistorCollection.Count; i++)
         {
            ResistorCollection[i].Number = i + 1;
         }
      }

      public void Calculate()
      {
         (TotalResistance, TotalCurrent) = CurrentCalculator.CalcCurrent(VCC, ResistorCollection);
      }
      #endregion

      #region Full Props
      public ObservableCollection<Resistor> ResistorCollection
      {
         get => _resistors;
         set
         {
            _resistors = value;
            OnPropertyChanged();
         }
      }

      public Resistor? SelectedResistor
      {
         get => _selectedResistor;
         set
         {
            _selectedResistor = value;
            OnPropertyChanged();
         }
      }

      public double? VCC
      {
         get => _vcc;
         set
         {
            _vcc = value;
            Calculate();
            OnPropertyChanged();
         }
      }

      public double? TotalCurrent
      {
         get => _totalCurrent;
         set
         {
            _totalCurrent = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TotalCurrRound));
         }
      }

      public double? TotalCurrRound
      {
         get
         {
            if (_totalCurrent == null) return null;
            return Math.Round((double)_totalCurrent, Round);
         }
      }

      public double? TotalResistance
      {
         get => _totalResistance;
         set
         {
            _totalResistance = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TotalResRound));
         }
      }

      public double? TotalResRound
      {
         get
         {
            if (_totalResistance == null) return null;
            return Math.Round((double)_totalResistance, Round);
         }
      }

      public int Round
      {
         get => _round;
         set
         {
            _round = value;
            OnPropertyChanged();
         }
      }

      public double NumberTest
      {
         get => _numberTest;
         set
         {
            _numberTest = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
