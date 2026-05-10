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

using ElectricalCalculators.Models;

namespace ElectricalCalculators.Calculators.STM32
{
   public partial class STM32DriverExamplesView : UserControl
   {
      private STM32DriverExamplesViewModel VM;
      public STM32DriverExamplesView()
      {
         VM = new STM32DriverExamplesViewModel();
         DataContext = VM;
         InitializeComponent();
      }

      private void OpenFolder_Click(object sender, RoutedEventArgs e)
      {
         if (sender is Button btn)
         {
            if (btn.DataContext is STM32ExampleFolder folder)
            {
               VM.OpenFolderEvent(folder);
            }
         }
      }
   }
}
