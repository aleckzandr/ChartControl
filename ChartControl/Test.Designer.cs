namespace ChartControls
{
	public partial class Test
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
			System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem1 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
			System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
			this.mChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.lDataSelected = new System.Windows.Forms.Label();
			this.panelChart = new GradiantPanel();
			this.checkBoxShowUserSelection = new System.Windows.Forms.CheckBox();
			this.trackBar1 = new gTrackBar.gTrackBar();
			this.cbChartView = new System.Windows.Forms.ComboBox();
			this.lPageInformation = new System.Windows.Forms.Label();
			this.cbItemsPerChart = new System.Windows.Forms.ComboBox();
			this.lCountInformation = new System.Windows.Forms.Label();
			this.cbThenBy = new System.Windows.Forms.ComboBox();
			this.cbSortBy = new System.Windows.Forms.ComboBox();
			this.lThenBy = new System.Windows.Forms.Label();
			this.lSortBy = new System.Windows.Forms.Label();
			this.gelButtPageR = new GelButton();
			this.gelButtPageL = new GelButton();
			this.gbContainer = new GelButton();
			this.panelVolts = new GradiantPanel();
			this.gbVolts = new GelButton();
			this.gbAlerts = new GelButton();
			this.panelMain = new GradiantPanel();
			this.gelButtIncrR = new GelButton();
			this.gelButtIncrL = new GelButton();
			((System.ComponentModel.ISupportInitialize)(this.mChart)).BeginInit();
			this.panelChart.SuspendLayout();
			this.panelVolts.SuspendLayout();
			this.panelMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// mChart
			// 
			this.mChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
			this.mChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
			this.mChart.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
			this.mChart.BorderlineColor = System.Drawing.Color.Black;
			chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
			chartArea1.AxisX.Interval = 1D;
			chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
			chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
			chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(64)))), ((int)(((byte)(70)))));
			chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
			chartArea1.AxisX.Title = "X Axis Title";
			chartArea1.AxisX.TitleFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
			chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.White;
			chartArea1.AxisY.InterlacedColor = System.Drawing.Color.White;
			chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
			chartArea1.AxisY.LabelStyle.Format = "{0}";
			chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
			chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(64)))), ((int)(((byte)(70)))));
			chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
			stripLine1.BorderColor = System.Drawing.Color.Yellow;
			stripLine1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
			stripLine1.BorderWidth = 2;
			stripLine1.ForeColor = System.Drawing.Color.White;
			stripLine1.IntervalOffset = 850D;
			stripLine1.ToolTip = "850 mV";
			chartArea1.AxisY.StripLines.Add(stripLine1);
			chartArea1.AxisY.Title = "Y Axis Title";
			chartArea1.AxisY.TitleFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
			customLabel1.ForeColor = System.Drawing.Color.White;
			customLabel1.FromPosition = 840D;
			customLabel1.MarkColor = System.Drawing.Color.Yellow;
			customLabel1.Text = "-850 mV";
			customLabel1.ToPosition = 860D;
			chartArea1.AxisY2.CustomLabels.Add(customLabel1);
			chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
			chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(64)))), ((int)(((byte)(70)))));
			chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
			chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.White;
			chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
			chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
			chartArea1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
			chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
			chartArea1.CursorX.IsUserEnabled = true;
			chartArea1.CursorX.IsUserSelectionEnabled = true;
			chartArea1.CursorX.LineWidth = 2;
			chartArea1.CursorX.SelectionColor = System.Drawing.Color.Blue;
			chartArea1.Name = "Main";
			chartArea1.Position.Auto = false;
			chartArea1.Position.Height = 94F;
			chartArea1.Position.Width = 98F;
			this.mChart.ChartAreas.Add(chartArea1);
			legend1.AutoFitMinFontSize = 6;
			legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
			legend1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
			legendItem1.BorderColor = System.Drawing.Color.Empty;
			legendItem1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
			legendItem1.BorderWidth = 3;
			legendItem1.Color = System.Drawing.Color.Yellow;
			legendItem1.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Line;
			legendItem1.Name = "Cuztom";
			legend1.CustomItems.Add(legendItem1);
			legend1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			legend1.ForeColor = System.Drawing.Color.White;
			legend1.IsTextAutoFit = false;
			legend1.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.ReversedSeriesOrder;
			legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
			legend1.MaximumAutoSize = 36F;
			legend1.Name = "Legend1";
			legend1.Position.Auto = false;
			legend1.Position.Height = 6F;
			legend1.Position.Width = 42F;
			legend1.Position.X = 2F;
			legend1.Position.Y = 92F;
			legend2.AutoFitMinFontSize = 6;
			legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
			legend2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
			legend2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
			legend2.ForeColor = System.Drawing.Color.White;
			legend2.IsTextAutoFit = false;
			legend2.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.ReversedSeriesOrder;
			legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
			legend2.Name = "Legend2";
			legend2.Position.Auto = false;
			legend2.Position.Height = 6F;
			legend2.Position.Width = 12.8F;
			legend2.Position.X = 84F;
			legend2.Position.Y = 92F;
			this.mChart.Legends.Add(legend1);
			this.mChart.Legends.Add(legend2);
			this.mChart.Location = new System.Drawing.Point(0, 29);
			this.mChart.Margin = new System.Windows.Forms.Padding(0);
			this.mChart.Name = "mChart";
			series1.ChartArea = "Main";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
			series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(120)))), ((int)(((byte)(48)))));
			series1.CustomProperties = "DrawingStyle=Cylinder, EmptyPointValue=Zero, PointWidth=0.5";
			series1.Font = new System.Drawing.Font("Verdana", 8F);
			series1.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(220)))), ((int)(((byte)(20)))));
			series1.Legend = "Legend1";
			series1.LegendText = "Series1 data";
			series1.Name = "Series1";
			series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
			series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			series2.ChartArea = "Main";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
			series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			series2.CustomProperties = "DrawingStyle=Cylinder, EmptyPointValue=Zero, PointWidth=0.5";
			series2.Font = new System.Drawing.Font("Verdana", 8F);
			series2.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			series2.Legend = "Legend1";
			series2.LegendText = "Series2 data";
			series2.Name = "Series2";
			series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
			series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			series3.ChartArea = "Main";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
			series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
			series3.CustomProperties = "DrawingStyle=Cylinder, EmptyPointValue=Zero, PointWidth=0.5";
			series3.Font = new System.Drawing.Font("Verdana", 8F);
			series3.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(220)))));
			series3.Legend = "Legend1";
			series3.LegendText = "Series3 data";
			series3.Name = "Series3";
			series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
			series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			series4.ChartArea = "Main";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series4.Color = System.Drawing.Color.Gold;
			series4.Legend = "Legend2";
			series4.Name = "* Polarization";
			series4.YValuesPerPoint = 4;
			this.mChart.Series.Add(series1);
			this.mChart.Series.Add(series2);
			this.mChart.Series.Add(series3);
			this.mChart.Series.Add(series4);
			this.mChart.Size = new System.Drawing.Size(1017, 397);
			this.mChart.TabIndex = 0;
			this.mChart.Text = "mChart";
			title1.DockedToChartArea = "Main";
			title1.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold);
			title1.ForeColor = System.Drawing.Color.White;
			title1.Name = "Title1";
			title1.Position.Auto = false;
			title1.Position.Width = 100F;
			title1.Position.Y = 10F;
			title1.Text = "Chart Title";
			title2.DockedToChartArea = "Main";
			title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			title2.Font = new System.Drawing.Font("Arial", 8.25F);
			title2.ForeColor = System.Drawing.Color.Yellow;
			title2.IsDockedInsideChartArea = false;
			title2.Name = "Title2";
			title2.Position.Auto = false;
			title2.Position.Height = 6F;
			title2.Position.Width = 90F;
			title2.Position.X = 8.5F;
			title2.Position.Y = 92F;
			title2.Text = "Chart Title 2";
			this.mChart.Titles.Add(title1);
			this.mChart.Titles.Add(title2);
			this.mChart.CursorPositionChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.cursor_position_changing);
			this.mChart.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.cursor_position_changed);
			// 
			// lDataSelected
			// 
			this.lDataSelected.AutoSize = true;
			this.lDataSelected.BackColor = System.Drawing.Color.Transparent;
			this.lDataSelected.CausesValidation = false;
			this.lDataSelected.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.lDataSelected.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lDataSelected.ForeColor = System.Drawing.Color.White;
			this.lDataSelected.Location = new System.Drawing.Point(102, 47);
			this.lDataSelected.Margin = new System.Windows.Forms.Padding(136, 44, 0, 0);
			this.lDataSelected.Name = "lDataSelected";
			this.lDataSelected.Size = new System.Drawing.Size(102, 16);
			this.lDataSelected.TabIndex = 0;
			this.lDataSelected.Text = "Data Selected";
			this.lDataSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lDataSelected.Visible = false;
			// 
			// panelChart
			// 
			this.panelChart.BackColor = System.Drawing.Color.Black;
			this.panelChart.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.panelChart.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
			this.panelChart.ColorAngle = -90F;
			this.panelChart.Controls.Add(this.checkBoxShowUserSelection);
			this.panelChart.Controls.Add(this.trackBar1);
			this.panelChart.Controls.Add(this.cbChartView);
			this.panelChart.Controls.Add(this.lPageInformation);
			this.panelChart.Controls.Add(this.cbItemsPerChart);
			this.panelChart.Controls.Add(this.lCountInformation);
			this.panelChart.Controls.Add(this.cbThenBy);
			this.panelChart.Controls.Add(this.cbSortBy);
			this.panelChart.Controls.Add(this.lThenBy);
			this.panelChart.Controls.Add(this.lSortBy);
			this.panelChart.Controls.Add(this.gelButtPageR);
			this.panelChart.Controls.Add(this.gelButtPageL);
			this.panelChart.Controls.Add(this.gbContainer);
			this.panelChart.Controls.Add(this.lDataSelected);
			this.panelChart.Controls.Add(this.mChart);
			this.panelChart.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelChart.Location = new System.Drawing.Point(0, 0);
			this.panelChart.Name = "panelChart";
			this.panelChart.Size = new System.Drawing.Size(1017, 496);
			this.panelChart.TabIndex = 1;
			// 
			// checkBoxShowUserSelection
			// 
			this.checkBoxShowUserSelection.AutoSize = true;
			this.checkBoxShowUserSelection.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxShowUserSelection.ForeColor = System.Drawing.Color.White;
			this.checkBoxShowUserSelection.Location = new System.Drawing.Point(9, 428);
			this.checkBoxShowUserSelection.Name = "checkBoxShowUserSelection";
			this.checkBoxShowUserSelection.Size = new System.Drawing.Size(69, 30);
			this.checkBoxShowUserSelection.TabIndex = 18;
			this.checkBoxShowUserSelection.Text = "Show\r\nAll Series";
			this.checkBoxShowUserSelection.UseVisualStyleBackColor = false;
			this.checkBoxShowUserSelection.Visible = false;
			this.checkBoxShowUserSelection.CheckedChanged += new System.EventHandler(this.checkBoxShowUserSelection_CheckedChanged);
			// 
			// trackBar1
			// 
			this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
			this.trackBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.trackBar1.FloatValue = false;
			this.trackBar1.FloatValueFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.trackBar1.JumpToMouse = true;
			this.trackBar1.Label = null;
			this.trackBar1.LabelPadding = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.trackBar1.Location = new System.Drawing.Point(87, 428);
			this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.ShowFocus = false;
			this.trackBar1.Size = new System.Drawing.Size(921, 30);
			this.trackBar1.SliderShape = gTrackBar.gTrackBar.eShape.ArrowUp;
			this.trackBar1.SliderWidthHigh = 1F;
			this.trackBar1.SliderWidthLow = 1F;
			this.trackBar1.TabIndex = 17;
			this.trackBar1.TickThickness = 1F;
			this.trackBar1.Value = 0;
			this.trackBar1.ValueAdjusted = 0F;
			this.trackBar1.ValueDivisor = gTrackBar.gTrackBar.eValueDivisor.e1;
			this.trackBar1.ValueStrFormat = null;
			this.trackBar1.ValueChanged += new gTrackBar.gTrackBar.ValueChangedEventHandler(this.trackBar1_ValueChanged);
			// 
			// cbChartView
			// 
			this.cbChartView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbChartView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbChartView.FormattingEnabled = true;
			this.cbChartView.Items.AddRange(new object[] {
            "{0} of {1}"});
			this.cbChartView.Location = new System.Drawing.Point(870, 467);
			this.cbChartView.Name = "cbChartView";
			this.cbChartView.Size = new System.Drawing.Size(90, 21);
			this.cbChartView.TabIndex = 16;
			this.cbChartView.Visible = false;
			// 
			// lPageInformation
			// 
			this.lPageInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lPageInformation.AutoSize = true;
			this.lPageInformation.BackColor = System.Drawing.Color.Transparent;
			this.lPageInformation.CausesValidation = false;
			this.lPageInformation.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.lPageInformation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lPageInformation.ForeColor = System.Drawing.Color.White;
			this.lPageInformation.Location = new System.Drawing.Point(825, 470);
			this.lPageInformation.Margin = new System.Windows.Forms.Padding(136, 44, 0, 0);
			this.lPageInformation.Name = "lPageInformation";
			this.lPageInformation.Size = new System.Drawing.Size(39, 13);
			this.lPageInformation.TabIndex = 15;
			this.lPageInformation.Text = "Chart";
			this.lPageInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lPageInformation.Visible = false;
			// 
			// cbItemsPerChart
			// 
			this.cbItemsPerChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbItemsPerChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbItemsPerChart.FormattingEnabled = true;
			this.cbItemsPerChart.Items.AddRange(new object[] {
            "{0} items per"});
			this.cbItemsPerChart.Location = new System.Drawing.Point(640, 467);
			this.cbItemsPerChart.Name = "cbItemsPerChart";
			this.cbItemsPerChart.Size = new System.Drawing.Size(129, 21);
			this.cbItemsPerChart.TabIndex = 14;
			this.cbItemsPerChart.Visible = false;
			// 
			// lCountInformation
			// 
			this.lCountInformation.AutoSize = true;
			this.lCountInformation.BackColor = System.Drawing.Color.Transparent;
			this.lCountInformation.CausesValidation = false;
			this.lCountInformation.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.lCountInformation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lCountInformation.ForeColor = System.Drawing.Color.White;
			this.lCountInformation.Location = new System.Drawing.Point(6, 470);
			this.lCountInformation.Margin = new System.Windows.Forms.Padding(136, 44, 0, 0);
			this.lCountInformation.Name = "lCountInformation";
			this.lCountInformation.Size = new System.Drawing.Size(102, 13);
			this.lCountInformation.TabIndex = 13;
			this.lCountInformation.Text = "{0} - {1} of {2}";
			this.lCountInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbThenBy
			// 
			this.cbThenBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbThenBy.FormattingEnabled = true;
			this.cbThenBy.Location = new System.Drawing.Point(398, 467);
			this.cbThenBy.Name = "cbThenBy";
			this.cbThenBy.Size = new System.Drawing.Size(115, 21);
			this.cbThenBy.TabIndex = 12;
			this.cbThenBy.Visible = false;
			this.cbThenBy.SelectedIndexChanged += new System.EventHandler(this.cbThenBy_SelectedIndexChanged);
			// 
			// cbSortBy
			// 
			this.cbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSortBy.FormattingEnabled = true;
			this.cbSortBy.Items.AddRange(new object[] {
            "Default"});
			this.cbSortBy.Location = new System.Drawing.Point(215, 467);
			this.cbSortBy.Name = "cbSortBy";
			this.cbSortBy.Size = new System.Drawing.Size(115, 21);
			this.cbSortBy.TabIndex = 6;
			this.cbSortBy.Visible = false;
			this.cbSortBy.SelectedIndexChanged += new System.EventHandler(this.cbSortBy_SelectedIndexChanged);
			// 
			// lThenBy
			// 
			this.lThenBy.AutoSize = true;
			this.lThenBy.BackColor = System.Drawing.Color.Transparent;
			this.lThenBy.CausesValidation = false;
			this.lThenBy.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.lThenBy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lThenBy.ForeColor = System.Drawing.Color.White;
			this.lThenBy.Location = new System.Drawing.Point(337, 470);
			this.lThenBy.Margin = new System.Windows.Forms.Padding(136, 44, 0, 0);
			this.lThenBy.Name = "lThenBy";
			this.lThenBy.Size = new System.Drawing.Size(54, 13);
			this.lThenBy.TabIndex = 11;
			this.lThenBy.Text = "Then By";
			this.lThenBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lThenBy.Visible = false;
			// 
			// lSortBy
			// 
			this.lSortBy.AutoSize = true;
			this.lSortBy.BackColor = System.Drawing.Color.Transparent;
			this.lSortBy.CausesValidation = false;
			this.lSortBy.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.lSortBy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lSortBy.ForeColor = System.Drawing.Color.White;
			this.lSortBy.Location = new System.Drawing.Point(161, 470);
			this.lSortBy.Margin = new System.Windows.Forms.Padding(136, 44, 0, 0);
			this.lSortBy.Name = "lSortBy";
			this.lSortBy.Size = new System.Drawing.Size(50, 13);
			this.lSortBy.TabIndex = 9;
			this.lSortBy.Text = "Sort By";
			this.lSortBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lSortBy.Visible = false;
			// 
			// gelButtPageR
			// 
			this.gelButtPageR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gelButtPageR.CornerRadiusScaler = 3;
			this.gelButtPageR.Enabled = false;
			this.gelButtPageR.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gelButtPageR.ForeColor = System.Drawing.Color.White;
			this.gelButtPageR.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtPageR.GradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtPageR.HighlightColor = System.Drawing.Color.PaleVioletRed;
			this.gelButtPageR.HighlightRectangleScaler = 3F;
			this.gelButtPageR.Location = new System.Drawing.Point(968, 468);
			this.gelButtPageR.Name = "gelButtPageR";
			this.gelButtPageR.Size = new System.Drawing.Size(40, 20);
			this.gelButtPageR.TabIndex = 6;
			this.gelButtPageR.Text = ">>";
			this.gelButtPageR.UseVisualStyleBackColor = true;
			this.gelButtPageR.Visible = false;
			this.gelButtPageR.Click += new System.EventHandler(this.gelButtPageR_Click);
			// 
			// gelButtPageL
			// 
			this.gelButtPageL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gelButtPageL.CornerRadiusScaler = 3;
			this.gelButtPageL.Enabled = false;
			this.gelButtPageL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gelButtPageL.ForeColor = System.Drawing.Color.White;
			this.gelButtPageL.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtPageL.GradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtPageL.HighlightColor = System.Drawing.Color.PaleVioletRed;
			this.gelButtPageL.HighlightRectangleScaler = 3F;
			this.gelButtPageL.Location = new System.Drawing.Point(781, 468);
			this.gelButtPageL.Name = "gelButtPageL";
			this.gelButtPageL.Size = new System.Drawing.Size(40, 20);
			this.gelButtPageL.TabIndex = 5;
			this.gelButtPageL.Text = "<<";
			this.gelButtPageL.UseVisualStyleBackColor = true;
			this.gelButtPageL.Visible = false;
			this.gelButtPageL.Click += new System.EventHandler(this.gelButtPageL_Click);
			// 
			// gbContainer
			// 
			this.gbContainer.CornerRadiusScaler = 3;
			this.gbContainer.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbContainer.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbContainer.ForeColor = System.Drawing.Color.White;
			this.gbContainer.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gbContainer.GradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gbContainer.HighlightColor = System.Drawing.Color.PaleVioletRed;
			this.gbContainer.HighlightRectangleScaler = 3F;
			this.gbContainer.Location = new System.Drawing.Point(0, 0);
			this.gbContainer.Margin = new System.Windows.Forms.Padding(0);
			this.gbContainer.Name = "gbContainer";
			this.gbContainer.Size = new System.Drawing.Size(1017, 28);
			this.gbContainer.TabIndex = 4;
			this.gbContainer.Text = "Control Title";
			this.gbContainer.UseVisualStyleBackColor = true;
			// 
			// panelVolts
			// 
			this.panelVolts.BackColor = System.Drawing.Color.Black;
			this.panelVolts.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.panelVolts.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
			this.panelVolts.ColorAngle = -90F;
			this.panelVolts.Controls.Add(this.gbVolts);
			this.panelVolts.Location = new System.Drawing.Point(23, 535);
			this.panelVolts.Name = "panelVolts";
			this.panelVolts.Size = new System.Drawing.Size(254, 71);
			this.panelVolts.TabIndex = 5;
			// 
			// gbVolts
			// 
			this.gbVolts.CornerRadiusScaler = 3;
			this.gbVolts.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbVolts.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbVolts.ForeColor = System.Drawing.Color.White;
			this.gbVolts.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gbVolts.GradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gbVolts.HighlightColor = System.Drawing.Color.PaleVioletRed;
			this.gbVolts.HighlightRectangleScaler = 3F;
			this.gbVolts.Location = new System.Drawing.Point(0, 0);
			this.gbVolts.Name = "gbVolts";
			this.gbVolts.Size = new System.Drawing.Size(254, 28);
			this.gbVolts.TabIndex = 3;
			this.gbVolts.Text = "Volts";
			this.gbVolts.UseVisualStyleBackColor = true;
			// 
			// gbAlerts
			// 
			this.gbAlerts.CornerRadiusScaler = 3;
			this.gbAlerts.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbAlerts.ForeColor = System.Drawing.Color.White;
			this.gbAlerts.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gbAlerts.GradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gbAlerts.HighlightColor = System.Drawing.Color.PaleVioletRed;
			this.gbAlerts.HighlightRectangleScaler = 3F;
			this.gbAlerts.Location = new System.Drawing.Point(694, 558);
			this.gbAlerts.Name = "gbAlerts";
			this.gbAlerts.Size = new System.Drawing.Size(218, 48);
			this.gbAlerts.TabIndex = 2;
			this.gbAlerts.Text = "Alerts\n0 Vdc or >60 Vdc";
			this.gbAlerts.UseVisualStyleBackColor = true;
			// 
			// panelMain
			// 
			this.panelMain.Color1 = System.Drawing.Color.White;
			this.panelMain.Color2 = System.Drawing.Color.Black;
			this.panelMain.ColorAngle = 0F;
			this.panelMain.Controls.Add(this.gelButtIncrR);
			this.panelMain.Controls.Add(this.gelButtIncrL);
			this.panelMain.Controls.Add(this.panelVolts);
			this.panelMain.Controls.Add(this.gbAlerts);
			this.panelMain.Controls.Add(this.panelChart);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(1017, 644);
			this.panelMain.TabIndex = 2;
			// 
			// gelButtIncrR
			// 
			this.gelButtIncrR.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gelButtIncrR.CornerRadiusScaler = 3;
			this.gelButtIncrR.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gelButtIncrR.ForeColor = System.Drawing.Color.White;
			this.gelButtIncrR.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtIncrR.GradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtIncrR.HighlightColor = System.Drawing.Color.PaleVioletRed;
			this.gelButtIncrR.HighlightRectangleScaler = 3F;
			this.gelButtIncrR.Location = new System.Drawing.Point(537, 502);
			this.gelButtIncrR.Name = "gelButtIncrR";
			this.gelButtIncrR.Size = new System.Drawing.Size(40, 20);
			this.gelButtIncrR.TabIndex = 7;
			this.gelButtIncrR.Text = ">";
			this.gelButtIncrR.UseVisualStyleBackColor = true;
			this.gelButtIncrR.Click += new System.EventHandler(this.gelButtIncrR_Click);
			// 
			// gelButtIncrL
			// 
			this.gelButtIncrL.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gelButtIncrL.CornerRadiusScaler = 3;
			this.gelButtIncrL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gelButtIncrL.ForeColor = System.Drawing.Color.White;
			this.gelButtIncrL.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtIncrL.GradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtIncrL.HighlightColor = System.Drawing.Color.PaleVioletRed;
			this.gelButtIncrL.HighlightRectangleScaler = 3F;
			this.gelButtIncrL.Location = new System.Drawing.Point(491, 502);
			this.gelButtIncrL.Name = "gelButtIncrL";
			this.gelButtIncrL.Size = new System.Drawing.Size(40, 20);
			this.gelButtIncrL.TabIndex = 6;
			this.gelButtIncrL.Text = "<";
			this.gelButtIncrL.UseVisualStyleBackColor = true;
			this.gelButtIncrL.Click += new System.EventHandler(this.gelButtIncrL_Click);
			// 
			// chartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1017, 644);
			this.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
			this.Controls.Add(this.panelMain);
			this.Name = "chartForm";
			this.Text = "CP Module";
			this.Load += new System.EventHandler(this.Form_Load);
			((System.ComponentModel.ISupportInitialize)(this.mChart)).EndInit();
			this.panelChart.ResumeLayout(false);
			this.panelChart.PerformLayout();
			this.panelVolts.ResumeLayout(false);
			this.panelMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}


		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart mChart;
		private GelButton gbAlerts;
		private GelButton gbContainer;
		private GelButton gbVolts;
		private GelButton gelButtPageR;
		private GelButton gelButtPageL;
		private GelButton gelButtIncrL;
		private GelButton gelButtIncrR;
		private GradiantPanel panelChart;
		private GradiantPanel panelMain;
		private GradiantPanel panelVolts;
		private System.Windows.Forms.Label lDataSelected;
		private System.Windows.Forms.Label lSortBy;
		private System.Windows.Forms.Label lThenBy;
		private System.Windows.Forms.Label lCountInformation;
		private System.Windows.Forms.Label lPageInformation;
		private System.Windows.Forms.ComboBox cbSortBy;
		private System.Windows.Forms.ComboBox cbThenBy;
		private System.Windows.Forms.ComboBox cbItemsPerChart;
		private System.Windows.Forms.ComboBox cbChartView;
		private gTrackBar.gTrackBar trackBar1;
		private System.Windows.Forms.CheckBox checkBoxShowUserSelection;
	}
}

