namespace ChartControls
{
	partial class ChartControlSimple
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chartContainerControl1 = new ChartControls.ChartContainerControl();
			this.mChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.mChart)).BeginInit();
			this.SuspendLayout();
			// 
			// chartContainerControl1
			// 
			this.chartContainerControl1.BackColor = System.Drawing.Color.Transparent;
			this.chartContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.chartContainerControl1.Name = "chartContainerControl1";
			this.chartContainerControl1.Size = new System.Drawing.Size(577, 227);
			this.chartContainerControl1.TabIndex = 0;
			// 
			// mChart
			// 
			this.mChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.Name = "Main";
			chartArea1.Position.Auto = false;
			chartArea1.Position.Height = 94F;
			chartArea1.Position.Width = 94F;
			this.mChart.ChartAreas.Add(chartArea1);
			this.mChart.Location = new System.Drawing.Point(3, 33);
			this.mChart.Margin = new System.Windows.Forms.Padding(0);
			this.mChart.Name = "mChart";
			series1.ChartArea = "Main";
			series1.Name = "Series1";
			this.mChart.Series.Add(series1);
			this.mChart.Size = new System.Drawing.Size(571, 191);
			this.mChart.TabIndex = 1;
			this.mChart.Text = "chart1";
			// 
			// ChartControlSimple
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.mChart);
			this.Controls.Add(this.chartContainerControl1);
			this.Name = "ChartControlSimple";
			this.Size = new System.Drawing.Size(577, 227);
			this.Load += new System.EventHandler(this.ChartControlSimple_Load);
			((System.ComponentModel.ISupportInitialize)(this.mChart)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ChartControls.ChartContainerControl chartContainerControl1;
		private System.Windows.Forms.DataVisualization.Charting.Chart mChart;
	}
}
