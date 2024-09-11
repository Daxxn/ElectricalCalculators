using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace ElectricalCalculators.Calculators.RegFeedback
{
   public class DividerResult : Model
   {
      #region Local Props
      private double _rtop = 0;
      private double _rbot = 0;
      private double _vout = 0;
      private double _err = 0;
      #endregion

      #region Constructors
      public DividerResult() { }
      public DividerResult(double rTop, double rBot, double vout, double error)
      {
         RTop = rTop;
         RBot = rBot;
         Vout = vout;
         Error = error;
      }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      public double RTop
      {
         get => _rtop;
         set
         {
            _rtop = value;
            OnPropertyChanged();
         }
      }

      public double RBot
      {
         get => _rbot;
         set
         {
            _rbot = value;
            OnPropertyChanged();
         }
      }

      public double Vout
      {
         get => _vout;
         set
         {
            _vout = value;
            OnPropertyChanged();
         }
      }

      public double Error
      {
         get => _err;
         set
         {
            _err = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
