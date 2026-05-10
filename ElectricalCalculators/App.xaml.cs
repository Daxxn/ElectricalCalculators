using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using ElectricalCalculators.Utils;

using ElectricalSuffixParser.Models;

using SettingsLibrary;

namespace ElectricalCalculators
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      public static SettingsModel Settings { get; set; } = new();
      public static MainViewModel MainVM { get; private set; } = new();
      public static SuffixModelManager SuffixManager = new();

      protected override void OnStartup(StartupEventArgs e)
      {
         try
         {
            Settings = SettingsManager.OnStartup<SettingsModel>(nameof(ElectricalCalculators));
            MainVM.OnStartup();
            SuffixManager.OnStartup(nameof(ElectricalCalculators));
         }
         catch (Exception ex)
         {
            MessageBox.Show($"unable to start cleanly: {ex.Message}");
         }
         base.OnStartup(e);
      }

      protected override void OnExit(ExitEventArgs e)
      {
         try
         {
            MainVM.OnExit();
            SuffixManager.OnExit(nameof(ElectricalCalculators));
            SettingsManager.OnExit(Settings, nameof(ElectricalCalculators));
         }
         catch (Exception ex)
         {
            MessageBox.Show($"unable to exit cleanly: {ex.Message}");
         }
         base.OnExit(e);
      }
   }
}
