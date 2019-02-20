using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tide_Analyzer
{
    public partial class Select_Sheet : Form
    {
        public Select_Sheet()
        {
            InitializeComponent();
        }
        string selectedExcelSheet;

        public string SelectedExcelSheet { get => selectedExcelSheet; set => selectedExcelSheet = value; }

        public void FillDropList(List<string> excelSheets)
        {
            CB_SelectExcelSheet.Items.AddRange(excelSheets.ToArray());
            CB_SelectExcelSheet.SelectedIndex = 0;
        }

        private void Btn_SelectExcelSheet_Click(object sender, EventArgs e)
        {
            this.selectedExcelSheet = CB_SelectExcelSheet.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
