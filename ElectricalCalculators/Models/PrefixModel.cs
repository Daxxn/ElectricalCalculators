using ElectricalCalculators.Models.Prefixes.Enums;
using System;
using System.Collections.Generic;

namespace ElectricalCalculators.Models.Prefixes
{
    public class PrefixModel
    {
        #region Prefixes
        public static readonly Dictionary<int, string> AllPrefixes = new()
        {
            { 15, "Peta" },
            { 12, "Tera" },
            { 9, "Giga" },
            { 6, "Mega" },
            { 3, "Kilo" },
            { 0, "" },
            { -2, "Centi" },
            { -3, "Milli" },
            { -6, "Micro" },
            { -9, "Nano" },
            { -12, "Pico" },
        };

        public static readonly Dictionary<int, string> ResistorPrefixes = new()
        {
            { 9, "Giga" },
            { 6, "Mega" },
            { 3, "Kilo" },
            { 0, "" },
            { -3, "Milli" },
            { -6, "Micro" },
            { -9, "Nano" },
        };

        public static readonly Dictionary<int, string> CapIndPrefixes = new()
        {
            { 0, "" },
            { -3, "Milli" },
            { -6, "Micro" },
            { -9, "Nano" },
            { -12, "Pico" },
        };
        #endregion

        #region Short Prefixes
        public static readonly Dictionary<int, string> AllShortPrefixes = new()
        {
            { 15, "P" },
            { 12, "T" },
            { 9, "G" },
            { 6, "M" },
            { 3, "K" },
            { 2, "H" },
            { 1, "D" },
            { 0, "" },
            { -1, "d" },
            { -2, "c" },
            { -3, "m" },
            { -6, "µ" },
            { -9, "n" },
            { -12, "p" },
        };

        public static readonly Dictionary<int, string> ResistorShortPrefixes = new()
        {
            { 9, "G" },
            { 6, "M" },
            { 3, "K" },
            { 0, "" },
            { -3, "m" },
            { -6, "µ" },
            { -9, "n" },
        };

        public static readonly Dictionary<int, string> CapIndShortPrefixes = new()
        {
            { 0, "" },
            { -3, "m" },
            { -6, "µ" },
            { -9, "n" },
            { -12, "p" },
        };
        #endregion

        #region Get Prefixes
        public static Dictionary<int, string> GetAllPrefixes()
        {
            return AllPrefixes;
        }

        public static Dictionary<int, string> GetResistorPrefixes()
        {
            return ResistorPrefixes;
        }

        public static Dictionary<int, string> GetCapIndPrefixes()
        {
            return CapIndPrefixes;
        }
        #endregion

        #region Get Short Prefixes
        public static Dictionary<int, string> GetAllShortPrefixes()
        {
            return AllShortPrefixes;
        }

        public static Dictionary<int, string> GetResistorShortPrefixes()
        {
            return ResistorShortPrefixes;
        }

        public static Dictionary<int, string> GetCapIndShortPrefixes()
        {
            return CapIndShortPrefixes;
        }
        #endregion

        public static Dictionary<int, string> GetPrefixes(PrefixType type)
        {
            if (type == PrefixType.All)
            {
                return AllPrefixes;
            }
            else if (type == PrefixType.Resisitor)
            {
                return ResistorPrefixes;
            }
            else
            {
                return CapIndPrefixes;
            }
        }

        public static Dictionary<int, string> GetShortPrefixes(PrefixType type)
        {
            if (type == PrefixType.All)
            {
                return AllShortPrefixes;
            }
            else if (type == PrefixType.Resisitor)
            {
                return ResistorShortPrefixes;
            }
            else
            {
                return CapIndShortPrefixes;
            }
        }

        /// <summary>
        /// Finds a prefix.
        /// </summary>
        /// <param name="exponent">Original Exponent</param>
        /// <param name="option">Search Options</param>
        /// <returns>Prefix name and Exponent</returns>
        /// <exception cref="ArgumentException">Throws if the exponent is too high or not a driect match.</exception>
        public static (string, int) GetPrefix(int exponent, PrefixOption option)
        {
            if (AllPrefixes.ContainsKey(exponent))
            {
                return (AllPrefixes[exponent], exponent);
            }
            else if (option == PrefixOption.Exact || (exponent > 15 && exponent < -12))
            {
                throw new ArgumentException("Prefix not found.");
            }

            if (option == PrefixOption.Lowest)
            {
                return GetLowest(exponent);
            }
            else
            {
                return GetHighest(exponent);
            }
        }

        public static double Getvalue(double? baseValue, int exp)
        {
            if (baseValue is not null)
            {
                return (double)baseValue * Math.Pow(10, exp);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Cycles through the exponent indexes until it finds the lowest matching prefix.
        /// </summary>
        /// <param name="exponent">Original Exponent</param>
        /// <returns>Prefix name and Exponent</returns>
        private static (string, int) GetLowest(int exponent)
        {
            for (int i = exponent; i > -13; i--)
            {
                if (AllPrefixes.ContainsKey(i))
                {
                    return (AllPrefixes[i], i);
                }
            }
            return ("", exponent);
        }

        /// <summary>
        /// Cycles through the exponent indexes until it finds the highest matching prefix.
        /// </summary>
        /// <param name="exponent">Original Exponent</param>
        /// <returns>Prefix name and Exponent</returns>
        private static (string, int) GetHighest(int exponent)
        {
            for (int i = exponent; i < 16; i++)
            {
                if (AllPrefixes.ContainsKey(i))
                {
                    return (AllPrefixes[i], i);
                }
            }
            return ("", exponent);
        }
    }
}
