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

namespace ElectricalCalculators.Calculators.Prefixes
{
   /// <summary>
   /// Interaction logic for PrefixesView.xaml
   /// </summary>
   public partial class PrefixesView : UserControl
   {
      private PrefixesViewModel VM { get; set; }
      public PrefixesView()
      {
         VM = new PrefixesViewModel();
         DataContext = VM;
         InitializeComponent();
         //HistoryList.SelectionChanged += HistoryList_SelectionChanged;
      }

      /// <summary>
      /// --NOT USED--
      /// Keep for future examination.
      /// <para/>
      /// Sends the Selection changes to the MainViewModel.
      /// <br/>
      /// <br/>
      /// Used this instead of a driect binding. That way when the new item is selected, the InputValue
      /// <br/>
      /// can be changed without the need for more bindings. Multiple chained bindings tend to break and
      /// arent reliable.
      /// </summary>
      /// <param name="sender">Event sender</param>
      /// <param name="e">Event args</param>
      //private void HistoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
      //{
      //    if (sender is ListBox lb)
      //    {
      //        VM.HistorySelection(lb.SelectedItem as string);
      //    }
      //}
   }
}
