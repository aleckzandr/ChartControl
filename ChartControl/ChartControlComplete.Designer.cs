namespace ChartControls
{
	partial class ChartControlComplete
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.mChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.checkBoxShowUserSelection = new System.Windows.Forms.CheckBox();
			this.cbChartView = new System.Windows.Forms.ComboBox();
			this.cbItemsPerChart = new System.Windows.Forms.ComboBox();
			this.cbSortBy = new System.Windows.Forms.ComboBox();
			this.cbThenBy = new System.Windows.Forms.ComboBox();
			this.lCountInformation = new System.Windows.Forms.Label();
			this.lPageInformation = new System.Windows.Forms.Label();
			this.lSortBy = new System.Windows.Forms.Label();
			this.lThenBy = new System.Windows.Forms.Label();
			this.trackBar1 = new gTrackBar.gTrackBar();
			this.lDataSelected = new LabelWithBorder();
			this.gelButtPageR = new GelButton();
			this.gelButtPageL = new GelButton();
			this.chartContainerControl1 = new ChartControls.ChartContainerControl();
			((System.ComponentModel.ISupportInitialize)(this.mChart)).BeginInit();
			this.SuspendLayout();
			// 
			// mChart
			// 
			this.mChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.Name = "Main";
			chartArea1.Position.Auto = false;
			chartArea1.Position.Height = 94F;
			chartArea1.Position.Width = 94F;
			this.mChart.ChartAreas.Add(chartArea1);
			this.mChart.Location = new System.Drawing.Point(0, 32);
			this.mChart.Margin = new System.Windows.Forms.Padding(0);
			this.mChart.Name = "mChart";
			series1.ChartArea = "Main";
			series1.Name = "Series1";
			this.mChart.Series.Add(series1);
			this.mChart.Size = new System.Drawing.Size(870, 246);
			this.mChart.TabIndex = 1;
			this.mChart.Text = "chart1";
			this.mChart.CursorPositionChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.cursor_position_changing);
			this.mChart.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.cursor_position_changed);
			// 
			// checkBoxShowUserSelection
			// 
			this.checkBoxShowUserSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxShowUserSelection.AutoSize = true;
			this.checkBoxShowUserSelection.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxShowUserSelection.ForeColor = System.Drawing.Color.White;
			this.checkBoxShowUserSelection.Location = new System.Drawing.Point(0, 278);
			this.checkBoxShowUserSelection.Margin = new System.Windows.Forms.Padding(0);
			this.checkBoxShowUserSelection.Name = "checkBoxShowUserSelection";
			this.checkBoxShowUserSelection.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
			this.checkBoxShowUserSelection.Size = new System.Drawing.Size(71, 30);
			this.checkBoxShowUserSelection.TabIndex = 30;
			this.checkBoxShowUserSelection.Text = "Show\r\nAll Series";
			this.checkBoxShowUserSelection.UseVisualStyleBackColor = false;
			this.checkBoxShowUserSelection.Visible = false;
			this.checkBoxShowUserSelection.CheckedChanged += new System.EventHandler(this.checkBoxShowUserSelection_CheckedChanged);
			// 
			// cbChartView
			// 
			this.cbChartView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cbChartView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbChartView.FormattingEnabled = true;
			this.cbChartView.Items.AddRange(new object[] {
            "{0} of {1}"});
			this.cbChartView.Location = new System.Drawing.Point(724, 317);
			this.cbChartView.Name = "cbChartView";
			this.cbChartView.Size = new System.Drawing.Size(90, 21);
			this.cbChartView.TabIndex = 28;
			this.cbChartView.Visible = false;
			this.cbChartView.SelectedIndexChanged += new System.EventHandler(this.cbChartView_SelectedIndexChanged);
			// 
			// cbItemsPerChart
			// 
			this.cbItemsPerChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cbItemsPerChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbItemsPerChart.FormattingEnabled = true;
			this.cbItemsPerChart.Items.AddRange(new object[] {
            "{0} items per"});
			this.cbItemsPerChart.Location = new System.Drawing.Point(500, 317);
			this.cbItemsPerChart.Name = "cbItemsPerChart";
			this.cbItemsPerChart.Size = new System.Drawing.Size(129, 21);
			this.cbItemsPerChart.TabIndex = 26;
			this.cbItemsPerChart.Visible = false;
			// 
			// cbSortBy
			// 
			this.cbSortBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSortBy.FormattingEnabled = true;
			this.cbSortBy.Items.AddRange(new object[] {
            "Default"});
			this.cbSortBy.Location = new System.Drawing.Point(203, 317);
			this.cbSortBy.Name = "cbSortBy";
			this.cbSortBy.Size = new System.Drawing.Size(115, 21);
			this.cbSortBy.TabIndex = 20;
			this.cbSortBy.Visible = false;
			this.cbSortBy.SelectedIndexChanged += new System.EventHandler(this.cbSortBy_SelectedIndexChanged);
			// 
			// cbThenBy
			// 
			this.cbThenBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbThenBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbThenBy.FormattingEnabled = true;
			this.cbThenBy.Location = new System.Drawing.Point(376, 317);
			this.cbThenBy.Name = "cbThenBy";
			this.cbThenBy.Size = new System.Drawing.Size(115, 21);
			this.cbThenBy.TabIndex = 24;
			this.cbThenBy.Visible = false;
			this.cbThenBy.SelectedIndexChanged += new System.EventHandler(this.cbThenBy_SelectedIndexChanged);
			// 
			// lCountInformation
			// 
			this.lCountInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lCountInformation.AutoSize = true;
			this.lCountInformation.BackColor = System.Drawing.Color.Transparent;
			this.lCountInformation.CausesValidation = false;
			this.lCountInformation.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.lCountInformation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lCountInformation.ForeColor = System.Drawing.Color.White;
			this.lCountInformation.Location = new System.Drawing.Point(3, 320);
			this.lCountInformation.Margin = new System.Windows.Forms.Padding(136, 44, 0, 0);
			this.lCountInformation.Name = "lCountInformation";
			this.lCountInformation.Size = new System.Drawing.Size(102, 13);
			this.lCountInformation.TabIndex = 25;
			this.lCountInformation.Text = "{0} - {1} of {2}";
			this.lCountInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lPageInformation
			// 
			this.lPageInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lPageInformation.AutoSize = true;
			this.lPageInformation.BackColor = System.Drawing.Color.Transparent;
			this.lPageInformation.CausesValidation = false;
			this.lPageInformation.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.lPageInformation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lPageInformation.ForeColor = System.Drawing.Color.White;
			this.lPageInformation.Location = new System.Drawing.Point(681, 320);
			this.lPageInformation.Margin = new System.Windows.Forms.Padding(136, 44, 0, 0);
			this.lPageInformation.Name = "lPageInformation";
			this.lPageInformation.Size = new System.Drawing.Size(39, 13);
			this.lPageInformation.TabIndex = 27;
			this.lPageInformation.Text = "Chart";
			this.lPageInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lPageInformation.Visible = false;
			// 
			// lSortBy
			// 
			this.lSortBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lSortBy.AutoSize = true;
			this.lSortBy.BackColor = System.Drawing.Color.Transparent;
			this.lSortBy.CausesValidation = false;
			this.lSortBy.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.lSortBy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lSortBy.ForeColor = System.Drawing.Color.White;
			this.lSortBy.Location = new System.Drawing.Point(151, 320);
			this.lSortBy.Margin = new System.Windows.Forms.Padding(136, 44, 0, 0);
			this.lSortBy.Name = "lSortBy";
			this.lSortBy.Size = new System.Drawing.Size(50, 13);
			this.lSortBy.TabIndex = 22;
			this.lSortBy.Text = "Sort By";
			this.lSortBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lSortBy.Visible = false;
			// 
			// lThenBy
			// 
			this.lThenBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lThenBy.AutoSize = true;
			this.lThenBy.BackColor = System.Drawing.Color.Transparent;
			this.lThenBy.CausesValidation = false;
			this.lThenBy.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.lThenBy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lThenBy.ForeColor = System.Drawing.Color.White;
			this.lThenBy.Location = new System.Drawing.Point(321, 320);
			this.lThenBy.Margin = new System.Windows.Forms.Padding(136, 44, 0, 0);
			this.lThenBy.Name = "lThenBy";
			this.lThenBy.Size = new System.Drawing.Size(54, 13);
			this.lThenBy.TabIndex = 23;
			this.lThenBy.Text = "Then By";
			this.lThenBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lThenBy.Visible = false;
			// 
			// trackBar1
			// 
			this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar1.BackColor = System.Drawing.Color.Transparent;
			this.trackBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.trackBar1.FloatValue = false;
			this.trackBar1.FloatValueFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.trackBar1.JumpToMouse = true;
			this.trackBar1.Label = null;
			this.trackBar1.LabelPadding = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.trackBar1.Location = new System.Drawing.Point(82, 278);
			this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.ShowFocus = false;
			this.trackBar1.Size = new System.Drawing.Size(788, 30);
			this.trackBar1.SliderShape = gTrackBar.gTrackBar.eShape.ArrowUp;
			this.trackBar1.SliderWidthHigh = 1F;
			this.trackBar1.SliderWidthLow = 1F;
			this.trackBar1.TabIndex = 29;
			this.trackBar1.TickThickness = 1F;
			this.trackBar1.Value = 0;
			this.trackBar1.ValueAdjusted = 0F;
			this.trackBar1.ValueDivisor = gTrackBar.gTrackBar.eValueDivisor.e1;
			this.trackBar1.ValueStrFormat = null;
			this.trackBar1.ValueChanged += new gTrackBar.gTrackBar.ValueChangedEventHandler(this.trackBar1_ValueChanged);
			// 
			// lDataSelected
			// 
			this.lDataSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lDataSelected.AutoSize = true;
			this.lDataSelected.BackColor = System.Drawing.Color.Transparent;
			this.lDataSelected.CausesValidation = false;
			this.lDataSelected.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.lDataSelected.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lDataSelected.ForeColor = System.Drawing.Color.White;
			this.lDataSelected.Location = new System.Drawing.Point(570, 235);
			this.lDataSelected.Margin = new System.Windows.Forms.Padding(0);
			this.lDataSelected.Name = "lDataSelected";
			this.lDataSelected.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.lDataSelected.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lDataSelected.Size = new System.Drawing.Size(297, 20);
			this.lDataSelected.TabIndex = 0;
			this.lDataSelected.Text = "Data Selected - Autosized12345678901234";
			this.lDataSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lDataSelected.Visible = false;
			// 
			// gelButtPageR
			// 
			this.gelButtPageR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.gelButtPageR.CornerRadiusScaler = 3;
			this.gelButtPageR.Enabled = false;
			this.gelButtPageR.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gelButtPageR.ForeColor = System.Drawing.Color.White;
			this.gelButtPageR.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtPageR.GradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtPageR.HighlightColor = System.Drawing.Color.PaleVioletRed;
			this.gelButtPageR.HighlightRectangleScaler = 3F;
			this.gelButtPageR.Location = new System.Drawing.Point(822, 318);
			this.gelButtPageR.Name = "gelButtPageR";
			this.gelButtPageR.Size = new System.Drawing.Size(40, 20);
			this.gelButtPageR.TabIndex = 21;
			this.gelButtPageR.Text = ">>";
			this.gelButtPageR.UseVisualStyleBackColor = true;
			this.gelButtPageR.Visible = false;
			this.gelButtPageR.Click += new System.EventHandler(this.gelButtPageR_Click);
			// 
			// gelButtPageL
			// 
			this.gelButtPageL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.gelButtPageL.CornerRadiusScaler = 3;
			this.gelButtPageL.Enabled = false;
			this.gelButtPageL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gelButtPageL.ForeColor = System.Drawing.Color.White;
			this.gelButtPageL.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtPageL.GradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gelButtPageL.HighlightColor = System.Drawing.Color.PaleVioletRed;
			this.gelButtPageL.HighlightRectangleScaler = 3F;
			this.gelButtPageL.Location = new System.Drawing.Point(638, 318);
			this.gelButtPageL.Name = "gelButtPageL";
			this.gelButtPageL.Size = new System.Drawing.Size(40, 20);
			this.gelButtPageL.TabIndex = 19;
			this.gelButtPageL.Text = "<<";
			this.gelButtPageL.UseVisualStyleBackColor = true;
			this.gelButtPageL.Visible = false;
			this.gelButtPageL.Click += new System.EventHandler(this.gelButtPageL_Click);
			// 
			// chartContainerControl1
			// 
			this.chartContainerControl1.BackColor = System.Drawing.Color.Transparent;
			this.chartContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.chartContainerControl1.Name = "chartContainerControl1";
			this.chartContainerControl1.Size = new System.Drawing.Size(870, 349);
			this.chartContainerControl1.TabIndex = 0;
			// 
			// ChartControlComplete
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.checkBoxShowUserSelection);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.cbChartView);
			this.Controls.Add(this.lPageInformation);
			this.Controls.Add(this.cbItemsPerChart);
			this.Controls.Add(this.lCountInformation);
			this.Controls.Add(this.cbThenBy);
			this.Controls.Add(this.cbSortBy);
			this.Controls.Add(this.lThenBy);
			this.Controls.Add(this.lSortBy);
			this.Controls.Add(this.lDataSelected);
			this.Controls.Add(this.gelButtPageR);
			this.Controls.Add(this.gelButtPageL);
			this.Controls.Add(this.mChart);
			this.Controls.Add(this.chartContainerControl1);
			this.Name = "ChartControlComplete";
			this.Size = new System.Drawing.Size(870, 349);
			this.Load += new System.EventHandler(this.ChartControlComplete_Load);
			((System.ComponentModel.ISupportInitialize)(this.mChart)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ChartControls.ChartContainerControl chartContainerControl1;
		private System.Windows.Forms.DataVisualization.Charting.Chart mChart;
		private System.Windows.Forms.CheckBox checkBoxShowUserSelection;
		private System.Windows.Forms.ComboBox cbChartView;
		private System.Windows.Forms.ComboBox cbItemsPerChart;
		private System.Windows.Forms.ComboBox cbSortBy;
		private System.Windows.Forms.ComboBox cbThenBy;
		private System.Windows.Forms.Label lCountInformation;
		private LabelWithBorder lDataSelected;
		private System.Windows.Forms.Label lPageInformation;
		private System.Windows.Forms.Label lSortBy;
		private System.Windows.Forms.Label lThenBy;
		private GelButton gelButtPageR;
		private GelButton gelButtPageL;
		private gTrackBar.gTrackBar trackBar1;
	}
}
