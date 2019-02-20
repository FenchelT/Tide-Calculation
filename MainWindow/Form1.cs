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
using MathNet.Numerics.Statistics;
using System.IO;


namespace MainWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            rBRawDataVisible.Checked = true;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.yyyy HH:mm";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "0000";
        }

        const double _scaler = 0.002;

        List<DateTimeValues> myRawData;
        List<DateTimeValues> myFilteredData;
        List<DateTimeValues> myPolyFilteredData;
        List<DateTimeValues> myMovingAvFilteredData;

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            myRawData = null;
            myFilteredData = null;
            myPolyFilteredData = null;
            myMovingAvFilteredData = null;
            

            if (openData.ShowDialog() == DialogResult.OK)
            {
                ReadRawData readRawData = new ReadRawData();
                readRawData.GetData(openData.FileName);
                myRawData = readRawData.GetValues;

                // Fill File Info Field //
                groupBox1.Enabled = true;
                lblFileName.Text = new FileInfo(openData.FileName).Name;
                double[] limits = GetDataLimits(myRawData);
                lblObsInt.Text = DateTime.FromOADate(limits[0]).ToString("dd.MM.yyyy HH:mm") + " - "
                    + DateTime.FromOADate(limits[1]).ToString("dd.MM.yyyy HH:mm");
                lblMinY.Text = limits[2].ToString();
                lblMaxY.Text = limits[3].ToString();

                //----------------------//
                DrawGraph(myRawData, "Raw Data");
            }

        }

        private List<DateTimeValues> DoPolynomialRegression(List<DateTimeValues> values)
        {

            myPolyFilteredData = new List<DateTimeValues>();
            myPolyFilteredData = CopyList(values);

            double[] _values = new double[myPolyFilteredData.Count];
            double[] _time = new double[myPolyFilteredData.Count];


            for (int i = 0; i < myPolyFilteredData.Count; i++)
            {
                _time[i] = i;
                _values[i] = myPolyFilteredData[i].values;
            }

            double[] p = Fit.Polynomial(_time, _values, (int)numRank.Value);

            for (int i = 0; i < myPolyFilteredData.Count; i++)
            {
                myPolyFilteredData[i].values = p[0];

                for (int z = 1; z < p.Length; z++)
                {
                    double t1 = p[z] * Math.Pow(_time[i], z);
                    myPolyFilteredData[i].values += p[z] * Math.Pow(_time[i], z);
                }

            }

            return myPolyFilteredData;
        }

        private List<DateTimeValues> DoPreFiltering(List<DateTimeValues> values)
        {
            myFilteredData = new List<DateTimeValues>();
            myFilteredData = CopyList(values);

            double[] _values = new double[myFilteredData.Count];

            for (int i = 0; i < myFilteredData.Count; i++)
            {
                _values[i] = myFilteredData[i].values;
            }

            StatisticCalculations statisticCalculations = new StatisticCalculations(_values);

            myFilteredData.RemoveAll(obj => (obj.values < (statisticCalculations.Percentile((double)numPreFilter.Value * _scaler))));
            myFilteredData.RemoveAll(obj => (obj.values > (statisticCalculations.Percentile(1-(double)numPreFilter.Value * _scaler))));
            
            return myFilteredData;

        }

        private void DrawGraph(List<DateTimeValues> values, string _name)
        {

            if (chart1.Series.IndexOf(_name) != -1)
                for (int i = 0; i < chart1.Series.Count -1; i++)
                {
                    chart1.Series.RemoveAt(chart1.Series.IndexOf(_name));
                }
                
      
            chart1.Series.Add(_name);
            chart1.Series[_name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[_name].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;

            chart1.ChartAreas[0].AxisY.Maximum = 20 + values.Max(obj => obj.values);
            chart1.ChartAreas[0].AxisY.Minimum = -20 + values.Min(obj => obj.values);
            chart1.ChartAreas[0].AxisX.Maximum = values.Max(obj => obj.dateTime.ToOADate());
            chart1.ChartAreas[0].AxisX.Minimum = values.Min(obj => obj.dateTime.ToOADate());

            switch (_name)
            {
                case "Raw Data":
                    chart1.Series[_name].MarkerSize = 4;
                    chart1.Series[_name].Color = Color.Gray;
                    break;
                case "Filtered Data":
                    chart1.Series[_name].MarkerSize = 2;
                    chart1.Series[_name].Color = Color.Blue;
                    break;
                case "Polynomial Regression":
                    chart1.Series[_name].MarkerSize = 3;
                    chart1.Series[_name].Color = Color.GreenYellow;
                    break;
                case "Moving Average":
                    chart1.Series[_name].MarkerSize = 3;
                    chart1.Series[_name].Color = Color.Purple;
                    break;
                default:
                    chart1.Series[_name].MarkerSize = 4;
                    chart1.Series[_name].Color = Color.Gray;
                    break;
            }

            for (int i = 0; i < values.Count; i++)
            {
                chart1.Series[_name].Points.AddXY(values[i].dateTime, values[i].values);
            }

        }
    
        static List<DateTimeValues> CopyList(List<DateTimeValues> list)
        {

                List<DateTimeValues> newList = new List<DateTimeValues>(list.Count);
                foreach (DateTimeValues item in list)
                    newList.Add((DateTimeValues)item.Clone());
                return newList;
       
        }

        private void RbPolyReg_CheckedChanged(object sender, EventArgs e)
        {
            if (cBPreFilter.Checked)
            {
                DoPolynomialRegression(myFilteredData);
                DrawGraph(myPolyFilteredData, "Polynomial Regression");
                chart1.Series["Raw Data"].Enabled = false;
                chart1.Series["Filtered Data"].Enabled = true;
            }
            else
            {
                DoPolynomialRegression(myRawData);
                DrawGraph(myPolyFilteredData, "Polynomial Regression");
                chart1.Series["Raw Data"].Enabled = true;
                if(chart1.Series.IndexOf("Filtered Data") != -1)
                    chart1.Series["Filtered Data"].Enabled = false;
            }
        }

        private void CBPreFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (cBPreFilter.Checked)
            {

                DoPreFiltering(myRawData);   
                DrawGraph(myFilteredData, "Filtered Data");
                chart1.Series["Raw Data"].Enabled = false;

                if (rbPolyReg.Checked)
                {
                    DoPolynomialRegression(myFilteredData);
                    DrawGraph(myPolyFilteredData, "Polynomial Regression");
                }

            }
            else
            {
                chart1.Series["Raw Data"].Enabled = true;

                if (chart1.Series.IndexOf("Filtered Data") != -1)
                    chart1.Series["Filtered Data"].Enabled = false;
                

                if (rbPolyReg.Checked)
                {
                    DoPolynomialRegression(myRawData);
                    DrawGraph(myPolyFilteredData, "Polynomial Regression");
                }
                
            }

        }

        private void NumPreFilter_ValueChanged(object sender, EventArgs e)
        {
            if (cBPreFilter.Checked)
            {
                DoPreFiltering(myRawData);
                DrawGraph(myFilteredData, "Filtered Data");
            }

        }

        private void AppExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RBRawDataVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (rBRawDataVisible.Checked && myRawData != null)
            {
                if (chart1.Series.IndexOf("Polynomial Regression") != -1)
                    chart1.Series.RemoveAt(chart1.Series.IndexOf("Polynomial Regression"));

                if (cBPreFilter.Checked)
                {
                    DoPreFiltering(myRawData);
                    DrawGraph(myFilteredData, "Filtered Data");
                    chart1.Series["Raw Data"].Enabled = false;
                }
                else
                {
                    if (chart1.Series.IndexOf("Filtered Data") != -1)
                        chart1.Series.RemoveAt(chart1.Series.IndexOf("Filtered Data"));

                    chart1.Series["Raw Data"].Enabled = true;
                }

            }
        }

        private void NumRank_ValueChanged(object sender, EventArgs e)
        {
            if (cBPreFilter.Checked)
            {
                DoPolynomialRegression(myFilteredData);
                DrawGraph(myPolyFilteredData, "Polynomial Regression");
                chart1.Series["Raw Data"].Enabled = false;
                chart1.Series["Filtered Data"].Enabled = true;
            }
            else
            {
                DoPolynomialRegression(myRawData);
                DrawGraph(myPolyFilteredData, "Polynomial Regression");
                chart1.Series["Raw Data"].Enabled = true;
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (saveData.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveData.FileName);

                if (rbPolyReg.Checked)
                {
                    for (int i = 1; i < myPolyFilteredData.Count; i++)
                    {
                        
                        if (myPolyFilteredData[i].dateTime.Second != myPolyFilteredData[i-1].dateTime.Second )
                            sw.WriteLine(myPolyFilteredData[i].dateTime.ToString("dd.MM.yyyy HH:mm:ss") + "\t" + myPolyFilteredData[i].values.ToString("0000.00"));
                        
                    }
                }

                sw.Close();
            }
        }

        private List<DateTimeValues> DoMovingAv(List<DateTimeValues> values)
        {
            myMovingAvFilteredData = new List<DateTimeValues>();
            myMovingAvFilteredData = CopyList(values);

            double[] _values = new double[myMovingAvFilteredData.Count];

            for (int i = 0; i <  myMovingAvFilteredData.Count; i++)
            {
                _values[i] =  myMovingAvFilteredData[i].values;
            }

            IEnumerable<double> query = _values.Cast<double>();
            IEnumerable<double> movAv = Statistics.MovingAverage(query, 2000);

            int z = 0;
            foreach (double value in movAv)
            { 
                myMovingAvFilteredData[z].values = value;
                z++;
            }
            
            return myMovingAvFilteredData;
        }

        private double[] GetDataLimits (List<DateTimeValues> values)
        {
            double[] limits = new double[4]; //takes minX,maxX, minY, maxY of the data

            limits[0] = values.Min(obj => obj.dateTime.ToOADate());
            limits[1] = values.Max(obj => obj.dateTime.ToOADate());
            limits[2] = values.Min(obj => obj.values);
            limits[3] = values.Max(obj => obj.values);

            return limits;
        }

        private void rBMovingAv_CheckedChanged(object sender, EventArgs e)
        {
            if (cBPreFilter.Checked)
            {
                DoMovingAv(myFilteredData);
                DrawGraph(myMovingAvFilteredData, "Moving Average");
                chart1.Series["Raw Data"].Enabled = false;
                chart1.Series["Filtered Data"].Enabled = true;
            }
            else
            {
                //DoPolynomialRegression(myRawData);
                //DrawGraph(myPolyFilteredData, "Polynomial Regression");
                //chart1.Series["Raw Data"].Enabled = true;
                //if (chart1.Series.IndexOf("Filtered Data") != -1)
                //    chart1.Series["Filtered Data"].Enabled = false;
            }
        }
    }
}

