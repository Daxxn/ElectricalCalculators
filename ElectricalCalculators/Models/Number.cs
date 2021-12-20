using ElectricalCalculators.Calculators.Prefixes.Models.Enums;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.GlobalModels
{
    public class Number : Model
    {
        #region Local Props
        private double _base = 0;
        private int _exp = 0;
        private double _raw = 0;
        private string _prefix = "";
        private int _prefixExp = 0;
        private double _prefixBase = 0;
        private int _round = 5;
        #endregion

        #region Constructors
        public Number() { }
        #endregion

        #region Methods
        private void ParsePrefixes(PrefixOption option)
        {
            (Prefix, PrefixExponent) = Prefixes.GetPrefix(Exponent, option);
            PrefixBase = Raw * Math.Pow(10, -PrefixExponent);
        }

        /// <summary>
        /// Parses an incoming number, Gets the exponent and the base.
        /// </summary>
        private void ParseNumber()
        {
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
        }

        /// <summary>
        /// Removes commas from the input number.
        /// </summary>
        /// <param name="input">Raw input</param>
        /// <returns></returns>
        private static string CleanInput(string input)
        {
            return input.Replace(",", "");
        }

        /// <summary>
        /// Parses an incoming number from the user and converts the number to
        /// a scientific number.
        /// </summary>
        /// <param name="value">Raw input</param>
        /// <param name="option"></param>
        /// <exception cref="Exception">Throwm if the numbers base or exponent could not parse.</exception>
        /// <exception cref="ArgumentException">Thrown if the string is not parsable at all.</exception>
        public void Parse(string value, PrefixOption option)
        {
            string input = CleanInput(value);
            if (input.Contains('e'))
            {
                var spl = input.Split('e');
                if (spl.Length == 2)
                {
                    var success = double.TryParse(spl[0], out double _b);
                    if (!success) throw new Exception("Unable to parse Base.");

                    Base = _b;
                    success = int.TryParse(spl[1], out int _e);
                    if (!success) throw new Exception("Unable to parse Exponent.");

                    Exponent = _e;
                    Raw = Base * Math.Pow(10, Exponent);
                    ParsePrefixes(option);
                }
                else
                {
                    throw new ArgumentException("Value is not recognized.");
                }
            }
            else
            {
                if (!double.TryParse(input, out double _r)) throw new ArgumentException("Value cannot be parsed.");
                Raw = _r;
                ParseNumber();
                ParsePrefixes(option);
            }
        }
        #endregion

        #region Full Props
        public double Base
        {
            get => _base;
            set
            {
                _base = value;
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

        public int PrefixExponent
        {
            get => _prefixExp;
            set
            {
                _prefixExp = value;
                OnPropertyChanged();
            }
        }

        public double PrefixBase
        {
            get => _prefixBase;
            set
            {
                _prefixBase = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PrefixBaseRound));
            }
        }

        public double PrefixBaseRound
        {
            get => Math.Round(_prefixBase, Round);
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
        #endregion
    }
}
