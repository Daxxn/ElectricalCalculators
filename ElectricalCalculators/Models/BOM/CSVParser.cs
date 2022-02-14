using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models.BOM
{
    public class CSVParser : Model
    {
        #region Local Props
        private string[] _attrDelimiters;
        private string[] _lineDelimiters;
        #endregion

        #region Constructors
        public CSVParser(string[] attrDelimiters, string[] lineDelimiters)
        {
            AttrDelimiters = attrDelimiters;
            LineDelimiters = lineDelimiters;
        }
        #endregion

        #region Methods
        public BomModel? Parse(string path)
        {
            try
            {
                using StreamReader reader = new(path);
                BomModel model = new BomModel();
                string? attrNames = reader.ReadLine();
                if (attrNames == null) return null;
                var names = CleanLine(attrNames.Split(AttrDelimiters, StringSplitOptions.RemoveEmptyEntries));
                var values = ParseLines(reader.ReadToEnd());
                foreach (var partArr in values)
                {
                    var part = new Part();
                    for (int i = 0; i < names.Length; i++)
                    {
                        part.AddAttribute(names[i], partArr[i]);
                    }
                    model.Add(part);
                }
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string[][] ParseLines(string data)
        {
            List<string[]> output = new();
            var lines = data.Split(LineDelimiters, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var l = line;
                output.Add(CleanLine(l.Split(AttrDelimiters, StringSplitOptions.RemoveEmptyEntries)));
            }
            return output.ToArray();
        }

        private static string[] CleanLine(string[] values)
        {
            var output = new string[values.Length];
            for (int i = 0;i < values.Length;i++)
            {
                output[i] = values[i].Trim('"');
            }
            return output;
        }
        #endregion

        #region Full Props
        public string[] AttrDelimiters
        {
            get => _attrDelimiters;
            set
            {
                _attrDelimiters = value;
                OnPropertyChanged();
            }
        }

        public string[] LineDelimiters
        {
            get => _lineDelimiters;
            set
            {
                _lineDelimiters = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
