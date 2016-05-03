using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using X;

namespace ChartControls
{
	public partial class Test : GradiantForm
	{
		public Test() : this(null) { }

		/// <summary>
		/// Constructor with IChartData param
		/// </summary>
		/// <param name="data"></param>
		public Test(IChartData data)
		{
			InitializeComponent();

			if (this.mChart.ChartAreas.Count > 0)
				ca = this.mChart.ChartAreas[0];
			else
			{
				ca = new ChartArea("Main");
				this.mChart.ChartAreas.Add(ca);
			}

			cData = data ?? ChartData.GetTestSurveyData(479); // if data is null set it to Test Data with 479 random points
		}

		#region fields and props

		private const int forcedPageSize = 2000; // anything larger the chart is too slow

		private int _primarySeriesIdx = 0;
		private int primarySeriesIdx
		{
			get { return _primarySeriesIdx; }
			set
			{
				pointsScanned = false;
				_primarySeriesIdx = value > -1 ? value : 0;
			}
		}

		private IList<int> lowestValueIdx { get; set; }
		//private IList<int> highestValueIdx { get; set; }

		private double lowestValue { get; set; }
		//private double highestValue { get; set; }

		private int pts = 0;

		private int _pageIdx;
		private int pageIdx
		{
			get { return _pageIdx;  }
			set { _pageIdx = value > -1 ? value : 0; }
		}

		private int _chartIdx;
		private int chartIdx // -1 is a valid value, a trackbar may be set to 0, which means the index should be -1
		{
			get { return _chartIdx; }
			set { _chartIdx = value > -2 ? value : -1; }
		}

		private int pageSize { get; set; }

		private readonly int[] itemsPerChartTenThousandPlus = new int[] { 2000, 1000, 500, 100, 50, 40, 20 };
		private readonly int[] itemsPerChartThousandPlus = new int[] { 1000, 500, 400, 200, 100, 50, 40, 20 };
		private readonly int[] itemsPerChart = new int[] { 500, 400, 200, 100, 50, 40, 20 };
		private int labelPageSizeThreshold = 41;

		private double rangePosFirst;
		private double rangePosSecond;
		//private int rangeSize = int.MaxValue;
		private bool cursorChanging;

		private string countFormatString;
		private string pageFormatString;
		private string itemsPerChartFormatString;
		private string ascendingMark = "asc";
		private string descendingMark = "desc";
		private string seriesCustomProperties = "DrawingStyle=Cylinder, EmptyPointValue=Zero, PointWidth=0.5";
		private ChartArea ca;

		private string _chartDescription;
		private string chartDescription
		{
			get
			{
				if (_chartDescription == null)
					_chartDescription = "Chart";

				return _chartDescription;
			}
			set { _chartDescription = value; }
		}

		private IChartData cData;
		private IEnumerable<KeyValuePair<string, IPointData>> oList;
		private IList<Func<KeyValuePair<string, IPointData>, object>> defaultSorts;
		private bool[] defaultDescendingOrderBys;

		private bool sortRun;
		private bool pointsScanned;
		private bool fireTrackBarEvent = true;

		#endregion

		private void PointsScan()
		{
			pointsScanned = true;
			lowestValue = double.MaxValue;
			//highestValue = double.MinValue;
			pts = 0;
			// find min and max for primary series, this is very fast, < 1 second for 65k points and checking maxValue too
			foreach (var kvp in cData.Points)
			{
				pts++;
				if (kvp.Value == null || kvp.Value.Values == null || kvp.Value.Values.Length == 0)
					continue;

				double yValue = kvp.Value.Values[primarySeriesIdx]; // potential out of range exception
				if (yValue < lowestValue)
					lowestValue = yValue;

				//if (yValue > highestValue)
				//	highestValue = yValue;
			}
		}

