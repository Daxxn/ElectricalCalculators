using MVVMLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Calculators.STM32;

public class STM32QSPIConfigViewModelViewModel : ViewModel
{
   #region Local Props
   private double? _flashSizeBits = null;
   private double? _flashSizeBytes = null;
   private double? _sizeConfigRaw = null;
   private int? _sizeConfig = null;
   #region Commands
   public Command CalcCmd { get; init; }
   public Command ClearCmd { get; init; }
   #endregion
   #endregion

   #region Constructors
   public STM32QSPIConfigViewModelViewModel()
   {
      CalcCmd = new(Calc);
      ClearCmd = new(Clear);
   }
   #endregion

   #region Methods
   private void Calc()
   {
      if (FlashSizeBits is null && FlashSizeBytes is null) return;
      if (FlashSizeBits is null || FlashSizeBits == 0)
      {
         ConvertToBits();
      }
      else if (FlashSizeBytes is null || FlashSizeBytes == 0)
      {
         ConvertToBytes();
      }
      SizeConfigRaw = (Math.Log((double)FlashSizeBytes!) - Math.Log(2)) / Math.Log(2);
      SizeConfigOutput = (int)Math.Ceiling((double)SizeConfigRaw);
   }

   private void Clear()
   {
      FlashSizeBits = null;
      FlashSizeBytes = null;
      SizeConfigRaw = null;
      SizeConfigOutput = null;
   }

   private void ConvertToBits()
   {
      FlashSizeBits = FlashSizeBytes * 8;
   }

   private void ConvertToBytes()
   {
      if (FlashSizeBits is null) return;
      FlashSizeBytes = FlashSizeBits / 8;
      //if (FlashSizeBits > 1024)
      //{
      //   FlashSizeBytes = FlashSizeBits / 1024;
      //}
      //else
      //{
      //   FlashSizeBytes = FlashSizeBits / 8;
      //}
   }
   #region Events

   #endregion
   #endregion

   #region Full Props
   public double? FlashSizeBits
   {
      get => _flashSizeBits;
      set
      {
         _flashSizeBits = value;
         OnPropertyChanged();
      }
   }

   public double? FlashSizeBytes
   {
      get => _flashSizeBytes;
      set
      {
         _flashSizeBytes = value;
         OnPropertyChanged();
      }
   }

   public double? SizeConfigRaw
   {
      get => _sizeConfigRaw;
      set
      {
         _sizeConfigRaw = value;
         OnPropertyChanged();
      }
   }

   public int? SizeConfigOutput
   {
      get => _sizeConfig;
      set
      {
         _sizeConfig = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
