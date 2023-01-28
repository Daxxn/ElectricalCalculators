using ElectricalCalculators.Models;

using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectricalCalculators.Calculators.Radial
{
   public class RadialViewModel : ViewModel
   {
      #region Local Props
      public event EventHandler UpdateCanvas = null!;
      private RadialCollection _coll = new();
      private RadialComponent? _selectedComponent = null;

      private double _offsetX = 0;
      private double _offestY = 0;
      private double _scale = 0;

      private bool _invertSign = false;

      #region Commands
      public Command CalcCmd { get; init; }
      public Command CopyXCmd { get; init; }
      public Command CopyYCmd { get; init; }
      public Command CopyAngleCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public RadialViewModel()
      {
         CalcCmd = new(Calc);
         CopyXCmd = new(CopyX);
         CopyYCmd = new(CopyY);
         CopyAngleCmd = new(CopyAngle);
      }
      #endregion

      #region Methods
      public void Calc()
      {
         Collection.Calc(Scale, InvertSign);
         UpdateCanvas?.Invoke(this, new());
      }

      private void CopyX()
      {
         if (SelectedComponent is null)
            return;
         Clipboard.SetText($"{Math.Round(SelectedComponent.X, 6)}");
      }

      private void CopyY()
      {
         if (SelectedComponent is null)
            return;
         Clipboard.SetText($"{Math.Round(SelectedComponent.Y, 6)}");
      }

      private void CopyAngle()
      {
         if (SelectedComponent is null)
            return;
         Clipboard.SetText($"{Math.Round(SelectedComponent.Angle, 6)}");
      }
      #region Events

      #endregion
      #endregion

      #region Full Props
      public RadialCollection Collection
      {
         get => _coll;
         set
         {
            _coll = value;
            Calc();
            OnPropertyChanged();
         }
      }

      public RadialComponent? SelectedComponent
      {
         get => _selectedComponent;
         set
         {
            _selectedComponent = value;
            OnPropertyChanged();
         }
      }

      public double OffsetX
      {
         get => _offsetX;
         set
         {
            _offsetX = value;
            OnPropertyChanged();
         }
      }

      public double OffsetY
      {
         get => _offestY;
         set
         {
            _offestY = value;
            OnPropertyChanged();
         }
      }

      public double Scale
      {
         get => _scale;
         set
         {
            _scale = value;
            Calc();
            OnPropertyChanged();
         }
      }

      public bool InvertSign
      {
         get => _invertSign;
         set
         {
            _invertSign = value;
            Calc();
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
