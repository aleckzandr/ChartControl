using System;
using System.Windows.Forms;
using ChartHelper;

namespace ChartControls
{
	public partial class AGaugeControl : UserControl
	{
		private IChartData _data;

		protected internal IChartData Data
		{
			get
			{
#if DEBUG && TESTDATA
				if (_data == null)
					_data = ChartData.GetTestSurveyData(25, ChartThemeStyle.Dark); // if data is null set it to Test Data with 25 random points
#endif
				return _data;
			}

			set { _data = value; }
		}

		public AGaugeControl() { InitializeComponent(); gaugeLabel.Text = string.Empty; } //: this(0f, "Gauge") { }

		public AGaugeControl(float gaugeValue) : this(gaugeValue, "Gauge") { }

		public AGaugeControl(string title) : this(0f, title) { }

		public AGaugeControl(float gaugeValue, string title)
		{
			InitializeComponent();

			gaugeLabel.Text = string.Empty;

			Set(gaugeValue, title);
		}

		public void Set(float gaugeValue)
		{
			Set(gaugeValue, null, null);
		}

		public void Set(float gaugeValue, string title)
		{
			Set(gaugeValue, title, null);
		}

		public void Set(float gaugeValue, float[] fourSeperatorValues)
		{
			Set(gaugeValue, null, fourSeperatorValues);
		}

		public void Set(float gaugeValue, string title, float[] fourSeperatorValues)
		{
			if (!string.IsNullOrEmpty(title))
				chartContainerControl.gbTitle.Text = title;

			if (fourSeperatorValues != null && fourSeperatorValues.Length > 3)
			{
				float sepFactor = 0.2f;
				this.range1.StartValue = 0F;
				this.range1.EndValue = fourSeperatorValues[0] - sepFactor;

				this.range2.StartValue = fourSeperatorValues[0];
				this.range2.EndValue = fourSeperatorValues[1] - sepFactor;

				this.range3.StartValue = fourSeperatorValues[1];
				this.range3.EndValue = fourSeperatorValues[2] - sepFactor;

				this.range4.StartValue = fourSeperatorValues[2];
				this.range4.EndValue = fourSeperatorValues[3] - sepFactor;

				this.range5.StartValue = fourSeperatorValues[3];
				this.range5.EndValue = 180F;
			}

			gauge.Value = gaugeValue;
			gaugeLabel.Color = Data.Theme.ControlBackColor2;
		}

		private void gauge_ValueChanged(object sender, EventArgs e)
		{
			gaugeLabel.Text = gauge.Value > 0 ? string.Format("{0}", gauge.Value) : string.Empty;
		}

		private void gauge_Click(object sender, EventArgs e)
		{
			gbBackground.Focus();
			gaugeLabel.Color = Data.Theme.ControlFaintSelection;
			// anything else?
		}

		private void AGaugeControl_Load(object sender, EventArgs e)
		{
			#region Color
			//this.chartContainerControl.gbTitle.Text = Data.TitleControl;
			this.BackColor = Data.Theme.PanelColor1; // important
			this.chartContainerControl.gradControlPanel.Color1 = Data.Theme.PanelColor1;
			this.chartContainerControl.gradControlPanel.Color2 = Data.Theme.PanelColor2;

			this.gauge.BackColor = this.gauge.NeedleColor2 = Data.Theme.PanelColor1;
			this.gauge.NeedleColor1 = Data.Theme.Style.Equals(ChartThemeStyle.Light) ? AGaugeNeedleColor.Gray : AGaugeNeedleColor.White;
			this.gaugeLabel.Color = Data.Theme.ControlBackColor2;

			this.gbBackground.GradientBottom = Data.Theme.PanelColor1;
			this.gbBackground.GradientTop = Data.Theme.PanelColor1;
			this.gbBackground.HighlightColor = Data.Theme.PanelColor1;
			#endregion
		}
	}
}
