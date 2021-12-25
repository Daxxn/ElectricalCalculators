using ElectricalCalculators.GlobalModels;
using ElectricalCalculators.Utils;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.MilToMetric
{
    public class MilToMetricViewModel : ViewModel
    {
        #region Local Props
        private string _input;
        private double _inputValue;
        private double _directOutput;

        private MultipleManager _multiple = new();
        private DivisionManager _division = new();

        private double _multiInput;

        private int _selectedConversion = 0;

        private string _selectedOutput;
        #endregion

        #region Constructors
        public MilToMetricViewModel() { }
        #endregion

        #region Methods
        private void Calc()
        {
            CalcConversion();
            CalcMultDiv();
        }

        private void CalcConversion()
        {
            if (SelectedConversion == 0)
            {
                milliToMilDirect();
            }
            else
            {
                MilToMilliDirect();
            }
        }
        private void milliToMilDirect()
        {
            DirectOutput = InputValue / Constants._milliToMil;
        }

        private void MilToMilliDirect()
        {
            DirectOutput = InputValue * Constants._milToMilli;
        }

        private void CalcMultDiv()
        {
            Multiple.Calc(MultiInput);
            Division.Calc(MultiInput);
        }

        public void SetMultiConvInput(string name)
        {
            SelectedOutput = name;
            MultiInput = GetMultiConvInput(SelectedOutput);
            Calc();
        }

        private double GetMultiConvInput(string name)
        {
            switch (name)
            {
                case "DirectInputRB":
                    return InputValue;
                case "DirectOutputRB":
                    return DirectOutput;
                default:
                    return InputValue;
            }
        }
        #endregion

        #region Full Props
        public string SelectedOutput
        {
            get => _selectedOutput;
            set
            {
                _selectedOutput = value;
                OnPropertyChanged();
            }
        }

        public string DirectInput
        {
            get => _input;
            set
            {
                _input = value;
                InputValue = TextUtils.ParseDouble(value);
                CalcConversion();
                OnPropertyChanged();
                OnPropertyChanged(nameof(DirectOutput));
            }
        }

        public double InputValue
        {
            get => _inputValue;
            set
            {
                _inputValue = value;
            }
        }

        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                InputValue = TextUtils.ParseDouble(value);
                Calc();
                OnPropertyChanged();
            }
        }

        public double DirectOutput
        {
            get => _directOutput;
            set
            {
                _directOutput = value;
                OnPropertyChanged();
            }
        }

        public MultipleManager Multiple
        {
            get => _multiple;
            set
            {
                _multiple = value;
                OnPropertyChanged();
            }
        }

        public DivisionManager Division
        {
            get => _division;
            set
            {
                _division = value;
                OnPropertyChanged();
            }
        }

        public int SelectedConversion
        {
            get => _selectedConversion;
            set
            {
                _selectedConversion = value;
                OnPropertyChanged();
            }
        }

        public double MultiInput
        {
            get => _multiInput;
            set
            {
                _multiInput = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
