using ElectricalCalculators.Models.BOM;
using Microsoft.Win32;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectricalCalculators.Calculators.BomReader
{
    public class BomReaderViewModel : ViewModel
    {
        #region Local Props
        private string _filePath = "";

        private BomModel? _bom = new();
        private CSVParser _parser = new(new string[] {";"}, new string[] { "\n", "\r\n"});

        private Part? _selectedPart = null;
        private PartAttribute? _selectedAttr = null;

        #region Commands
        public Command OpenFileCmd { get; init; }
        #endregion
        #endregion

        #region Constructors
        public BomReaderViewModel()
        {
            OpenFileCmd = new Command(OpenFile);
        }
        #endregion

        #region Methods
        private void OpenFile()
        {
            try
            {
                OpenFileDialog dialog = new()
                {
                    Title = "Open BOM",
                    DefaultExt = ".csv",
                    Filter = "csv|*.csv|all files|*.*"
                };
                if (dialog.ShowDialog() == true)
                {
                    FilePath = dialog.FileName;
                    BOM = Parser.Parse(dialog.FileName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void SelectedPartChanged(Part part)
        {
            SelectedPart = part;
        }

        public void SelectedAttrChanged(PartAttribute attr)
        {
            SelectedAttr = attr;
        }
        #endregion

        #region Full Props
        public BomModel? BOM
        {
            get => _bom;
            set
            {
                _bom = value;
                OnPropertyChanged();
            }
        }

        public CSVParser Parser
        {
            get => _parser;
            set
            {
                _parser = value;
                OnPropertyChanged();
            }
        }

        public Part? SelectedPart
        {
            get => _selectedPart;
            set
            {
                _selectedPart = value;
                OnPropertyChanged();
            }
        }

        public PartAttribute? SelectedAttr
        {
            get => _selectedAttr;
            set
            {
                _selectedAttr = value;
                OnPropertyChanged();
            }
        }

        public string FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FileName));
            }
        }

        public string FileName
        {
            get
            {
                if (FilePath is not null)
                {
                    if (File.Exists(FilePath))
                    {
                        return Path.GetFileNameWithoutExtension(FilePath);
                    }
                }
                return "";
            }
        }
        #endregion
    }
}
