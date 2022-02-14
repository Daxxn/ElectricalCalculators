using ElectricalCalculators.Models.Prefixes.Enums;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models
{
    public class MOSFET : Model
    {
        #region Local Props
        //private double _rdsON = 0;
        //private double _qt = 0;
        //private double _vcc = 0;
        //private double _loadCurr = 0;
        //private double _tPerW = 0;
        //private double _gateRes = 0;
        //private double _driveCurr = 0;

        //private double _powerDiss = 0;
        //private double _tempDelta = 0;
        //private double _swTime = 0;
        //private double _gateCurr = 0;

        private Number _rdsON = new(PrefixType.Resisitor);
        private Number _qt = new(PrefixType.Cap_Ind);
        private Number _vcc = new(PrefixType.All);
        private Number _loadCurr = new(PrefixType.All);
        private Number _tPerW = new(PrefixType.All);
        private Number _gateRes = new(PrefixType.Resisitor);
        private Number _driveCurr = new(PrefixType.All);

        private Number _powerDiss = new(PrefixType.All);
        private Number _tempDelta = new(PrefixType.All);
        private Number _swTime = new(PrefixType.All);
        private Number _gateCurr = new(PrefixType.All);
        #endregion

        #region Constructors
        public MOSFET() { }
        #endregion

        #region Methods
        public void Calc()
        {
            CalcPowerDiss();
            CalcTempDelta();
            calcGateCurrent();
            CalcSwitchingTime();
        }

        private void CalcPowerDiss()
        {
            PowerDiss.ParseNumber(Math.Pow(LoadCurrent.CalcRaw(), 2) * RDSON.CalcRaw());
        }

        private void CalcTempDelta()
        {
            TempDelta = TempPerWatt * PowerDiss;
        }

        private void calcGateCurrent()
        {
            GateCurrent = DriveCurrent / GateResistance;
        }

        private void CalcSwitchingTime()
        {
            SwitchingTime = QT / GateCurrent;
        }

        public void SetVCCEvent(object s, double vcc)
        {
            VCC.ParseNumber(vcc);
        }
        #endregion

        #region Full Props
        public Number RDSON
        {
            get => _rdsON;
            set
            {
                _rdsON = value;
                OnPropertyChanged();
            }
        }

        public Number QT
        {
            get => _qt;
            set
            {
                _qt = value;
                OnPropertyChanged();
            }
        }

        public Number VCC
        {
            get => _vcc;
            set
            {
                _vcc = value;
                OnPropertyChanged();
            }
        }

        public Number LoadCurrent
        {
            get => _loadCurr;
            set
            {
                _loadCurr = value;
                OnPropertyChanged();
            }
        }

        public Number TempPerWatt
        {
            get => _tPerW;
            set
            {
                _tPerW = value;
                OnPropertyChanged();
            }
        }

        public Number GateResistance
        {
            get => _gateRes;
            set
            {
                _gateRes = value;
                OnPropertyChanged();
            }
        }

        public Number DriveCurrent
        {
            get => _driveCurr;
            set
            {
                _driveCurr = value;
                OnPropertyChanged();
            }
        }

        public Number PowerDiss
        {
            get => _powerDiss;
            set
            {
                _powerDiss = value;
                OnPropertyChanged();
            }
        }

        public Number TempDelta
        {
            get => _tempDelta;
            set
            {
                _tempDelta = value;
                OnPropertyChanged();
            }
        }

        public Number SwitchingTime
        {
            get => _swTime;
            set
            {
                _swTime = value;
                OnPropertyChanged();
            }
        }

        public Number GateCurrent
        {
            get => _gateCurr;
            set
            {
                _gateCurr = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
