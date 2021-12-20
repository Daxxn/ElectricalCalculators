using ElectricalCalculators.Calculators.Prefixes.Models;
using ElectricalCalculators.Calculators.Prefixes.Models.Enums;
using ElectricalCalculators.GlobalModels;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectricalCalculators.Calculators.Prefixes
{
    public class PrefixesViewModel : ViewModel
    {
        #region Background Props
        private string? _input = null;
        private Number _number = new();
        private PrefixOption _prefixOption = PrefixOption.Lowest;
        private History<string> _history = new();

        private bool _expanderSwitch = true;
        #endregion

        public Command CalcCmd { get; set; }
        public Command ExpanderToggleCmd { get; set; }

        public PrefixesViewModel()
        {
            CalcCmd = new Command(o => Calculate());
            ExpanderToggleCmd = new(o => ExpanderSwitch = !ExpanderSwitch);
        }

        private void Calculate()
        {
            try
            {
                if (InputValue is not null)
                {
                    Number.Parse(InputValue, PrefixOption);
                    InputHistory.AddToHistory(InputValue);
                    InputValue = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void HistorySelection(string? selected)
        {
            if (selected is not null)
            {
                InputValue = selected;
            }
        }

        #region Binding Props
        public string? InputValue
        {
            get => _input;
            set
            {
                _input = value;
                Calculate();
                OnPropertyChanged();
            }
        }

        public Number Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        public PrefixOption PrefixOption
        {
            get => _prefixOption;
            set
            {
                _prefixOption = value;
                OnPropertyChanged();
            }
        }

        public History<string> InputHistory
        {
            get => _history;
            set
            {
                _history = value;
                OnPropertyChanged();
            }
        }

        public bool ExpanderSwitch
        {
            get => _expanderSwitch;
            set
            {
                _expanderSwitch = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PrefixVisible));
                OnPropertyChanged(nameof(ValueVisible));
            }
        }

        public Visibility PrefixVisible
        {
            get => ExpanderSwitch ? Visibility.Visible : Visibility.Collapsed;
        }

        public Visibility ValueVisible
        {
            get => !ExpanderSwitch ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion
    }
}
