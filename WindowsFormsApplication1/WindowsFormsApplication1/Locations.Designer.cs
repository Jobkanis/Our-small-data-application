namespace WindowsFormsApplication1
{
    partial class Locations
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_District1 = new System.Windows.Forms.Button();
            this.button_District12 = new System.Windows.Forms.Button();
            this.button_District10 = new System.Windows.Forms.Button();
            this.button_District9 = new System.Windows.Forms.Button();
            this.button_District5 = new System.Windows.Forms.Button();
            this.button_District3 = new System.Windows.Forms.Button();
            this.button_District6 = new System.Windows.Forms.Button();
            this.button_District2 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DrawGraph = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.button_District1);
            this.panel1.Controls.Add(this.button_District12);
            this.panel1.Controls.Add(this.button_District10);
            this.panel1.Controls.Add(this.button_District9);
            this.panel1.Controls.Add(this.button_District5);
            this.panel1.Controls.Add(this.button_District3);
            this.panel1.Controls.Add(this.button_District6);
            this.panel1.Controls.Add(this.button_District2);
            this.panel1.Location = new System.Drawing.Point(54, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 283);
            this.panel1.TabIndex = 1;
            // 
            // button_District1
            // 
            this.button_District1.AccessibleName = "District2";
            this.button_District1.Location = new System.Drawing.Point(29, 22);
            this.button_District1.Name = "button_District1";
            this.button_District1.Size = new System.Drawing.Size(216, 25);
            this.button_District1.TabIndex = 10;
            this.button_District1.Text = "District 1";
            this.button_District1.UseVisualStyleBackColor = true;
            this.button_District1.Click += new System.EventHandler(this.button_District1_Click_1);
            // 
            // button_District12
            // 
            this.button_District12.Location = new System.Drawing.Point(29, 241);
            this.button_District12.Name = "button_District12";
            this.button_District12.Size = new System.Drawing.Size(216, 25);
            this.button_District12.TabIndex = 9;
            this.button_District12.Text = "District 12";
            this.button_District12.UseVisualStyleBackColor = true;
            this.button_District12.Click += new System.EventHandler(this.button_District12_Click);
            // 
            // button_District10
            // 
            this.button_District10.Location = new System.Drawing.Point(29, 208);
            this.button_District10.Name = "button_District10";
            this.button_District10.Size = new System.Drawing.Size(216, 27);
            this.button_District10.TabIndex = 8;
            this.button_District10.Text = "District 10";
            this.button_District10.UseVisualStyleBackColor = true;
            this.button_District10.Click += new System.EventHandler(this.button_District10_Click);
            // 
            // button_District9
            // 
            this.button_District9.Location = new System.Drawing.Point(29, 176);
            this.button_District9.Name = "button_District9";
            this.button_District9.Size = new System.Drawing.Size(216, 26);
            this.button_District9.TabIndex = 7;
            this.button_District9.Text = "District 9";
            this.button_District9.UseVisualStyleBackColor = true;
            this.button_District9.Click += new System.EventHandler(this.button_District9_Click);
            // 
            // button_District5
            // 
            this.button_District5.Location = new System.Drawing.Point(29, 115);
            this.button_District5.Name = "button_District5";
            this.button_District5.Size = new System.Drawing.Size(216, 25);
            this.button_District5.TabIndex = 5;
            this.button_District5.Text = "District 5";
            this.button_District5.UseVisualStyleBackColor = true;
            this.button_District5.Click += new System.EventHandler(this.button_District5_Click);
            // 
            // button_District3
            // 
            this.button_District3.Location = new System.Drawing.Point(29, 84);
            this.button_District3.Name = "button_District3";
            this.button_District3.Size = new System.Drawing.Size(216, 25);
            this.button_District3.TabIndex = 3;
            this.button_District3.Text = "District 3";
            this.button_District3.UseVisualStyleBackColor = true;
            this.button_District3.Click += new System.EventHandler(this.button_District3_Click);
            // 
            // button_District6
            // 
            this.button_District6.Location = new System.Drawing.Point(29, 146);
            this.button_District6.Name = "button_District6";
            this.button_District6.Size = new System.Drawing.Size(216, 24);
            this.button_District6.TabIndex = 4;
            this.button_District6.Text = "District 6";
            this.button_District6.UseVisualStyleBackColor = true;
            this.button_District6.Click += new System.EventHandler(this.button_District6_Click);
            // 
            // button_District2
            // 
            this.button_District2.AccessibleName = "District2";
            this.button_District2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_District2.Location = new System.Drawing.Point(29, 53);
            this.button_District2.Name = "button_District2";
            this.button_District2.Size = new System.Drawing.Size(216, 25);
            this.button_District2.TabIndex = 2;
            this.button_District2.Text = "District 2";
            this.button_District2.UseVisualStyleBackColor = true;
            this.button_District2.Click += new System.EventHandler(this.button_District2_Click);
            // 
            // chart1
            // 
            this.chart1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chart1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            chartArea2.AxisX.IsStartedFromZero = false;
            chartArea2.AxisX.Maximum = 25D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.ScaleBreakStyle.MaxNumberOfBreaks = 1;
            chartArea2.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Default;
            this.chart1.Enabled = false;
            this.chart1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chart1.Location = new System.Drawing.Point(407, 89);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series3.ChartArea = "ChartArea1";
            series3.Name = "Fietsdiefstal";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Straatroof";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(510, 283);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // DrawGraph
            // 
            this.DrawGraph.Location = new System.Drawing.Point(83, 378);
            this.DrawGraph.Name = "DrawGraph";
            this.DrawGraph.Size = new System.Drawing.Size(216, 25);
            this.DrawGraph.TabIndex = 11;
            this.DrawGraph.Text = "Update Graph";
            this.DrawGraph.UseVisualStyleBackColor = true;
            this.DrawGraph.Click += new System.EventHandler(this.DrawGraph_Click);
            // 
            // Locations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1212, 551);
            this.Controls.Add(this.DrawGraph);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Locations";
            this.Text = "Locations";
            this.Load += new System.EventHandler(this.Locations_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_District3;
        private System.Windows.Forms.Button button_District2;
        private System.Windows.Forms.Button button_District6;
        private System.Windows.Forms.Button button_District5;
        private System.Windows.Forms.Button button_District12;
        private System.Windows.Forms.Button button_District10;
        private System.Windows.Forms.Button button_District9;
        private System.Windows.Forms.Button button_District1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button DrawGraph;
    }
}