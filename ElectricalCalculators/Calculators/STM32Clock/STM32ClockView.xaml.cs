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

namespace ElectricalCalculators.Calculators.STM32Clock;

/// <summary>
/// Interaction logic for STM32ClockView.xaml
/// </summary>
public partial class STM32ClockView : UserControl
{
   STM32ClockViewModel VM { get; set; }
   public STM32ClockView()
   {
      VM = new STM32ClockViewModel();
      DataContext = VM;
      InitializeComponent();
   }

   private void Prescalar_Max_Click(object sender, RoutedEventArgs e)
   {
      PrescalarTB.Text = "65535";
      VM.PreviousInput = InputType.Prescalar;
   }

   private void Prescalar_Min_Click(object sender, RoutedEventArgs e)
   {
      PrescalarTB.Text = "0";
      VM.PreviousInput = InputType.Prescalar;
   }

   private void Period_Max_Click(object sender, RoutedEventArgs e)
   {
      PeriodTB.Text = "65535";
      VM.PreviousInput = InputType.Period;
   }

   private void Period_Min_Click(object sender, RoutedEventArgs e)
   {
      PeriodTB.Text = "0";
      VM.PreviousInput = InputType.Period;
   }

   private void TextBox_GotFocus(object sender, RoutedEventArgs e)
   {
      if (sender is TextBox tb)
      {
         tb.CaretIndex = tb.Text.Length;
         tb.SelectAll();

         switch (tb.Name)
         {
            case "PrescalarTB":
               VM.PreviousInput = InputType.Prescalar;
               break;
            case "PeriodTB":
               VM.PreviousInput = InputType.Period;
               break;
            case "ClockTB":
               VM.PreviousInput = InputType.Clock;
               break;
            case "TimerTB":
               VM.PreviousInput = InputType.Timer;
               break;
            case "IntervalTB":
               VM.PreviousInput = InputType.Timer;
               break;
            default:
               break;
         }
      }
   }
}
