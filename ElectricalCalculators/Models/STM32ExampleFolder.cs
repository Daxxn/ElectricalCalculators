using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace ElectricalCalculators.Models
{
   public class STM32ExampleFolder : Model
   {
      #region Local Props
      private DirectoryInfo _folder;
      private string _name;
      private string _version;
      #endregion

      #region Constructors
      public STM32ExampleFolder() { }
      #endregion

      #region Methods

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

      public string Version
      {
         get => _version;
         set
         {
            _version = value;
            OnPropertyChanged();
         }
      }

      public DirectoryInfo Folder
      {
         get => _folder;
         set
         {
            _folder = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
