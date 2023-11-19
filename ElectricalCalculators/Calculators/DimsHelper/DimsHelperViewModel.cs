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
      private double? _innerWidth = null;
      private double? _outerWidth = null;

      private double? _halfCenterWidth = null;

      private double? _padWidth = null;
      private double? _padCentersWidth = null;

      private bool _showPackage = false;

      #region Commands
      public Command ShowPackageCmd { get; init; }
      public Command CalcCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public DimsHelperViewModel()
      {
         ShowPackageCmd = new(() => ShowPackage = !ShowPackage);
         CalcCmd = new(Calc);
      }
      #endregion

      #region Methods
      public void Calc()
      {
         (InnerWidth, OuterWidth, PadWidth) = DimsCalculator.Calc(InnerWidth, OuterWidth, PadWidth);
         PadCentersWidth = DimsCalculator.CalcPadHalfCoordinate(InnerWidth, OuterWidth);
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

      public double? InnerWidth
      {
         get => _innerWidth;
         set
         {
            _innerWidth = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CenterLine));
            OnPropertyChanged(nameof(PadCentersWidth));
         }
      }

      public double? OuterWidth
      {
         get => _outerWidth;
         set
         {
            _outerWidth = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CenterLine));
            OnPropertyChanged(nameof(PadCentersWidth));
         }
      }

      public double? PadCentersWidth
      {
         get => _padCentersWidth;
         set
         {
            _padCentersWidth = value;
            OnPropertyChanged();
         }
      }

      public double? CenterLine => PadCentersWidth / 2;

      public double? PadWidth
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
