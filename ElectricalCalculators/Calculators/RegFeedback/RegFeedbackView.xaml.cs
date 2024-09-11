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

namespace ElectricalCalculators.Calculators.RegFeedback
{
   /// <summary>
   /// Interaction logic for RegFeedbackView.xaml
   /// </summary>
   public partial class RegFeedbackView : UserControl
   {
      private readonly RegFeedbackViewModel RegFeedbackVM = new();
      private readonly NearestResViewModel NearestResVM = new();
      public RegFeedbackView()
      {
         InitializeComponent();
         FeedbackCalcTab.DataContext = RegFeedbackVM;
         NearestResTab.DataContext = NearestResVM;
         NearestResVM.OnInitialized();
      }

      private void RadioButton_Checked(object sender, RoutedEventArgs e)
      {
         if (sender is RadioButton btn)
         {
            switch (btn.Name)
            {
               case "RadioR1":
                  RegFeedbackVM.CalcOption = RadioR1.IsChecked ?? false;
                  break;
               case "RadioVout":
                  RegFeedbackVM.CalcOption = !RadioVout.IsChecked ?? true;
                  break;
            }
         }
      }

      private void TextBox_GotFocus(object sender, RoutedEventArgs e)
      {
         if (sender is TextBox txt)
         {
            txt.SelectAll();
            e.Handled = true;
         }
      }
   }
}
