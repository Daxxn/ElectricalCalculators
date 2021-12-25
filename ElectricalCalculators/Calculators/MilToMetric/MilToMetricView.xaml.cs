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

namespace ElectricalCalculators.Calculators.MilToMetric
{
    /// <summary>
    /// Interaction logic for MilToMetricView.xaml
    /// </summary>
    public partial class MilToMetricView : UserControl
    {
        private MilToMetricViewModel VM { get; init; }
        public MilToMetricView()
        {
            VM = new();
            DataContext = VM;
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.SelectAll();
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton rb)
            {
                VM.SetMultiConvInput(rb.Name);
            }
        }

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (sender is TextBox tb)
        //    {
        //        if (string.IsNullOrEmpty(tb.Text))
        //        {
        //            tb.Text = "0";
        //        }
        //        else if (string.)
        //    }
        //}
    }
}
