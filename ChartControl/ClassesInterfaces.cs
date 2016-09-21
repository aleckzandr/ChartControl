using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

// TODO: Comment all classes, methods, and properties
namespace X
{
	public interface IPointContainer
	{
		string Name { get; set; }

		IPointData PointData { get; set; }
	}

	public class PointContainer : IPointContainer
	{
		public string Name { get; set; }

		public IPointData PointData { get; set; }
	}

	public class PointContainerArgs : EventArgs
	{
		private IPointContainer _pc;

		public PointContainerArgs(IPointContainer pointContainer)
		{
			_pc = pointContainer;
		}

		public IPointContainer PointContainer { get { return _pc; } }
	}

	public interface IPointData
	{
		/// <summary>
		/// An ID to use, if wanted
		/// </summary>
		int ID { get; set; } // max 2,147,483,647		//Int64 ID { get; set; } // max 9,223,372,036,854,775,807

		/// <summary>
		/// The array of values (on the y-Axis)
		/// </summary>
		double[] Values { get; set; }

		/// <summary>
		/// A fomat string for a label, must have 3 params, i.e. "{0} - {1} {2}" or empty string
		/// </summary>
		string SelectedPointLabelFormat { get; set; }

		/// <summary>
		/// An object one can associate with the IPointData
		/// </summary>
		object Bag { get; set; }
	}

	public class PointData : IPointData
	{
		/// <summary>
		/// An ID to use, if wanted
		/// </summary>
		public int ID { get; set; } // max 2,147,483,647		//Int64 ID { get; set; } // max 9,223,372,036,854,775,807

		/// <summary>
		/// The array of values (on the y-Axis)
		/// </summary>
		public double[] Values { get; set; }

		/// <summary>
		/// A fomat string for a label, must have 3 params, i.e. "{0} - {1} {2}" or empty string
		/// </summary>
		public string SelectedPointLabelFormat { get; set; }

		/// <summary>
		///  An object one can associate with the IPointData
		/// </summary>
		public object Bag { get; set; }
	}

	public interface IChartData
	{
		IEnumerable<KeyValuePair<string, IPointData>> Points { get; set; }

		bool[] DescendingOrderBys { get; set; }

		IList<Func<KeyValuePair<string, IPointData>, object>> Sorts { get; set; }

		IEnumerable<KeyValuePair<string, IPointData>> Sort<T>(
			IEnumerable<KeyValuePair<string, IPointData>> src,
			params Func<KeyValuePair<string, IPointData>, T>[] sort);

		int PrimaryArrayIndex { get; set; }

		int PageSize { get; set; }

		IList<ISeriesData> Series { get; set; }

		string CustomProperties { get; set; }

		string PagingText { get; set; } // "Chart", "Graph", etc

		string TitleControl { get; set; }

		string TitleChart { get; set; }

		string TitleChart2 { get; set; }

		string TitleXAxis { get; set; }

		string TitleYAxis { get; set; }

		string SeriesNameComparisonOne { get; set; }

		string SeriesNameComparisonTwo { get; set; }

		string SeriesNameForComparisonLabel { get; set; }

		string ShowAllSeriesLabelText { get; set; } //"Show\r\nAll Series"

		string YAxisLabelFormat { get; set; }

		string YAxisUnitOfMeasure { get; set; }

		double XAxisInterval { get; set; }

		bool XAxisIsReversed { get; set; }

		IList<IStripLineContainer> StripLinesXAxis { get; set; }

		IList<IStripLineContainer> StripLinesYAxis { get; set; }

		double YAxisMinimum { get; set; }

		double YAxisMaximum { get; set; }

		bool IsYAxisUnitOfMeasureNegative { get; set; }

		bool EnableValueLabels { get; set; }

		bool EnableYAxisStripLineLabels { get; set; }

		bool EnableLegend { get; set; }

		IList<SILegendItem> LegendItems { get; set; }

		IThemeChart Theme { get; set; }
	}

	public class ChartData : IChartData
	{
		#region instance
		public IEnumerable<KeyValuePair<string, IPointData>> Points { get; set; }

		public bool[] DescendingOrderBys { get; set; }

		private IList<Func<KeyValuePair<string, IPointData>, object>> _sorts;
		public IList<Func<KeyValuePair<string, IPointData>, object>> Sorts
		{
			get
			{
				if (_sorts == null)
					_sorts = new List<Func<KeyValuePair<string, IPointData>, object>>();
				return _sorts;
			}

			set { _sorts = value; }
		}

		public IEnumerable<KeyValuePair<string, IPointData>> Sort<T>(
			IEnumerable<KeyValuePair<string, IPointData>> src,
			params Func<KeyValuePair<string, IPointData>, T>[] sort)
		{
			var retval = DescendingOrderBys != null && DescendingOrderBys[0] ? src.OrderByDescending(sort[0]) : src.OrderBy(sort[0]);

			for (int c = 1; c < sort.Length; c++)
				retval = DescendingOrderBys != null && DescendingOrderBys.Length > c && DescendingOrderBys[c] ?
					retval.ThenByDescending(sort[c]) : retval.ThenBy(sort[c]);

			return retval;
		}

		public int PrimaryArrayIndex { get; set; }

		private int _pageSize = int.MaxValue;
		public int PageSize { get { return _pageSize; } set { _pageSize = value; } }

		public IList<ISeriesData> Series { get; set; }

		public string CustomProperties { get; set; }

		private string _pagingText = null;
		public string PagingText  // "Chart", "Graph", etc
		{
			get
			{
				if (_pagingText == null)
					_pagingText = "Chart";

				return _pagingText;
			}
			set
			{
				_pagingText = value;
			}
		}

		public string TitleControl { get; set; }

		public string TitleChart { get; set; }

		public string TitleChart2 { get; set; }

		public string TitleXAxis { get; set; }

		public string TitleYAxis { get; set; }

		public string SeriesNameComparisonOne { get; set; }

		public string SeriesNameComparisonTwo { get; set; }

		public string SeriesNameForComparisonLabel { get; set; }

		public string ShowAllSeriesLabelText { get; set; } //"Show\r\nAll Series"

		public string YAxisLabelFormat { get; set; }

		public string YAxisUnitOfMeasure { get; set; }

		private double _xAxisInterval = 1d;
		public double XAxisInterval
		{
			get { return _xAxisInterval; }
			set { _xAxisInterval = value; }
		}

