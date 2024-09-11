using MVVMLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectricalCalculators.Calculators.STM32;

public enum InputType
{
   Prescalar,
   Period,
   Timer,
   Clock
}

public class STM32ClockViewModel : ViewModel
{
   #region Local Props
   private bool _updateAllowed = false;
   private uint _prescalar = 0;
   private uint _period = 0;
   private double _clockFreq = 0;

   public InputType PreviousInput { get; set; }

   private double _timerFreq = 0;
   private double _timerInterval = 0;
   #region Commands
   public Command CalcCmd { get; init; }
   public Command ClearCmd { get; init; }
   #endregion
   #endregion

   #region Constructors
   public STM32ClockViewModel()
   {
      CalcCmd = new(Calc);
      ClearCmd = new(Clear);
   }
   #endregion

   #region Methods
   private void Calc()
   {
      if (ClockFrequency == 0)
      {
         MessageBox.Show("A clock frequency is required.");
         return;
      }
      switch (PreviousInput)
      {
         case InputType.Prescalar:
            TimerFrequency = ClockFrequency / (Prescalar + 1) / (Period + 1);
            break;
         case InputType.Period:
            TimerFrequency = ClockFrequency / (Prescalar + 1) / (Period + 1);
            break;
         case InputType.Timer:
            Period = (uint)Math.Round(ClockFrequency / (Prescalar + 1) / TimerFrequency);
            if (Period > UInt16.MaxValue)
            {
               Prescalar = (uint)Math.Floor(ClockFrequency / (UInt16.MaxValue / 1.5) / (TimerFrequency) + 0.5);
               Period = (uint)Math.Round(ClockFrequency / (Prescalar + 1) / TimerFrequency);
            }
            break;
      }
   }

   private void Clear()
   {
      TimerFrequency = 0;
      Period = 0;
      Prescalar = 0;
   }
   #region Events

   #endregion
   #endregion

   #region Full Props
   public uint Prescalar
   {
      get => +_prescalar;
      set
      {
         _prescalar = value;
         OnPropertyChanged();
      }
   }

   public uint Period
   {
      get => _period;
      set
      {
         _period = value;
         OnPropertyChanged();
      }
   }

   public double ClockFrequency
   {
      get => _clockFreq;
      set
      {
         _clockFreq = value;
         OnPropertyChanged();
      }
   }

   public double TimerFrequency
   {
      get => _timerFreq;
      set
      {
         _timerFreq = value;
         _timerInterval = 1 / value;
         OnPropertyChanged();
         OnPropertyChanged(nameof(TimerInterval));
         OnPropertyChanged(nameof(ToggleTimerInterval));
      }
   }

   public double TimerInterval
   {
      get => _timerInterval;
      set
      {
         _timerInterval = value;
         _timerFreq = 1 / value;
         OnPropertyChanged();
         OnPropertyChanged(nameof(TimerFrequency));
         OnPropertyChanged(nameof(ToggleTimerInterval));
      }
   }
   public double ToggleTimerInterval => _timerInterval * 2;
   #endregion
}
