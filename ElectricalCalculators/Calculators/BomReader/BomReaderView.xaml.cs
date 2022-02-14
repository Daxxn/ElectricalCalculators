using ElectricalCalculators.Models.BOM;
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

namespace ElectricalCalculators.Calculators.BomReader
{
    /// <summary>
    /// Interaction logic for BomReaderView.xaml
    /// </summary>
    public partial class BomReaderView : UserControl
    {
        private BomReaderViewModel VM { get; init; }
        public BomReaderView()
        {
            VM = new();
            DataContext = VM;
            InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is Part part)
            {
                VM.SelectedPartChanged(part);
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                if (e.AddedItems[0] is PartAttribute attr)
                {
                    VM.SelectedAttrChanged(attr);
                }
            }
        }
    }
}