		private void Bind() // if cData.Points is null this bombs, which we want
		{
			oList = cData.Sorts != null && cData.Sorts.Count > 0 ? cData.Sort(cData.Points, cData.Sorts.ToArray()) : cData.Points;

			if (pageSize > 0)
				oList = oList.Skip(pageIdx * pageSize).Take(pageSize);

			foreach (var srxm in this.mChart.Series)
				srxm.Points.Clear();

			if (!pointsScanned)
				PointsScan();

			lowestValueIdx = new List<int>();

			Series primary = this.mChart.Series[primarySeriesIdx]; // this bombs if there are no series, that's ok, want that. Out of range is currently checked in Form_Load()

			int dpi = 0;
			foreach (var kvp in oList)
			{
				if (kvp.Value != null && kvp.Value.Values != null && kvp.Value.Values.Length > 0)
				{
					double yValue = kvp.Value.Values[primarySeriesIdx]; // potential out of range

					if (yValue == lowestValue) // possible precision check failure
						lowestValueIdx.Add(dpi);

					var srxp = cData.Series.ElementAt(primarySeriesIdx);

					string sName = srxp.Name; // again, potential out of range // kvp.Value.Names.ElementAt(primarySeriesIdx);

					double compValueSecond = 0d;
					double compValueFirst = 0d;
					double difference = 0d;

					if (sName.Equals(cData.SeriesNameComparisonOne, StringComparison.CurrentCultureIgnoreCase))
						compValueFirst = yValue;
					else if (sName.Equals(cData.SeriesNameComparisonTwo, StringComparison.CurrentCultureIgnoreCase))
						compValueSecond = yValue;

					var datapoint = new DataPoint(dpi, yValue)
					{
						AxisLabel = kvp.Key,
						Tag = new PointContainer() { Name = kvp.Key, PointData = kvp.Value },
						ToolTip = string.Format("{0}: {1}{2}", sName, yValue.ToString(srxp.YPointFormat), srxp.UnitOfMeasure)
					};

					for (int si = 0; si < this.mChart.Series.Count; si++)
					{
						if (si == primarySeriesIdx) // we  use the datapoint above
							continue;

						if (kvp.Value.Values.Length > si)
						{
							double jValue = kvp.Value.Values[si];
							var srx = cData.Series.ElementAt(si);
							sName = srx.Name; // kvp.Value.Names.ElementAt(si);

							if (sName.Equals(cData.SeriesNameComparisonOne, StringComparison.CurrentCultureIgnoreCase))
								compValueFirst = jValue;
							else if (sName.Equals(cData.SeriesNameComparisonTwo, StringComparison.CurrentCultureIgnoreCase))
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

					if (ValidationComparison(compValueFirst, compValueSecond, primarySeriesIdx, out difference))
						PointSetLabel(datapoint, string.Format("{0}*", difference.ToString(srxp.YPointFormat)));
					else if (srxp.EnablePointLabel && yValue > 0)
						PointSetLabel(datapoint, string.Format("{0}{1}", yValue.ToString(srxp.YPointFormat), srxp.UnitOfMeasure));

					primary.Points.Add(datapoint);
				}
				dpi++;
			}

			trackBar1.MaxValue = dpi;

			ca.AxisX.StripLines.Clear();

			var listLowestValues = lowestValueIdx.Count;
			if (listLowestValues < 1)
			{
				ca.CursorX.Position = chartIdx = -1;
				this.lDataSelected.Visible = false;
				fireTrackBarEvent = false;
				trackBar1.Value = 0;
				fireTrackBarEvent = true;
			}

			for (int x = 0; x < listLowestValues; x++)
			{
				ca.AxisX.StripLines.Add(new StripLine()
				{
					BorderColor = primary.Color,
					BorderDashStyle = cData.Theme.XAxis.StripLineChartDashStyle,
					BorderWidth = cData.Theme.XAxis.StripLineBorderWidth,
					IntervalOffset = lowestValueIdx[x]
				});
				if (x == 0)
				{
					ca.CursorX.Position = chartIdx = lowestValueIdx[x];
					fireTrackBarEvent = false;
					trackBar1.Value = chartIdx + 1; // trackBar1.Value isn't 0 based
					fireTrackBarEvent = true;
					PointSelected(lowestValueIdx[x], primarySeriesIdx);
				}
			}

			int fromCount = (pageIdx * pageSize) + 1; // pageIdx is 0 based

			int toCount = (pageIdx + 1) * pageSize;
			if (toCount == 0 || toCount > pts)
				toCount = pts;

			int lpz = pageSize > 0 ? pageSize : pts;

			int pageCount = (pts / lpz) + ((pts % lpz == 0) ? 0 : 1);

			lCountInformation.Text = string.Format(countFormatString, fromCount, toCount, pts);

			//lPageInformation.Text = string.Format(pageFormatString, pageIdx + 1, pageCount);

			var items = new List<Item>();
			for (int iz = 0; iz < pageCount; iz++)
				items.Add(new Item(string.Format(pageFormatString, iz + 1, pageCount), iz)); // no need to sort

			this.cbChartView.Items.Clear();
			this.cbChartView.Items.AddRange(items.ToArray());

			this.cbChartView.SelectedIndexChanged -= this.cbChartView_SelectedIndexChanged;
			this.cbChartView.SelectedIndex = pageIdx;
			this.cbChartView.SelectedIndexChanged += this.cbChartView_SelectedIndexChanged;

			gelButtPageL.Enabled = pageIdx > 0;
			gelButtPageR.Enabled = (pageIdx + 1) * pageSize < pts;
		}

		private void PointSetLabel(DataPoint datapoint, string txt)
		{
			if (cData.EnableValueLabels &&
			    pageSize > 0 &&
			    pageSize < labelPageSizeThreshold)
			{
				datapoint.Label = txt;
			}
		}

		private void PointSelected(int pointIndex, int seriesIndex)
		{
			if (pointIndex < 0) // left boundary check
			{
				this.lDataSelected.Visible = false;
				return;
			}

			var srx = this.mChart.Series[seriesIndex];
			int bnd = srx.Points.Count - 1;

			if (pointIndex > bnd) // right boundary check - user clicking way on the right
				pointIndex = bnd;

			// if rangePosFirst > rangePosSecond, it means an individual point was selected, if rangePosFirst = rangePosSecond, most likely formload where they are 0
			// otherwise we don't show the label if the the selected range doesn't overlap the last selected point (idx)
			this.lDataSelected.Visible = (rangePosFirst >= rangePosSecond) || (rangePosFirst <= pointIndex && pointIndex <= rangePosSecond);

			rangePosFirst = rangePosSecond = 0; // reset!

			if (this.lDataSelected.Visible)
			{
				DataPoint pt = srx.Points[pointIndex];
				pt.MarkerStyle = MarkerStyle.Cross; //.Diamond; //.Cross; //.Square; //.Circle;

				var container = pt.Tag as IPointContainer;
				string formatT = (container != null && container.PointData != null && !string.IsNullOrEmpty(container.PointData.SelectedPointLabelFormat)) ?
					container.PointData.SelectedPointLabelFormat :
					"{0} : {1} - {2}";

				string tagName = (container != null) ? container.Name : (pt.XValue + 1).ToString(); // TagName is a key to a Dictionary, it cannot be null

				string srxName = cData.Series != null && cData.Series.Count > primarySeriesIdx ? cData.Series.ElementAt(primarySeriesIdx).Name : "";

				this.lDataSelected.Text = string.Format(formatT, tagName, srxName, pt.YValues[0]); // only one YValue per Series, so use 0 indexer

				// raise an event somewhere?
			}
		}

		private bool ValidationComparison(double firstValue, double secondValue, int seriesIndex, out double difference)
		{
			// business rule encapsulated in method, call business object method in future?
			difference = Math.Abs(firstValue) - Math.Abs(secondValue);
			if (difference < 0)
				difference = 0;

			return firstValue > 0 && secondValue > 0 && cData.Series.ElementAt(seriesIndex).Name.Equals(cData.SeriesNameForComparisonLabel, StringComparison.CurrentCultureIgnoreCase);
		}

		private Series CreateSeries(ISeriesData isd)
		{
			var sz = new Series()
			{
				BorderWidth = isd.LineWidth > 0 ? isd.LineWidth : 1,
				ChartArea = ca.Name,
				ChartType = isd.ChartType,
				Color = isd.Color,
				CustomProperties = seriesCustomProperties,
				Enabled = !isd.RequiresUserSelection,
				Font = cData.Theme.SeriesFont,
				LabelForeColor = isd.LabelForeColor,
				Legend = cData.EnableLegend && cData.Theme.Legends.Count > isd.LegendIndex ? this.mChart.Legends[isd.LegendIndex].Name : null,
				LegendText = isd.LegendText,
				Name = isd.Name,
				XValueType = isd.ValueTypeX,
				YValueType = isd.ValueTypeY
			};

			return sz;
		}

		#region Events

		private void Form_Load(object sender, EventArgs e) // setup
		{
			this.gbContainer.Text = cData.TitleControl;
			if (!string.IsNullOrEmpty(cData.ShowAllSeriesLabelText))
				this.checkBoxShowUserSelection.Text = cData.ShowAllSeriesLabelText;

			#region Chart Color
			this.panelChart.Color1 = cData.Theme.PanelColor1;
			this.panelChart.Color2 = cData.Theme.PanelColor2;

			this.lDataSelected.ForeColor =
				this.lCountInformation.ForeColor = 
					this.lSortBy.ForeColor = 
						this.lThenBy.ForeColor =
							this.lPageInformation.ForeColor =
								this.checkBoxShowUserSelection.ForeColor =
									cData.Theme.ForeColor;

			this.trackBar1.BackColor = cData.Theme.ControlBackColor1;
			this.trackBar1.BorderColor = cData.Theme.ControlBorderColor;

			this.mChart.BackColor = cData.Theme.BackColor;
			this.mChart.BackGradientStyle = cData.Theme.BackGradientStyle;
			this.mChart.BackSecondaryColor = cData.Theme.BackSecondaryColor;
			this.mChart.BorderlineColor = cData.Theme.BorderColor;
			#endregion

			#region Chart Titles
			this.mChart.Titles.Clear();
			var tlCount = cData.Theme.Titles.Count;
			if (!string.IsNullOrEmpty(cData.TitleChart) && tlCount > 0)
			{
				this.mChart.Titles.Add(new Title()
				{
					Docking = cData.Theme.Titles[0].Docking,
					Font = cData.Theme.Titles[0].Font,
					ForeColor = cData.Theme.Titles[0].Color,
					Position = cData.Theme.Titles[0].Position,
					Name = cData.Theme.Titles[0].Name,
					Text = cData.TitleChart
				});
			}

			if (!string.IsNullOrEmpty(cData.TitleChart2) && tlCount > 1)
			{
				this.mChart.Titles.Add(new Title()
				{
					Docking = cData.Theme.Titles[1].Docking,
					Font = cData.Theme.Titles[1].Font,
					ForeColor = cData.Theme.Titles[1].Color,
					Position = cData.Theme.Titles[1].Position,
					Name = cData.Theme.Titles[1].Name,
					Text = cData.TitleChart2
				});
			}
			#endregion

			#region Chart Legends
			this.mChart.Legends.Clear();
			// this must be done before Series
			if (cData.EnableLegend)
			{
				int lgdIdx = 0;
				foreach (var lg in cData.Theme.Legends)
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

					if (cData.LegendItems != null)
						foreach (var li in cData.LegendItems.Where(x => x.LegendIndex == lgdIdx))
							lgd.CustomItems.Add(li);

					this.mChart.Legends.Add(lgd);
					lgdIdx++;
				}
			}
			#endregion

			#region Chart Area

			ca.BackColor = cData.Theme.AreaBackColor;
			ca.BackGradientStyle = cData.Theme.AreaBackGradientStyle;
			ca.BackSecondaryColor = cData.Theme.AreaBackSecondaryColor;
			ca.BorderColor = cData.Theme.AreaBorderColor;
			//ca.CursorX.IsUserEnabled = true;
			//ca.CursorX.IsUserSelectionEnabled = true;
			//ca.CursorX.LineWidth = 2;
			//ca.CursorX.SelectionColor = Color.Blue;

			#region Chart X-Axis
			ca.AxisX.Title = cData.TitleXAxis;
			ca.AxisX.Interval = cData.XAxisInterval;

			ca.AxisX.LabelStyle.ForeColor = cData.Theme.XAxis.LabelStyleForeColor;
			ca.AxisX.LineColor = cData.Theme.XAxis.LineColor;
			ca.AxisX.MajorGrid.LineColor = cData.Theme.XAxis.MajorGridLineColor;
			ca.AxisX.MajorTickMark.Enabled = cData.Theme.XAxis.MajorTickMarkEnabled;
			ca.AxisX.MajorTickMark.LineColor = cData.Theme.XAxis.MajorTickMarkColor;
			ca.AxisX.TitleFont = cData.Theme.XAxis.TitleFont;
			ca.AxisX.TitleForeColor = cData.Theme.XAxis.TitleForeColor;

			ca.AxisY.InterlacedColor = cData.Theme.YAxis.InterlacedColor;
			ca.AxisY.LabelStyle.ForeColor = cData.Theme.YAxis.LabelStyleForeColor;
			ca.AxisY.LineColor = cData.Theme.YAxis.LineColor;
			ca.AxisY.MajorGrid.LineColor = cData.Theme.YAxis.MajorGridLineColor;
			ca.AxisY.MajorTickMark.Enabled = cData.Theme.YAxis.MajorTickMarkEnabled;
			ca.AxisY.MajorTickMark.LineColor = cData.Theme.YAxis.MajorTickMarkColor;
			ca.AxisY.TitleFont = cData.Theme.YAxis.TitleFont;
			ca.AxisY.TitleForeColor = cData.Theme.YAxis.TitleForeColor;
			#endregion

			#region Chart Y-Axis
			ca.AxisY.Title = cData.TitleYAxis;
			#endregion

			#region strip lines
			ca.AxisY.StripLines.Clear();
			ca.AxisY2.CustomLabels.Clear();
			ca.AxisY2.Enabled = cData.EnableYAxisStripLineLabels ? AxisEnabled.True : AxisEnabled.False;

			if (cData.StripLinesYAxis != null && cData.StripLinesYAxis.Any())
			{
				foreach (var strpValue in cData.StripLinesYAxis)
				{
					ca.AxisY.StripLines.Add(new StripLine()
					{
						BorderColor = strpValue.StripLineColor,
						BorderDashStyle = strpValue.StripLineStyle,
						BorderWidth = cData.Theme.YAxis.StripLineBorderWidth,
						ForeColor = cData.Theme.YAxis.StripLineForeColor,
						IntervalOffset = strpValue.StripLineValue,
						ToolTip = string.Format("{0} {1}", strpValue, cData.YAxisUnitOfMeasure)
					});

					if (cData.EnableYAxisStripLineLabels)
					{
						ca.AxisY2.CustomLabels.Add(new CustomLabel()
						{
							ForeColor = cData.Theme.YAxis.StripLineForeColor,
							FromPosition = strpValue.StripLineValue - 10,
							MarkColor = cData.Theme.YAxis.StripLineBorderColor,
							Text = string.Format("{0}{1}{2}", (cData.IsYAxisUnitOfMeasureNegative ? "-" : ""), strpValue, cData.YAxisUnitOfMeasure),
							ToPosition = strpValue.StripLineValue + 10
						});
					}
				}
			}
			#endregion

			#endregion

			#region Series
			this.mChart.Series.Clear();
			// Legends must be done first
			foreach (var isd in cData.Series)
			{
				if (isd.RequiresUserSelection)
					checkBoxShowUserSelection.Visible = true;

				this.mChart.Series.Add(CreateSeries(isd));
			}
			#endregion

			countFormatString = !string.IsNullOrEmpty(lCountInformation.Text) ? lCountInformation.Text : "{0} - {1} of {2}";
			lPageInformation.Text = !string.IsNullOrEmpty(cData.PagingText) ? cData.PagingText : chartDescription;
			//pageFormatString = !string.IsNullOrEmpty(lPageInformation.Text) ? lPageInformation.Text : chartDescription + " {0} of {1}";
			this.cbChartView.SelectedIndex = 0;
			pageFormatString = this.cbChartView.Items[cbChartView.SelectedIndex].ToString();

			primarySeriesIdx = cData.PrimaryYPointIndex;
			if (primarySeriesIdx > this.mChart.Series.Count - 1) // code will still bomb if no series
				primarySeriesIdx = this.mChart.Series.Count - 1; // prevents out of range exception

			defaultSorts = cData.Sorts;
			defaultDescendingOrderBys = cData.DescendingOrderBys;

			PointsScan();
	
			if (cData.Series != null) // remove this if statement?
			{
				var sortableSeries = cData.Series.Where(sr => sr.EnableSort &&
					(!sr.RequiresUserSelection || !checkBoxShowUserSelection.Visible || checkBoxShowUserSelection.Checked));

				lSortBy.Visible = cbSortBy.Visible = sortableSeries.Any();
				foreach (ISeriesData sdx in sortableSeries)
				{
					cbSortBy.Items.Add(string.Format("{0} {1}", sdx.Name, ascendingMark));
					cbSortBy.Items.Add(string.Format("{0} {1}", sdx.Name, descendingMark));
				}
			}

			int formPageSize = cData.PageSize < forcedPageSize ? cData.PageSize : forcedPageSize;
			if (pts > formPageSize) // if true, do paging
			{
				pageSize = formPageSize;
				this.gelButtPageR.Enabled =
					this.gelButtPageR.Visible =
						this.gelButtPageL.Visible =
							this.cbItemsPerChart.Visible =
								this.cbChartView.Visible =
									this.lPageInformation.Visible = 
										true;

				this.cbItemsPerChart.SelectedIndex = 0;
				itemsPerChartFormatString = string.Format("{0} {1}", cbItemsPerChart.Items[cbItemsPerChart.SelectedIndex], lPageInformation.Text);
				this.cbItemsPerChart.Items.Clear();

				var items = new List<Item>();
				var selectedItem = new Item(string.Format(itemsPerChartFormatString, pageSize), pageSize);
				items.Add(selectedItem);
				int[] vpz;
				if (pts > 10000)
					vpz = itemsPerChartTenThousandPlus;
				else if (pts > 1000)
					vpz = itemsPerChartThousandPlus;
				else
					vpz = itemsPerChart;

				foreach (int pz in vpz.Where(vp => vp != pageSize))
					items.Add(new Item(string.Format(itemsPerChartFormatString, pz), pz));

				items.Sort();

				this.cbItemsPerChart.Items.AddRange(items.ToArray());
				this.cbItemsPerChart.SelectedIndex = items.IndexOf(selectedItem);
			}

			this.cbItemsPerChart.SelectedIndexChanged += this.cbItemsPerChart_SelectedIndexChanged; // do this here so we only have to deal with it once (i.e. don't do it in designer)

			Bind();
		}

		//this.mChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.axis_view_changed);
		//private void axis_view_changed(object sender, ViewEventArgs e)
		//{
		//}

		private void cursor_position_changing(object sender, CursorEventArgs e) // this catches the user range boundaries on mouse click & drag
		{
			if (!cursorChanging)
				rangePosFirst = e.NewPosition;
			else
				rangePosSecond = e.NewPosition;

			cursorChanging = true;
		}

		private void cursor_position_changed(object sender, CursorEventArgs e)
		{
			cursorChanging = false; // always set this to false ~after~ a "change"
			int idx = (int)Math.Max(e.ChartArea.CursorX.Position, -1); // CursorX.Position could be NaN when user selects a range, which means idx will be int.Minimum
			if (idx < -1) // left boundary check - it's the user selecting a range
			{
				if (lowestValueIdx.Any())
				{
					chartIdx = lowestValueIdx[0];
					e.ChartArea.CursorX.Position = chartIdx; // highestValueIdx; // lowestValueIdx;
					fireTrackBarEvent = false;
					trackBar1.Value = chartIdx + 1;
					fireTrackBarEvent = true;
					PointSelected(chartIdx, primarySeriesIdx);
				}
			}
			else
			{
				chartIdx = idx;
				fireTrackBarEvent = false;
				trackBar1.Value = chartIdx + 1;
				fireTrackBarEvent = true;
				PointSelected(chartIdx, primarySeriesIdx);
			}
		}

		private void gelButtPageL_Click(object sender, EventArgs e)
		{
			pageIdx--;
			Bind();
		}

		private void gelButtPageR_Click(object sender, EventArgs e)
		{
			pageIdx++;
			Bind();
		}

		private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbThenBy.Items.Clear();

			var selected = cbSortBy.Items[cbSortBy.SelectedIndex].ToString();

			if (!string.IsNullOrEmpty(selected) && !selected.Equals("Default", StringComparison.CurrentCultureIgnoreCase))
			{
				sortRun = true;

				int x = 0, z = 0;

				foreach (ISeriesData sdx in cData.Series.Where(sr => sr.EnableSort &&
					(!sr.RequiresUserSelection || !checkBoxShowUserSelection.Visible || checkBoxShowUserSelection.Checked)))
				{
					if (!selected.StartsWith(sdx.Name))
					{
						cbThenBy.Items.Add(string.Format("{0} {1}", sdx.Name, ascendingMark));
						cbThenBy.Items.Add(string.Format("{0} {1}", sdx.Name, descendingMark));
					}
					else
						z = x; // used for ordering, see below

					x++;
				}

				lThenBy.Visible = cbThenBy.Visible = cbThenBy.Items.Count > 0;

				Func<KeyValuePair<string, IPointData>, object> asort = kvp => kvp.Value.Values[z];

				cData.Sorts = new List<Func<KeyValuePair<string, IPointData>, object>>() { asort };

				if (selected.EndsWith(descendingMark, StringComparison.CurrentCultureIgnoreCase))
					cData.DescendingOrderBys = new bool[] { true };
				else
					cData.DescendingOrderBys = new bool[] { false };

				pageIdx = 0;
				Bind();
			}
			else
			{
				lThenBy.Visible = cbThenBy.Visible = false;

				if (sortRun)
				{
					cData.Sorts = defaultSorts;
					cData.DescendingOrderBys = defaultDescendingOrderBys;
					pageIdx = 0;
					Bind();
				}
			}
		}

