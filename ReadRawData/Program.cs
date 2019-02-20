using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using OxyPlot;
using OxyPlot.Series;

namespace ReadRawData
{
    
    class ReadRawData
    {
       

        static void Main(string[] args)
        {
           GetData("C:\\Users\\phuem\\OneDrive\\Business\\Apps\\TideCalculation\\TG_20180522.txt");
        }

        static TideData tideData;
        static List<TideData> myTide = new List<TideData>();


        public static List<TideData> GetTide
        {
            get
            {
                return myTide;
            }
        }


        public static void GetData(string _dataFile)
        {

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

            // Zeitdifferenz setzen wenn benötigt
            //tideData.dateTime = tideData.dateTime.AddHours(2);

            
            Console.ReadLine();

        }
    }


    class TideData
    {
        public DateTime dateTime;
        public double tideValue;
    }

}