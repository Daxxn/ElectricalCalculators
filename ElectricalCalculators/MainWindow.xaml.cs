using ElectricalCalculators.Calculators.Binary;
using ElectricalCalculators.Calculators.BomReader;
using ElectricalCalculators.Calculators.CurrentDivider;
using ElectricalCalculators.Calculators.LEDCurrent;
using ElectricalCalculators.Calculators.MaxFreq;
using ElectricalCalculators.Calculators.MilToMetric;
using ElectricalCalculators.Calculators.MOSFETCalc;
using ElectricalCalculators.Calculators.OhmsLaw;
using ElectricalCalculators.Calculators.Prefixes;
using ElectricalCalculators.Calculators.VoltageDivider;
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

namespace ElectricalCalculators
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel VM { get; init; }
        public MainWindow()
        {
            VM = new MainViewModel();
            DataContext = VM;
            InitializeComponent();
            MetricPrefixTab.Content = new PrefixesView();
            OhmsLawTab.Content = new OhmsLawView();
            LEDCurrentTab.Content = new LEDCurrentView();
            VoltageDividerTab.Content = new VoltageDividerView();
            CurrentDividerTab.Content = new CurrentDividerView();
            MilToMetricTab.Content = new MilToMetricView();
            BinaryTab.Content = new BinaryView();
            BOMTab.Content = new BomReaderView();
            MOSFETTab.Content = new MOSFETCalcView();
            MaxFreqTab.Content = new MaxFreqView();
        }

        private void TypicalResistors_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TypicalCapacitors_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TypicalInductors_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
