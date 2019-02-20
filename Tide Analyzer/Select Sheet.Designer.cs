namespace Tide_Analyzer
{
    partial class Select_Sheet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CB_SelectExcelSheet = new System.Windows.Forms.ComboBox();
            this.Btn_SelectExcelSheet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CB_SelectExcelSheet
            // 
            this.CB_SelectExcelSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_SelectExcelSheet.FormattingEnabled = true;
            this.CB_SelectExcelSheet.ItemHeight = 20;
            this.CB_SelectExcelSheet.Location = new System.Drawing.Point(12, 22);
            this.CB_SelectExcelSheet.Name = "CB_SelectExcelSheet";
            this.CB_SelectExcelSheet.Size = new System.Drawing.Size(284, 28);
            this.CB_SelectExcelSheet.TabIndex = 0;
            // 
            // Btn_SelectExcelSheet
            // 
            this.Btn_SelectExcelSheet.Location = new System.Drawing.Point(319, 21);
            this.Btn_SelectExcelSheet.Name = "Btn_SelectExcelSheet";
            this.Btn_SelectExcelSheet.Size = new System.Drawing.Size(82, 31);
            this.Btn_SelectExcelSheet.TabIndex = 1;
            this.Btn_SelectExcelSheet.Text = "Select";
            this.Btn_SelectExcelSheet.UseVisualStyleBackColor = true;
            this.Btn_SelectExcelSheet.Click += new System.EventHandler(this.Btn_SelectExcelSheet_Click);
            // 
            // Select_Sheet
            // 
            this.AcceptButton = this.Btn_SelectExcelSheet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 72);
            this.Controls.Add(this.Btn_SelectExcelSheet);
            this.Controls.Add(this.CB_SelectExcelSheet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Select_Sheet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Excel Sheet";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_SelectExcelSheet;
        private System.Windows.Forms.ComboBox CB_SelectExcelSheet;
    }
}