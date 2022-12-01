using ElectricalCalculators.Calculators.Models.MaxFreq;
using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.MaxFreq
{
   public class MaxFreqViewModel : ViewModel
   {
      #region Local Props
      private double? _riseTimeInput = null;

      private double _dialectricOuter = 4.6;
      private double _dialectricInner = 3.4;

      private double? _riseTimeResult = null;
      private double? _freqMaxResult = null;
      private double? _innerCriticaLengthResult = null;
      private double? _outerCriticaLengthResult = null;

      #region Commands
      public Command CalcCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public MaxFreqViewModel()
      {
         CalcCmd = new(Calc);
      }
      #endregion

      #region Methods
      private void Calc()
      {
         if (RiseFallTimeInput is null) return;
         RiseFallTimeResult = MaxFreqCalc.CalcFullRiseFallTime((double)RiseFallTimeInput);
         FreqMaxResult = MaxFreqCalc.Calc((double)RiseFallTimeInput);
         InnerCriticalLengthResult = MaxFreqCalc.CalcCriticalLength((double)RiseFallTimeResult, DialectricInner);
         OuterCriticalLengthResult = MaxFreqCalc.CalcCriticalLength((double)RiseFallTimeResult, DialectricOuter);
      }
      #endregion

      #region Full Props
      public double? RiseFallTimeInput
      {
         get => _riseTimeInput;
         set
         {
            _riseTimeInput = value;
            Calc();
            OnPropertyChanged();
            OnPropertyChanged(nameof(RiseFallTimeResult));
            OnPropertyChanged(nameof(FreqMaxResult));
            OnPropertyChanged(nameof(InnerCriticalLengthResult));
            OnPropertyChanged(nameof(OuterCriticalLengthResult));
         }
      }

      public double? RiseFallTimeResult
      {
         get => _riseTimeResult;
         set
         {
            _riseTimeResult = value;
            OnPropertyChanged();
         }
      }

      public double DialectricOuter
      {
         get => _dialectricOuter;
         set
         {
            _dialectricOuter = value;
            OnPropertyChanged();
         }
      }

      public double DialectricInner
      {
         get => _dialectricInner;
         set
         {
            _dialectricInner = value;
            OnPropertyChanged();
         }
      }

      public double? FreqMaxResult
      {
         get => _freqMaxResult;
         set
         {
            _freqMaxResult = value;
            OnPropertyChanged();
         }
      }

      public double? InnerCriticalLengthResult
      {
         get => _innerCriticaLengthResult;
         set
         {
            _innerCriticaLengthResult = value;
            OnPropertyChanged();
         }
      }

      public double? OuterCriticalLengthResult
      {
         get => _outerCriticaLengthResult;
         set
         {
            _outerCriticaLengthResult = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