		private void cbThenBy_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selected = cbThenBy.Items[cbThenBy.SelectedIndex].ToString();

			if (!string.IsNullOrEmpty(selected)) // && !selected.Equals("Default", StringComparison.CurrentCultureIgnoreCase))
			{
				int x = 0, z = 0;

				foreach (ISeriesData sdx in cData.Series)
				{
					if (selected.StartsWith(sdx.Name))
					{
						z = x;
						break;
					}
					x++;
				}

				Func<KeyValuePair<string, IPointData>, object> firstSort = cData.Sorts[0];
				Func<KeyValuePair<string, IPointData>, object> asort = kvp => kvp.Value.Values[z];
				cData.Sorts = new List<Func<KeyValuePair<string, IPointData>, object>>() { firstSort, asort };

				bool firstOrder = cData.DescendingOrderBys[0];
				if (selected.EndsWith(descendingMark, StringComparison.CurrentCultureIgnoreCase))
					cData.DescendingOrderBys = new bool[] { firstOrder, true };
				else
					cData.DescendingOrderBys = new bool[] { firstOrder, false };

				pageIdx = 0;
				Bind();
			}
		}

		private void cbItemsPerChart_SelectedIndexChanged(object sender, EventArgs e)
		{
			var item = this.cbItemsPerChart.Items[this.cbItemsPerChart.SelectedIndex] as Item;
			pageIdx = 0;
			fireTrackBarEvent = false;
			pageSize = this.trackBar1.Value = item.Value;
			fireTrackBarEvent = true;
			Bind();
		}

