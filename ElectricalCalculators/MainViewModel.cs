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
