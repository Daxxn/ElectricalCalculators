using ElectricalCalculators.Models;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.DimsHelper
{
   public class DimsHelperViewModel : ViewModel
   {
      #region Local Props
      private double _innerWidth = 0;
      private double _outerWidth = 0;

      private double _halfCenterWidth = 0;

      private double _padWidth = 0;

      private bool _showPackage = false;

      #region Commands
      public Command ShowPackageCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public DimsHelperViewModel()
      {
         ShowPackageCmd = new(() => ShowPackage = !ShowPackage);
      }
      #endregion

      #region Methods
      private void Calc()
      {
         if (InnerWidth == 0 || OuterWidth == 0) return;

         PadWidth = DimsCalculator.CalcPadSize(InnerWidth, OuterWidth);
         HalfCenterWidth = DimsCalculator.CalcPadHalfCoordinate(InnerWidth, PadWidth);
      }
      #endregion

      #region Full Props
      public bool ShowPackage
      {
         get => _showPackage;
         set
         {
            _showPackage = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ShowPackageText));
         }
      }

      public string ShowPackageText
      {
         get => !ShowPackage ? "Show Pkg" : "Hide Pkg";
      }

      public double InnerWidth
      {
         get => _innerWidth;
         set
         {
            _innerWidth = value;
            Calc();
            OnPropertyChanged();
         }
      }

      public double OuterWidth
      {
         get => _outerWidth;
         set
         {
            _outerWidth = value;
            Calc();
            OnPropertyChanged();
         }
      }

      public double CenterWidth
      {
         get => _halfCenterWidth * 2;
      }

      public double HalfCenterWidth
      {
         get => _halfCenterWidth;
         set
         {
            _halfCenterWidth = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CenterWidth));
         }
      }

      public double PadWidth
      {
         get => _padWidth;
         set
         {
            _padWidth = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
