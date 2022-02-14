using ElectricalCalculators.Models;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.MOSFETCalc
{
    public class MOSFETCalcViewModel : ViewModel
    {
        #region Local Props
        private MOSFET _mosfet = new();

        #region Commands
        public Command CalcCmd { get; init; }
        #endregion
        #endregion

        #region Constructors
        public MOSFETCalcViewModel()
        {
            CalcCmd = new(() => MOSFET.Calc());
        }
        #endregion

        #region Methods

        #endregion

        #region Full Props
        public MOSFET MOSFET
        {
            get => _mosfet;
            set
            {
                _mosfet = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
