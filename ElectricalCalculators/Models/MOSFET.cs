using ElectricalCalculators.Models.Prefixes.Enums;

using MVVMLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models
{
   public class MOSFET : Model
   {
      #region Local Props
      private double? _rdsON = null;
      private double? _qt = null;
      private double? _vcc = null;
      private double? _loadCurr = null;
      private double? _tPerW = null;
      private double? _gateRes = null;
      private double? _driveCurr = null;

      private double? _powerDiss = null;
      private double? _tempDelta = null;
      private double? _swFreq = null;
      private double? _gateCurr = null;
      #endregion

      #region Constructors
      public MOSFET() { }
      #endregion

      #region Methods
      public void Calc()
      {
         CalcPowerDiss();
         CalcTempDelta();
         calcGateCurrent();
         CalcSwitchingTime();
      }

      private void CalcPowerDiss()
      {
         if (LoadCurrent is null) return;
         PowerDiss = Math.Pow((double)LoadCurrent, 2) * RDSON;
      }

      private void CalcTempDelta()
      {
         TempDelta = TempPerWatt * PowerDiss;
      }

      private void calcGateCurrent()
      {
         GateCurrent = DriveCurrent / GateResistance;
      }

      private void CalcSwitchingTime()
      {
         SwitchingFreq = QT / GateCurrent;
      }

      public void SetVCCEvent(object _, double vcc)
      {
         VCC = vcc;
      }
      #endregion

      #region Full Props
      public double? RDSON
      {
         get => _rdsON;
         set
         {
            _rdsON = value;
            OnPropertyChanged();
         }
      }

      public double? QT
      {
         get => _qt;
         set
         {
            _qt = value;
            OnPropertyChanged();
         }
      }

      public double? VCC
      {
         get => _vcc;
         set
         {
            _vcc = value;
            OnPropertyChanged();
         }
      }

      public double? LoadCurrent
      {
         get => _loadCurr;
         set
         {
            _loadCurr = value;
            OnPropertyChanged();
         }
      }

      public double? TempPerWatt
      {
         get => _tPerW;
         set
         {
            _tPerW = value;
            OnPropertyChanged();
         }
      }

      public double? GateResistance
      {
         get => _gateRes;
         set
         {
            _gateRes = value;
            OnPropertyChanged();
         }
      }

      public double? DriveCurrent
      {
         get => _driveCurr;
         set
         {
            _driveCurr = value;
            OnPropertyChanged();
         }
      }

      public double? PowerDiss
      {
         get => _powerDiss;
         set
         {
            _powerDiss = value;
            OnPropertyChanged();
         }
      }

      public double? TempDelta
      {
         get => _tempDelta;
         set
         {
            _tempDelta = value;
            OnPropertyChanged();
         }
      }

      public double? SwitchingFreq
      {
         get => _swFreq;
         set
         {
            _swFreq = value;
            OnPropertyChanged();
         }
      }

      public double? GateCurrent
      {
         get => _gateCurr;
         set
         {
            _gateCurr = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
