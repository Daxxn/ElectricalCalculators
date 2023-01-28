using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectricalCalculators.Calculators.Radial;

/// <summary>
/// Interaction logic for RadialView.xaml
/// </summary>
public partial class RadialView : UserControl
{
   public RadialViewModel VM { get; set; }
   public RadialView()
   {
      VM = new();
      DataContext = VM;
      InitializeComponent();
      VM.UpdateCanvas += VM_UpdateCanvas;
   }

   private void VM_UpdateCanvas(object? sender, EventArgs e)
   {
      RadialViewCanvas.Children.Clear();
      foreach (var item in VM.Collection.Components)
      {
         var rect = new Ellipse
         {
            RenderTransform = new TranslateTransform(item.ScaledX + VM.OffsetX, item.ScaledY + VM.OffsetY),
            //RenderTransform = new RotateTransform(item.Angle),
            Width = 10, Height = 10,
            Fill = new SolidColorBrush(Color.FromRgb(20,100,255)),
         };
         RadialViewCanvas.Children.Add(rect);
      }
   }

   private void TextBox_TextChanged(object sender, TextChangedEventArgs e) => VM.Calc();

   private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => VM_UpdateCanvas(sender, e);
}
