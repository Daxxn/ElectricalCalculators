using ElectricalCalculators.Utils;

using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.RegFeedback
{
   public class NearestResViewModel : ViewModel
   {
      #region Local Props
      private SettingsModel _settings;

      private double _vfb = 0;
      private double _vout = 0;
      private double _r2Min = 0;
      private double _accuracy = 0.1;

      private ObservableCollection<double> _resistors = new();
      private int _selectedResIndex = -1;
      private ObservableCollection<DividerResult> _results = new();
      private double? _tempResValue = null;
      #region Commands
      public Command CalcCmd { get; init; }
      public Command ClearCmd { get; init; }
      public Command AddResCmd { get; init; }
      public Command RemResCmd { get; init; }
      public Command UseSelectedResCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public NearestResViewModel()
      {
         CalcCmd = new Command(Calc);
         ClearCmd = new Command(Clear);
         AddResCmd = new Command(AddRes);
         RemResCmd = new Command(RemRes);
         UseSelectedResCmd = new Command(UseSelectedRes);
      }
      #endregion

      #region Methods
      private void Calc()
      {
         if (Vfb == 0 || Vout == 0 || R2Min == 0) return;

         var tempResistors = Settings.Resistors.Where(x => x >= R2Min);

         var output = new List<DividerResult>();
         DivResults.Clear();

         foreach (var resBot in tempResistors)
         {
            foreach (var resTop in Settings.Resistors)
            {
               double voltage = CalcVoltage(resTop, resBot);
               double err = CalcError(voltage);
               if (Math.Abs(err) <= Accuracy)
               {
                  output.Add(new(resTop, resBot, voltage, err));
               }
            }
         }

         DivResults = new(output.OrderBy(x => x.Error).ToList());
      }

      private double CalcVoltage(double rTop, double rBot)
      {
         return Vfb * (1 + (rTop / rBot));
      }

      private double CalcError(double result)
      {
         return (result - Vout) / Vout;
      }

      private void Clear()
      {
         Vfb = 0;
         Vout = 0;
         R2Min = 0;
         DivResults.Clear();
      }

      private void AddRes()
      {
         if (TempResValue is null) return;
         if (Settings.Resistors.Any((r) => r == TempResValue))
         {
            TempResValue = null;
            return;
         }

         Settings.Resistors.Add((double)TempResValue);
         Settings.Resistors = new(Settings.Resistors.OrderBy(x => x));
         TempResValue = null;
      }

      private void RemRes()
      {
         if (SelectedResIndex < 0) return;
         Settings.Resistors.RemoveAt(SelectedResIndex);
         Settings.Resistors = new(Settings.Resistors.OrderBy(x => x));
         SelectedResIndex = -1;
      }
      private void UseSelectedRes()
      {
         if (SelectedResIndex < 0) return;
         R2Min = Settings.Resistors[SelectedResIndex];
      }
      #region Events
      public void OnInitialized()
      {
         Settings = App.MainVM.Settings;
      }
      #endregion
      #endregion

      #region Full Props
      public double Vfb
      {
         get => _vfb;
         set
         {
            _vfb = value;
            OnPropertyChanged();
         }
      }

      public double Vout
      {
         get => _vout;
         set
         {
            _vout = value;
            OnPropertyChanged();
         }
      }

      public double R2Min
      {
         get => _r2Min;
         set
         {
            _r2Min = value;
            OnPropertyChanged();
         }
      }

      public double Accuracy
      {
         get => _accuracy;
         set
         {
            _accuracy = value;
            OnPropertyChanged();
         }
      }

      public ObservableCollection<DividerResult> DivResults
      {
         get => _results;
         set
         {
            _results = value;
            OnPropertyChanged();
         }
      }

      public int SelectedResIndex
      {
         get => _selectedResIndex;
         set
         {
            _selectedResIndex = value;
            OnPropertyChanged();
         }
      }

      public double? TempResValue
      {
         get => _tempResValue;
         set
         {
            _tempResValue = value;
            OnPropertyChanged();
         }
      }
      public SettingsModel Settings
      {
         get => _settings;
         set
         {
            _settings = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
