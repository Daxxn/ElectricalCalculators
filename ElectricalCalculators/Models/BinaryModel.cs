using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models
{
    public class BinaryModel : Model
    {
        #region Local Props
        private bool internalChange = false;
        private ObservableCollection<bool> _states = new();
        private uint _size = 0;

        private int _value = 0;
        #endregion

        #region Constructors
        public BinaryModel() { }
        #endregion

        #region Methods
        public void SetBit(uint index, bool state)
        {
            States[(int)index] = state;
            CalcValue();
        }

        private void CalcValue()
        {
            internalChange = true;
            for (int i = 0; i < Size; i++)
            {
                Value |= (1 << i) * (States[i] ? 1 : 0);
            }
            internalChange = false;
        }

        private void CalcByte()
        {
            for (int i = 0; i < Size; i++)
            {
                States[i] = ((Value >> i) & 1) == 1 ? true : false;
            }
        }

        public void ChangeSize(uint size)
        {
            if (size > Size)
            {
                var diff = size - Size;
                Size = size;
                for (int i = 0; i < diff; i++)
                {
                    States.Add(false);
                }
            }
            else
            {
                States.Clear();
                Size = size;
                for (int i = 0; i < size; i++)
                {
                    States.Add(false);
                }
            }
        }
        #endregion

        #region Full Props
        public ObservableCollection<bool> States
        {
            get => _states;
            set
            {
                _states = value;
                OnPropertyChanged();
            }
        }

        public uint Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged();
            }
        }

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                if (!internalChange)
                {
                    CalcByte();
                }
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
