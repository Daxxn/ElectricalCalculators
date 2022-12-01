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

namespace ElectricalCalculators.Calculators.MaxFreq
{
   /// <summary>
   /// Interaction logic for MaxFreqView.xaml
   /// </summary>
   public partial class MaxFreqView : UserControl
   {
      public MaxFreqViewModel VM { get; init; }
      public MaxFreqView()
      {
         VM = new();
         DataContext = VM;
         InitializeComponent();
      }

      private void TextBox_GotFocus(object sender, RoutedEventArgs e)
      {
         if (sender is TextBox tb) tb.SelectAll();
      }
   }
}
