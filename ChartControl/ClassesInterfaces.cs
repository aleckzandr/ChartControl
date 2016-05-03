using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

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
		int ID { get; set; } // max 2,147,483,647
		//Int64 ID { get; set; } // max 9,223,372,036,854,775,807
		//string[] Names { get; set; }
		double[] Values { get; set; }
		string SelectedPointLabelFormat { get; set; } // must have 3 params, i.e. "{0} - {1} {2}" or empty string

		DateTime DateFirst { get; set; }
		DateTime DateSecond { get; set; }
		string TextFirst { get; set; }
		string TextSecond { get; set; }
		Double DoubleFirst { get; set; }
		Double DoubleSecond { get; set; }
	}

	public class PointData : IPointData
	{
		public int ID { get; set; } // max 2,147,483,647
		//public string[] Names { get; set; }
		public double[] Values { get; set; }
		public string SelectedPointLabelFormat { get; set; } // must have 3 params, i.e. "{0} - {1} {2}" or empty string

		public DateTime DateFirst { get; set; }
		public DateTime DateSecond { get; set; }
		public string TextFirst { get; set; }
		public string TextSecond { get; set; }
		public Double DoubleFirst { get; set; }
		public Double DoubleSecond { get; set; }
	}

	public interface IChartData
	{
		IEnumerable<KeyValuePair<string, IPointData>> Points { get; set; }

		bool[] DescendingOrderBys { get; set; }

		IList<Func<KeyValuePair<string, IPointData>, object>> Sorts { get; set; }

		IEnumerable<KeyValuePair<string, IPointData>> Sort<T>(
			IEnumerable<KeyValuePair<string, IPointData>> src,
			params Func<KeyValuePair<string, IPointData>, T>[] sort);

		int PrimaryYPointIndex { get; set; }

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

		public int PrimaryYPointIndex { get; set; }

		public int PageSize { get; set; }

		public IList<ISeriesData> Series { get; set; }

		public string CustomProperties { get; set; }

		public string PagingText { get; set; } // "Chart", "Graph", etc

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

		public double XAxisInterval { get; set; }

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

		#region static methods

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
					, TextFirst = string.Format("Testing{0}", i)
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
				PrimaryYPointIndex = 1, // In this case: 0 = Native, 1 = Instant Off, etc.
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
					, TextFirst = string.Format("Testing{0}", i)
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
				PrimaryYPointIndex = 0,
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
					//new StripLineContainer()
					//{
					//	StripLineValue = 30d,
					//	StripLineColor = Color.Purple,
					//	StripLineStyle = ChartDashStyle.DashDotDot,
					//	ForeColor =  Color.Purple,
					//	Width = theme.YAxis.StripLineBorderWidth
					//},
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
					, TextFirst = string.Format("Testing{0}", i)
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
				PrimaryYPointIndex = 0,
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
	}

	public class StripLineContainer : IStripLineContainer
	{
		public double StripLineValue { get; set; }

		public Color StripLineColor { get; set; }

		public Color ForeColor { get; set; }

		public ChartDashStyle StripLineStyle { get; set; }

		public int Width { get; set; }
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
	}

	public class SILegendItem : LegendItem
	{
		public int LegendIndex { get; set; }
	}
}
