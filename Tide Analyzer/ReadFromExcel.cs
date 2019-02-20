using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace Tide_Analyzer
{
    class ReadFromExcel
    {
        Select_Sheet selectForm;

        List<string> excelSheets = new List<string>();

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
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(_dataFile, 0, true);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                range = xlWorkSheet.UsedRange;

                object[,] values = range.Value2;

                for (int i = 1; i < values.GetLength(0); i++)
                {
                    if (DateTime.TryParse(values[i, 1].ToString(), out DateTime _dateTime))
                    {
                        myData = new DateTimeValues
                        {
                            dateTime = _dateTime,
                            values = Convert.ToDouble(values[i, 2])
                        };
                        myValues.Add(myData);
                    }
                    else if (DateTime.TryParse(values[i, 1].ToString(), CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.AssumeLocal, out DateTime _dateValue))
                    {
                        myData = new DateTimeValues
                        {
                            dateTime = _dateValue,
                            values = Convert.ToDouble(values[i, 2])
                        };
                        myValues.Add(myData);
                    }
                }

                myValues.Sort();
            }

            catch (Exception ex)
            {
                MessageBox.Show("No Data were imported! Check data format. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                importSuccseeded = false;
            }


            //    this._dataFile = _dataFile;

            //    Workbook wb = excel.Workbooks.Open(_dataFile,0,true);

            //    selectForm = new Select_Sheet();

            //    foreach (Worksheet ws in wb.Worksheets)
            //    {
            //        excelSheets.Add(ws.Name.ToString());
            //    }

            //    selectForm.FillDropList(excelSheets);

            //    var result = selectForm.ShowDialog();

            //    if (result == DialogResult.OK)
            //    {
            //        //string excelSheet = selectForm.SelectedExcelSheet;            //values preserved after close

            //        Worksheet ws = wb.Worksheets[selectForm.SelectedExcelSheet];

            //        myData = new DateTimeValues();

            //        for (int i = 1; i < 10; i++)
            //        {
            //        //    if (DateTime.TryParse(ws.Cells[i,1].Value2, out DateTime dateValue))
            //        //    {
            //                myData.dateTime = Convert.ToDateTime( ws.Cells[i, 1].Value2);
            //                myData.values = Convert.ToDouble(ws.Cells[i,2].Value2);
            //                myValues.Add(myData);
            //            //}
            //            //else if (DateTime.TryParse(ws.Cells[i, 1].Value2, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.AssumeLocal, out dateValue))
            //            //{
            //            //    myData.dateTime = dateValue;
            //            //    myData.values = Convert.ToDouble(ws.Cells[i, 2].Value2);
            //            //    myValues.Add(myData);
            //            //}
            //        }
            //    }
            //}
        }
    }
}
