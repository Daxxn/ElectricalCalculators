using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ElectricalCalculators.Utils.Converters
{
   public class ResistanceConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is double d)
         {
            if (d < 1)
            {
               return $"{ConvertPower(d, 3)}m";
            }
            else if (d < 100000 && d > 999)
            {
               return $"{ConvertPower(d, -3)}K";
            }
            else if (d > 1000000)
            {
               return $"{ConvertPower(d, -6)}M";
            }
            return Math.Round(d, 4);
         }
         return value;
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;

      private static double ConvertPower(double value, double pwr) => Math.Round(value * Math.Pow(10, pwr), 3);
   }
}
