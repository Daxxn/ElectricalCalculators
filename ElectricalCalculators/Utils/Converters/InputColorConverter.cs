using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ElectricalCalculators.Utils.Converters
{
   public class InputColorConverter : IValueConverter
   {
      private readonly SolidColorBrush _defaultColor = new(Color.FromRgb(255, 255, 255));
      private readonly SolidColorBrush _inputColor = new(Color.FromRgb(240, 240, 250));
      private readonly SolidColorBrush _outputColor = new(Color.FromRgb(250, 240, 240));

      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is bool bl)
         {
            return bl ? _inputColor : _outputColor;
         }
         return _defaultColor;
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return value;
      }
   }
}
