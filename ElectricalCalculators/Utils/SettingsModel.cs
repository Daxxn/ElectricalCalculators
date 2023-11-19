using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using SettingsLibrary.Models;

namespace ElectricalCalculators.Utils
{
   public class SettingsModel : Model, ISettingsModel
   {
      private int _tabindex = 0;

      public string SavePath { get; set; }
      public string LastSavePath { get; set; }

      public int TabIndex
      {
         get => _tabindex;
         set
         {
            _tabindex = value;
            OnPropertyChanged();
         }
      }
   }
}
