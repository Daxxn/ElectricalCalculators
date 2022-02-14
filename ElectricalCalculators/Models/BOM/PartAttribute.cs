using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models.BOM
{
    public class PartAttribute : Model
    {
        #region Local Props
        private string _name = "";
        private string _rawvalue = "";
        private double _value = 0;
        private bool _isParsable = false;
        private bool _isLink = false;
        #endregion

        #region Constructors
        public PartAttribute(string name, string val)
        {
            Name = name;
            RawValue = val;
            ParseValue(val);
        }
        #endregion

        #region Methods
        private void ParseValue(string val)
        {
            if (val == null) return;
            IsParsable = double.TryParse(val, out _value);
            if (!IsParsable)
            {
                if (val.StartsWith("http"))
                {
                    IsLink = true;
                }
            }
        }

        public void SetValue(string value)
        {
            RawValue = value;
            ParseValue(value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is PartAttribute part)
            {
                return Equals(part);
            }
            return base.Equals(obj);
        }

        public bool Equals(PartAttribute? part)
        {
            if (part is null) return false;
            return part.Name == Name && part.RawValue == RawValue;
        }
        #endregion

        #region Full Props
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string RawValue
        {
            get => _rawvalue;
            set
            {
                _rawvalue = value;
                OnPropertyChanged();
            }
        }

        public double Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public bool IsParsable
        {
            get => _isParsable;
            set
            {
                _isParsable = value;
                OnPropertyChanged();
            }
        }

        public bool IsLink
        {
            get => _isLink;
            set
            {
                _isLink = value;
                OnPropertyChanged();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
