using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ElectricalCalculators.Utils.Converters
{
   public class Percentconverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is double d)
         {
            return Math.Round(d * 100, 2);
         }
         return value;
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is string str)
         {
            if (double.TryParse(str, out double d))
            {
               if (d < 0) return 0;
               if (d > 100) return 1;
               return d / 100;
            }
         }
         return 0;
      }
   }
}
