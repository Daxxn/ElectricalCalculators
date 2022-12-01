using ElectricalCalculators.Models;
using ElectricalCalculators.Models.Binary;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.Binary
{
    public class BinaryViewModel : ViewModel
    {
        #region Local Props
        public event EventHandler<uint> BinarySizeChanged;

        private BinarySize _size = BinarySize.Byte;
        private uint _selectedSize = 8;

        private BinaryModel _binary = new();
        #region Commands

        #endregion
        #endregion

        #region Constructors
        public BinaryViewModel()
        {
            BinarySizeChanged += BinarySizeChangedEvent;

            Binary.ChangeSize(SelectedSize);
        }
        #endregion

        #region Methods
        public void BinaryChange(uint index, bool state)
        {
            Binary.SetBit(index, state);
        }

        private void BinarySizeChangedEvent(object? sender, uint e)
        {
            Binary.ChangeSize(e);
        }
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

        public uint SelectedSize
        {
            get => _selectedSize;
            set
            {
                _selectedSize = value;
                OnPropertyChanged();
                BinarySizeChanged?.Invoke(this, value);
            }
        }

        public BinaryModel Binary
        {
            get => _binary;
            set
            {
                _binary = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
