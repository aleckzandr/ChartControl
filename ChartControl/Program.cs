using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartHelper;

namespace ChartControls
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

			//Application.Run(new ChartControls.Test(GetData(ChartThemeStyle.Light)));
			//Application.Run(new ChartControls.Test());
			Application.Run(new ChartControls.TestForm(ChartThemeStyle.Light));
		}
	}
}
