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
    public class NumberDisplay : Model
    {
        #region Local Props
        private double _base = 0;
        private int _exp = 0;
        private double _raw = 0;
        private string _prefix = "";
        private string _shortPrefix = "";
        private bool _disableAutoCalc = false;
        private PrefixType _prefixType = PrefixType.All;
        private Dictionary<int, string> _prefixes = new();
        private Dictionary<int, string> _shortPrefixes = new();
        private int _round = 5;
        #endregion

        #region Constructors
        public NumberDisplay(PrefixType type)
        {
            Prefixes = PrefixModel.GetPrefixes(type);
            ShortPrefixes = PrefixModel.GetShortPrefixes(type);
        }
        public NumberDisplay(PrefixType type, int round)
        {
            Prefixes = PrefixModel.GetPrefixes(type);
            ShortPrefixes = PrefixModel.GetShortPrefixes(type);
            Round = round;
        }
        #endregion

        #region Methods
        private void ParsePrefixes(PrefixOption option = PrefixOption.Lowest)
        {
            (Prefix, Exponent) = PrefixModel.GetPrefix(Exponent, option);
            Base = Raw * Math.Pow(10, -Exponent);
        }

        public double CalcRaw()
        {
            Raw = Base * Math.Pow(10, Exponent);
            _disableAutoCalc = true;
            ParsePrefixes();
            _disableAutoCalc = false;
            Prefix = Prefixes[Exponent];
            return Raw;
        }

        /// <summary>
        /// Parses an incoming number, Gets the exponent and the base.
        /// </summary>
        public void CalcBase()
        {
            _disableAutoCalc = true;
            var ex = Math.Floor(Math.Log10(Raw > 0 ? Raw : -Raw));
            if (ex == 0)
            {
                Base = Raw;
                Exponent = 0;
                return;
            }
            else if (Raw > 0)
            {
                Exponent = (int)ex;
            }
            else
            {
                Exponent = -(int)ex;
            }
            Base = Raw * Math.Pow(10, -Exponent);
            ParsePrefixes();
            _disableAutoCalc = false;
        }

        #region Operators
        public static NumberDisplay operator +(NumberDisplay x, NumberDisplay y)
        {
            NumberDisplay output = new(x.PrefixType);
            output.Raw = x.Raw + y.Raw;
            output.CalcBase();
            output.ParsePrefixes();
            return output;
        }

        public static NumberDisplay operator -(NumberDisplay x, NumberDisplay y)
        {
            NumberDisplay output = new(x.PrefixType);
            output.Raw = x.Raw - y.Raw;
            output.CalcBase();
            output.ParsePrefixes();
            return output;
        }

        public static NumberDisplay operator /(NumberDisplay x, NumberDisplay y)
        {
            NumberDisplay output = new(x.PrefixType);
            output.Raw = x.Raw / y.Raw;
            output.CalcBase();
            output.ParsePrefixes();
            return output;
        }

        public static NumberDisplay operator *(NumberDisplay x, NumberDisplay y)
        {
            NumberDisplay output = new(x.PrefixType);
            output.Raw = x.Raw * y.Raw;
            output.CalcBase();
            output.ParsePrefixes();
            return output;
        }
        #endregion

        #endregion

        #region Full Props
        public double Base
        {
            get => _base;
            set
            {
                _base = value;
                if (!_disableAutoCalc)
                {
                    CalcRaw();
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(BaseRound));
            }
        }

        public double BaseRound
        {
            get => Math.Round(_base, Round);
        }

        public int Exponent
        {
            get => _exp;
            set
            {
                _exp = value;
                if (!_disableAutoCalc)
                {
                    CalcRaw();
                }
                OnPropertyChanged();
            }
        }

        public double Raw
        {
            get => _raw;
            set
            {
                _raw = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RawRound));
            }
        }

        public double RawRound
        {
            get => Math.Round(_raw, Round);
        }

        public string Prefix
        {
            get => _prefix;
            set
            {
                _prefix = value;
                OnPropertyChanged();
            }
        }

        public string ShortPrefix
        {
            get => _shortPrefix;
            set
            {
                _shortPrefix = value;
                OnPropertyChanged();
            }
        }

        public int Round
        {
            get => _round;
            set
            {
                _round = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<int, string> Prefixes
        {
            get => _prefixes;
            set
            {
                _prefixes = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<int, string> ShortPrefixes
        {
            get => _shortPrefixes;
            set
            {
                _shortPrefixes = value;
                OnPropertyChanged();
            }
        }

        public PrefixType PrefixType
        {
            get => _prefixType;
            set
            {
                _prefixType = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
