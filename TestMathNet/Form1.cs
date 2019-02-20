using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;

namespace TestMathNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Series.Clear();
            chart1.Series.Add("RawData");
            chart1.Series["RawData"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

            for (int i = 0; i < myXAxis.Length; i++)
            {
                chart1.Series["RawData"].Points.AddXY(myXAxis[i], myYAxis[i]);
            }
        }

        double[] myXAxis = new double[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20 };
        double[] myYAxis = new double[] { 5,4,3,2,1,1,2,2,0,22,0,3,5,8,10,12,11,10,9,15};

        double[] _fYValues = new double[20];

        private void button1_Click(object sender, EventArgs e)
        {
            double[] p = Fit.Polynomial( myXAxis, myYAxis, 3);

            for (int i = 0; i < myXAxis.Length; i++)
            {
                _fYValues[i] = p[0];

                for (int z = 1; z < p.Length; z++)
                {
                    _fYValues[i] += p[z] * Math.Pow(myXAxis[i], z); 
                }

            }

            chart1.Series.Add("Polynom");
            chart1.Series["Polynom"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

            for (int i = 0; i < myXAxis.Length; i++)
            {
                chart1.Series["Polynom"].Points.AddXY(myXAxis[i], _fYValues[i]);
            }

        }
    }
}
