using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models.STM32Enums
{
   public enum Stm32FsmcBank : uint
   {
      BANK1 = 0x60000000,
      BANK2 = 0x70000000,
      BANK3 = 0x80000000,
      BANK4 = 0x90000000,
   }

   public enum Stm32FsmcChipSelect : uint
   {
      NE1 = 0b00,
      NE2 = 0b01,
      NE3 = 0b10,
      NE4 = 0b11,
   }
}
