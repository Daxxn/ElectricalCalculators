using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using MVVMLibrary;

namespace ElectricalCalculators.Calculators.STM32;
public class STM32SdramConfigViewModelViewModel : ViewModel
{
   #region Local Props
   private const decimal NanoSecConv = 0.000000001m;
   private double _fmcClock = 100000000;

   private decimal _tmrd = 0;
   private decimal _txsr = 0;
   private decimal _tras = 0;
   private decimal _trc = 0;
   private decimal _trp = 0;
   private decimal _trcd = 0;

   private int _loadRegDelay = 0;
   private int _exitRefreshDelay = 0;
   private int _selfrefreshTime = 0;
   private int _rowCycleDelay = 0;
   private int _writeRecoveryTime = 0;
   private int _rowPrechargeDelay = 0;
   private int _rowToColDelay = 0;

   #region Commands
   public Command CalcCmd { get; init; }
   public Command CopyValueCmd { get; init; }
   #endregion
   #endregion

   #region Constructors
   public STM32SdramConfigViewModelViewModel()
   {
      CalcCmd = new(Calc);
      CopyValueCmd = new(CopyValue);
   }
   #endregion

   #region Methods
   private void Calc()
   {
      if (FMCClock == 0) return;

      if (TMRD == 0 || TXSR == 0 || TRAS == 0 || TRC == 0 || TRP == 0 || TRCD == 0) return;

      LoadRegDelay = (int)Math.Ceiling((TMRD * NanoSecConv) / (decimal)ClockInterval);
      ExitRefreshDelay = (int)Math.Ceiling((TXSR * NanoSecConv) / (decimal)ClockInterval);
      SelfRefreshTime = (int)Math.Ceiling((TRAS * NanoSecConv) / (decimal)ClockInterval);
      RowCycleDelay = (int)Math.Ceiling((TRC * NanoSecConv) / (decimal)ClockInterval);
      RowPrechargeDelay = (int)Math.Ceiling((TRP * NanoSecConv) / (decimal)ClockInterval);
      RowToColDelay = (int)Math.Ceiling((TRCD * NanoSecConv) / (decimal)ClockInterval);

      WriteRecoveryTime = SelfRefreshTime - RowToColDelay;
   }

   private void CopyValue(object param)
   {
      if (param is int val)
      {
         Clipboard.SetText(val.ToString());
      }
   }
   #region Events

   #endregion
   #endregion

   #region Full Props
   public double FMCClock
   {
      get => _fmcClock;
      set
      {
         _fmcClock = value;
         OnPropertyChanged();
         OnPropertyChanged(nameof(ClockInterval));
      }
   }

   public double ClockInterval => 1 / FMCClock;
   //public double ClockInterval => (1 / FMCClock) * Math.Pow(10, 9);

   public decimal TMRD
   {
      get => _tmrd;
      set
      {
         _tmrd = value;
         OnPropertyChanged();
      }
   }

   public decimal TXSR
   {
      get => _txsr;
      set
      {
         _txsr = value;
         OnPropertyChanged();
      }
   }

   public decimal TRAS
   {
      get => _tras;
      set
      {
         _tras = value;
         OnPropertyChanged();
      }
   }

   public decimal TRC
   {
      get => _trc;
      set
      {
         _trc = value;
         OnPropertyChanged();
      }
   }

   public decimal TRP
   {
      get => _trp;
      set
      {
         _trp = value;
         OnPropertyChanged();
      }
   }

   public decimal TRCD
   {
      get => _trcd;
      set
      {
         _trcd = value;
         OnPropertyChanged();
      }
   }

   public int LoadRegDelay
   {
      get => _loadRegDelay;
      set
      {
         _loadRegDelay = value;
         OnPropertyChanged();
      }
   }

   public int ExitRefreshDelay
   {
      get => _exitRefreshDelay;
      set
      {
         _exitRefreshDelay = value;
         OnPropertyChanged();
      }
   }

   public int SelfRefreshTime
   {
      get => _selfrefreshTime;
      set
      {
         _selfrefreshTime = value;
         OnPropertyChanged();
      }
   }

   public int RowCycleDelay
   {
      get => _rowCycleDelay;
      set
      {
         _rowCycleDelay = value;
         OnPropertyChanged();
      }
   }

   public int WriteRecoveryTime
   {
      get => _writeRecoveryTime;
      set
      {
         _writeRecoveryTime = value;
         OnPropertyChanged();
         OnPropertyChanged(nameof(WriteRecoveryTimeError));
      }
   }

   public int RowPrechargeDelay
   {
      get => _rowPrechargeDelay;
      set
      {
         _rowPrechargeDelay = value;
         OnPropertyChanged();
      }
   }

   public int RowToColDelay
   {
      get => _rowToColDelay;
      set
      {
         _rowToColDelay = value;
         OnPropertyChanged();
      }
   }

   public Visibility WriteRecoveryTimeError
   {
      get
      {
         if (SelfRefreshTime == 0 && RowToColDelay == 0) return Visibility.Hidden;

         return WriteRecoveryTime >= SelfRefreshTime - RowToColDelay
            && WriteRecoveryTime >= RowCycleDelay - RowToColDelay - RowPrechargeDelay ? Visibility.Hidden : Visibility.Visible;
      }
   }
   #endregion
}
