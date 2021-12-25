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

namespace ElectricalCalculators.Calculators.LEDCurrent
{
    /// <summary>
    /// Interaction logic for LEDCurrentView.xaml
    /// </summary>
    public partial class LEDCurrentView : UserControl
    {
        public LEDCurrentViewModel VM { get; init; }
        public LEDCurrentView()
        {
            VM = new();
            DataContext = VM;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            VM.UpdateCalc(sender, e);
        }
    }
}
