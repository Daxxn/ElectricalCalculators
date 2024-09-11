using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ElectricalCalculators.Utils.Converters
{
   public class HexConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is uint uval)
         {
            return $"0x{uval:X}";
         }
         else if (value is int ival)
         {
            return $"0x{ival:X}";
         }
         return value;
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is string str)
         {
            if (int.TryParse(str, out int val))
            {
               return val;
            }
         }
         return 0;
      }
   }
}
