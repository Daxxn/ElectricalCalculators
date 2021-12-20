using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.Prefixes.Models
{
    public class History<T> : Model
    {
        #region Local Props
        private ObservableCollection<T> _hist = new();
        private int _limit = 10;
        #endregion

        #region Constructors
        public History() { }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the input item to the history list.
        /// </summary>
        /// <param name="hist">Item to add</param>
        public void AddToHistory(T hist)
        {
            Hist.Insert(0, hist);
        }

        /// <summary>
        /// Clears the input history.
        /// </summary>
        public void Clear()
        {
            Hist.Clear();
        }

        /// <summary>
        /// Checks the length of the history, if its too long it removes old values.
        /// </summary>
        private void CheckLength()
        {
            if (Hist.Count > Limit)
            {
                while (Hist.Count > Limit)
                {
                    Hist.RemoveAt(Hist.Count - 1);
                }
            }
        }
        #endregion

        #region Full Props
        public ObservableCollection<T> Hist
        {
            get => _hist;
            set
            {
                _hist = value;
                CheckLength();
                OnPropertyChanged();
            }
        }

        public int Limit
        {
            get => _limit;
            set
            {
                _limit = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
