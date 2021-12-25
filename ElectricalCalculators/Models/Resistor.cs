using ElectricalCalculators.Models.Prefixes;
using ElectricalCalculators.Models.Prefixes.Enums;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models
{
    public class Resistor : Model
    {
        #region Local Props
        private NumberDisplay _value = new(PrefixType.Resisitor);
        private string? _name = null;
        private int _number = 0;
        private double _current = 0;
        #endregion

        #region Constructors
        public Resistor() { }
        public Resistor(string name)
        {
            Name = name;
        }
        #endregion

        #region Methods
        public void Clear()
        {
            Value = new(PrefixType.Resisitor);
        }
        #endregion

        #region Full Props
        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public NumberDisplay Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        public double Current
        {
            get => _current;
            set
            {
                _current = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
