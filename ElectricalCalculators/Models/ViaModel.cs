using MVVMLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models.Vias;

public class ViaModel : Model
{
   #region Local Props
   private double _drillSize = 0;
   private double _padSize = 0;
   private double _annularRing = 0;
   #endregion

   #region Constructors
   public ViaModel() { }
   #endregion

   #region Methods
   public void CalcAnnularRing() => AnnularRing = (PadSize - DrillSize) / 2;
   public void CalcDrillSize() => DrillSize = PadSize - AnnularRing * 2;
   public void CalcPadSize() => PadSize = AnnularRing * 2 + DrillSize;

   public bool Check() => DrillSize > 0 && PadSize > DrillSize;

   public override string ToString() => $"Ar: {AnnularRing} Dr: {DrillSize} Pa: {PadSize}";
   #endregion

   #region Full Props
   public double DrillSize
   {
      get => _drillSize;
      set
      {
         _drillSize = value;
         OnPropertyChanged();
         OnPropertyChanged(nameof(DrillOk));
      }
   }

   public double PadSize
   {
      get => _padSize;
      set
      {
         _padSize = value;
         OnPropertyChanged();
         OnPropertyChanged(nameof(DrillOk));
      }
   }

   public double AnnularRing
   {
      get => _annularRing;
      set
      {
         _annularRing = value;
         OnPropertyChanged();
         OnPropertyChanged(nameof(DrillOk));
      }
   }

   public bool DrillOk => Check();
   #endregion
}