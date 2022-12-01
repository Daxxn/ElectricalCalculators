using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Utils
{
    public static class TextUtils
    {
        public static string CleanNumberInput(string input, bool allowDecimal = true)
        {
            if (input == null || string.IsNullOrEmpty(input)) return "";

            if (input.Length > 0)
            {
                StringBuilder sb = new();
                foreach (var ch in input)
                {
                    if (char.IsDigit(ch))
                    {
                        sb.Append(ch);
                    }
                    else if (allowDecimal && char.IsPunctuation(ch) && ch == '.')
                    {
                        sb.Append(ch);
                    }
                }
                return sb.ToString();
            }
            return input;
        }

        public static double ParseDouble(string input)
        {
            var success = double.TryParse(CleanNumberInput(input), out double output);
            if (success) return output;
            return double.NaN;
        }

        public static int ParseInt(string input)
        {
            var success = int.TryParse(CleanNumberInput(input), out int output);
            if (success) return output;
            return 0;
        }

        public static decimal ParseDecimal(string input)
        {
            var success = decimal.TryParse(CleanNumberInput(input), out decimal output);
            if (success) return output;
            return decimal.Zero;
        }
    }
}
