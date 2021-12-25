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

namespace ElectricalCalculators.Calculators.VoltageDivider
{
    /// <summary>
    /// Interaction logic for VoltageDividerView.xaml
    /// </summary>
    public partial class VoltageDividerView : UserControl
    {
        public VoltageDividerViewModel VM { get; init; }
        public VoltageDividerView()
        {
            VM = new();
            DataContext = VM;
            InitializeComponent();
        }
    }
}
