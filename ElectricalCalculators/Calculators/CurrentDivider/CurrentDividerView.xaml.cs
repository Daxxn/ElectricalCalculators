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

namespace ElectricalCalculators.Calculators.CurrentDivider
{
    /// <summary>
    /// Interaction logic for CurrentDividerView.xaml
    /// </summary>
    public partial class CurrentDividerView : UserControl
    {
        public CurrentDividerViewModel VM { get; init; }
        public CurrentDividerView()
        {
            VM = new();
            DataContext = VM;
            InitializeComponent();

            //ResistorList.KeyDown += UpdateResistorList;
            ResistorList.LostKeyboardFocus += UpdateResistorList;
        }

        private void UpdateResistorList(object sender, EventArgs e)
        {
            VM.Calculate();
        }
    }
}
