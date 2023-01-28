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

namespace ElectricalCalculators.Calculators.Vias
{
   /// <summary>
   /// Interaction logic for ViasView.xaml
   /// </summary>
   public partial class ViasView : UserControl
   {
      private ViasViewModel VM { get; set; }
      public ViasView()
      {
         VM = new();
         DataContext = VM;
         InitializeComponent();
      }

      private void DataGridTextColumn_LostFocus(object sender, RoutedEventArgs e)
      {

      }
   }
}
