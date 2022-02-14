using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models
{
    public class ByteModel : Model
    {
        #region Local Props
        private ObservableCollection<Bit> _bytes = new();
        #endregion

        #region Constructors
        public ByteModel() { }
        #endregion

        #region Methods

        #endregion

        #region Full Props
        public ObservableCollection<Bit> Bytes
        {
            get => _bytes;
            set
            {
                _bytes = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
