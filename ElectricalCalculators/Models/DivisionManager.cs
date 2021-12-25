using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.GlobalModels
{
    public class DivisionManager : Model, ICalcManager
    {
        #region Local Props
        private double _2Div;
        private double _3Div;
        private double _4Div;
        private double _6Div;
        private double _8Div;
        private double _10Div;
        private double _12Div;
        #endregion

        #region Constructors
        public DivisionManager() { }
        #endregion

        #region Methods
        public void Calc(double input)
        {
            TwoDiv = input / 2;
            ThreeDiv = input / 3;
            FourDiv = input / 4;
            SixDiv = input / 6;
            EightDiv = input / 8;
            TenDiv = input / 10;
            TwelveDiv = input / 12;
        }
        #endregion

        #region Full Props
        public double TwoDiv
        {
            get => _2Div;
            set
            {
                _2Div = value;
                OnPropertyChanged();
            }
        }
        public double ThreeDiv
        {
            get => _3Div;
            set
            {
                _3Div = value;
                OnPropertyChanged();
            }
        }
        public double FourDiv
        {
            get => _4Div;
            set
            {
                _4Div = value;
                OnPropertyChanged();
            }
        }
        public double SixDiv
        {
            get => _6Div;
            set
            {
                _6Div = value;
                OnPropertyChanged();
            }
        }
        public double EightDiv
        {
            get => _8Div;
            set
            {
                _8Div = value;
                OnPropertyChanged();
            }
        }
        public double TenDiv
        {
            get => _10Div;
            set
            {
                _10Div = value;
                OnPropertyChanged();
            }
        }
        public double TwelveDiv
        {
            get => _12Div;
            set
            {
                _12Div = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
