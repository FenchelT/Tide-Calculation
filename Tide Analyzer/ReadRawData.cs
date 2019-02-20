using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows.Forms;



namespace Tide_Analyzer
{
    class ReadRawData
    {
        
        DateTimeValues myData;
        List<DateTimeValues> myValues = new List<DateTimeValues>();

        bool importSuccseeded = true;
        

        public List<DateTimeValues> GetValues
        {
            get
            {
                return myValues;
            }
        }

        public bool ImportSuccseeded { get => importSuccseeded; set => importSuccseeded = value; }

        public void GetData(string _dataFile)
        {

            StreamReader sr = new StreamReader(_dataFile);

            string[] separators = { "!", "?", ";", ",", "\t"};

            try
            {
                while (!sr.EndOfStream)
                {

                    myData = new DateTimeValues();

                    string[] _values;

                    _values = sr.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    if (_values.Length != 0)
                    {
                        if (DateTime.TryParse(_values[0], out DateTime dateValue))
                        {
                            myData.dateTime = dateValue;
                            myData.values = Convert.ToDouble(_values[1]);
                            myValues.Add(myData);
                        }
                        else if (DateTime.TryParse(_values[0], CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.AssumeLocal, out dateValue))
                        {
                            myData.dateTime = dateValue;
                            myData.values = Convert.ToDouble(_values[1]);
                            myValues.Add(myData);
                        }
                    }

                }
                // Sortieren über LINQ        
                //IOrderedEnumerable<DateTimeValues> aft_sort  = from obj in myValues orderby obj.dateTime ascending select obj;
                //mySortedValues = aft_sort.ToList();

                myValues.Sort();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data were imported! Check data format. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                importSuccseeded = false;

            }
        }
    }

    public class DateTimeValues : ICloneable, IComparable
    {
        public DateTime dateTime;
        public double values; 

        // This is a deep copy implementation of Clone
        public object Clone()
        {
            return new DateTimeValues
            {
                dateTime = this.dateTime,
                values = this.values,
            };
        }

        public int CompareTo(object obj)
        {
            DateTimeValues _dateTimeValues = obj as DateTimeValues;
            return this.dateTime.CompareTo(_dateTimeValues.dateTime);          
        }

    }
}
