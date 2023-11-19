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
      public static MainViewModel MainVM { get; private set; } = new();
      public static SuffixModelManager SuffixManager = new();

      protected override void OnStartup(StartupEventArgs e)
      {
         try
         {
            MainVM.OnStartup();
            SuffixManager.OnStartup(nameof(ElectricalCalculators));
         }
         catch (Exception ex)
         {
            MessageBox.Show($"unable to load Suffix data: {ex.Message}");
         }
         base.OnStartup(e);
      }

      protected override void OnExit(ExitEventArgs e)
      {
         try
         {
            MainVM.OnExit();
            SuffixManager.OnExit(nameof(ElectricalCalculators));
         }
         catch (Exception ex)
         {
            MessageBox.Show($"unable to save Suffix data: {ex.Message}");
         }
         base.OnExit(e);
      }
   }
}