		public bool XAxisIsReversed { get; set; }

		public IList<IStripLineContainer> StripLinesXAxis { get; set; }

		public IList<IStripLineContainer> StripLinesYAxis { get; set; }

		public double YAxisMinimum { get; set; }

		public double YAxisMaximum { get; set; }

		public bool IsYAxisUnitOfMeasureNegative { get; set; }

		public bool EnableValueLabels { get; set; }

		public bool EnableYAxisStripLineLabels { get; set; }

		public bool EnableLegend { get; set; }

		private IList<SILegendItem> _legendItems;
		public IList<SILegendItem> LegendItems
		{
			get
			{
				if (_legendItems == null)
					_legendItems = new List<SILegendItem>();

				return _legendItems;
			}
			set
			{
				_legendItems = value;
			}
		}

		public IThemeChart Theme { get; set; }

		#endregion

		#region static

		// see https://msdn.microsoft.com/en-us/library/dd456764.aspx
		public const string SeriesCustomPropsDefault = "DrawingStyle=Cylinder, EmptyPointValue=Zero, PointWidth=0.5";

		public static Series CreateSeries(IChartData chartData, ISeriesData isd, string chartAreaName, string customProperties = SeriesCustomPropsDefault)
		{
			var sz = new Series()
			{
				BorderWidth = isd.LineWidth > 0 ? isd.LineWidth : 1,
				ChartArea = chartAreaName,
				ChartType = isd.ChartType,
				Color = isd.Color,
				CustomProperties = isd.CustomProperties != null ? isd.CustomProperties : chartData.CustomProperties != null ? chartData.CustomProperties : customProperties, // allow empty string
				Enabled = !isd.RequiresUserSelection,
				Font = chartData.Theme.SeriesFont,
				LabelForeColor = isd.LabelForeColor,
				Legend = chartData.EnableLegend && chartData.Theme.Legends.Count > isd.LegendIndex ? chartData.Theme.Legends[isd.LegendIndex].Name : null,
				LegendText = isd.LegendText,
				Name = isd.Name,
				XValueType = isd.ValueTypeX,
				YValueType = isd.ValueTypeY
			};

			return sz;
		}

		public static Dictionary<string, IPointData> GetRandomPointData(int numOfRecords, IList<ISeriesData> seriesData, string pointFormat = "TS # ")
		{
			//Int32.MaxValue; // 2,147,483,647
			var rnd = new Random();
			var dict = new Dictionary<string, IPointData>();
			int x = numOfRecords > 0 ? numOfRecords : 20;
			//string[] sNames = seriesData.Select(sd => sd.Name).ToArray();
			for (int i = x - 1; i > -1; i--)
			{
				string txt = string.Format("{0}{1}", pointFormat, i + 1);

				int nativeInt = rnd.Next(0, 500);
				int instantOffInt = rnd.Next(572, 1730);
				int onInt = rnd.Next(40, 1200);
				int testInt = rnd.Next(20, 1800);

				double frac = instantOffInt > 1540 ? rnd.NextDouble() : 0;
				double frac2 = instantOffInt > 1540 ? rnd.NextDouble() : 0;

				double native = (i + 1) % 15 == 0 ? 0 : Math.Round(nativeInt + frac, 2);
				double instantOff = (i + 1) % 60 == 0 ? 0 : Math.Round(instantOffInt + frac2, 2);
				double on = (i + 1) % 12 == 0 ? 0 : Math.Round(onInt + frac, 2);
				double test = Math.Round(testInt + frac, 2);
				double polar = instantOff - native;
				if (polar < 0 || native == 0d)
					polar = 0;

				dict.Add(txt, new PointData()
				{
					Values = new double[] { native, instantOff, on, polar, test }
					//, Names = sNames
					, SelectedPointLabelFormat = "{0} {1} voltage: {2}mV" // must have 3 params, i.e. "{0} - {1} {2}" or empty string
				});
			}

			return dict;
		}

