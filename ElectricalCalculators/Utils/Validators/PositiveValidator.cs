using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ElectricalCalculators.Utils.Validators
{
   public class PositiveValidator : ValidationRule
   {
      public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
      {
         if (value is double d)
         {
            if (d <= 0)
            {
               return new(false, null);
            }
         }
         return new(true, null);
      }
   }
}
