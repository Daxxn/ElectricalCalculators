using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
      private ObservableCollection<double> _resistors = new();
      //private ObservableCollection<double> _resistors = new()
      //{
      //   1d,1.1d,1.2d,1.3d,1.5d,1.6d,1.8d,2d,2.2d,2.4d,2.7d,3d,3.3d,3.6d,3.9d,4.3d,4.7d,5.1d,5.6d,6.2d,6.8d,7.5d,8.2d,9.1d,10d,
      //   11d,12d,13d,15d,16d,18d,20d,22d,24d,27d,30d,33d,36d,39d,43d,47d,51d,56d,62d,68d,75d,82d,91d,96d,100d,
      //   110d,120d,130d,150d,160d,180d,200d,220d,240d,270d,300d,330d,360d,390d,430d,470d,510d,560d,620d,680d,750d,820d,910d,1000d,
      //   1100d,1200d,1300d,1500d,1600d,1800d,2000d,2200d,2400d,2700d,3000d,3300d,3600d,3900d,4300d,4700d,5100d,5600d,6200d,6800d,7500d,8200d,9100d,10000d,
      //   11000d,12000d,13000d,14000d,15000d,16000d,18000d,20000d,22000d,24000d,27000d,30000d,33000d,36000d,39000d,43000d,47000d,51000d,56000d,62000d,68000d,75000d,82000d,91000d,100000d,
      //   110000d,120000d,130000d,140000d,150000d,160000d,180000d,200000d,220000d,240000d,270000d,300000d,330000d,360000d,390000d,430000d,470000d,510000d,560000d,620000d,680000d,750000d,820000d,910000d,1000000d,
      //   1100000d,1200000d,1300000d,1500000d,1600000d,1800000d,2000000d,2200000d,2400000d,2700000d,3000000d,3300000d,3600000d,3900000d,4300000d,4700000d,5100000d,5600000d,6200000d,6800000d,7500000d,8200000d,9100000d,10000000d,20000000d
      //};

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

      public ObservableCollection<double> Resistors
      {
         get => _resistors;
         set
         {
            _resistors = value;
            OnPropertyChanged();
         }
      }
   }
}