		public static IChartData GetTestSurveyData(int numOfRecords, ChartThemeStyle cThemeStyle = ChartThemeStyle.Dark)
		{
			var theme = new ThemeChart(cThemeStyle);

			#region Series List
			var seriesList = new List<ISeriesData>()
			{
				new SeriesData()
				{
					Name = "Native",
					ChartType = SeriesChartType.StackedColumn,
					Color = Color.FromArgb(90, 120, 48), // (20, 220, 20), //(146, 215, 79), //(52, 88, 48),  //(90, 120, 48),
					LabelForeColor = Color.White, //FromArgb(20, 220, 20),
					LegendText = "Native",
					EnablePointLabel = false,
					YPointFormat = "0.00",
					UnitOfMeasure = " mV",
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
					EnablePointLabel = false,
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
					LabelForeColor = Color.White, //, Color.FromArgb(20, 20, 220),
					LegendText = "On",
					EnablePointLabel = false,
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
					EnableSort = true,
					LabelForeColor = theme.ForeColor,
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
				//	ChartType = SeriesChartType.Line, // FastLine
				//	Color = Color.Violet,
				//	EnablePointLabel = true,
				//	EnableSort = false,
				//	LabelForeColor = Color.Violet,
				//	LegendText = "Test Data",
				//	YPointFormat = "0.00",
				//	UnitOfMeasure = " mV",
				//	LegendIndex = 0,
				//	LineWidth = 1,
				//	ValueTypeX = ChartValueType.String,
				//	ValueTypeY = ChartValueType.Double
				//}
			};
			#endregion

			//Func<KeyValuePair<string, IPointData>, object> sort1 = kvp => kvp.Key.Length;
			//Func<KeyValuePair<string, IPointData>, object> sort2 = kvp => kvp.Key;
			//Func<KeyValuePair<string, IPointData>, object> sort3 = kvp => kvp.Value.YPoints[seriesRed];

			var cd = new ChartData()
			{
				PageSize = 400,
				//DescendingOrderBys = new bool[] { true, true },
				//Sorts = new List<Func<KeyValuePair<string, IPointData>, object>>() { sort1, sort2 }, // { sort3 } // { sort1, sort2 }
				//Sorts = new List<Func<KeyValuePair<string, IPointData>, object>>() { kvp.Value.YPoints[0] },
				Sorts = new List<Func<KeyValuePair<string, IPointData>, object>>() { kvp => kvp.Key.Length, kvp => kvp.Key },
				Series = seriesList,
				PrimaryArrayIndex = 1, // In this case: 0 = Native, 1 = Instant Off, etc.
				PagingText = "Chart", // "Graph", "Chart", etc.
				XAxisInterval = 1d, // 1d = every point has an axis label, 5d = every 5th point has an axis label
				TitleControl = "Pipe to soil potentials",
				TitleChart = "Survey Data",
				TitleChart2 = "--- -850 mV instant off criteria",
				TitleXAxis = "Test Stations",
				TitleYAxis = "Structure-to-Soil Potential (-mV CSE)",
				StripLinesYAxis = new List<IStripLineContainer>() {
					new StripLineContainer()
					{
						StripLineValue = 850d,
						StripLineColor = theme.YAxis.StripLineBorderColor,
						StripLineStyle = theme.YAxis.StripLineChartDashStyle,
						ForeColor =  theme.YAxis.StripLineForeColor,
						Width = theme.YAxis.StripLineBorderWidth
					}
				},
				EnableYAxisStripLineLabels = true,
				YAxisUnitOfMeasure = " mV",
				IsYAxisUnitOfMeasureNegative = true,
				YAxisLabelFormat = "{0}",
				SeriesNameComparisonOne = "Instant Off",
				SeriesNameComparisonTwo = "Native",
				SeriesNameForComparisonLabel = "Polarization", // could set it to "Instant Off"
				EnableValueLabels = true,
				ShowAllSeriesLabelText = "Show\r\nPolarization",
				EnableLegend = true,
				Points = GetRandomPointData(numOfRecords, seriesList),
				Theme = theme
			};

			// Add custom legend items here:
			cd.LegendItems.Add(new SILegendItem()
			{
				BorderColor = Color.Empty,
				BorderDashStyle = ChartDashStyle.DashDotDot,
				BorderWidth = 3,
				Color = Color.Fuchsia,
				ImageStyle = LegendImageStyle.Line,
				Name = "Cuztom",
				LegendIndex = 0
			});

			return cd;
		}

		public static IChartData GetTestAmperageData(int numOfRecords, ChartThemeStyle cThemeStyle = ChartThemeStyle.Dark)
		{
			var theme = new ThemeChart(cThemeStyle);

			#region Series
			var seriesList = new List<ISeriesData>()
			{
				new SeriesData()
				{
					Name = "Amperage",
					ChartType = SeriesChartType.Line,
					Color = Color.FromArgb(90, 120, 48), // (20, 220, 20), //(146, 215, 79), //(52, 88, 48),  //(90, 120, 48),
					EnablePointLabel = false,
					LabelForeColor = Color.White, //FromArgb(20, 220, 20),
					LegendText = "Amperage",
					YPointFormat = "0.00",
					UnitOfMeasure = " mA", // note space
					LegendIndex = 0,
					LineWidth = 2,
					ValueTypeX = ChartValueType.String,
					ValueTypeY = ChartValueType.Double
				}
			};
			#endregion

			#region Points
			var rnd = new Random();
			var dict = new Dictionary<string, IPointData>();
			//string[] sNames = seriesList.Select(sd => sd.Name).ToArray();
			DateTime start = new DateTime(2012, 7, 1);
			for (int i = 0; i < numOfRecords; i++)
			{
				string txt = start.ToString("MM-yy");
				start = start.AddMonths(1);

				int dataInt = rnd.Next(27, 32);

				double frac = dataInt > 31 ? rnd.NextDouble() : 0;

				double dat = Math.Round(dataInt + frac, 2);

				dict.Add(txt, new PointData()
				{
					Values = new double[] { dat }
					, SelectedPointLabelFormat = "{0} - {1} : {2}mA", // must have 3 params, or empty string
				});
			}
			#endregion Points

			return new ChartData()
			{
				PageSize = numOfRecords,
				//DescendingOrderBys = new bool[] { true, true },
				//Sorts = new List<Func<KeyValuePair<string, IPointData>, object>>() { sort1, sort2 }, // { sort3 } // { sort1, sort2 }
				//Sorts = new List<Func<KeyValuePair<string, IPointData>, object>>() { kvp => kvp.Value.YPoints[0] },
				Series = seriesList,
				PrimaryArrayIndex = 0,
				PagingText = "Chart", //"Graph",
				XAxisInterval = 1d,
				TitleControl = "Current Output",
				TitleChart = "",
				TitleChart2 = "",
				TitleXAxis = "",
				TitleYAxis = "Amperage (A)",
				StripLinesYAxis = new List<IStripLineContainer>()
				{
					new StripLineContainer()
					{
						StripLineValue = 25d,
						StripLineColor = theme.YAxis.StripLineBorderColor,
						StripLineStyle = theme.YAxis.StripLineChartDashStyle,
						ForeColor =  theme.YAxis.StripLineForeColor,
						Width = theme.YAxis.StripLineBorderWidth
					},
					new StripLineContainer()
					{
						StripLineValue = 35d,
						StripLineColor = theme.YAxis.StripLineBorderColor,
						StripLineStyle = theme.YAxis.StripLineChartDashStyle,
						ForeColor = theme.YAxis.StripLineForeColor,
						Width = theme.YAxis.StripLineBorderWidth
					}
				},
				YAxisMaximum = 40d,
				YAxisMinimum = 20d,
				EnableYAxisStripLineLabels = false,
				//YAxisUnitOfMeasure = " mA", // add space?
				IsYAxisUnitOfMeasureNegative = false, // leave off the negative symbol
				YAxisLabelFormat = "{0}",
				EnableValueLabels = false,
				ShowAllSeriesLabelText = "",
				EnableLegend = false,
				Points = dict,
				Theme = theme
			};
		}

		public static IChartData GetTestOhmData(int numOfRecords, ChartThemeStyle theme = ChartThemeStyle.Dark)
		{
			#region Series
			var seriesList = new List<ISeriesData>()
			{
				new SeriesData()
				{
					Name = "Ohms",
					ChartType = SeriesChartType.Line,
					Color = Color.FromArgb(90, 120, 48), // (20, 220, 20), //(146, 215, 79), //(52, 88, 48),  //(90, 120, 48),
					EnablePointLabel = false,
					LabelForeColor = Color.White, //FromArgb(20, 220, 20),
					LegendText = "Ohms",
					YPointFormat = "0.00",
					UnitOfMeasure = " ", // note space
					LegendIndex = 0,
					LineWidth = 2,
					ValueTypeX = ChartValueType.String,
					ValueTypeY = ChartValueType.Double
				}
			};
			#endregion

			#region Points
			var rnd = new Random();
			var dict = new Dictionary<string, IPointData>();
			//string[] sNames = seriesList.Select(sd => sd.Name).ToArray();
			DateTime start = new DateTime(2012, 7, 1);
			for (int i = 0; i < numOfRecords; i++)
			{
				string txt = start.ToString("MM-yy");
				start = start.AddMonths(1);

				double dataInt = 1.1d;

				double frac = rnd.NextDouble();
				frac = frac > 0.9d ? 0.9 : frac;

				double dat = Math.Round(dataInt + frac, 2);

				dict.Add(txt, new PointData()
				{
					Values = new double[] { dat }
					, SelectedPointLabelFormat = "{0} - {1} : {2}", // must have 3 params, or empty string
				});
			}
			#endregion Points

			return new ChartData()
			{
				PageSize = numOfRecords,
				//DescendingOrderBys = new bool[] { true, true },
				//Sorts = new List<Func<KeyValuePair<string, IPointData>, object>>() { sort1, sort2 }, // { sort3 } // { sort1, sort2 }
				//Sorts = new List<Func<KeyValuePair<string, IPointData>, object>>() { kvp => kvp.Value.YPoints[0] },
				Series = seriesList,
				PrimaryArrayIndex = 0,
				PagingText = "Chart", //"Graph",
				XAxisInterval = 1d,
				TitleControl = "Circuit Resistance",
				TitleChart = "",
				TitleChart2 = "",
				TitleXAxis = "",
				TitleYAxis = "Ohms (Ω)",
				//StripLinesYAxis = new double[] { 0d, 0d },
				YAxisMaximum = 2d,
				//YAxisMinimum = 0d,
				EnableYAxisStripLineLabels = false,
				//YAxisUnitOfMeasure = " mA", // add space?
				IsYAxisUnitOfMeasureNegative = false, // leave off the negative symbol
				YAxisLabelFormat = "{0}",
				EnableValueLabels = false,
				ShowAllSeriesLabelText = "",
				EnableLegend = false,
				Points = dict,
				Theme = new ThemeChart(theme)
			};
		}

		/// <summary>
		/// Method to bind data to a chart control
		/// </summary>
		/// <param name="data"></param>
		/// <param name="pChart"></param>
		public static void Bind(IChartData data, Chart pChart, bool enableXAxisCursor = false, bool enableYAxisCursor = false) // if data.Points is null this method bombs, which we want
		{
			pChart.Legends.Clear();
			pChart.Series.Clear();

			var pointData = data.Sorts != null && data.Sorts.Count > 0 ? data.Sort(data.Points, data.Sorts.ToArray()) : data.Points;

			#region Chart Area initialization, cursors, and theme/color stuff
			ChartArea ca;
			if (pChart.ChartAreas.Count > 0)
			{
				ca = pChart.ChartAreas[0];
				ca.AxisX.StripLines.Clear();
				ca.AxisY.StripLines.Clear();
			}
			else
			{
				ca = new ChartArea("Main");
				pChart.ChartAreas.Add(ca);
			}

			// mutual chart theme stuff
			pChart.BackColor = data.Theme.BackColor;
			pChart.BackGradientStyle = data.Theme.BackGradientStyle;
			pChart.BackSecondaryColor = data.Theme.BackSecondaryColor;
			pChart.BorderlineColor = data.Theme.BorderColor;

			// mutual chart ~area~ theme stuff (regardless if using a new ChartArea or not) 
			ca.BackColor = data.Theme.AreaBackColor;
			ca.BackGradientStyle = data.Theme.AreaBackGradientStyle;
			ca.BackSecondaryColor = data.Theme.AreaBackSecondaryColor;
			ca.BorderColor = data.Theme.AreaBorderColor;

			#region Chart X-Axis

			ca.AxisX.StripLines.Clear();
			ca.CursorX.IsUserEnabled = enableXAxisCursor;
			ca.CursorX.IsUserSelectionEnabled = enableXAxisCursor;
			ca.CursorX.LineWidth = data.Theme.XAxis.StripLineBorderWidth;
			ca.CursorX.SelectionColor = data.Theme.XAxis.StripLineBorderColor;

			ca.AxisX.Interval = data.XAxisInterval;
			ca.AxisX.IsReversed = data.XAxisIsReversed;

			ca.AxisX.Title = data.TitleXAxis ?? ca.AxisX.Title;
			ca.AxisX.TitleFont = data.Theme.XAxis.TitleFont;
			ca.AxisX.TitleForeColor = data.Theme.XAxis.TitleForeColor;
			ca.AxisX.InterlacedColor = data.Theme.XAxis.InterlacedColor;
			ca.AxisX.LabelStyle.ForeColor = data.Theme.XAxis.LabelStyleForeColor;
			if (data.Theme.XAxis.LabelStyleFormat != null)
				ca.AxisX.LabelStyle.Format = data.Theme.XAxis.LabelStyleFormat;
			ca.AxisX.LineColor = data.Theme.XAxis.LineColor;
			ca.AxisX.MajorGrid.LineColor = data.Theme.XAxis.MajorGridLineColor;
			ca.AxisX.MajorTickMark.Enabled = data.Theme.XAxis.MajorTickMarkEnabled;
			ca.AxisX.MajorTickMark.LineColor = data.Theme.XAxis.MajorTickMarkColor;

			#endregion

			#region Chart Y-Axis

			ca.AxisY.StripLines.Clear();
			ca.CursorY.IsUserEnabled = enableYAxisCursor;
			ca.CursorY.IsUserSelectionEnabled = enableYAxisCursor;
			ca.CursorY.LineWidth = data.Theme.YAxis.StripLineBorderWidth;
			ca.CursorY.SelectionColor = data.Theme.YAxis.StripLineBorderColor;

			if (data.YAxisMinimum > 0)
			{
				ca.AxisY.IsStartedFromZero = ca.AxisY2.IsStartedFromZero = false;
				ca.AxisY.Minimum = ca.AxisY2.Minimum = data.YAxisMinimum;
			}

			if (data.YAxisMaximum > 0)
				ca.AxisY.Maximum = ca.AxisY2.Maximum = data.YAxisMaximum;

			ca.AxisY.Title = data.TitleYAxis ?? ca.AxisY.Title;
			ca.AxisY.TitleFont = ca.AxisY2.TitleFont = data.Theme.YAxis.TitleFont;
			ca.AxisY.TitleForeColor = ca.AxisY2.TitleForeColor = data.Theme.YAxis.TitleForeColor;
			ca.AxisY.InterlacedColor = ca.AxisY2.InterlacedColor = data.Theme.YAxis.InterlacedColor;
			ca.AxisY.LabelStyle.ForeColor = ca.AxisY2.LabelStyle.ForeColor = data.Theme.YAxis.LabelStyleForeColor;
			if (data.Theme.YAxis.LabelStyleFormat != null)
				ca.AxisY.LabelStyle.Format = data.Theme.YAxis.LabelStyleFormat;
			ca.AxisY.LineColor = ca.AxisY2.LineColor = data.Theme.YAxis.LineColor;
			ca.AxisY.MajorGrid.LineColor = ca.AxisY2.MajorGrid.LineColor = data.Theme.YAxis.MajorGridLineColor;
			ca.AxisY.MajorTickMark.Enabled = ca.AxisY2.MajorTickMark.Enabled = data.Theme.YAxis.MajorTickMarkEnabled;
			ca.AxisY.MajorTickMark.LineColor = ca.AxisY2.MajorTickMark.LineColor = data.Theme.YAxis.MajorTickMarkColor;

			#endregion

			#endregion

			#region Chart Titles (note: does not delete any titles in list, only adds them)
			var tlCount = data.Theme.Titles.Count;
			if (!string.IsNullOrEmpty(data.TitleChart) && tlCount > 0)
			{
				var mainTitle = data.Theme.Titles[0];
				pChart.Titles.Add(new Title()
				{
					Docking = mainTitle.Docking,
					IsDockedInsideChartArea = mainTitle.IsDockedInsideChartArea,
					DockedToChartArea = ca.Name,
					Font = mainTitle.Font,
					ForeColor = mainTitle.Color,
					Position = mainTitle.Position,
					Name = mainTitle.Name,
					Text = data.TitleChart
				});
			}

			if (!string.IsNullOrEmpty(data.TitleChart2) && tlCount > 1)
			{
				var subTitle = data.Theme.Titles[1];
				pChart.Titles.Add(new Title()
				{
					Docking = subTitle.Docking,
					IsDockedInsideChartArea = subTitle.IsDockedInsideChartArea,
					DockedToChartArea = ca.Name,
					Font = subTitle.Font,
					ForeColor = subTitle.Color,
					Position = subTitle.Position,
					Name = subTitle.Name,
					Text = data.TitleChart2
				});
			}
			#endregion

			#region Chart Legends (note: 
			// this must be done before Series
			if (data.EnableLegend)
			{
				int lgdIdx = 0;
				foreach (var lg in data.Theme.Legends)
				{
					var lgd = new Legend()
					{
						AutoFitMinFontSize = lg.AutoFitMinFontSize,
						BackColor = lg.BackColor,
						BorderColor = lg.BorderColor,
						Font = lg.Font,
						ForeColor = lg.ForeColor,
						IsTextAutoFit = lg.IsTextAutoFit,
						LegendItemOrder = lg.LegendItemOrder,
						LegendStyle = lg.LegendStyle,
						MaximumAutoSize = lg.MaximumAutoSize,
						Name = lg.Name,
						Position = lg.Position
					};

					if (data.LegendItems != null)
						foreach (var li in data.LegendItems.Where(x => x.LegendIndex == lgdIdx))
							lgd.CustomItems.Add(li);

					pChart.Legends.Add(lgd);
					lgdIdx++;
				}
			}
			#endregion

			#region Strip Lines
			if (data.StripLinesYAxis != null && data.StripLinesYAxis.Any())
			{
				foreach (var stripLine in data.StripLinesYAxis)
				{
					ca.AxisY.StripLines.Add(new StripLine()
					{
						BorderColor = stripLine.StripLineColor,
						BorderDashStyle = stripLine.StripLineStyle,
						BorderWidth = stripLine.Width,
						ForeColor = stripLine.ForeColor,
						IntervalOffset = stripLine.StripLineValue,
						ToolTip = string.Format("{0} {1}", stripLine.StripLineValue, data.YAxisUnitOfMeasure) // stripLine.ToolTip
					});

					if (data.EnableYAxisStripLineLabels)
					{
						ca.AxisY2.Enabled = AxisEnabled.True;
						ca.AxisY2.CustomLabels.Add(new CustomLabel()
						{
							ForeColor = stripLine.ForeColor,
							FromPosition = stripLine.StripLineValue - 10,
							MarkColor = stripLine.StripLineColor,
							Text = string.Format("{0}{1}{2}", (data.IsYAxisUnitOfMeasureNegative ? "-" : ""), stripLine.StripLineValue, data.YAxisUnitOfMeasure),
							ToPosition = stripLine.StripLineValue + 10
						});
					}
				}
			}
			#endregion

			// note legends must be done first
			foreach (var isd in data.Series)
				pChart.Series.Add(CreateSeries(data, isd, ca.Name));

			if (data.PrimaryArrayIndex > pChart.Series.Count - 1)
				data.PrimaryArrayIndex = pChart.Series.Count - 1; // trys to prevent out of range exception

			Series primary = pChart.Series[data.PrimaryArrayIndex];

			var srs = data.Series.ElementAt(data.PrimaryArrayIndex); // cannot be out of range

			int dpi = 0; // data point index
			foreach (var kvp in pointData)
			{
				if (kvp.Value != null && kvp.Value.Values != null && kvp.Value.Values.Length > 0)
				{
					double yValue = kvp.Value.Values[data.PrimaryArrayIndex]; // still potential out of range

					primary.Points.Add(new DataPoint(dpi, yValue)
					{
						AxisLabel = kvp.Key,
						Tag = new PointContainer() { Name = kvp.Key, PointData = kvp.Value },
						ToolTip = string.Format("{0}: {1}{2}", srs.Name, yValue.ToString(srs.YPointFormat), srs.UnitOfMeasure)
					});

					for (int si = 0; si < pChart.Series.Count; si++)
					{
						if (si == data.PrimaryArrayIndex) // if so we  use the datapoint above in primary series
							continue;

						if (kvp.Value.Values.Length > si) // because we are iterating through series, not the array elements
						{
							double jValue = kvp.Value.Values[si];
							var srx = data.Series.ElementAt(si);

							pChart.Series[si].Points.Add(new DataPoint(dpi, jValue)
							{
								ToolTip = string.Format("{0}: {1}{2}", srx.Name, jValue.ToString(srx.YPointFormat), srx.UnitOfMeasure)
							});
						}
					}
				}
				dpi++;
			}
		}

		#endregion
	}

