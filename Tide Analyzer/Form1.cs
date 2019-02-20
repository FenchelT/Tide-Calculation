using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MathNet.Numerics;
using MathNet.Numerics.Statistics;


namespace Tide_Analyzer
{

    //TIDE = 10132.5*(P_TG-P_WS-480)/(9.807*1000); //P = rho*g*z (pascals)

    public partial class TideAnalyzerMainForm : Form
    {

        DrawTideGraph drawTideGraph;
        List<DateTimeValues> myRawData;
        List<DateTimeValues> myFilteredData;

        List<DateTimeValues> myPolyFilteredDataResult;
        List<DateTimeValues> myMovingAvFilteredDataResult;

        const double _scaler = 0.002;

        public TideAnalyzerMainForm()
        {
            InitializeComponent();
            drawTideGraph = new DrawTideGraph(this);
            Btn_Export.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            myRawData = null;
            myFilteredData = null;
            
            myMovingAvFilteredDataResult = null;

            CB_PreFilter.Checked = false;
            CB_Regression.Checked = false;
            CB_MovingAverage.Checked = false;


            drawTideGraph.ClearAllGraphData();

            if (openData.ShowDialog() == DialogResult.OK)
            {
                int _filterSelected = openData.FilterIndex;

                switch (_filterSelected)
                {
                    case 1:
                        ReadRawData readRawData = new ReadRawData();
                        readRawData.GetData(openData.FileName);
                        myRawData = readRawData.GetValues;

                        if (readRawData.ImportSuccseeded)
                        {
                            UpDateHeadInfo(myRawData);
                            drawTideGraph.DrawGraph(myRawData, "RAW Tide");
                        }
                        break;
                    case 2:
                        ReadFromExcel readFromExcel = new ReadFromExcel();
                        readFromExcel.GetData(openData.FileName);
                        myRawData = readFromExcel.GetValues;
                        if (readFromExcel.ImportSuccseeded)
                        {
                            UpDateHeadInfo(myRawData);
                            drawTideGraph.DrawGraph(myRawData, "RAW Tide");
                        }
                        break;
                }
            }

        }

        private void UpDateHeadInfo(List<DateTimeValues> values)
        {
            // Fill File Info Field //
            groupBox1.Enabled = true;
            lblFileName.Text = new FileInfo(openData.FileName).Name;
            double[] limits = GetDataLimits(values);
            lblObsInt.Text = DateTime.FromOADate(limits[0]).ToString("dd.MM.yyyy HH:mm") + " - "
                + DateTime.FromOADate(limits[1]).ToString("dd.MM.yyyy HH:mm");
            lblMinY.Text = limits[2].ToString();
            lblMaxY.Text = limits[3].ToString();
            lblAverage.Text = limits[4].ToString();
            lblNoOfSample.Text = limits[5].ToString();
        }

        private double[] GetDataLimits(List<DateTimeValues> values)
        {
            double[] limits = new double[6]; //takes minX,maxX, minY, maxY of the data

            limits[0] = values.Min(obj => obj.dateTime.ToOADate());
            limits[1] = values.Max(obj => obj.dateTime.ToOADate());
            limits[2] = values.Min(obj => obj.values);
            limits[3] = values.Max(obj => obj.values);
            limits[4] = values.Sum(obj => obj.values) / values.Count;
            limits[5] = values.Count;

            return limits;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //Change Size of the drawing area
             drawTideGraph.OnChangeWindowSize(this);
        }

