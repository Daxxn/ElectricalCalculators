using ElectricalCalculators.Models;
using ElectricalCalculators.Models.Vias;

using MVVMLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.Vias
{
   public class ViasViewModel : ViewModel
   {
      #region Local Props
      private ViaCollection _viaList = new();
      private SizeType _sizeTypeSelection = SizeType.Drill;
      private double _annularRing = 0.13;
      private double _drill = 0;
      private double _pad = 0.2;
      private double _iterate = 0.1;
      private SizeType _iterateType = SizeType.Pad;
      #region Commands
      public Command CalcCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public ViasViewModel()
      {
         CalcCmd = new(Calc);
         ViaList.Calc(SizeTypeSelection, AnnularRing, Drill, Pad, Iterator, IterateType);
      }
      #endregion

      #region Methods
      private void Calc()
      {
         if (AnnularRing == 0 && Drill == 0 && Pad == 0)
            return;
         ViaList.Calc(SizeTypeSelection, AnnularRing, Drill, Pad, Iterator, IterateType);
      }
      #region Events

      #endregion
      #endregion

      #region Full Props
      public ViaCollection ViaList
      {
         get => _viaList;
         set
         {
            _viaList = value;
            OnPropertyChanged();
         }
      }

      public SizeType SizeTypeSelection
      {
         get => _sizeTypeSelection;
         set
         {
            _sizeTypeSelection = value;
            OnPropertyChanged();
         }
      }

      public double AnnularRing
      {
         get => _annularRing;
         set
         {
            _annularRing = value;
            OnPropertyChanged();
         }
      }

      public double Drill
      {
         get => _drill;
         set
         {
            _drill = value;
            OnPropertyChanged();
         }
      }

      public double Pad
      {
         get => _pad;
         set
         {
            _pad = value;
            OnPropertyChanged();
         }
      }

      public double Iterator
      {
         get => _iterate;
         set
         {
            _iterate = value;
            OnPropertyChanged();
         }
      }

      public SizeType IterateType
      {
         get => _iterateType;
         set
         {
            _iterateType = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
