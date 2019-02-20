namespace MainWindow
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openData = new System.Windows.Forms.OpenFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.rbPolyReg = new System.Windows.Forms.RadioButton();
            this.numRank = new System.Windows.Forms.NumericUpDown();
            this.rBMovingAv = new System.Windows.Forms.RadioButton();
            this.cBPreFilter = new System.Windows.Forms.CheckBox();
            this.numPreFilter = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBRawDataVisible = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMaxY = new System.Windows.Forms.Label();
            this.lblMinY = new System.Windows.Forms.Label();
            this.lblObsInt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.saveData = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreFilter)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(13, 171);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.Size = new System.Drawing.Size(1015, 390);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(13, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // rbPolyReg
            // 
            this.rbPolyReg.AutoSize = true;
            this.rbPolyReg.Location = new System.Drawing.Point(6, 69);
            this.rbPolyReg.Name = "rbPolyReg";
            this.rbPolyReg.Size = new System.Drawing.Size(131, 17);
            this.rbPolyReg.TabIndex = 4;
            this.rbPolyReg.Text = "Polynomial Regression";
            this.rbPolyReg.UseVisualStyleBackColor = true;
            this.rbPolyReg.CheckedChanged += new System.EventHandler(this.RbPolyReg_CheckedChanged);
            // 
            // numRank
            // 
            this.numRank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRank.Location = new System.Drawing.Point(220, 69);
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
            this.numRank.Size = new System.Drawing.Size(45, 20);
            this.numRank.TabIndex = 7;
            this.numRank.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numRank.ValueChanged += new System.EventHandler(this.NumRank_ValueChanged);
            // 
            // rBMovingAv
            // 
            this.rBMovingAv.AutoSize = true;
            this.rBMovingAv.Location = new System.Drawing.Point(6, 92);
            this.rBMovingAv.Name = "rBMovingAv";
            this.rBMovingAv.Size = new System.Drawing.Size(103, 17);
            this.rBMovingAv.TabIndex = 8;
            this.rBMovingAv.TabStop = true;
            this.rBMovingAv.Text = "Moving Average";
            this.rBMovingAv.UseVisualStyleBackColor = true;
            this.rBMovingAv.CheckedChanged += new System.EventHandler(this.rBMovingAv_CheckedChanged);
            // 
            // cBPreFilter
            // 
            this.cBPreFilter.AutoSize = true;
            this.cBPreFilter.Location = new System.Drawing.Point(6, 19);
            this.cBPreFilter.Name = "cBPreFilter";
            this.cBPreFilter.Size = new System.Drawing.Size(195, 17);
            this.cBPreFilter.TabIndex = 9;
            this.cBPreFilter.Text = "Apply pre filtering to remove  outliers";
            this.cBPreFilter.UseVisualStyleBackColor = true;
            this.cBPreFilter.CheckedChanged += new System.EventHandler(this.CBPreFilter_CheckedChanged);
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
            this.numPreFilter.Size = new System.Drawing.Size(45, 20);
            this.numPreFilter.TabIndex = 10;
            this.numPreFilter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPreFilter.ValueChanged += new System.EventHandler(this.NumPreFilter_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBRawDataVisible);
            this.groupBox1.Controls.Add(this.cBPreFilter);
            this.groupBox1.Controls.Add(this.numPreFilter);
            this.groupBox1.Controls.Add(this.rbPolyReg);
            this.groupBox1.Controls.Add(this.rBMovingAv);
            this.groupBox1.Controls.Add(this.numRank);
            this.groupBox1.Location = new System.Drawing.Point(438, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 152);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Data";
            // 
            // rBRawDataVisible
            // 
            this.rBRawDataVisible.AutoSize = true;
            this.rBRawDataVisible.Location = new System.Drawing.Point(6, 46);
            this.rBRawDataVisible.Name = "rBRawDataVisible";
            this.rBRawDataVisible.Size = new System.Drawing.Size(73, 17);
            this.rBRawDataVisible.TabIndex = 12;
            this.rBRawDataVisible.TabStop = true;
            this.rBRawDataVisible.Text = "Raw Data";
            this.rBRawDataVisible.UseVisualStyleBackColor = true;
            this.rBRawDataVisible.CheckedChanged += new System.EventHandler(this.RBRawDataVisible_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMaxY);
            this.groupBox2.Controls.Add(this.lblMinY);
            this.groupBox2.Controls.Add(this.lblObsInt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblFileName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(123, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 153);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Information";
            // 
            // lblMaxY
            // 
            this.lblMaxY.AutoSize = true;
            this.lblMaxY.Location = new System.Drawing.Point(117, 93);
            this.lblMaxY.Name = "lblMaxY";
            this.lblMaxY.Size = new System.Drawing.Size(10, 13);
            this.lblMaxY.TabIndex = 7;
            this.lblMaxY.Text = "-";
            // 
            // lblMinY
            // 
            this.lblMinY.AutoSize = true;
            this.lblMinY.Location = new System.Drawing.Point(117, 70);
            this.lblMinY.Name = "lblMinY";
            this.lblMinY.Size = new System.Drawing.Size(10, 13);
            this.lblMinY.TabIndex = 6;
            this.lblMinY.Text = "-";
            // 
            // lblObsInt
            // 
            this.lblObsInt.AutoSize = true;
            this.lblObsInt.Location = new System.Drawing.Point(117, 47);
            this.lblObsInt.Name = "lblObsInt";
            this.lblObsInt.Size = new System.Drawing.Size(10, 13);
            this.lblObsInt.TabIndex = 5;
            this.lblObsInt.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Maximum:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Minimum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Observation Interval:";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(69, 19);
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
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(735, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 152);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Process Data";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(13, 41);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 24);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 15;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AppExit_Click);
            // 
            // saveData
            // 
            this.saveData.DefaultExt = "txt";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 573);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.chart1);
            this.MinimumSize = new System.Drawing.Size(1055, 612);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreFilter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.OpenFileDialog openData;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.RadioButton rbPolyReg;
        private System.Windows.Forms.NumericUpDown numRank;
        private System.Windows.Forms.RadioButton rBMovingAv;
        private System.Windows.Forms.CheckBox cBPreFilter;
        private System.Windows.Forms.NumericUpDown numPreFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rBRawDataVisible;
        private System.Windows.Forms.SaveFileDialog saveData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblMaxY;
        private System.Windows.Forms.Label lblMinY;
        private System.Windows.Forms.Label lblObsInt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

