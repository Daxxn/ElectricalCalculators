using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ElectricalCalculators.Utils.Validators
{
   public class DecimalValidationRule : ValidationRule
   {
      public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
      {
         if (value is string str)
         {
            if (str.EndsWith('.'))
            {
               str += '0';
            }
            if (double.TryParse(str, out double val))
            {
               return new(true, null);
            }
         }
         return new(false, null);
      }
   }
}
