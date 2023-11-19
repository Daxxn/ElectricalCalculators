using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using ElectricalSuffixParser.Models;
using ElectricalSuffixParser.Parsers;

namespace ElectricalCalculators.Utils.Converters;

public class SuffixConverter : IValueConverter
{
   private static SuffixParser parser { get; set; } = new(App.SuffixManager.Suffixes);

   public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
   {
      if (value is double output)
      {
         return parser.Convert(output, (string?)parameter);
      }
      return null;
   }

   public object? ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
   {
      if (value is string input)
      {
         return parser.ParseInput(input);
      }
      return null;
   }
}
