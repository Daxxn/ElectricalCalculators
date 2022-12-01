using MVVMLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalCalculators.Models
{
    public static class CurrentCalculator
    {
        #region Local Props
        #endregion

        #region Methods
        public static (double totalRes, double totalCurr) CalcCurrent(double vcc, IEnumerable<Resistor> resistors)
        {
            double totalRes = 0;
            //double totalCurr = 0;

            foreach (Resistor res in resistors)
            {
                totalRes += 1 / res.Value.Raw;
                var tempCurr = vcc / res.Value.Raw;
                res.Current = tempCurr;
            }
            totalRes = 1 / totalRes;
            return (totalRes, vcc / totalRes);
        }
        #endregion

        #region Full Props
        #endregion
    }
}
