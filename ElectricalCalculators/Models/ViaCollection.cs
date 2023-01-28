using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace ElectricalCalculators.Models.Vias;

public enum SizeType
{
   Drill,
   Pad,
   AnnularRing
}

public class ViaCollection : Model, IList<ViaModel>
{
   #region Local Props
   private ObservableCollection<ViaModel> _vias = new();
   public ViaModel this[int index] { get => _vias[index]; set => _vias[index] = value; }
   public int _count = 5;
   public bool IsReadOnly => false;
   #endregion

   #region Constructors
   public ViaCollection() { }
   #endregion

   #region Methods
   public void Init()
   {
      Calc(SizeType.Drill, 0.13, 0, 0.2, 0.1, SizeType.Drill);
   }
   public void Calc(SizeType calcType, double annularRing, double drill, double pad, double iterator, SizeType IterateType)
   {
      if (Count <= 0)
         return;
      Vias.Clear();
      double iter = 0;
      switch (IterateType)
      {
         case SizeType.Drill:
            for (int i = 0; i < Count; i++)
            {
               ViaModel newVia = new()
               {
                  AnnularRing = annularRing,
                  DrillSize = drill + iter,
                  PadSize = pad,
               };
               Vias.Add(newVia);
               iter += iterator;
            }
            break;
         case SizeType.Pad:
            for (int i = 0; i < Count; i++)
            {
               ViaModel newVia = new()
               {
                  AnnularRing = annularRing,
                  DrillSize = drill,
                  PadSize = pad + iter,
               };
               Vias.Add(newVia);
               iter += iterator;
            }
            break;
         case SizeType.AnnularRing:
            for (int i = 0; i < Count; i++)
            {
               ViaModel newVia = new()
               {
                  AnnularRing = annularRing + iter,
                  DrillSize = drill,
                  PadSize = pad,
               };
               Vias.Add(newVia);
               iter += iterator;
            }
            break;
         default:
            break;
      }
      switch (calcType)
      {
         case SizeType.Drill:
            CalcDrillSizes();
            break;
         case SizeType.Pad:
            CalcPadSizes();
            break;
         case SizeType.AnnularRing:
            CalcAnnularRings();
            break;
         default:
            return;
      }
   }

   private void CalcAnnularRings()
   {
      foreach (var via in Vias)
      {
         via.CalcAnnularRing();
      }
   }

   private void CalcPadSizes()
   {
      foreach (var via in Vias)
      {
         via.CalcPadSize();
      }
   }

   private void CalcDrillSizes()
   {
      foreach (var via in Vias)
      {
         via.CalcDrillSize();
      }
   }

   public void Add(ViaModel item) => _vias.Add(item);
   public void Add(double drill) => _vias.Add(new() { DrillSize = drill });
   public void Clear() => _vias.Clear();
   public bool Contains(ViaModel item) => _vias.Contains(item);
   public void CopyTo(ViaModel[] array, int arrayIndex) => _vias.CopyTo(array, arrayIndex);
   public int IndexOf(ViaModel item) => _vias.IndexOf(item);
   public void Insert(int index, ViaModel item) => _vias.Insert(index, item);
   public bool Remove(ViaModel item) => _vias.Remove(item);
   public void RemoveAt(int index) => _vias.RemoveAt(index);

   public IEnumerator<ViaModel> GetEnumerator() => _vias.GetEnumerator();
   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   #endregion

   #region Full Props
   public ObservableCollection<ViaModel> Vias
   {
      get => _vias;
      set
      {
         _vias = value;
         OnPropertyChanged();
      }
   }

   public int Count
   {
      get => _count;
      set
      {
         _count = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
