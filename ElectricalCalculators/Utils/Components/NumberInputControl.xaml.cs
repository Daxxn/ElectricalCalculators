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

namespace ElectricalCalculators.Utils.Components
{
    /// <summary>
    /// Interaction logic for NumberInputControl.xaml
    /// </summary>
    public partial class NumberInputControl : UserControl
    {
        #region Dep Props
        public string RawText
        {
            get { return (string)GetValue(RawTextProperty); }
            set 
            {
                SetValue(RawTextProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for RawText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RawTextProperty =
            DependencyProperty.Register("RawText", typeof(string), typeof(NumberInputControl), new PropertyMetadata(null));

        public double Number
        {
            get { return (double)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Number.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(double), typeof(NumberInputControl), new PropertyMetadata(0.0));
        #endregion

        public NumberInputControl()
        {
            InitializeComponent();
            textInput.TextChanged += TextInput_TextChanged;
        }

        private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                Number = TextUtils.ParseDouble(tb.Text);
                SetValue(NumberProperty, Number);
            }
        }
    }
}
