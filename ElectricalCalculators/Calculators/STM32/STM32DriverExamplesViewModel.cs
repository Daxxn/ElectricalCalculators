using ElectricalCalculators.Models;
using ElectricalCalculators.Utils;

using Microsoft.Win32;

using MVVMLibrary;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectricalCalculators.Calculators.STM32
{
   public class STM32DriverExamplesViewModel : ViewModel
   {
      #region Local Props
      private SettingsModel _settings;

      private ObservableCollection<STM32ExampleFolder> _exampleFolders = [];
      #region Commands
      public Command UpdateRootFolderCmd { get; init; }
      public Command OpenRootFolderCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public STM32DriverExamplesViewModel()
      {
         _settings = App.Settings;
         UpdateRootFolderCmd = new Command(UpdateRootFolder);
         OpenRootFolderCmd = new Command(OpenRootFolder);

         try
         {
            FindDriverFolders();
         }
         catch (Exception e)
         {
            MessageBox.Show(e.Message);
         }
      }
      #endregion

      #region Methods
      private void UpdateRootFolder()
      {
         OpenFolderDialog dialog = new()
         {
            Title = "Select STM32 Examples Root Folder",
            Multiselect = false,
         };

         if (dialog.ShowDialog() == true)
         {
            _settings.STM32DriverExamplesRootFolder = dialog.FolderName;
            FindDriverFolders();
         }
      }

      private void OpenRootFolder()
      {
         try
         {
            ProcessStartInfo startInfo = new()
            {
               FileName = "Explorer.exe",
               Arguments = _settings.STM32DriverExamplesRootFolder,
            };
            Process.Start(startInfo);
         }
         catch (Exception e)
         {
            MessageBox.Show($"Failed to open root folder, {e.Message}", "ERROR");
            throw;
         }
      }

      #region Events
      private void FindDriverFolders()
      {
         if (Directory.Exists(_settings?.STM32DriverExamplesRootFolder))
         {
            if (!string.IsNullOrEmpty(_settings.STM32ExampleFolderSearchPattern))
            {
               ExampleFolders.Clear();
               var folders = Directory.GetDirectories(_settings.STM32DriverExamplesRootFolder, _settings.STM32ExampleFolderSearchPattern);
               var replaceString = _settings.STM32ExampleFolderSearchPattern.Replace("*", "");
               var latestFolders = GetLatestFolders(folders, replaceString);

               foreach (var folder in latestFolders)
               {
                  var tempName = Path.GetFileName(folder).Replace(replaceString, "");
                  var tempSplit = tempName.Split('_', StringSplitOptions.RemoveEmptyEntries);

                  if (tempSplit.Length > 1)
                  {
                     ExampleFolders.Add(new()
                     {
                        Folder = new(folder),
                        Name = $"STM32{tempSplit[0]}",
                        Version = tempSplit[^1],
                     });
                  }
                  else
                  {
                     throw new Exception("Unable to read the example folders. ST may have changed their naming structure.");
                  }
               }
            }
            else
            {
               throw new Exception("The STM32 examples folder search pattern is missing.");
            }
         }
         else
         {
            throw new DirectoryNotFoundException("The STM32 examples folder doesn't exist.");
         }
      }

      public void OpenFolderEvent(STM32ExampleFolder example)
      {
         try
         {
            if (example.Folder.Exists)
            {
               ProcessStartInfo startInfo = new()
               {
                  FileName = "Explorer.exe",
                  Arguments = _settings.STM32ExampleOpenWithFolderExtension ? Path.Combine(example.Folder.FullName, _settings.STM32ExampleOpenFolderExtension) : example.Folder.FullName,
               };
               Process.Start(startInfo);
            }
         }
         catch (Exception e)
         {
            MessageBox.Show($"Unable to open example folder. {e.Message}", "ERROR");
            throw;
         }
      }
      #endregion

      private List<string> GetLatestFolders(string[] folders, string replaceString)
      {
         List<string> output = [];
         Dictionary<string, List<string>> exampleFolders = [];

         foreach (var folder in folders)
         {
            var tempName = Path.GetFileName(folder).Replace(replaceString, string.Empty);
            var tempSplit = tempName.Split("_", StringSplitOptions.RemoveEmptyEntries);
            if (exampleFolders.ContainsKey(tempSplit[0]))
            {
               exampleFolders[tempSplit[0]].Add(folder);
            }
            else
            {
               exampleFolders.Add(tempSplit[0], [folder]);
            }
         }

         foreach (var item in exampleFolders)
         {
            string exampleFolder = "";
            int versionNumber = -1;
            foreach (var versionFolder in item.Value)
            {
               var version = ParseVersionString(Path.GetFileName(versionFolder));
               if (version > versionNumber)
               {
                  exampleFolder = versionFolder;
                  versionNumber = version;
               }
            }

            output.Add(exampleFolder);
         }

         return output;
      }

      private int ParseVersionString(string folderName)
      {
         var split = folderName.Split('_', StringSplitOptions.RemoveEmptyEntries);
         if (split.Length > 1)
         {
            var versionString = split[^1];
            if (int.TryParse(versionString[1..].Replace(".", ""), out int versionNumber))
            {
               return versionNumber;
            }
         }
         return -1;
      }
      #endregion

      #region Full Props
      public ObservableCollection<STM32ExampleFolder> ExampleFolders
      {
         get => _exampleFolders;
         set
         {
            _exampleFolders = value;
            OnPropertyChanged();
         }
      }

      public SettingsModel Settings => _settings;
      public string RootFolderName => Path.GetFileName(Settings.STM32DriverExamplesRootFolder);
      #endregion
   }
}
