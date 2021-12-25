﻿using ElectricalCalculators.Models;
using ElectricalCalculators.Models.LEDCurrent;
using ElectricalCalculators.Models.Prefixes;
using ElectricalCalculators.Models.Prefixes.Enums;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.LEDCurrent
{
    public class LEDCurrentViewModel : ViewModel
    {
        #region Local Props

        private double _vcc = new();
        private double _forwardVoltage = new();
        private double _forwardCurrent = new();

        private Number _resistor = new(PrefixType.Resisitor);
        private Number _power = new(PrefixType.All);

        #region Commands
        public Command CalculateCmd { get; init; }
        #endregion
        #endregion

        #region Constructors
        public LEDCurrentViewModel()
        {
            CalculateCmd = new(Calculate);
        }
        #endregion

        #region Methods
        private void Calculate()
        {
            Resistor = LEDCurrentCalculator.Calc(VCC, ForwardVoltage, ForwardCurrent);
        }

        public void UpdateCalc(object sender, EventArgs e)
        {
            Calculate();
        }
        #endregion

        #region Full Props
        public double VCC
        {
            get => _vcc;
            set
            {
                _vcc = value;
                OnPropertyChanged();
            }
        }

        public double ForwardCurrent
        {
            get => _forwardCurrent;
            set
            {
                _forwardCurrent = value;
                OnPropertyChanged();
            }
        }

        public double ForwardVoltage
        {
            get => _forwardVoltage;
            set
            {
                _forwardVoltage = value;
                OnPropertyChanged();
            }
        }

        public Number Resistor
        {
            get => _resistor;
            set
            {
                _resistor = value;
                OnPropertyChanged();
            }
        }

        public Number Power
        {
            get => _power;
            set
            {
                _power = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}