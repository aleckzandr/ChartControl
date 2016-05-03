namespace ChartControls
{
	partial class AGaugeControl
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
			this.gauge = new AGauge();
			this.gaugeLabel = new AGaugeLabel();
			this.range1 = new AGaugeRange();
			this.range2 = new AGaugeRange();
			this.range3 = new AGaugeRange();
			this.range4 = new AGaugeRange();
			this.range5 = new AGaugeRange();
			this.gbBackground = new GelButton();
			this.chartContainerControl = new ChartContainerControl();
			this.SuspendLayout();
			// 
			// gauge
			// 
			this.gauge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.gauge.BaseArcColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.gauge.BaseArcRadius = 80;
			this.gauge.BaseArcStart = 180;
			this.gauge.BaseArcSweep = 180;
			this.gauge.BaseArcWidth = 1;
			this.gauge.Center = new System.Drawing.Point(84, 82);
			this.gauge.GaugeLabels.Add(this.gaugeLabel);
			this.gauge.GaugeRanges.Add(this.range1);
			this.gauge.GaugeRanges.Add(this.range2);
			this.gauge.GaugeRanges.Add(this.range3);
			this.gauge.GaugeRanges.Add(this.range4);
			this.gauge.GaugeRanges.Add(this.range5);
			this.gauge.Location = new System.Drawing.Point(5, 36);
			this.gauge.Margin = new System.Windows.Forms.Padding(0);
			this.gauge.MaxValue = 180F;
			this.gauge.MinValue = 0F;
			this.gauge.Name = "gauge";
			this.gauge.NeedleColor1 = AGaugeNeedleColor.White;
			this.gauge.NeedleColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.gauge.NeedleRadius = 58;
			this.gauge.NeedleType = NeedleType.Simple;
			this.gauge.NeedleWidth = 4;
			this.gauge.ScaleLinesInterColor = System.Drawing.Color.Transparent;
			this.gauge.ScaleLinesInterInnerRadius = 72;
			this.gauge.ScaleLinesInterOuterRadius = 80;
			this.gauge.ScaleLinesInterWidth = 1;
			this.gauge.ScaleLinesMajorColor = System.Drawing.Color.Transparent;
			this.gauge.ScaleLinesMajorInnerRadius = 70;
			this.gauge.ScaleLinesMajorOuterRadius = 80;
			this.gauge.ScaleLinesMajorStepValue = 20F;
			this.gauge.ScaleLinesMajorWidth = 2;
			this.gauge.ScaleLinesMinorColor = System.Drawing.Color.Transparent;
			this.gauge.ScaleLinesMinorInnerRadius = 70;
			this.gauge.ScaleLinesMinorOuterRadius = 80;
			this.gauge.ScaleLinesMinorTicks = 9;
			this.gauge.ScaleLinesMinorWidth = 1;
			this.gauge.ScaleNumbersColor = System.Drawing.Color.Transparent;
			this.gauge.ScaleNumbersFormat = null;
			this.gauge.ScaleNumbersRadius = 80;
			this.gauge.ScaleNumbersRotation = 0;
			this.gauge.ScaleNumbersStartScaleLine = 1;
			this.gauge.ScaleNumbersStepScaleLines = 1;
			this.gauge.Size = new System.Drawing.Size(168, 104);
			this.gauge.TabIndex = 8;
			this.gauge.Text = "gauge";
			this.gauge.Value = 0F;
			this.gauge.ValueChanged += new System.EventHandler(this.gauge_ValueChanged);
			this.gauge.Click += new System.EventHandler(this.gauge_Click);
			// 
			// gaugeLabel
			// 
			this.gaugeLabel.Color = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
			this.gaugeLabel.Font = new System.Drawing.Font("Verdana", 7F);
			this.gaugeLabel.Location = new System.Drawing.Point(0, 0);
			this.gaugeLabel.Name = "gaugeLabel";
			this.gaugeLabel.Position = new System.Drawing.Point(74, 92);
			this.gaugeLabel.Size = new System.Drawing.Size(0, 0);
			this.gaugeLabel.TabIndex = 10;
			// 
			// range1
			// 
			this.range1.Color = System.Drawing.Color.White;
			this.range1.ColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.range1.EndValue = 45.8F;
			this.range1.InnerRadius = 38;
			this.range1.InRange = false;
			this.range1.Location = new System.Drawing.Point(0, 0);
			this.range1.Name = "range1";
			this.range1.OuterRadius = 80;
			this.range1.Size = new System.Drawing.Size(0, 0);
			this.range1.StartValue = 0F;
			this.range1.TabIndex = 20;
			// 
			// range2
			// 
			this.range2.Color = System.Drawing.Color.WhiteSmoke;
			this.range2.ColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(10)))));
			this.range2.EndValue = 65.8F;
			this.range2.InnerRadius = 38;
			this.range2.InRange = false;
			this.range2.Location = new System.Drawing.Point(0, 0);
			this.range2.Name = "range2";
			this.range2.OuterRadius = 80;
			this.range2.Size = new System.Drawing.Size(0, 0);
			this.range2.StartValue = 46F;
			this.range2.TabIndex = 30;
			// 
			// range3
			// 
			this.range3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(178)))), ((int)(((byte)(78)))));
			this.range3.ColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
			this.range3.EndValue = 125.8F;
			this.range3.InnerRadius = 38;
			this.range3.InRange = false;
			this.range3.Location = new System.Drawing.Point(0, 0);
			this.range3.Name = "range3";
			this.range3.OuterRadius = 80;
			this.range3.Size = new System.Drawing.Size(0, 0);
			this.range3.StartValue = 66F;
			this.range3.TabIndex = 40;
			// 
			// range4
			// 
			this.range4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(8)))));
			this.range4.ColorSecond = System.Drawing.Color.WhiteSmoke;
			this.range4.EndValue = 145.8F;
			this.range4.InnerRadius = 38;
			this.range4.InRange = false;
			this.range4.Location = new System.Drawing.Point(0, 0);
			this.range4.Name = "range4";
			this.range4.OuterRadius = 80;
			this.range4.Size = new System.Drawing.Size(0, 0);
			this.range4.StartValue = 126F;
			this.range4.TabIndex = 50;
			// 
			// range5
			// 
			this.range5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.range5.ColorSecond = System.Drawing.Color.White;
			this.range5.EndValue = 180F;
			this.range5.InnerRadius = 38;
			this.range5.InRange = false;
			this.range5.Location = new System.Drawing.Point(0, 0);
			this.range5.Name = "range5";
			this.range5.OuterRadius = 80;
			this.range5.Size = new System.Drawing.Size(0, 0);
			this.range5.StartValue = 146F;
			this.range5.TabIndex = 60;
			// 
			// gbBackground
			// 
			this.gbBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbBackground.BackColor = System.Drawing.Color.Transparent;
			this.gbBackground.CornerRadiusScaler = 1;
			this.gbBackground.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
			this.gbBackground.GradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.gbBackground.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.gbBackground.HighlightRectangleScaler = 1F;
			this.gbBackground.Location = new System.Drawing.Point(0, 32);
			this.gbBackground.Margin = new System.Windows.Forms.Padding(0);
			this.gbBackground.Name = "gbBackground";
			this.gbBackground.Size = new System.Drawing.Size(182, 116);
			this.gbBackground.TabIndex = 7;
			this.gbBackground.UseVisualStyleBackColor = false;
			// 
			// chartContainerControl
			// 
			this.chartContainerControl.BackColor = System.Drawing.Color.Transparent;
			this.chartContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartContainerControl.Location = new System.Drawing.Point(0, 0);
			this.chartContainerControl.Margin = new System.Windows.Forms.Padding(0);
			this.chartContainerControl.Name = "chartContainerControl";
			this.chartContainerControl.Size = new System.Drawing.Size(182, 148);
			this.chartContainerControl.TabIndex = 0;
			// 
			// AGaugeControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.gauge);
			this.Controls.Add(this.gbBackground);
			this.Controls.Add(this.chartContainerControl);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "AGaugeControl";
			this.Size = new System.Drawing.Size(182, 148);
			this.Load += new System.EventHandler(this.AGaugeControl_Load);
			this.ResumeLayout(false);

		}

		#endregion

		public AGaugeLabel gaugeLabel;
		public AGaugeRange range1;
		public AGaugeRange range2;
		public AGaugeRange range3;
		public AGaugeRange range4;
		public AGaugeRange range5;
		public AGauge gauge;
		private GelButton gbBackground;
		public ChartContainerControl chartContainerControl;
	}
}
