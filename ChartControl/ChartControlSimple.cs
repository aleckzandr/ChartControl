using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using X;

namespace ChartControls
{
	public partial class ChartControlSimple : UserControl
	{
		public static Series CreateSeries(IChartData chartData, ISeriesData isd, string chartAreaName, string customProperties = "DrawingStyle=Cylinder, EmptyPointValue=Zero, PointWidth=0.5")
		{
			var sz = new Series()
			{
				BorderWidth = isd.LineWidth > 0 ? isd.LineWidth : 1,
				ChartArea = chartAreaName,
				ChartType = isd.ChartType,
				Color = isd.Color,
				CustomProperties = chartData.CustomProperties != null ? chartData.CustomProperties : customProperties, // allow empty string
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

		private bool controlLoaded;
		private IChartData _data;
		protected internal IChartData Data
		{
			get
			{
#if DEBUG && TESTDATA
				if (_data == null)
					_data = X.ChartData.GetTestSurveyData(25); // if data is null set it to Test Data with 25 random points
#endif
				return _data;
			}

			set { _data = value;  }
		}

		/// <summary>
		/// ctor
		/// </summary>
		public ChartControlSimple()
		{
			InitializeComponent();
		}

		internal void Bind() // if cData.Points is null this bombs, which we want
		{
			if (!controlLoaded) // wait for the control to be loaded first
				return;

			var oList = Data.Sorts != null && Data.Sorts.Count > 0 ? Data.Sort(Data.Points, Data.Sorts.ToArray()) : Data.Points;

			foreach (var srxm in this.mChart.Series)
				srxm.Points.Clear();

			if (Data.PrimaryYPointIndex > this.mChart.Series.Count - 1) // code will still bomb if no series
				Data.PrimaryYPointIndex = this.mChart.Series.Count - 1; // prevents out of range exception

			Series primary = this.mChart.Series[Data.PrimaryYPointIndex]; // this bombs if there are no series, that's ok, want that. Out of range is currently checked in Form_Load()

			int dpi = 0;
			foreach (var kvp in oList)
			{
				if (kvp.Value != null && kvp.Value.Values != null && kvp.Value.Values.Length > 0)
				{
					double yValue = kvp.Value.Values[Data.PrimaryYPointIndex]; // potential out of range

					var srxp = Data.Series.ElementAt(Data.PrimaryYPointIndex);

					string sName = srxp.Name; // again, potential out of range // kvp.Value.Names.ElementAt(primarySeriesIdx);

					double compValueSecond = 0d;
					double compValueFirst = 0d;
					double difference = 0d;

					if (sName.Equals(Data.SeriesNameComparisonOne, StringComparison.CurrentCultureIgnoreCase))
						compValueFirst = yValue;
					else if (sName.Equals(Data.SeriesNameComparisonTwo, StringComparison.CurrentCultureIgnoreCase))
						compValueSecond = yValue;

					var datapoint = new DataPoint(dpi, yValue)
					{
						AxisLabel = kvp.Key,
						Tag = new PointContainer() { Name = kvp.Key, PointData = kvp.Value },
						ToolTip = string.Format("{0}: {1}{2}", sName, yValue.ToString(srxp.YPointFormat), srxp.UnitOfMeasure)
					};

					for (int si = 0; si < this.mChart.Series.Count; si++)
					{
						if (si == Data.PrimaryYPointIndex) // we  use the datapoint above
							continue;

						if (kvp.Value.Values.Length > si)
						{
							double jValue = kvp.Value.Values[si];
							var srx = Data.Series.ElementAt(si);
							sName = srx.Name; // kvp.Value.Names.ElementAt(si);

							if (sName.Equals(Data.SeriesNameComparisonOne, StringComparison.CurrentCultureIgnoreCase))
								compValueFirst = jValue;
							else if (sName.Equals(Data.SeriesNameComparisonTwo, StringComparison.CurrentCultureIgnoreCase))
								compValueSecond = jValue;

							var dpoint = new DataPoint(dpi, jValue)
							{
								ToolTip = string.Format("{0}: {1}{2}", sName, jValue.ToString(srx.YPointFormat), srx.UnitOfMeasure)
							};

							if (ValidationComparison(compValueFirst, compValueSecond, si, out difference))
								PointSetLabel(dpoint, string.Format("{0}*", difference.ToString(srx.YPointFormat)));
							else if (srx.EnablePointLabel && jValue > 0)
								PointSetLabel(dpoint, string.Format("{0}{1}", jValue.ToString(srx.YPointFormat), srx.UnitOfMeasure));

							this.mChart.Series[si].Points.Add(dpoint);
						}
					}

					if (ValidationComparison(compValueFirst, compValueSecond, Data.PrimaryYPointIndex, out difference))
						PointSetLabel(datapoint, string.Format("{0}*", difference.ToString(srxp.YPointFormat)));
					else if (srxp.EnablePointLabel && yValue > 0)
						PointSetLabel(datapoint, string.Format("{0}{1}", yValue.ToString(srxp.YPointFormat), srxp.UnitOfMeasure));

					primary.Points.Add(datapoint);
				}
				dpi++;
			}
		}

		private bool ValidationComparison(double firstValue, double secondValue, int seriesIndex, out double difference)
		{
			// business rule encapsulated in method, call business object method in future?
			difference = Math.Abs(firstValue) - Math.Abs(secondValue);
			if (difference < 0)
				difference = 0;

			return firstValue > 0 && secondValue > 0 && Data.Series.ElementAt(seriesIndex).Name.Equals(Data.SeriesNameForComparisonLabel, StringComparison.CurrentCultureIgnoreCase);
		}

		private void PointSetLabel(DataPoint datapoint, string txt)
		{
			if (Data.EnableValueLabels)
				datapoint.Label = txt;
		}

		private void ChartControlSimple_Load(object sender, System.EventArgs e)
		{
			//Note: Bind() method could be called first, but it returns if this hasn't been called first

			this.mChart.Series.Clear();

			if (Data == null)
				return;

			#region Chart Area initialization
			// Note: in ChartControlComplete this is run in the constructor
			ChartArea ca;
			if (this.mChart.ChartAreas.Count > 0)
				ca = this.mChart.ChartAreas[0];
			else
			{
				ca = new ChartArea("Main");
				this.mChart.ChartAreas.Add(ca);
			}
			#endregion

			#region Color
			this.chartContainerControl1.gbTitle.Text = Data.TitleControl;
			this.chartContainerControl1.gradControlPanel.Color1 = Data.Theme.PanelColor1;
			this.chartContainerControl1.gradControlPanel.Color2 = Data.Theme.PanelColor2;
			this.mChart.BackColor = Data.Theme.BackColor;
			this.mChart.BackGradientStyle = Data.Theme.BackGradientStyle;
			this.mChart.BackSecondaryColor = Data.Theme.BackSecondaryColor;
			this.mChart.BorderlineColor = Data.Theme.BorderColor;
			#endregion

			#region Chart Titles
			var tlCount = Data.Theme.Titles.Count;
			if (!string.IsNullOrEmpty(Data.TitleChart) && tlCount > 0)
			{
				this.mChart.Titles.Add(new Title()
				{
					Docking = Data.Theme.Titles[0].Docking,
					IsDockedInsideChartArea = Data.Theme.Titles[0].IsDockedInsideChartArea,
					DockedToChartArea = ca.Name,
					Font = Data.Theme.Titles[0].Font,
					ForeColor = Data.Theme.Titles[0].Color,
					Position = Data.Theme.Titles[0].Position,
					Name = Data.Theme.Titles[0].Name,
					Text = Data.TitleChart
				});
			}

			if (!string.IsNullOrEmpty(Data.TitleChart2) && tlCount > 1)
			{
				this.mChart.Titles.Add(new Title()
				{
					Docking = Data.Theme.Titles[1].Docking,
					IsDockedInsideChartArea = Data.Theme.Titles[1].IsDockedInsideChartArea,
					DockedToChartArea = ca.Name,
					Font = Data.Theme.Titles[1].Font,
					ForeColor = Data.Theme.Titles[1].Color,
					Position = Data.Theme.Titles[1].Position,
					Name = Data.Theme.Titles[1].Name,
					Text = Data.TitleChart2
				});
			}
			#endregion

			#region Chart Legends
			// this must be done before Series
			if (Data.EnableLegend)
			{
				int lgdIdx = 0;
				foreach (var lg in Data.Theme.Legends)
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

					if (Data.LegendItems != null)
						foreach (var li in Data.LegendItems.Where(x => x.LegendIndex == lgdIdx))
							lgd.CustomItems.Add(li);

					this.mChart.Legends.Add(lgd);
					lgdIdx++;
				}
			}
			#endregion

			#region Chart Area
			ca.BackColor = Data.Theme.AreaBackColor;
			ca.BackGradientStyle = Data.Theme.AreaBackGradientStyle;
			ca.BackSecondaryColor = Data.Theme.AreaBackSecondaryColor;
			ca.BorderColor = Data.Theme.AreaBorderColor;
			ca.CursorX.IsUserEnabled = true;
			ca.CursorX.IsUserSelectionEnabled = true;
			ca.CursorX.LineWidth = 2;
			ca.CursorX.SelectionColor = Color.Blue;

			#region Chart X-Axis
			ca.AxisX.Title = Data.TitleXAxis;
			ca.AxisX.Interval = Data.XAxisInterval;

			ca.AxisX.InterlacedColor = Data.Theme.XAxis.InterlacedColor;
			ca.AxisX.LabelStyle.ForeColor = Data.Theme.XAxis.LabelStyleForeColor;
			ca.AxisX.LineColor = Data.Theme.XAxis.LineColor;
			ca.AxisX.MajorGrid.LineColor = Data.Theme.XAxis.MajorGridLineColor;
			ca.AxisX.MajorTickMark.Enabled = Data.Theme.XAxis.MajorTickMarkEnabled;
			ca.AxisX.MajorTickMark.LineColor = Data.Theme.XAxis.MajorTickMarkColor;
			ca.AxisX.TitleFont = Data.Theme.XAxis.TitleFont;
			ca.AxisX.TitleForeColor = Data.Theme.XAxis.TitleForeColor;
			#endregion

			#region Chart Y-Axis
			if (Data.YAxisMinimum > 0)
			{
				ca.AxisY.IsStartedFromZero = ca.AxisY2.IsStartedFromZero = false;
				ca.AxisY.Minimum = ca.AxisY2.Minimum = Data.YAxisMinimum;
			}

			if (Data.YAxisMaximum > 0)
				ca.AxisY.Maximum = ca.AxisY2.Maximum = Data.YAxisMaximum;

			ca.AxisY.Title = Data.TitleYAxis;
			ca.AxisY.TitleFont = ca.AxisY2.TitleFont = Data.Theme.YAxis.TitleFont;
			ca.AxisY.TitleForeColor = ca.AxisY2.TitleForeColor = Data.Theme.YAxis.TitleForeColor;
			ca.AxisY.InterlacedColor = ca.AxisY2.InterlacedColor = Data.Theme.YAxis.InterlacedColor;
			ca.AxisY.LabelStyle.ForeColor = ca.AxisY2.LabelStyle.ForeColor = Data.Theme.YAxis.LabelStyleForeColor;
			ca.AxisY.LineColor = ca.AxisY2.LineColor = Data.Theme.YAxis.LineColor;
			ca.AxisY.MajorGrid.LineColor = ca.AxisY2.MajorGrid.LineColor = Data.Theme.YAxis.MajorGridLineColor;
			ca.AxisY.MajorTickMark.Enabled = ca.AxisY2.MajorTickMark.Enabled = Data.Theme.YAxis.MajorTickMarkEnabled;
			ca.AxisY.MajorTickMark.LineColor = ca.AxisY2.MajorTickMark.LineColor = Data.Theme.YAxis.MajorTickMarkColor;
			#endregion

			#region strip lines
			ca.AxisY2.Enabled = Data.EnableYAxisStripLineLabels ? AxisEnabled.True : AxisEnabled.False;

			if (Data.StripLinesYAxis != null && Data.StripLinesYAxis.Any())
			{
				foreach (var stripLine in Data.StripLinesYAxis)
				{
					ca.AxisY.StripLines.Add(new StripLine()
					{
						BorderColor = stripLine.StripLineColor,
						BorderDashStyle = stripLine.StripLineStyle,
						BorderWidth = stripLine.Width,
						ForeColor = stripLine.ForeColor,
						IntervalOffset = stripLine.StripLineValue,
						ToolTip = string.Format("{0} {1}", stripLine.StripLineValue, Data.YAxisUnitOfMeasure)
					});

					if (Data.EnableYAxisStripLineLabels)
					{
						ca.AxisY2.CustomLabels.Add(new CustomLabel()
						{
							ForeColor = stripLine.ForeColor,
							FromPosition = stripLine.StripLineValue - 10,
							MarkColor = stripLine.StripLineColor,
							Text = string.Format("{0}{1}{2}", (Data.IsYAxisUnitOfMeasureNegative ? "-" : ""), stripLine.StripLineValue, Data.YAxisUnitOfMeasure),
							ToPosition = stripLine.StripLineValue + 10
						});
					}
				}
			}
			#endregion

			#endregion

			#region Series

			// Legends must be done first
			foreach (var isd in Data.Series)
				this.mChart.Series.Add(CreateSeries(Data, isd, ca.Name));

			#endregion

			controlLoaded = true; // must be set here, before Bind()
			Bind();
		}
	}
}
