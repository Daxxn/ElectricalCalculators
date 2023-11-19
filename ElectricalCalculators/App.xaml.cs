using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using ElectricalSuffixParser.Models;

namespace ElectricalCalculators
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      public static SuffixModelManager SuffixManager = new();

      protected override void OnStartup(StartupEventArgs e)
      {
         try
         {
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