		private void cbChartView_SelectedIndexChanged(object sender, EventArgs e)
		{
			var item = this.cbChartView.Items[this.cbChartView.SelectedIndex] as Item;
			pageIdx = item.Value;
			Bind();
		}

		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			if (fireTrackBarEvent)
			{
				chartIdx = trackBar1.Value - 1;
				ca.CursorX.Position = chartIdx;
				cursor_position_changed(this, new CursorEventArgs(ca, ca.AxisX, chartIdx));
			}
		}

		private void checkBoxShowUserSelection_CheckedChanged(object sender, EventArgs e)
		{
			foreach (var isd in cData.Series.Where(sr => sr.RequiresUserSelection))
				this.mChart.Series[isd.Name].Enabled = checkBoxShowUserSelection.Checked;

			//cData.EnableValueLabels = checkBoxShowLineSeries.Checked;

			var sortableSeries = cData.Series.Where(sr => sr.EnableSort &&
				(!sr.RequiresUserSelection || !checkBoxShowUserSelection.Visible || checkBoxShowUserSelection.Checked));

			cbSortBy.Items.Clear();
			lSortBy.Visible = cbSortBy.Visible = sortableSeries.Any();

			cbSortBy.Items.Add("Default");
			foreach (ISeriesData sdx in sortableSeries)
			{
				cbSortBy.Items.Add(string.Format("{0} {1}", sdx.Name, ascendingMark));
				cbSortBy.Items.Add(string.Format("{0} {1}", sdx.Name, descendingMark));
			}

			cbThenBy.Items.Clear();
			cbThenBy.Visible = lThenBy.Visible = false;

			Bind();
		}

		private void gelButtIncrL_Click(object sender, EventArgs e)
		{
			ca.CursorX.Position = --chartIdx;
			cursor_position_changed(this, new CursorEventArgs(ca, ca.AxisX, chartIdx));
		}

		private void gelButtIncrR_Click(object sender, EventArgs e)
		{
			ca.CursorX.Position = ++chartIdx;
			cursor_position_changed(this, new CursorEventArgs(ca, ca.AxisX, chartIdx));
		}

		#endregion

		private class Item : IComparable<Item>, IEquatable<Item>
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
}