using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using ElectricalCalculators.Models;

namespace ElectricalCalculators.Utils.Converters;

public class ByteConverter : IValueConverter
{
   public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
   {
      //if (value is double d)
      //{
      //   return ByteParser.Convert(d);
      //}
      //return null;
      return value;
   }

   public object? ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
   {
      if (value is string str)
      {
         return ByteParser.Parse(str);
      }
      return null;
   }
}
