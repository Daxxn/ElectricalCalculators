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

namespace ElectricalCalculators.Calculators.DimsHelper
{
   /// <summary>
   /// Interaction logic for DimsHelperView.xaml
   /// </summary>
   public partial class DimsHelperView : UserControl
   {
      public DimsHelperViewModel VM { get; set; } = new();
      public DimsHelperView()
      {
         DataContext = VM;
         InitializeComponent();
      }

      private void TextBox_GotFocus(object sender, RoutedEventArgs e)
      {
         if (sender is TextBox tb) tb.SelectAll();
      }

      private void Dims_LostFocus(object sender, RoutedEventArgs e)
      {
         VM.Calc();
      }
   }
}
