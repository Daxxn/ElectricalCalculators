using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ElectricalCalculators.Utils.Converters
{
   public class DecimalConverter : IValueConverter
   {
      public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is double d)
         {
            return Math.Round(d, 4);
         }
         return value;
      }
      public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is string str)
         {
            if (str.EndsWith('.'))
            {
               str += '0';
            }
            if (double.TryParse(str, out double val))
            {
               return val;
            }
         }
         return 0;
      }
   }
}
