using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChartControls
{
	public partial class TestChart : GradiantForm
	{
		public TestChart()
		{
			InitializeComponent();

			chart1.ChartAreas.FindByName("ChartArea1").CursorX.IsUserEnabled = true;
			chart1.ChartAreas.FindByName("ChartArea1").CursorX.IsUserSelectionEnabled = true;

			//1
			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 80D) { AxisLabel = "A long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 70D) { AxisLabel = "B long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 22D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 8D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 70.5) { AxisLabel = "C long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 19.5D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 60D) { AxisLabel = "D long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 30D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));

			//5
			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 91D) { AxisLabel = "E long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 5D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 4D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 50D) { AxisLabel = "F long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 40D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 40D) { AxisLabel = "G long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 40D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 50D) { AxisLabel = "H long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 5D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 455D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 80D) { AxisLabel = "I long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));

			//10
			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 72D) { AxisLabel = "J long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 18D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 90D) { AxisLabel = "K long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D) { AxisLabel = "L long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 80D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 80D) { AxisLabel = "M long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 75D) { AxisLabel = "N long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 25D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 80D) { AxisLabel = "O long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 5D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 15D));

			//16
			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 80D) { AxisLabel = "P long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 72D) { AxisLabel = "Q long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 18D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 90D) { AxisLabel = "R long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D) { AxisLabel = "S long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 80D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D));

			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 80D) { AxisLabel = "T long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D));

			//21
			chart1.Series.FindByName("Series1").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 75D) { AxisLabel = "U long string here" });
			chart1.Series.FindByName("Series2").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 25D));
			chart1.Series.FindByName("Series3").Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D));
		}
	}
}
