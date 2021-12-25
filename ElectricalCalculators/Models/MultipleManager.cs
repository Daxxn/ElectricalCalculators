using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.GlobalModels
{
    public class MultipleManager : Model, ICalcManager
    {
        #region Local Props
        private double _2Mult;
        private double _3Mult;
        private double _4Mult;
        private double _6Mult;
        private double _8Mult;
        private double _10Mult;
        private double _12Mult;
        #endregion

        #region Constructors
        public MultipleManager() { }
        #endregion

        #region Methods
        public void Calc(double input)
        {
            TwoMult = input * 2;
            ThreeMult = input * 3;
            FourMult = input * 4;
            SixMult = input * 6;
            EightMult = input * 8;
            TenMult = input * 10;
            TwelveMult = input * 12;
        }
        #endregion

        #region Full Props
        public double TwoMult
        {
            get => _2Mult;
            set
            {
                _2Mult = value;
                OnPropertyChanged();
            }
        }
        public double ThreeMult
        {
            get => _3Mult;
            set
            {
                _3Mult = value;
                OnPropertyChanged();
            }
        }
        public double FourMult
        {
            get => _4Mult;
            set
            {
                _4Mult = value;
                OnPropertyChanged();
            }
        }
        public double SixMult
        {
            get => _6Mult;
            set
            {
                _6Mult = value;
                OnPropertyChanged();
            }
        }
        public double EightMult
        {
            get => _8Mult;
            set
            {
                _8Mult = value;
                OnPropertyChanged();
            }
        }
        public double TenMult
        {
            get => _10Mult;
            set
            {
                _10Mult = value;
                OnPropertyChanged();
            }
        }
        public double TwelveMult
        {
            get => _12Mult;
            set
            {
                _12Mult = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
