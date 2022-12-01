using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models.BOM
{
    public class BomModel : Model
    {
        #region Local Props
        private ObservableCollection<Part> _parts = new();
        #endregion

        #region Constructors
        public BomModel() { }
        #endregion

        #region Methods
        public void Add(Part part)
        {
            _parts.Add(part);
        }

        public void Remove(Part part)
        {
            _parts.Remove(part);
        }

        public void Clear()
        {
            _parts.Clear();
        }
        #endregion

        #region Full Props
        public ObservableCollection<Part> Parts
        {
            get => _parts;
            set
            {
                _parts = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
