using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.WindowsForms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace Tide_Analyzer
{
    class DrawTideGraph 
    {   
        //Create a PlotView Object
        PlotView pv = new PlotView();
        //Create Plotmodel Object
        PlotModel _canvas = new PlotModel();

        ScatterSeries scatterSeries;

        public DrawTideGraph(TideAnalyzerMainForm form)
        {
            pv.Location = new System.Drawing.Point(0, 170);
            pv.Size = new System.Drawing.Size(form.Width - 50, form.Height -210  );
            
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
            pv.Size = new System.Drawing.Size(form.Width - 50, form.Height -210);
        }

        public string[] GetListOfGraphs()
        {
            string[] _names = new string[_canvas.Series.Count];

            for (int i = 0; i < _canvas.Series.Count; i++)
            {
                _names[i] = _canvas.Series[i].Title;
            }

            return _names;
        }

        public void RemoveGraph(string _nameGraph)
        {
            for (int i = 0; i < _canvas.Series.Count; i++)
            {

                if (string.Equals(_canvas.Series[i].Title,_nameGraph) == true)
                {
                    _canvas.Series.RemoveAt(i);
                }

            }
            pv.InvalidatePlot(true);

        }

        public void ClearAllGraphData()
        {
 
            // Delete the entire series and redraw the canvas
            if (_canvas.Series.Count != 0)
                 _canvas.Series.Clear();
               
            pv.InvalidatePlot(true);    
        }
        

        public void DrawGraph(List<DateTimeValues> values, string _graphName)
        {
            scatterSeries = new ScatterSeries() 
            {
                Title = _graphName,
                MarkerType = MarkerType.Circle,
                MarkerSize = 2,
                
            };
            
            foreach (var item in values)
            {
                scatterSeries.Points.Add(new ScatterPoint(DateTimeAxis.ToDouble(item.dateTime), item.values));
            }

            _canvas.Series.Add(scatterSeries);

            pv.InvalidatePlot(true);

        }
    }
}
