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

namespace ElectricalCalculators.Calculators.LEDCurrent
{
   /// <summary>
   /// Interaction logic for LEDCurrentView.xaml
   /// </summary>
   public partial class LEDCurrentView : UserControl
   {
      public LEDCurrentViewModel VM { get; init; }
      public LEDCurrentView()
      {
         VM = new();
         DataContext = VM;
         InitializeComponent();

         IR_TB.DataContext = 1.45;
         Red_TB.DataContext = 1.85;
         Amber_TB.DataContext = 2.1;
         Orange_TB.DataContext = 2.05;
         Yellow_TB.DataContext = 2.05;
         Green_TB.DataContext = 2.55;
         Blue_TB.DataContext = 3.35;
         Purple_TB.DataContext = 3.05;
         UV_TB.DataContext = 5.0;
         White_TB.DataContext = 3.2;
      }

      private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
      {
         VM.UpdateCalc(sender, e);
      }

      private void TextBox_GotFocus(object sender, RoutedEventArgs e)
      {
         if (sender is TextBox tb) tb.SelectAll();
      }

      private void Color_Click(object sender, MouseButtonEventArgs e)
      {
         if (sender is TextBlock tb)
         {
            if (tb.DataContext is double val)
            {
               VM.ColorSelected(val);
            }
         }
      }
   }
}
