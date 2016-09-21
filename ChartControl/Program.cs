using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace X
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//Application.Run(new Test(GetData(ChartThemeStyle.Light)));
			//Application.Run(new Test());
			Application.Run(new ChartControls.TestForm(ChartThemeStyle.Dark));

			//Application.Run(new ChartControls.TestChart());
		}

		/// <summary>
		/// Get Test Data to play with
		/// </summary>
		/// <returns>ChartData</returns>
		public static ChartData GetData(ChartThemeStyle cThemeStyle = ChartThemeStyle.Dark)
		{
			const int pts = 1779;
			var theme = new ThemeChart(cThemeStyle);

			#region Series
			var seriesList = new List<ISeriesData>()
			{
				new SeriesData()
				{
					Name = "Native",
					ChartType = SeriesChartType.StackedColumn,
					Color = Color.FromArgb(90, 120, 48), // (20, 220, 20), //(146, 215, 79), //(52, 88, 48),  //(90, 120, 48),
					LabelForeColor = Color.White, //FromArgb(20, 220, 20),
					LegendText = "Native",
					YPointFormat = "0.00",
					UnitOfMeasure = " mV", // note space
					LegendIndex = 0,
					LineWidth = 2,
					ValueTypeX = ChartValueType.String,
					ValueTypeY = ChartValueType.Double
				}
				, new SeriesData()
				{
					Name = "Instant Off",
					ChartType = SeriesChartType.StackedColumn,
					Color = Color.FromArgb(200, 20, 20), //(238, 51, 51)
					LabelForeColor = Color.White,  // Color.FromArgb(220, 20, 20),
					LegendText = "Instant Off",
					YPointFormat = "0.00",
					UnitOfMeasure = " mV",
					LegendIndex = 0,
					LineWidth = 2, // if SeriesChartType.Line or SeriesChartType.FastLine
					ValueTypeX = ChartValueType.String,
					ValueTypeY = ChartValueType.Double
				}
				, new SeriesData()
				{
					Name = "On",
					ChartType = SeriesChartType.StackedColumn,
					Color = Color.FromArgb(8, 10, 50), //(84, 134, 134),
					//EnablePointLabel = true,
					LabelForeColor = Color.White, //, Color.FromArgb(20, 20, 220),
					LegendText = "On",
					YPointFormat = "0.00",
					UnitOfMeasure = " mV",
					LegendIndex = 0,
					LineWidth = 2,
					ValueTypeX = ChartValueType.String,
					ValueTypeY = ChartValueType.Double
				}
				, new SeriesData()
				{
					Name = "Polarization",
					ChartType = SeriesChartType.Line,
					Color = Color.FromArgb(220, 100, 10), //Color.DarkOrange
					EnableSort = true, // default is true
					//EnablePointLabel = true,
					LabelForeColor = Color.White, //.FromArgb(220, 100, 10), //60, 20, 0),
					LegendText = "Polarization *",
					YPointFormat = "0",
					UnitOfMeasure = " mV",
					LegendIndex = 1,
					LineWidth = 1,
					RequiresUserSelection = true,
					ValueTypeX = ChartValueType.String,
					ValueTypeY = ChartValueType.Double,
				}
				//, new SeriesData()
				//{
				//	Name = "Test",
				//	ChartType = SeriesChartType.FastLine,
				//	Color = Color.Violet,
				//	EnablePointLabel = false,
				//	LabelForeColor = Color.Black,
				//	LegendText = "Test 123",
				//	YPointFormat = "0.00",
				//	UnitOfMeasure = " mV",
				//	LegendIndex = 0,
				//	LineWidth = 1,
				//	ValueTypeX = ChartValueType.String,
				//	ValueTypeY = ChartValueType.Double
				//}
			};
			#endregion

			#region Points
			var rnd = new Random();
			var dict = new Dictionary<string, IPointData>();
			//string[] sNames = seriesList.Select(sd => sd.Name).ToArray();
			for (int i = 0; i < pts; i++)
			{
				string txt = string.Format("AB {0}", i + 1);

				int nativeInt = rnd.Next(0, 500);
				int instantOffInt = rnd.Next(580, 1710);
				int onInt = rnd.Next(50, 300);
				int testInt = rnd.Next(200, 250);

				double frac = instantOffInt > 1340 ? rnd.NextDouble() : 0;
				double frac2 = instantOffInt > 1340 ? rnd.NextDouble() : 0;

				double native = (i + 1) % 15 == 0 ? 0 : Math.Round(nativeInt + frac, 2);
				double instantOff = (i + 1) % 120 == 0 ? 0 : Math.Round(instantOffInt + frac2, 2);
				//double instantOff = Math.Round(instantOffInt + frac, 2);
				double on = (i + 1) % 12 == 0 ? 0 : Math.Round(onInt + frac, 2);
				double test = Math.Round(testInt + frac, 2);
				double polar = instantOff - native;
				if (polar < 0 || native == 0d)
					polar = 0;

				dict.Add(txt, new PointData()
				{
					Values = new double[] { native, instantOff, on, polar, test }
					//, Names = sNames
					, SelectedPointLabelFormat = "{0} - {1} voltage: {2}mV", // must have 3 params, or empty string
				});
			}
			#endregion Points

			//Func<KeyValuePair<string, IPointData>, object> sort1 = kvp => kvp.Key.Length;
			//Func<KeyValuePair<string, IPointData>, object> sort2 = kvp => kvp.Key;
			//Func<KeyValuePair<string, IPointData>, object> sort3 = kvp => kvp.Value.YPoints[0];

			return new ChartData()
			{
				PageSize = 40,
				//DescendingOrderBys = new bool[] { true, true },
				//Sorts = new List<Func<KeyValuePair<string, IPointData>, object>>() { sort1, sort2 }, // { sort3 } // { sort1, sort2 }
				//Sorts = new List<Func<KeyValuePair<string, IPointData>, object>>() { kvp => kvp.Value.YPoints[0] },
				Series = seriesList,
				PrimaryArrayIndex = 1, // In this case: 0 = Native, 1 = Instant Off, etc.
				PagingText = "Chart", //"Graph",
				XAxisInterval = 1d,
				TitleControl = "Pipe to Soil Potentials",
				TitleChart = "Annual Survey Data",
				TitleChart2 = "--- -850 mV Instant Off Criteria",
				TitleXAxis = "TEST STATIONS",
				TitleYAxis = "STRUCTURE-TO-SOIL POTENTIAL (-mV CSE)",
				StripLinesYAxis = new List<IStripLineContainer>() { new StripLineContainer() { StripLineValue = 850d, StripLineColor = theme.YAxis.StripLineBorderColor, StripLineStyle = theme.YAxis.StripLineChartDashStyle } },
				EnableYAxisStripLineLabels = false,
				//YAxisUnitOfMeasure = " mV", // add space?
				IsYAxisUnitOfMeasureNegative = false, // leave off the negative symbol
				YAxisLabelFormat = "{0}",
				SeriesNameComparisonOne = "Instant Off",
				SeriesNameComparisonTwo = "Native",
				SeriesNameForComparisonLabel = "Polarization", // could set it to "Instant Off"
				EnableValueLabels = true,
				ShowAllSeriesLabelText = "Show\r\nPolarization",
				EnableLegend = true,
				Points = dict,
				Theme = theme
			};
		}
	}
}
