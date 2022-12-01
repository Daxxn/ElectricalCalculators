using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ElectricalCalculators.Utils.Converters
{
   public class DecimalRoundConverter : IValueConverter
   {
      private int DefaultRound { get; } = 4;
      private int Round { get; set; } = 4;
      public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value == null) return null;
         if (parameter is null)
         {
            if (value is double d)
            {
               return Math.Round(d, DefaultRound);
            }
         }
         else if (parameter is string str)
         {
            if (int.TryParse(str, out int r))
            {
               Round = r;
            }
            if (value is double d)
            {
               return Math.Round(d, Round);
            }
         }
         return value;
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return value;
      }
   }
}
