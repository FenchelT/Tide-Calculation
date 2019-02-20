using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace OxyPlot1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();

            DrawGraph();
        }

        string _dataFile = "C:\\Users\\phuem\\OneDrive\\Business\\Apps\\TideCalculation\\FilteredTideExample.txt";

        static TideData tideData;
        static List<TideData> myTide = new List<TideData>();

        private void DrawGraph()
        {
            #region
            DateTime dateValue;

            StreamReader sr = new StreamReader(_dataFile);

            string[] separators = { "!", "?", ";", "," };

            while (!sr.EndOfStream)
            {

                tideData = new TideData();

                string[] _values;

                _values = sr.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if (DateTime.TryParse(_values[0], out dateValue))
                {
                    Console.WriteLine(dateValue + " " + _values[1]);
                    tideData.dateTime = dateValue;
                    tideData.tideValue = Convert.ToDouble(_values[1]);
                    myTide.Add(tideData);
                }
                else if (DateTime.TryParse(_values[0], CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.AssumeLocal, out dateValue))
                {
                    Console.WriteLine(dateValue + " " + _values[1]);
                    tideData.dateTime = dateValue;
                    tideData.tideValue = Convert.ToDouble(_values[1]);
                    myTide.Add(tideData);
                }

            }
            #endregion

            plotView1.Dock = DockStyle.Fill;

            LinearAxis yAxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "Tide Value",
                FontSize = 10,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };


            DateTimeAxis xAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "dd.MM.yyyy\n    HH:mm",
                Title = "Date",
                FontSize = 10,
                IntervalType = DateTimeIntervalType.Hours,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };



           ScatterSeries rawTide = new ScatterSeries()
           {
               MarkerType = MarkerType.Circle,
               MarkerSize = 2,
               
           };
           

            foreach (var item in myTide)
            {
                rawTide.Points.Add(new ScatterPoint(DateTimeAxis.ToDouble(item.dateTime), item.tideValue));
            }

            PlotModel myModel = new PlotModel();
           
            myModel.Series.Add(rawTide);
            myModel.Axes.Add(xAxis);
            myModel.Axes.Add(yAxis);



            this.plotView1.Model = myModel;
        }
    }

    class TideData
    {
        public DateTime dateTime;
        public double tideValue;
    }

}

