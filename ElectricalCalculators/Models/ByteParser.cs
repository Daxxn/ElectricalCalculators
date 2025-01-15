using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

namespace ElectricalCalculators.Models;

public static class ByteParser
{
   #region Local Props
   private static readonly Dictionary<char, int> Suffixes = new()
   {
      { 'K', 3 },
      { 'M', 6 },
      { 'G', 9 },
      { 'T', 12 },
      { 'P', 15 },
   };
   private static readonly Dictionary<int, string> ToSuffix = new()
   {
      { 0, "" },
      { 1, "" },
      { 2, "" },
      { 3, "K" },
      { 4, "K" },
      { 5, "K" },
      { 6, "M" },
      { 7, "M" },
      { 8, "M" },
      { 9, "G" },
      { 10, "G" },
      { 11, "G" },
      { 12, "T" },
      { 13, "T" },
      { 14, "T" },
      { 15, "P" },
      { 16, "P" },
      { 17, "P" },
   };
   #endregion

   #region Methods
   public static double? Parse(string input)
   {
      if (string.IsNullOrWhiteSpace(input)) return null;

      if (Suffixes.ContainsKey(input[^1]))
      {
         if (double.TryParse(input[..^1], out double val))
         {
            return val * Math.Pow(10, Suffixes[input[^1]]);
         }
      }
      else
      {
         if (double.TryParse(input, out double val))
         {
            return val;
         }
      }
      return null;
   }

   public static string? Convert(double input)
   {
      var exp = (int)Math.Floor(Math.Log10(input));
      if (exp == 0)
      {
         return $"{input:F}";
      }
      else if (exp > 15)
      {
         return $"{input:F}P";
      }
      else if (ToSuffix.TryGetValue(exp, out string? sfx))
      {
         return $"{input * Math.Pow(10, -exp)}{sfx}";
      }
      return null;
   }
   #endregion

   #region Full Props

   #endregion
}
