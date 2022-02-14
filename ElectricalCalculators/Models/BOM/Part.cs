using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models.BOM
{
    public class Part : Model
    {
        #region Local Props
        private ObservableCollection<PartAttribute> _attributes = new();
        private int _count = 1;
        private string? _link;
        #endregion

        #region Constructors
        public Part() { }
        #endregion

        #region Methods
        public void AddAttribute(string name, string val)
        {
            var attr = new PartAttribute(name, val);
            Attributes.Add(attr);
        }

        public void RemoveAttribute(string name)
        {
            var attr = Attributes.FirstOrDefault((p) => p.Name == name);
            if (attr is null) return;
            Attributes.Remove(attr);
        }

        public void SetAttribute(string name, string value)
        {
            var attr = GetAttribute(name);
            if (attr is not null)
            {
                attr.SetValue(value);
            }
            else
            {
                Attributes.Add(new PartAttribute(name, value));
            }
        }

        public PartAttribute? GetAttribute(string? name, string? value = null)
        {
            foreach (var attr in Attributes)
            {
                if (attr.Name == name)
                {
                    if (value is not null)
                    {
                        if (value == attr.RawValue)
                        {
                            return attr;
                        }
                    }
                    return attr;
                }
            }
            return null;
        }

        public bool HasAttribute(string? name)
        {
            if (name is not null)
            {
                foreach (var attr in Attributes)
                {
                    if (attr.Name == name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool EqualsAttribute(string? name, string? value)
        {
            if (value is null) return false;
            if (name is not null)
            {
                foreach (var attr in Attributes)
                {
                    if (attr.Name == name)
                    {
                        if (attr.RawValue == value)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion

        #region Full Props
        public ObservableCollection<PartAttribute> Attributes
        {
            get => _attributes;
            set
            {
                _attributes = value;
                OnPropertyChanged();
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }

        public string? Link
        {
            get => _link;
            set
            {
                _link = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
