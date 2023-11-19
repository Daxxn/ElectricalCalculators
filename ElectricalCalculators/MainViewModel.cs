using ElectricalCalculators.Calculators.FlashTimer;
using ElectricalCalculators.Calculators.LowPassFilter;

using ElectricalSuffixParser.Models;

using MVVMLibrary;

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

      #endregion

      #region Full Props

      #endregion
   }
}