	#region Themes, Styles, Fonts, etc.

	public interface IThemeChart
	{
		ChartThemeStyle Style { get; set; }

		Color PanelColor1 { get; set; }

		Color PanelColor2 { get; set; }

		Color ControlBackColor1 { get; set; }

		Color ControlBackColor2 { get; set; }

		Color ControlBorderColor { get; set; }

		Color ControlFaintSelection { get; set; }

		Color ForeColor { get; set; }

		Color BackColor { get; set; }

		Color BackColor2 { get; set; }

		Color BackSecondaryColor { get; set; }

		Color BorderColor { get; set; }

		GradientStyle BackGradientStyle { get; set; }

		// Area

		Color AreaBackColor { get; set; }

		Color AreaBackSecondaryColor { get; set; }

		Color AreaBorderColor { get; set; }

		Font SeriesFont { get; set; }

		GradientStyle AreaBackGradientStyle { get; set; }

		IThemeAxis XAxis { get; set; }

		IThemeAxis YAxis { get; set; }

		IList<IThemeTitle> Titles { get; set; }

		IList<IThemeLegend> Legends { get; set; }
	}

	public class ThemeChart : IThemeChart
	{
		public ThemeChart() : this (ChartThemeStyle.Dark) { }

		public ThemeChart(bool useDefaultTheme) { if (useDefaultTheme) Set(ChartThemeStyle.Dark); }

