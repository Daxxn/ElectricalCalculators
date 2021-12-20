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
using ElectricalCalculators.GlobalModels;

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
        }
    }
}
