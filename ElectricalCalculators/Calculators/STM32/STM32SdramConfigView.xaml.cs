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

namespace ElectricalCalculators.Calculators.STM32;

public partial class STM32SdramConfigView : UserControl
{
   private readonly STM32SdramConfigViewModelViewModel VM;
   public STM32SdramConfigView()
   {
      VM = new();
      DataContext = VM;
      InitializeComponent();
   }

   private void CopyButton_Click(object sender, RoutedEventArgs e)
   {

   }

   private void TextBox_GotFocus(object sender, RoutedEventArgs e)
   {
      if (sender is TextBox tb)
      {
         tb.SelectAll();
      }
   }
}
