using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;
using Tide_Analyzer;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Textfeld textfeld;
        List<DateTimeValues> myRawData;

        public Form1()
        {
            InitializeComponent();
            textfeld = new Textfeld(this);
        }

        

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            textfeld.OnChangeWindowSize(this);
        }

        private void Btn_Open_Click(object sender, EventArgs e)
        {
            myRawData = null;
            //myFilteredData = null;
            //myPolyFilteredData = null;
            //myMovingAvFilteredData = null;


            if (openData.ShowDialog() == DialogResult.OK)
            {
                ReadRawData readRawData = new ReadRawData();
                readRawData.GetData(openData.FileName);
                myRawData = readRawData.GetValues;

                textfeld.DrawTideGraph(myRawData);
            }
        }
    }

    public class Textfeld
    {
        PlotView pv = new PlotView();
        //Create Plotmodel Object
        PlotModel _canvas = new PlotModel();
        

        public Textfeld(Form form)
        {
   
            pv.Location = new System.Drawing.Point(0, 170);
            pv.Size = new System.Drawing.Size(form.Width - 50, form.Height - 210 );

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

            _canvas.Axes.Add(xAxis);
            _canvas.Axes.Add(yAxis);

            //Assign PlotModel to PlotView
            pv.Model = _canvas;

            form.Controls.Add(pv);
        }

        public void OnChangeWindowSize(Form form)
        {
            //Change Size of the drawing area
            pv.Location = new System.Drawing.Point(0, 170);
            pv.Size = new System.Drawing.Size(form.Width - 50, form.Height -210 );
        }

        

        public void DrawTideGraph(List<DateTimeValues> values)
        {
            

            ScatterSeries rawTide = new ScatterSeries()
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 2,
            };

            
            foreach (var item in values)
            {
                rawTide.Points.Add(new ScatterPoint(DateTimeAxis.ToDouble(item.dateTime), item.values));
            }

            _canvas.Series.Add(rawTide);
            
            pv.InvalidatePlot(true);
            
     

        }
    }
}
