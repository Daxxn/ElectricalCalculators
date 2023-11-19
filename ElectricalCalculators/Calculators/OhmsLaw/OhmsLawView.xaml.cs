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

namespace ElectricalCalculators.Calculators.OhmsLaw
{
   /// <summary>
   /// Interaction logic for OhmsLawView.xaml
   /// </summary>
   public partial class OhmsLawView : UserControl
   {
      //public Dictionary<int, string> PrefixesDict = Prefixes.AllPrefixes
      public OhmsLawViewModel VM { get; set; }
      public OhmsLawView()
      {
         VM = new();
         DataContext = VM;
         InitializeComponent();
         VM.ClearEvent += VM_ClearEvent;
      }

      private void VM_ClearEvent(object? sender, EventArgs e)
      {
         VoltInput.Focus();
      }

      private void TextBox_GotFocus(object sender, RoutedEventArgs e)
      {
         if (sender is TextBox tb) tb.SelectAll();
      }

      private void OhmsLaw_LostFocus(object sender, RoutedEventArgs e)
      {
         if (sender is TextBox tb)
         {
            if (!string.IsNullOrEmpty(tb.Text))
            {
               VM.UpdateTextBoxHistory(tb.TabIndex);
            }
         }
      }
   }
}