        private void CBPreFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_PreFilter.Checked && myRawData != null)
            {
                DoPreFiltering(myRawData);
                UpDateHeadInfo(myFilteredData);
                drawTideGraph.DrawGraph(myFilteredData, "Filtered Data");
                drawTideGraph.RemoveGraph("RAW Tide");

                if (CB_Regression.Checked)
                {
                    DoPolynomialRegression(myFilteredData);
                    drawTideGraph.RemoveGraph("Polynomial Regression");
                    drawTideGraph.DrawGraph(myPolyFilteredDataResult, "Polynomial Regression");
                }

            }
            else if (!CB_PreFilter.Checked && myRawData != null)
            {
                drawTideGraph.DrawGraph(myRawData, "RAW Tide");
                UpDateHeadInfo(myRawData);
                drawTideGraph.RemoveGraph("Filtered Data");

                if (CB_Regression.Checked)
                {
                    DoPolynomialRegression(myRawData);
                    drawTideGraph.RemoveGraph("Polynomial Regression");
                    drawTideGraph.DrawGraph(myPolyFilteredDataResult, "Polynomial Regression");
                }
                if (!CB_Regression.Checked)
                {
                    drawTideGraph.RemoveGraph("Polynomial Regression");
                }
            }
        }

        private List<DateTimeValues> DoMovingAverage(List<DateTimeValues> values)
        {
 
            myMovingAvFilteredDataResult = new List<DateTimeValues>();

            DateTimeValues myResultData;

            double[] _values = new double[values.Count];

            for (int i = 0; i < _values.Length / 2; i++)
            {
          
                for (int j = 0; j < (int)numMAverage.Value ; j++)
                {
                    _values[i] += values[j + i].values;
                }
                _values[i] /=  (int)numMAverage.Value ;
            }

            for (int i = _values.Length - 1; i >= _values.Length / 2; i--)
            {
                
                for (int j = 0; j < (int)numMAverage.Value ; j++)
                {
                    _values[i] += values[i - j].values;
                }
                _values[i] = _values[i] / (int)numMAverage.Value ;
            }


            for (int i = 0; i < _values.Length; i++)
            {
                myResultData = new DateTimeValues
                {
                    dateTime = values[i].dateTime,
                    values = _values[i]
                };

                myMovingAvFilteredDataResult.Add(myResultData);
            }

            return myMovingAvFilteredDataResult;
        }

        private List<DateTimeValues> DoPolynomialRegression(List<DateTimeValues> values)
        {
            DateTimeValues myResultData;

            myPolyFilteredDataResult = new List<DateTimeValues>();
            
            TimeSpan timeSpan =values[values.Count - 1].dateTime - values[0].dateTime;

            double[] _values = new double[values.Count];
            double[] _time = new double[values.Count];

            for (int i = 0; i < values.Count; i++)
            {
                _time[i] = i * (Math.Round(timeSpan.TotalSeconds) / values.Count);
                _values[i] = values[i].values;
            }

            double[] p = Fit.Polynomial(_time, _values, (int)numRank.Value, MathNet.Numerics.LinearRegression.DirectRegressionMethod.QR);
            
            for (int i = 0; i < timeSpan.TotalSeconds - 1; i++)
            {
                myResultData = new DateTimeValues
                {
                    dateTime = values[0].dateTime.AddSeconds(i),

                    values = p[0]
                };

                for (int z = 1; z < p.Length; z++)
                {
                    myResultData.values += p[z] * Math.Pow(i, z);
                }

                myPolyFilteredDataResult.Add(myResultData);
            }

            return myPolyFilteredDataResult;
        }
        #region
        //private List<DateTimeValues> DoPolynomialRegression(List<DateTimeValues> values)
        //{

        //    myPolyFilteredData = new List<DateTimeValues>();
        //    myPolyFilteredData = CopyList(values);


        //    double[] _values = new double[myPolyFilteredData.Count];
        //    double[] _time = new double[myPolyFilteredData.Count];


        //    for (int i = 0; i < myPolyFilteredData.Count; i++)
        //    {
        //        _time[i] = i;
        //        _values[i] = myPolyFilteredData[i].values;
        //    }

        //    double[] p = Fit.Polynomial(_time, _values, (int)numRank.Value, MathNet.Numerics.LinearRegression.DirectRegressionMethod.NormalEquations);


        //    for (int i = 0; i < myPolyFilteredData.Count; i++)
        //    {
        //        myPolyFilteredData[i].values = p[0];

        //        for (int z = 1; z < p.Length; z++)
        //        {
        //            double t1 = p[z] * Math.Pow(_time[i], z);
        //            myPolyFilteredData[i].values += p[z] * Math.Pow(_time[i], z);
        //        }

        //    }

        //    retu rn myPolyFilteredData;
        //}
        #endregion   

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NumPreFilter_ValueChanged(object sender, EventArgs e)
        {

            if (CB_PreFilter.Checked)
            {
                DoPreFiltering(myRawData);
                drawTideGraph.RemoveGraph("Filtered Data");
                UpDateHeadInfo(myFilteredData);
                drawTideGraph.DrawGraph(myFilteredData, "Filtered Data");

                if (CB_MovingAverage.Checked)
                {
                    DoMovingAverage(myFilteredData);
                    drawTideGraph.RemoveGraph("Moving Average");
                    drawTideGraph.DrawGraph(myMovingAvFilteredDataResult, "Moving Average");
                }

                if (CB_Regression.Checked)
                {
                    DoPolynomialRegression(myFilteredData);
                    drawTideGraph.RemoveGraph("Polynomial Regression");
                    drawTideGraph.DrawGraph(myPolyFilteredDataResult, "Polynomial Regression");
                }
            }
            
        }

        static List<DateTimeValues> CopyList(List<DateTimeValues> list)
        {
            List<DateTimeValues> newList = new List<DateTimeValues>(list.Count);
            foreach (DateTimeValues item in list)
                newList.Add((DateTimeValues)item.Clone());
            return newList;

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
            myFilteredData.RemoveAll(obj => (obj.values > (statisticCalculations.Percentile(1 - (double)numPreFilter.Value * _scaler))));

            return myFilteredData;

        }

        private void NumRank_ValueChanged(object sender, EventArgs e)
        {
            if (CB_PreFilter.Checked && CB_Regression.Checked && myRawData != null)
            {
                DoPolynomialRegression(myFilteredData);
                drawTideGraph.RemoveGraph("Polynomial Regression");
                drawTideGraph.DrawGraph(myPolyFilteredDataResult, "Polynomial Regression");
;
            }
            else if(CB_Regression.Checked && !CB_PreFilter.Checked && myRawData != null)
            {
                DoPolynomialRegression(myRawData);
                drawTideGraph.RemoveGraph("Polynomial Regression");
                drawTideGraph.DrawGraph(myPolyFilteredDataResult, "Polynomial Regression");
               
            }
        }

        
        private void CB_Regression_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Regression.Checked && myRawData != null)
            {
                Btn_Export.Enabled = true;

                if (CB_PreFilter.Checked)
                {
                    DoPolynomialRegression(myFilteredData);
                    drawTideGraph.DrawGraph(myPolyFilteredDataResult, "Polynomial Regression");

                }
                else if (!CB_PreFilter.Checked)
                {
                    DoPolynomialRegression(myRawData);
                    drawTideGraph.DrawGraph(myPolyFilteredDataResult, "Polynomial Regression");
                }
            }
            else if (!CB_Regression.Checked)
            {
                drawTideGraph.RemoveGraph("Polynomial Regression");
                Btn_Export.Enabled = false;
            }

        }

        private void CBMovingAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_MovingAverage.Checked && myRawData != null)
            {
                Btn_Export.Enabled = true;

                if (CB_PreFilter.Checked)
                {
                    DoMovingAverage(myFilteredData);
                    drawTideGraph.DrawGraph(myMovingAvFilteredDataResult , "Moving Average");

                }
                else if (!CB_PreFilter.Checked)
                {
                    DoMovingAverage(myRawData);
                    drawTideGraph.DrawGraph(myMovingAvFilteredDataResult, "Moving Average");
                }
            }
            else if (!CB_MovingAverage.Checked)
            {
                drawTideGraph.RemoveGraph("Moving Average");
            }
        }

        private void NumMAverage_ValueChanged(object sender, EventArgs e)
        {
            if (CB_MovingAverage.Checked && myRawData != null)
            {
                if (CB_PreFilter.Checked)
                {
                    DoMovingAverage(myFilteredData);
                    drawTideGraph.RemoveGraph("Moving Average");
                    drawTideGraph.DrawGraph(myMovingAvFilteredDataResult, "Moving Average");

                }
                else if (!CB_PreFilter.Checked)
                {
                    DoMovingAverage(myRawData);
                    drawTideGraph.RemoveGraph("Moving Average");
                    drawTideGraph.DrawGraph(myMovingAvFilteredDataResult, "Moving Average");
                }
            }
        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            saveData.Filter = "Text Fils (*.txt) | *.txt";
            saveData.DefaultExt = "txt";


            if (saveData.ShowDialog() == DialogResult.OK)
            {   
              
                if (CB_MovingAverage.Checked)
                {
                    StreamWriter sw = new StreamWriter(saveData.FileName.Insert(saveData.FileName.Length - 4, "_MovingAverage") );

                    sw.WriteLine(myMovingAvFilteredDataResult[0].dateTime.ToString("dd.MM.yyyy HH:mm") + "\t" + myMovingAvFilteredDataResult[0].values.ToString("0000.00"));

                    for (int i = 1; i < myMovingAvFilteredDataResult.Count; i++)
                    {
                        if (myMovingAvFilteredDataResult[i].dateTime.Minute.Equals(myMovingAvFilteredDataResult[i - 1].dateTime.Minute) != true)
                        {
                            sw.WriteLine(myMovingAvFilteredDataResult[i].dateTime.ToString("dd.MM.yyyy HH:mm") + "\t" + myMovingAvFilteredDataResult[i].values.ToString("0000.00"));
                        }

                    }

                    sw.Close();
                }

                if (CB_Regression.Checked)
                {
                    StreamWriter sw = new StreamWriter(saveData.FileName.Insert(saveData.FileName.Length - 4, "_Regression"));

                    sw.WriteLine(myPolyFilteredDataResult[0].dateTime.ToString("dd.MM.yyyy HH:mm") + "\t" + myPolyFilteredDataResult[0].values.ToString("0000.00"));

                    for (int i = 1 ; i < myPolyFilteredDataResult.Count; i++)
                    {
                        if (myPolyFilteredDataResult[i].dateTime.Minute.Equals(myPolyFilteredDataResult[i-1].dateTime.Minute) != true)
                        {
                            sw.WriteLine(myPolyFilteredDataResult[i].dateTime.ToString("dd.MM.yyyy HH:mm") + "\t" + myPolyFilteredDataResult[i].values.ToString("0000.00"));
                        }

                    }

                    sw.Close();
                }

                
            }
        }
    }
}