		public ThemeChart(ChartThemeStyle style)
		{
			Set(style);
		}

		private void Set(ChartThemeStyle style)
		{
			Style = style;

			switch (Style)
			{
				/////////////////////////
				case ChartThemeStyle.Light:
					/////////////////////////
					PanelColor1 = Color.FromArgb(255, 240, 210); //Bisque = FromArgb(255, 228, 196);
					PanelColor2 = Color.WhiteSmoke;
					ControlBackColor1 = Color.Transparent;
					ControlBackColor2 = Color.FromArgb(228, 228, 228);
					ControlBorderColor = Color.DarkRed;
					ControlFaintSelection = Color.Silver;
					ForeColor = Color.Black;
					BackColor = Color.White;
					BackColor2 = Color.WhiteSmoke;
					BackSecondaryColor = Color.Empty;
					BorderColor = Color.White;
					SeriesFont = new Font("Verdana", 8F);
					BackGradientStyle = GradientStyle.DiagonalRight;
					AreaBackColor = Color.FromArgb(255, 224, 192);
					AreaBackSecondaryColor = Color.Empty;
					AreaBorderColor = Color.Black;
					AreaBackGradientStyle = GradientStyle.TopBottom;
					XAxis = new ThemeAxis()
					{
						AxisName = "X-Axis",
						InterlacedColor = Color.Empty,
						LabelStyleForeColor = this.ForeColor,
						LineColor = this.ForeColor,
						MajorGridLineColor = Color.Silver,
						MajorTickMarkLineColor = Color.Transparent,
						ChartDashStyle = ChartDashStyle.NotSet,
						TitleForeColor = this.ForeColor,
						TitleFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0),
						MajorTickMarkEnabled = false,
						MajorTickMarkStyle = TickMarkStyle.InsideArea,
						MajorTickMarkColor = this.ForeColor,
						StripLineBorderColor = this.ControlBorderColor,
						StripLineChartDashStyle = ChartDashStyle.DashDot,
						StripLineBorderWidth = 2,
						StripLineForeColor = Color.White
					};
					YAxis = new ThemeAxis()
					{
						AxisName = "Y-Axis",
						InterlacedColor = Color.Silver,
						LabelStyleForeColor = this.ForeColor,
						LineColor = this.ForeColor,
						MajorGridLineColor = Color.Silver,
						MajorTickMarkLineColor = this.ForeColor,
						TitleForeColor = this.ForeColor,
						ChartDashStyle = ChartDashStyle.Dash,
						TitleFont = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
						MajorTickMarkEnabled = true,
						MajorTickMarkStyle = TickMarkStyle.InsideArea,
						MajorTickMarkColor = this.ForeColor,
						StripLineBorderColor = Color.DarkOrange,
						StripLineChartDashStyle = ChartDashStyle.DashDot,
						StripLineBorderWidth = 2,
						StripLineForeColor = this.ForeColor
					};
					Titles = new List<IThemeTitle>()
					{
						new ThemeTitle()
						{
							Name = "Title1",
							Color = this.ForeColor,
							Docking = Docking.Top,
							Position = new ElementPosition() { Auto = false, Width = 100f, Y = 10F },
							Font = new Font("Verdana", 13F, FontStyle.Bold)
						},
						new ThemeTitle()
						{
							Name = "Title2",
							Color = Color.DarkOrange,
							Docking = Docking.Bottom,
							IsDockedInsideChartArea = false,
							Position = new ElementPosition() { Auto = false, Height = 6f, Width = 90f, X = 6.8f, Y = 94f },
							Font = new Font("Arial", 9F, FontStyle.Bold)
						}
					};
					Legends = new List<IThemeLegend>()
					{
						new ThemeLegend()
						{
							AutoFitMinFontSize = 6,
							BackColor = this.BackColor2,
							BorderColor = this.ControlBorderColor,
							Font = new Font("Arial", 8F, FontStyle.Bold),
							ForeColor = this.ForeColor,
							IsTextAutoFit = false,
							LegendItemOrder = LegendItemOrder.ReversedSeriesOrder,
							LegendStyle = LegendStyle.Row,
							MaximumAutoSize = 36f,
							Name = "Legend1",
							Position = new ElementPosition() { Auto = false, Height = 6f, Width = 36f, X = 1f, Y = 94f }
						}
						, new ThemeLegend()
						{
							AutoFitMinFontSize = 6,
							BackColor = BackColor2,
							BorderColor = ControlBorderColor,
							Font = new Font("Arial", 8F, FontStyle.Bold),
							ForeColor = Color.Black,
							IsTextAutoFit = false,
							LegendItemOrder = LegendItemOrder.ReversedSeriesOrder,
							LegendStyle = LegendStyle.Row,
							MaximumAutoSize = 36f,
							Name = "Legend2",
							Position = new ElementPosition() { Auto = false, Height = 6f, Width = 15.0f, X = 82f, Y = 94f }
						}
					};
					break;
				/////////////////////////
				default: // Dark
						 /////////////////////////
					PanelColor1 = Color.FromArgb(40, 30, 30);
					PanelColor2 = Color.FromArgb(20, 10, 10);
					ControlBackColor1 = Color.Transparent;
					ControlBackColor2 = Color.FromArgb(62, 38, 38);
					ControlBorderColor = Color.FromArgb(80, 10, 10);
					ControlFaintSelection = Color.FromArgb(82, 52, 52);
					ForeColor = Color.White;
					BackColor = Color.FromArgb(30, 22, 22);
					BackColor2 = Color.FromArgb(26, 16, 16);
					BackSecondaryColor = Color.FromArgb(26, 16, 16);
					BorderColor = Color.Black;
					SeriesFont = new Font("Verdana", 8F, FontStyle.Regular);
					BackGradientStyle = GradientStyle.Center;
					AreaBackColor = Color.FromArgb(80, 64, 66);
					AreaBackSecondaryColor = Color.FromArgb(30, 22, 22);
					AreaBorderColor = Color.FromArgb(30, 22, 22);
					AreaBackGradientStyle = GradientStyle.Center;
					XAxis = new ThemeAxis()
					{
						AxisName = "X-Axis",
						InterlacedColor = this.ForeColor,
						LabelStyleForeColor = this.ForeColor,
						LineColor = this.ControlBorderColor,
						MajorGridLineColor = Color.FromArgb(84, 64, 70),
						MajorTickMarkLineColor = Color.Transparent,
						ChartDashStyle = ChartDashStyle.NotSet,
						TitleForeColor = this.ForeColor,
						TitleFont = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
						MajorTickMarkEnabled = false,
						MajorTickMarkStyle = TickMarkStyle.None,
						MajorTickMarkColor = Color.Empty,
						StripLineBorderColor = this.ControlBorderColor,
						StripLineChartDashStyle = ChartDashStyle.DashDot,
						StripLineBorderWidth = 2,
						StripLineForeColor = Color.White
					};
					YAxis = new ThemeAxis()
					{
						AxisName = "Y-Axis",
						InterlacedColor = this.ForeColor,
						LabelStyleForeColor = this.ForeColor,
						LineColor = this.ControlBorderColor,
						MajorGridLineColor = Color.FromArgb(84, 64, 70),
						MajorTickMarkLineColor = Color.Empty,
						TitleForeColor = this.ForeColor,
						ChartDashStyle = ChartDashStyle.NotSet, //.Solid ??
						TitleFont = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
						MajorTickMarkEnabled = true,
						MajorTickMarkStyle = TickMarkStyle.None,
						MajorTickMarkColor = Color.Empty,
						StripLineBorderColor = Color.Yellow,
						StripLineChartDashStyle = ChartDashStyle.DashDot,
						StripLineBorderWidth = 2,
						StripLineForeColor = this.ForeColor
					};
					Titles = new List<IThemeTitle>()
					{
						new ThemeTitle()
						{
							Name = "Title1",
							Color = this.ForeColor,
							Docking = Docking.Top,
							Position = new ElementPosition() { Auto = false, Width = 100f, Y = 10F },
							Font = new Font("Verdana", 13F, FontStyle.Bold)
						},
						new ThemeTitle()
						{
							Name = "Title2",
							Color = Color.Yellow,
							Docking = Docking.Bottom,
							IsDockedInsideChartArea = false,
							Position = new ElementPosition() { Auto = false, Height = 6f, Width = 90f, X = 6.8f, Y = 94f },
							Font = new Font("Arial", 9f, FontStyle.Bold)
						}
					};
					Legends = new List<IThemeLegend>()
					{
						new ThemeLegend()
						{
							AutoFitMinFontSize = 6,
							BackColor = this.BackColor2,
							BorderColor = this.ControlBorderColor,
							Font = new Font("Arial", 8F, FontStyle.Bold),
							ForeColor = this.ForeColor,
							IsTextAutoFit = false,
							LegendItemOrder = LegendItemOrder.ReversedSeriesOrder,
							LegendStyle = LegendStyle.Row,
							MaximumAutoSize = 36f,
							Name = "Legend1",
							Position = new ElementPosition() { Auto = false, Height = 6f, Width = 36f, X = 1f, Y = 94f }
						}
						, new ThemeLegend()
						{
							AutoFitMinFontSize = 6,
							BackColor = this.BackColor2,
							BorderColor = this.ControlBorderColor,
							Font = new Font("Arial", 8F, FontStyle.Bold),
							ForeColor = Color.White,
							IsTextAutoFit = false,
							LegendItemOrder = LegendItemOrder.ReversedSeriesOrder,
							LegendStyle = LegendStyle.Row,
							MaximumAutoSize = 36f,
							Name = "Legend2",
							Position = new ElementPosition() { Auto = false, Height = 6f, Width = 15.0f, X = 82f, Y = 94f }
						}
					};
					break;
			}
		}

