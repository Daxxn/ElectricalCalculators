using ElectricalCalculators.Models.Binary;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models
{
    public class Bit : Model
    {
        #region Local Props
        private BinarySize _size;

        private bool _state = false;
        #endregion

        #region Constructors
        public Bit(BinarySize size)
        {
            Size = size;
        }
        #endregion

        #region Methods

        #endregion

        #region Full Props
        public BinarySize Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged();
            }
        }

        public bool State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(BinState));
            }
        }

        public int BinState
        {
            get => _state ? 1 : 0;
        }
        #endregion
    }
}
