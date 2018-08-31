using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using ChartHelper;

namespace ChartControls
{
	public partial class ChartControlSimple : UserControl
	{
		public string SeriesCustomProps { get; set; }

		private bool controlLoaded;
		private IChartData _data;
		protected internal IChartData Data
		{
			get
			{
#if DEBUG && TESTDATA
				if (_data == null)
					_data = ChartData.GetTestOhmData(28); // if data is null set it to Test Data with 28 random points
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
			SeriesCustomProps = ChartData.SeriesCustomPropsDefault; // set to something custom here
			InitializeComponent();
		}

		// mocked business rule
		private bool ValidationComparison(double firstValue, double secondValue, int seriesIndex, out double difference)
		{
			// business rule encapsulated in method, call business object method in future?
			difference = Math.Abs(firstValue) - Math.Abs(secondValue);
			if (difference < 0)
				difference = 0;

			return firstValue > 0 && secondValue > 0 && Data.Series.ElementAt(seriesIndex).Name.Equals(Data.SeriesNameForComparisonLabel, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}