		public ChartThemeStyle Style { get; set; }

		public Color PanelColor1 { get; set; }

		public Color PanelColor2 { get; set; }

		public Color ControlBackColor1 { get; set; }

		public Color ControlBackColor2 { get; set; }

		public Color ControlBorderColor { get; set; }

		public Color ControlFaintSelection { get; set; }

		public Color ForeColor { get; set; }

		public Color BackColor { get; set; }

		public Color BackColor2 { get; set; }

		public Color BackSecondaryColor { get; set; }

		public Color BorderColor { get; set; }

		public Font SeriesFont { get; set; }

		public GradientStyle BackGradientStyle { get; set; }

		// currently means we only support on Chart Area per Chart
		public Color AreaBackColor { get; set; }

		public Color AreaBackSecondaryColor { get; set; }

		public Color AreaBorderColor { get; set; }

		public GradientStyle AreaBackGradientStyle { get; set; }

		public IThemeAxis XAxis { get; set; }

		public IThemeAxis YAxis { get; set; }

		public IList<IThemeTitle> Titles { get; set; }

		public IList<IThemeLegend> Legends { get; set; }
	}

	public interface IThemeAxis
	{
		string AxisName { get; set; }

		Color InterlacedColor { get; set; }

		Color LabelStyleForeColor { get; set; }

