using ElectricalCalculators.Calculators.FlashTimer;
using ElectricalCalculators.Calculators.LowPassFilter;
using ElectricalCalculators.Utils;

using ElectricalSuffixParser.Models;

using MVVMLibrary;

using SettingsLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators
{
   public class MainViewModel : ViewModel
   {
      #region Local Props
      private SettingsModel _settings = null!;
      public static FlashTimerViewModel FlashTimerViewModel = new();
      public static LowPassViewModel LowPassViewModel = new();
      #region Commands
      public Command OpenTypicalResistorsCmd { get; init; }
      public Command OpenTypicalCapacitorsCmd { get; init; }
      public Command OpenTypicalInductorsCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public MainViewModel() { }
      #endregion

      #region Methods
      public void OnStartup()
      {
         _settings = App.Settings;
      }

      public void OnExit()
      {
      }
      #endregion

      #region Full Props
      public SettingsModel Settings
      {
         get => _settings;
      }
      #endregion
   }
}
