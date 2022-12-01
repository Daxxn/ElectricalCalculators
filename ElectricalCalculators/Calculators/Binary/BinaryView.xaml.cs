using ElectricalCalculators.Models.Binary;
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

namespace ElectricalCalculators.Calculators.Binary
{
    /// <summary>
    /// Interaction logic for BinaryView.xaml
    /// </summary>
    public partial class BinaryView : UserControl
    {
        public BinaryViewModel VM { get; init; }
        public BinaryView()
        {
            VM = new();
            DataContext = VM;
            InitializeComponent();

            VM.BinarySizeChanged += VM_BinarySizeChanged;

            ConstructBinaryGrid(VM.SelectedSize);
        }

        private void VM_BinarySizeChanged(object? sender, uint e)
        {
            ConstructBinaryGrid(e);
        }

        private void ConstructBinaryGrid(uint e)
        {
            BinaryDigitsContainer.Children.Clear();
            for (uint i = 0; i < e; i++)
            {
                var cb = new CheckBox()
                {
                    Name = $"B{i}"
                };
                cb.DataContext = i;
                cb.Checked += Cb_Checked;
                var binding = new Binding($"Binary.States[{i}]");
                binding.Source = VM;
                cb.SetBinding(CheckBox.IsCheckedProperty, binding);
                BinaryDigitsContainer.Children.Add(cb);
            }
        }

        private void Cb_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb)
            {
                VM.BinaryChange((uint)cb.DataContext, cb.IsChecked == true);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox cb)
            {
                if (cb.SelectedValue is BinarySize size)
                {
                    VM.SelectedSize = (uint)size;
                }
            }
        }
    }
}
