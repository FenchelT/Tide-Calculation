namespace Tide_Analyzer
{
    partial class TideAnalyzerMainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.openData = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNoOfSample = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMaxY = new System.Windows.Forms.Label();
            this.lblMinY = new System.Windows.Forms.Label();
            this.lblObsInt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numMAverage = new System.Windows.Forms.NumericUpDown();
            this.CB_MovingAverage = new System.Windows.Forms.CheckBox();
            this.CB_Regression = new System.Windows.Forms.CheckBox();
            this.CB_PreFilter = new System.Windows.Forms.CheckBox();
            this.numPreFilter = new System.Windows.Forms.NumericUpDown();
            this.numRank = new System.Windows.Forms.NumericUpDown();
            this.Btn_Export = new System.Windows.Forms.Button();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.saveData = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRank)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // openData
            // 
            this.openData.Filter = "Text File | *.txt|Excel File (*.xlsx)| *.xlsx";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(898, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 152);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Process Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNoOfSample);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblAverage);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblMaxY);
            this.groupBox2.Controls.Add(this.lblMinY);
            this.groupBox2.Controls.Add(this.lblObsInt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblFileName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(127, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 153);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Information";
            // 
            // lblNoOfSample
            // 
            this.lblNoOfSample.AutoSize = true;
            this.lblNoOfSample.Location = new System.Drawing.Point(117, 65);
            this.lblNoOfSample.Name = "lblNoOfSample";
            this.lblNoOfSample.Size = new System.Drawing.Size(10, 13);
            this.lblNoOfSample.TabIndex = 11;
            this.lblNoOfSample.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Samples:";
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(117, 127);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(10, 13);
            this.lblAverage.TabIndex = 9;
            this.lblAverage.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Average:";
            // 
            // lblMaxY
            // 
            this.lblMaxY.AutoSize = true;
            this.lblMaxY.Location = new System.Drawing.Point(117, 105);
            this.lblMaxY.Name = "lblMaxY";
            this.lblMaxY.Size = new System.Drawing.Size(10, 13);
            this.lblMaxY.TabIndex = 7;
            this.lblMaxY.Text = "-";
            // 
            // lblMinY
            // 
            this.lblMinY.AutoSize = true;
            this.lblMinY.Location = new System.Drawing.Point(117, 85);
            this.lblMinY.Name = "lblMinY";
            this.lblMinY.Size = new System.Drawing.Size(10, 13);
            this.lblMinY.TabIndex = 6;
            this.lblMinY.Text = "-";
            // 
            // lblObsInt
            // 
            this.lblObsInt.AutoSize = true;
            this.lblObsInt.Location = new System.Drawing.Point(117, 42);
            this.lblObsInt.Name = "lblObsInt";
            this.lblObsInt.Size = new System.Drawing.Size(10, 13);
            this.lblObsInt.TabIndex = 5;
            this.lblObsInt.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Maximum:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Minimum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Observation Interval:";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(117, 19);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(10, 13);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numMAverage);
            this.groupBox1.Controls.Add(this.CB_MovingAverage);
            this.groupBox1.Controls.Add(this.CB_Regression);
            this.groupBox1.Controls.Add(this.CB_PreFilter);
            this.groupBox1.Controls.Add(this.numPreFilter);
            this.groupBox1.Controls.Add(this.numRank);
            this.groupBox1.Location = new System.Drawing.Point(601, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 152);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Data";
            // 
            // numMAverage
            // 
            this.numMAverage.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMAverage.Location = new System.Drawing.Point(220, 68);
            this.numMAverage.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMAverage.Name = "numMAverage";
            this.numMAverage.Size = new System.Drawing.Size(55, 20);
            this.numMAverage.TabIndex = 16;
            this.numMAverage.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMAverage.ValueChanged += new System.EventHandler(this.NumMAverage_ValueChanged);
            // 
            // CB_MovingAverage
            // 
            this.CB_MovingAverage.AutoSize = true;
            this.CB_MovingAverage.Location = new System.Drawing.Point(6, 71);
            this.CB_MovingAverage.Name = "CB_MovingAverage";
            this.CB_MovingAverage.Size = new System.Drawing.Size(104, 17);
            this.CB_MovingAverage.TabIndex = 15;
            this.CB_MovingAverage.Text = "Moving Average";
            this.CB_MovingAverage.UseVisualStyleBackColor = true;
            this.CB_MovingAverage.CheckedChanged += new System.EventHandler(this.CBMovingAverage_CheckedChanged);
            // 
            // CB_Regression
            // 
            this.CB_Regression.AutoSize = true;
            this.CB_Regression.Location = new System.Drawing.Point(6, 45);
            this.CB_Regression.Name = "CB_Regression";
            this.CB_Regression.Size = new System.Drawing.Size(132, 17);
            this.CB_Regression.TabIndex = 14;
            this.CB_Regression.Text = "Polynomial Regression";
            this.CB_Regression.UseVisualStyleBackColor = true;
            this.CB_Regression.CheckedChanged += new System.EventHandler(this.CB_Regression_CheckedChanged);
            // 
            // CB_PreFilter
            // 
            this.CB_PreFilter.AutoSize = true;
            this.CB_PreFilter.Location = new System.Drawing.Point(6, 19);
            this.CB_PreFilter.Name = "CB_PreFilter";
            this.CB_PreFilter.Size = new System.Drawing.Size(195, 17);
            this.CB_PreFilter.TabIndex = 9;
            this.CB_PreFilter.Text = "Apply pre filtering to remove  outliers";
            this.CB_PreFilter.UseVisualStyleBackColor = true;
            this.CB_PreFilter.CheckedChanged += new System.EventHandler(this.CBPreFilter_CheckedChanged);
            // 
            // numPreFilter
            // 
            this.numPreFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPreFilter.Location = new System.Drawing.Point(220, 16);
            this.numPreFilter.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numPreFilter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPreFilter.Name = "numPreFilter";
            this.numPreFilter.Size = new System.Drawing.Size(55, 20);
            this.numPreFilter.TabIndex = 10;
            this.numPreFilter.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numPreFilter.ValueChanged += new System.EventHandler(this.NumPreFilter_ValueChanged);
            // 
            // numRank
            // 
            this.numRank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRank.Location = new System.Drawing.Point(220, 42);
            this.numRank.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numRank.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numRank.Name = "numRank";
            this.numRank.Size = new System.Drawing.Size(55, 20);
            this.numRank.TabIndex = 7;
            this.numRank.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numRank.ValueChanged += new System.EventHandler(this.NumRank_ValueChanged);
            // 
            // Btn_Export
            // 
            this.Btn_Export.Location = new System.Drawing.Point(37, 49);
            this.Btn_Export.Name = "Btn_Export";
            this.Btn_Export.Size = new System.Drawing.Size(77, 30);
            this.Btn_Export.TabIndex = 17;
            this.Btn_Export.Text = "Export";
            this.Btn_Export.UseVisualStyleBackColor = true;
            this.Btn_Export.Click += new System.EventHandler(this.Btn_Export_Click);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Location = new System.Drawing.Point(37, 129);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(77, 30);
            this.Btn_Exit.TabIndex = 18;
            this.Btn_Exit.Text = "Exit";
            this.Btn_Exit.UseVisualStyleBackColor = true;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // TideAnalyzerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 461);
            this.Controls.Add(this.Btn_Exit);
            this.Controls.Add(this.Btn_Export);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(1200, 500);
            this.Name = "TideAnalyzerMainForm";
            this.Text = "Tide Analyzer";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMaxY;
        private System.Windows.Forms.Label lblMinY;
        private System.Windows.Forms.Label lblObsInt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CB_PreFilter;
        private System.Windows.Forms.NumericUpDown numPreFilter;
        private System.Windows.Forms.NumericUpDown numRank;
        private System.Windows.Forms.Button Btn_Export;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.CheckBox CB_Regression;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CB_MovingAverage;
        private System.Windows.Forms.Label lblNoOfSample;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numMAverage;
        private System.Windows.Forms.SaveFileDialog saveData;
    }
}

