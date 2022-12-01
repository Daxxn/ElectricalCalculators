using ElectricalCalculators.Models;
using ElectricalCalculators.Models.Prefixes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectricalCalculators.Calculators.MOSFETCalc
{
   /// <summary>
   /// Interaction logic for MOSFETCalcView.xaml
   /// </summary>
   public partial class MOSFETCalcView : UserControl
   {
      private MOSFETCalcViewModel VM { get; init; }
      public MOSFETCalcView()
      {
         VM = new();
         DataContext = VM;

         InitializeComponent();
      }

      /// <summary>
      /// !!NOT USED!!
      /// Could work but the Number class would need to extensively modified. Maybe later.
      /// </summary>
      private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
      {
         if (sender is TextBox tb)
         {
            if (tb.DataContext is Number num)
            {
               num.Parse(tb.Text, PrefixOption.Lowest);
            }
         }
      }

      private void TextBox_GotFocus(object sender, RoutedEventArgs e)
      {
         if (sender is TextBox tb) tb.SelectAll();
      }
   }
}
