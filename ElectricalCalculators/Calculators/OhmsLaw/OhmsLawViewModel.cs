using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectricalCalculators.Calculators.OhmsLaw.Models;
using ElectricalCalculators.GlobalModels;
using System.Windows;

namespace ElectricalCalculators.Calculators.OhmsLaw
{
    public class OhmsLawViewModel : ViewModel
    {
        #region Local Props
        //public Dictionary<int, string> PrefixesDict = ElectricalCalculators.Models.Prefixes.AllPrefixes;
        private double? _resistance = 0;
        private double? _voltage = 0;
        private double? _current = 0;
        private double? _power = 0;

        private int _voltagePrefix = 0;
        private int _resistancePrefix = 0;
        private int _currentPrefix = 0;
        private int _powerPrefix = 0;

        private bool _voltageInput = true;
        private bool _resistanceInput = true;
        private bool _currentInput = true;
        private bool _powerInput = true;

        #region Commands
        public Command CalculateCmd { get; init; }
        #endregion
        #endregion

        #region Constructors
        public OhmsLawViewModel()
        {
            CalculateCmd = new(Calculate);
        }
        #endregion

        #region Methods
        private void Calculate()
        {
            try
            {

                var GetValue = GlobalModels.Prefixes.Getvalue;
                VoltageInput = Voltage != 0 && Voltage is not null;
                ResistanceInput = Resistance != 0 && Resistance is not null;
                CurrentInput = Current != 0 && Current is not null;
                PowerInput = Power != 0 && Power is not null;

                (Voltage, Resistance, Current, Power) = OhmsLawCalculator.Calculate(
                    GetValue(Voltage, VoltagePrefix),
                    GetValue(Resistance, ResistancePrefix),
                    GetValue(Current, CurrentPrefix),
                    GetValue(Power, PowerPrefix)
                );
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Not enough data to calculate..");
            }
            catch (Exception)
            {
                throw;
            }
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

        public int VoltagePrefix
        {
            get => _voltagePrefix;
            set
            {
                _voltagePrefix = value;
                OnPropertyChanged();
            }
        }

        public int ResistancePrefix
        {
            get => _resistancePrefix;
            set
            {
                _resistancePrefix = value;
                OnPropertyChanged();
            }
        }

        public int CurrentPrefix
        {
            get => _currentPrefix;
            set
            {
                _currentPrefix = value;
                OnPropertyChanged();
            }
        }

        public int PowerPrefix
        {
            get => _powerPrefix;
            set
            {
                _powerPrefix = value;
                OnPropertyChanged();
            }
        }

        public bool VoltageInput
        {
            get => _voltageInput;
            set
            {
                _voltageInput = value;
                OnPropertyChanged();
            }
        }

        public bool ResistanceInput
        {
            get => _resistanceInput;
            set
            {
                _resistanceInput = value;
                OnPropertyChanged();
            }
        }

        public bool CurrentInput
        {
            get => _currentInput;
            set
            {
                _currentInput = value;
                OnPropertyChanged();
            }
        }

        public bool PowerInput
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
