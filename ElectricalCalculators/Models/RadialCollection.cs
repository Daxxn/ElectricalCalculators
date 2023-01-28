using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace ElectricalCalculators.Models
{
    public class RadialCollection : Model
   {
      #region Local Props
      private ObservableCollection<RadialComponent> _components = new();
      private double _distance = 0;
      private double _angularDiff = 0;
      private int _count = 0;
      #endregion

      #region Constructors
      public RadialCollection() { }
      #endregion

      #region Methods
      public void Calc(double scale, bool invertSign)
      {
         if (Count <= 0) return;
         if (Distance <= 0) return;

         Components.Clear();
         AngularDifference = 360 / (double)Count;
         for (int i = 0; i < Count; i++)
         {
            Components.Add(new RadialComponent(i, AngularDifference * i, Distance, scale, invertSign));
         }
      }
      #endregion

      #region Full Props
      public ObservableCollection<RadialComponent> Components
      {
         get => _components;
         set
         {
            _components = value;
            OnPropertyChanged();
         }
      }

      public double Distance
      {
         get => _distance;
         set
         {
            _distance = value;
            OnPropertyChanged();
         }
      }

      public double AngularDifference
      {
         get => _angularDiff;
         set
         {
            _angularDiff = value;
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
}
