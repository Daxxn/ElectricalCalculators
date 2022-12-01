using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ElectricalCalculators.Utils.Converters
{
    public class NumberInputConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";

            if (parameter is string param)
            {
                if (param.ToLower() == "double" || param.ToLower() == "decimal")
                {
                    if (value is string st)
                    {
                        return TextUtils.CleanNumberInput(st, false);
                    }
                    return value;
                }
                else if (param.ToLower() == "int")
                {
                    if (value is string st)
                    {
                        return TextUtils.CleanNumberInput(st);
                    }
                    return value;
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
