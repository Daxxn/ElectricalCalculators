using MVVMLibrary;
using ElectricalCalculators.Models.STM32Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ElectricalCalculators.Models;

namespace ElectricalCalculators.Calculators.STM32
{
   public class Stm32FsmcLcdViewModel : ViewModel
   {
      #region Local Props
      private static readonly Dictionary<bool, uint> MaxAddressDict = new()
      {
         { false, 25 },
         { true,  24 }
      };
      private bool _is16Bit = true;
      private Stm32FsmcBank _bank = Stm32FsmcBank.BANK1;
      private Stm32FsmcChipSelect _cs = Stm32FsmcChipSelect.NE1;
      private uint _addressPin = 1;

      private uint _cmdAddr = 0;
      private uint _dataAddr = 0;

      private double _clockFreq = 0;
      private double _clockFreqNano = 0;
      private double _writeCycle = 0;
      private double _readCycle = 0;
      private double _ctrlHighPulse = 0;
      private double _ctrlLowPulse = 0;
      private double _addressSetupTime = 0;
      private double _dataSetupTime = 0;
      private double _busTurnaroundTime = 0;
      #region Commands
      public Command CalcCmd { get; init; }
      public Command CopyPtrCmd { get; init; }
      #endregion
      #endregion

      #region Constructors
      public Stm32FsmcLcdViewModel()
      {
         CalcCmd = new(CalcAddresses);

         CopyPtrCmd = new(CopyPtr);
      }
      #endregion

      #region Methods
      private void CalcAddresses()
      {
         _cmdAddr = (uint)Bank;
         int addrOffset;
         if (Is16Bit)
         {
            if (AddressPin == 0)
            {
               addrOffset = 1;
            }
            else
            {
               addrOffset = (int)AddressPin << 1;
            }
         }
         else
         {
            addrOffset = (int)AddressPin;
         }
         _dataAddr = (uint)Bank | ((uint)ChipSelect << 26) | (1U << addrOffset);

         OnPropertyChanged(nameof(CommandAddress));
         OnPropertyChanged(nameof(DataAddress));
      }

      private void CalcTimings()
      {
         _clockFreqNano = 1 / ClockFreq;
         AddressSetupTime = WriteCycle / _clockFreqNano;
         DataSetupTime = ((ControlHighPulse + ControlLowPulse) / 2) / _clockFreqNano;
         BusTurnAroundTime = AddressSetupTime + DataSetupTime + 1;
      }

      private void CopyPtr(object obj)
      {
         if (obj is string s)
         {
            if (s == "CMD")
            {
               Clipboard.SetText($"0x{CommandAddress:X}");
            }
            else
            {
               Clipboard.SetText($"0x{DataAddress:X}");
            }
         }
      }
      #region Events

      #endregion
      #endregion

      #region Full Props
      public bool Is16Bit
      {
         get => _is16Bit;
         set
         {
            _is16Bit = value;
            CalcAddresses();
            OnPropertyChanged();
         }
      }

      public Stm32FsmcBank Bank
      {
         get => _bank;
         set
         {
            _bank = value;
            CalcAddresses();
            OnPropertyChanged();
         }
      }

      public Stm32FsmcChipSelect ChipSelect
      {
         get => _cs;
         set
         {
            _cs = value;
            CalcAddresses();
            OnPropertyChanged();
         }
      }

      public uint AddressPin
      {
         get => _addressPin;
         set
         {
            if (value > MaxAddressDict[Is16Bit])
            {
               _addressPin = MaxAddressDict[Is16Bit];
            }
            else
            {
               _addressPin = value;
            }
            CalcAddresses();
            OnPropertyChanged();
         }
      }

      public uint CommandAddress
      {
         get => _cmdAddr;
      }

      public uint DataAddress
      {
         get => _dataAddr;
      }

      public double ClockFreq
      {
         get => _clockFreq;
         set
         {
            _clockFreq = value;
            CalcTimings();
            OnPropertyChanged();
         }
      }

      public double WriteCycle
      {
         get => _writeCycle;
         set
         {
            _writeCycle = value;
            CalcTimings();
            OnPropertyChanged();
         }
      }

      public double ReadCycle
      {
         get => _readCycle;
         set
         {
            _readCycle = value;
            CalcTimings();
            OnPropertyChanged();
         }
      }

      public double ControlHighPulse
      {
         get => _ctrlHighPulse;
         set
         {
            _ctrlHighPulse = value;
            CalcTimings();
            OnPropertyChanged();
         }
      }

      public double ControlLowPulse
      {
         get => _ctrlLowPulse;
         set
         {
            _ctrlLowPulse = value;
            CalcTimings();
            OnPropertyChanged();
         }
      }

      public double AddressSetupTime
      {
         get => _addressSetupTime;
         set
         {
            _addressSetupTime = value;
            OnPropertyChanged();
         }
      }

      public double DataSetupTime
      {
         get => _dataSetupTime;
         set
         {
            _dataSetupTime = value;
            OnPropertyChanged();
         }
      }

      public double BusTurnAroundTime
      {
         get => _busTurnaroundTime;
         set
         {
            _busTurnaroundTime = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
