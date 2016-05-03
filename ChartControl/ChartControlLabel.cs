using System.Windows.Forms;
using X;

namespace ChartControls
{
	public partial class ChartControlLabel : UserControl
	{
		public ChartControlLabel()
		{
			InitializeComponent();
		}

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

			set { _data = value; }
		}

		private void chartContainerControl1_Load(object sender, System.EventArgs e)
		{
			#region Color
			//this.chartContainerControl1.gbTitle.Text = Data.TitleControl;
			this.chartContainerControl1.gradControlPanel.Color1 = Data.Theme.PanelColor1;
			this.chartContainerControl1.gradControlPanel.Color2 = Data.Theme.PanelColor1;
			this.labelOne.ForeColor = this.labelTwo.ForeColor = Data.Theme.ForeColor;
			//this.labelOne.BackColor = this.labelTwo.BackColor = Data.Theme.PanelColor2;
			#endregion
		}
	}
}
