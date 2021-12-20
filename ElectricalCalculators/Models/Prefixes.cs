using ElectricalCalculators.Calculators.Prefixes.Models.Enums;
using System;
using System.Collections.Generic;

namespace ElectricalCalculators.GlobalModels
{
    public class Prefixes
    {
        public static readonly Dictionary<int, string> AllPrefixes = new()
        {
            { 15, "Peta" },
            { 12, "Tera" },
            { 9, "Giga" },
            { 6, "Mega" },
            { 3, "Kilo" },
            { 2, "Hecto" },
            { 1, "Deka" },
            { 0, "" },
            { -1, "Deci" },
            { -2, "Centi" },
            { -3, "Milli" },
            { -6, "Micro" },
            { -9, "Nano" },
            { -12, "Pico" },
        };

        public static Dictionary<int, string> GetAllPrefixes()
        {
            return AllPrefixes;
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
