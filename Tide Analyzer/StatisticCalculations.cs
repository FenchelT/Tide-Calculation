using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tide_Analyzer
{
    class StatisticCalculations
    {
        private double[] afVal;
        private int iSize;

        public StatisticCalculations(double[] afVal)
        {
            this.afVal = afVal;
            this.iSize = afVal.GetLength(0);
            Array.Sort(this.afVal);
        }

        internal Tuple<double, double, double> Quartiles()
        {
           
            int iMid = iSize / 2; //this is the mid from a zero based index, eg mid of 7 = 3;

            double fQ1 = 0;
            double fQ2 = 0;
            double fQ3 = 0;

            if (iSize % 2 == 0)
            {
                //================ EVEN NUMBER OF POINTS: =====================
                //even between low and high point
                fQ2 = (afVal[iMid - 1] + afVal[iMid]) / 2;

                int iMidMid = iMid / 2;

                //easy split 
                if (iMid % 2 == 0)
                {
                    fQ1 = (afVal[iMidMid - 1] + afVal[iMidMid]) / 2;
                    fQ3 = (afVal[iMid + iMidMid - 1] + afVal[iMid + iMidMid]) / 2;
                }
                else
                {
                    fQ1 = afVal[iMidMid];
                    fQ3 = afVal[iMidMid + iMid];
                }
            }
            else if (iSize == 1)
            {
                //================= special case, sorry ================
                fQ1 = afVal[0];
                fQ2 = afVal[0];
                fQ3 = afVal[0];
            }
            else
            {
                //odd number so the median is just the midpoint in the array.
                fQ2 = afVal[iMid];

                if ((iSize - 1) % 4 == 0)
                {
                    //======================(4n-1) POINTS =========================
                    int n = (iSize - 1) / 10;
                    fQ1 = (afVal[n - 1] * .1) + (afVal[n] * .9);
                    fQ3 = (afVal[3 * n] * .9) + (afVal[3 * n + 1] * .1);
                }
                else if ((iSize - 3) % 4 == 0)
                {
                    //======================(4n-3) POINTS =========================
                    int n = (iSize - 3) / 4;

                    fQ1 = (afVal[n] * .75) + (afVal[n + 1] * .25);
                    fQ3 = (afVal[3 * n + 1] * .25) + (afVal[3 * n + 2] * .75);
                }
            }

            return new Tuple<double, double, double>(fQ1, fQ2, fQ3);
        }

        internal double Percentile( double excelPercentile)
        {
            int k;

            double n = (iSize - 1) * excelPercentile;
            // Another method: double n = (N + 1) * excelPercentile;
            if (n == 1d) return afVal[0];
            else if (n == iSize) return afVal[iSize - 1];
            else
            {
                if ((int)n < 1)
                {
                     k = 1;
                    double d = n - k;
                    return afVal[k - 1] + d * (afVal[k] - afVal[k - 1]);
                }
                else
                {
                    k = (int)n;
                    double d = n - k;
                    return afVal[k - 1] + d * (afVal[k] - afVal[k - 1]);
                }
            }
        }
    }
}
