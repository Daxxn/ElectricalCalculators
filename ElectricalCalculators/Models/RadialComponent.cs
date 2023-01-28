using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace ElectricalCalculators.Models;

 public class RadialComponent : Model
{
   #region Local Props
   private double _angle = 0;
   private double _x = 0;
   private double _y = 0;
   private double _scale = 0;
   private int _index = 0;
   #endregion

   #region Constructors
   public RadialComponent(int index, double angle, double distance, double scale, bool invertSign)
   {
      Index = index + 1;
      Angle = angle;
      _scale = scale;
      var tempX = distance * Math.Sin(Math.PI * 2 * angle / 360);
      var tempY = distance * Math.Cos(Math.PI * 2 * angle / 360);
      X = invertSign ? -tempX : tempX;
      Y = invertSign ? -tempY : tempY;
   }
   #endregion

   #region Methods
   #endregion

   #region Full Props
   public int Index
   {
      get => _index;
      set
      {
         _index = value;
         OnPropertyChanged();
      }
   }

   public double Angle
   {
      get => _angle;
      set
      {
         _angle = value;
         OnPropertyChanged();
      }
   }

   public double X
   {
      get => _x;
      set
      {
         _x = value;
         OnPropertyChanged();
         OnPropertyChanged(nameof(ScaledX));
      }
   }

   public double Y
   {
      get => _y;
      set
      {
         _y = value;
         OnPropertyChanged();
         OnPropertyChanged(nameof(ScaledY));
      }
   }

   public double ScaledX => _scale * Math.Sin(Math.PI * 2 * Angle / 360);

   public double ScaledY => _scale * Math.Cos(Math.PI * 2 * Angle / 360);
   #endregion
}