		string LabelStyleFormat { get; set; }

		Color LineColor { get; set; }

		Color MajorGridLineColor { get; set; }

		Color MajorTickMarkLineColor { get; set; }

		Color TitleForeColor { get; set; }

		Font TitleFont { get; set; }

		ChartDashStyle ChartDashStyle { get; set; }

		bool MajorTickMarkEnabled { get; set; }

		TickMarkStyle MajorTickMarkStyle { get; set; }

		Color MajorTickMarkColor { get; set; }

		Color StripLineBorderColor { get; set; }

		Color StripLineBorderColor2 { get; set; }

		ChartDashStyle StripLineChartDashStyle { get; set; }

		int StripLineBorderWidth { get; set; }

		Color StripLineForeColor { get; set; }
	}

	public class ThemeAxis : IThemeAxis
	{
		public string AxisName { get; set; }

		public Color InterlacedColor { get; set; }

		public Color LabelStyleForeColor { get; set; }

		public string LabelStyleFormat { get; set; }

		public Color LineColor { get; set; }

		public Color MajorGridLineColor { get; set; }

		public Color MajorTickMarkLineColor { get; set; }

		public Color TitleForeColor { get; set; }

		public Font TitleFont { get; set; }

		public ChartDashStyle ChartDashStyle { get; set; }

