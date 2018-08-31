using System;
using ChartHelper;

namespace ChartControls
{
	public partial class TestForm : ChartForm
	{
		/// <summary>
		/// ctor
		/// </summary>
		public TestForm(ChartThemeStyle theme = ChartThemeStyle.Dark)
		{
			InitializeComponent();

			chartControlLabel1.chartContainerControl1.gbTitle.Text = "Availability";
			chartControlLabel2.chartContainerControl1.gbTitle.Text = "Effectiveness";
			chartControlLabel3.chartContainerControl1.gbTitle.Text = "Tap Settings";

			// Todo: Get Data for main dashboard chart
			var data = ChartData.GetTestSurveyData(249, theme);
			data.PageSize = 40;

			this.Color1 = data.Theme.PanelColor1; //.BackColor; // gradient colors
			this.Color2 = data.Theme.PanelColor2; //.BackColor2;
			this.ColorAngle = -90f; // darker on bottom

			chartControlComplete1.OnPointSelected += Form_OnPointSelected;
			chartControlComplete1.Data = data;

			aGaugeControl1.Data = data; // set Data first, becuase it has Theme Data
			aGaugeControl1.Set(0f, "Volts");

			aGaugeControl2.Data = data;
			aGaugeControl2.Set(0f, "Amps");

			chartControlLabel1.Data = data;
			chartControlLabel2.Data = data;
			chartControlLabel3.Data = data;

			//Note: chartControlSimple1.Data and chartControlSimple2.Data set in Form_OnPointSelected
		}

		#region helpers
		private float[] Regions(float ratedOut, float operatingValue, out float gaugeValue)
		{
			const float gaugeMax = 180.0f; // 180 degree gauge
			const float green = 0.05f; // 5% margin is small!
			const float yellow = 0.15f; // 15% margin
			const float regionScaler = 2.80f; // 2.20 means 220% bigger (3.2 times), 1.20 means 120% bigger, 0.1 means 10% bigger, 0 means no scaling, etc. This allows us to scale the green and yellow regions without affecting the score

			float middle = gaugeMax / 2; //  90 degrees
			float first = middle * (1 - (yellow * (1 + regionScaler)));
			float second = middle * (1 - (green * (1 + regionScaler)));
			float third = middle * (1 + (green * (1 + regionScaler)));
			float fourth = middle * (1 + (yellow * (1 + regionScaler)));

			// ratedOut typically 18 for voltage, 45 for amperage
			if (ratedOut > 0 && operatingValue != 0)
			{
				float factor = gaugeMax / ratedOut;
				gaugeValue = operatingValue * factor;
				if (gaugeValue >= gaugeMax)
				{
					gaugeValue = gaugeMax;
				}
				else
				{
					var scaled = (Math.Abs(middle - gaugeValue) / middle) * (1 + regionScaler);

					gaugeValue = middle * (gaugeValue < middle ? 1 - scaled : 1 + scaled);

					gaugeValue = gaugeValue < 1 ?
						1
						: gaugeValue > 179 ?
						179
						:
						gaugeValue;
				}
			}
			else
				gaugeValue = 0;

			// this function needs to return 4 single-precision numbers in the array
			return new float[] { first, second, third, fourth };
		}

		#endregion

		#region # events
		internal protected override void Form_OnPointSelected(object obj, PointContainerArgs e) // implementation
		{
			var pc = e.PointContainer;
			//pc.Name
			//pc.PointData
			//pc.PointData.Bag
			//pc.PointData.ID

			// Todo: Get Data based on the argument(point) given
			// Voltage
			float ratedValue = 100.0f;
			float operValue = 47.5f;
			float gValue;
			var vals = Regions(ratedValue, operValue, out gValue);
			aGaugeControl1.Set(gValue, vals);

			// Todo: Bind data to gauge control, labels, and sub charts

			// Amperage
			ratedValue = 24.0f;
			operValue = 10.2f;
			vals = Regions(ratedValue, operValue, out gValue);
			aGaugeControl2.Set(gValue, vals);

			// Availability
			chartControlLabel1.labelOne.Text = "1 Year - 85%";
			chartControlLabel1.labelTwo.Text = "10 Year - 83%";

			// Effectiveness
			chartControlLabel2.labelOne.Text = "1 Year - 100%";
			chartControlLabel2.labelTwo.Text = "10 Year - 84%";

			// Tap Settings
			chartControlLabel3.labelOne.Text = "Coarse - 3";
			chartControlLabel3.labelTwo.Text = "Fine - 2";

			// Sub charts -- pass PointData.ID or something out of PointData.Bag here for future
			ChartData.Bind(ChartData.GetTestAmperageData(42, chartControlComplete1.Data.Theme.Style), chartControlSimple1.mChart);
			ChartData.Bind(ChartData.GetTestOhmData(42, chartControlComplete1.Data.Theme.Style), chartControlSimple2.mChart);
		}

		private void TestForm_Load(object sender, System.EventArgs e)
		{
			// all child control "loads" get called first
			chartControlComplete1.PointSelected(0, chartControlComplete1.PrimarySeriesIdx); // select the first (zero based index), this will end up calling Form_OnPointSelected above
		}
		#endregion
	}
}
