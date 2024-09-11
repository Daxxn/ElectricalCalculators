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

namespace ElectricalCalculators.Calculators.ADCConversionFactor
{
   /// <summary>
   /// Interaction logic for AdcConversionView.xaml
   /// </summary>
   public partial class AdcConversionView : UserControl
   {
      private AdcConversionViewModel VM;
      public AdcConversionView()
      {
         VM = new();
         DataContext = VM;
         InitializeComponent();
      }
   }
}