		public bool MajorTickMarkEnabled { get; set; }

		public TickMarkStyle MajorTickMarkStyle { get; set; }

		public Color MajorTickMarkColor { get; set; }

		public Color StripLineBorderColor { get; set; }

		public Color StripLineBorderColor2 { get; set; }

		public ChartDashStyle StripLineChartDashStyle { get; set; }

		public int StripLineBorderWidth { get; set; }

		public Color StripLineForeColor { get; set; }
	}

	public interface IThemeLegend
	{
		int AutoFitMinFontSize { get; set; }

		Color BackColor { get; set; }

		Color BorderColor { get; set; }

		Font Font { get; set; }

		Color ForeColor { get; set; }

		bool IsTextAutoFit { get; set; }

		LegendItemOrder LegendItemOrder { get; set; }

		LegendStyle LegendStyle { get; set; }

		float MaximumAutoSize { get; set; }

		string Name { get; set; }

		ElementPosition Position { get; set; }
	}

	public class ThemeLegend: IThemeLegend
	{
		public int AutoFitMinFontSize { get; set; }

		public Color BackColor { get; set; }

		public Color BorderColor { get; set; }

		public Font Font { get; set; }

		public Color ForeColor { get; set; }

		public bool IsTextAutoFit { get; set; }

		public LegendItemOrder LegendItemOrder { get; set; }

		public LegendStyle LegendStyle { get; set; }

		public float MaximumAutoSize { get; set; }

		public string Name { get; set; }

		public ElementPosition Position { get; set; }
	}

	public interface IThemeTitle
	{
		string Name { get; set; }

		Font  Font { get; set; }

		Color Color { get; set; }

		Docking Docking { get; set; }

		bool IsDockedInsideChartArea { get; set; }

		ElementPosition Position { get; set; }
	}

	public class ThemeTitle : IThemeTitle
	{
		public ThemeTitle() { IsDockedInsideChartArea = true; }

		public string Name { get; set; }

		public Font Font { get; set; }

		public Color Color { get; set; }

		public Docking Docking { get; set; }

		public bool IsDockedInsideChartArea { get; set; }

		public ElementPosition Position { get; set; }
	}

	/// <summary>
	/// Enumeration for Chart Theme
	/// </summary>
	public enum ChartThemeStyle
	{
		Dark = 0,
		Light
	}

	#endregion

	public interface IStripLineContainer
	{
		double StripLineValue { get; set; }

		Color StripLineColor { get; set; }

		Color ForeColor { get; set; }

		ChartDashStyle StripLineStyle { get; set; }

		int Width { get; set; }

		//string ToolTip { get; set; }
	}

	public class StripLineContainer : IStripLineContainer
	{
		public double StripLineValue { get; set; }

		public Color StripLineColor { get; set; }

		public Color ForeColor { get; set; }

		public ChartDashStyle StripLineStyle { get; set; }

		public int Width { get; set; }

		//public string ToolTip { get; set; }
	}

	public interface ISeriesData
	{
		string Name { get; set; }

		string LegendText { get; set; }

		string UnitOfMeasure { get; set; }

		string YPointFormat { get; set; }

		Color Color { get; set; }

		Color LabelForeColor { get; set; }

		int LineWidth { get; set; }

		int LegendIndex { get; set; }

		bool EnablePointLabel { get; set; }

		bool EnableSort { get; set; }

		bool RequiresUserSelection { get; set; }

		SeriesChartType ChartType { get; set; }

		ChartValueType ValueTypeX { get; set; }

		ChartValueType ValueTypeY { get; set; }

		string CustomProperties { get; set; }
	}

	public class SeriesData : ISeriesData
	{
		public SeriesData()
		{
			this.EnableSort = true;
		}

		public string Name { get; set; }

		public string LegendText { get; set; }

		public string UnitOfMeasure { get; set; }

		public string YPointFormat { get; set; }

		public Color Color { get; set; }

		public Color LabelForeColor { get; set; }

		public int LineWidth { get; set; }

		public int LegendIndex { get; set; }

		public bool EnablePointLabel { get; set; }

		public bool EnableSort { get; set; } // default is true in constructor

		public bool RequiresUserSelection { get; set; }

		public SeriesChartType ChartType { get; set; }

		public ChartValueType ValueTypeX { get; set; }

		public ChartValueType ValueTypeY { get; set; }

		public string CustomProperties { get; set; }
	}

	public class SILegendItem : LegendItem
	{
		public int LegendIndex { get; set; }
	}

	public class Item : IComparable<Item>, IEquatable<Item>
	{
		public string Name;
		public int Value;

		public Item(string name, int value)
		{
			Name = name; Value = value;
		}

		public override string ToString()
		{
			// Generates the text shown in the combo box
			return Name;
		}

		public bool Equals(Item other)
		{
			if (other != null && other.Value == this.Value)
				return true;
			else
				return false;
		}

		public int CompareTo(Item other)
		{
			return other == null ? 1 : this.Value.CompareTo(other.Value);
		}

		public override int GetHashCode()
		{
			return Value;
		}
	}

}
