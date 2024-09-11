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

namespace ElectricalCalculators.Calculators.STM32
{
   /// <summary>
   /// Interaction logic for Stm32FsmcLcdView.xaml
   /// </summary>
   public partial class Stm32FsmcLcdView : UserControl
   {
      private Stm32FsmcLcdViewModel viewModel;
      public Stm32FsmcLcdView()
      {
         viewModel = new();
         DataContext = viewModel;
         InitializeComponent();
      }
   }
}
