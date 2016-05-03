namespace ChartControls
{
	partial class ChartControlLabel
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
			this.labelOne = new System.Windows.Forms.Label();
			this.labelTwo = new System.Windows.Forms.Label();
			this.chartContainerControl1 = new ChartControls.ChartContainerControl();
			this.SuspendLayout();
			// 
			// labelOne
			// 
			this.labelOne.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelOne.AutoSize = true;
			this.labelOne.BackColor = System.Drawing.Color.Transparent;
			this.labelOne.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelOne.ForeColor = System.Drawing.Color.White;
			this.labelOne.Location = new System.Drawing.Point(20, 52);
			this.labelOne.Margin = new System.Windows.Forms.Padding(0);
			this.labelOne.Name = "labelOne";
			this.labelOne.Size = new System.Drawing.Size(88, 22);
			this.labelOne.TabIndex = 1;
			this.labelOne.Text = "Label - 1";
			this.labelOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTwo
			// 
			this.labelTwo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelTwo.AutoSize = true;
			this.labelTwo.BackColor = System.Drawing.Color.Transparent;
			this.labelTwo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTwo.ForeColor = System.Drawing.Color.White;
			this.labelTwo.Location = new System.Drawing.Point(20, 94);
			this.labelTwo.Margin = new System.Windows.Forms.Padding(0);
			this.labelTwo.Name = "labelTwo";
			this.labelTwo.Size = new System.Drawing.Size(88, 22);
			this.labelTwo.TabIndex = 2;
			this.labelTwo.Text = "Label - 2";
			this.labelTwo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chartContainerControl1
			// 
			this.chartContainerControl1.BackColor = System.Drawing.Color.Transparent;
			this.chartContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.chartContainerControl1.Name = "chartContainerControl1";
			this.chartContainerControl1.Size = new System.Drawing.Size(182, 148);
			this.chartContainerControl1.TabIndex = 0;
			this.chartContainerControl1.Load += new System.EventHandler(this.chartContainerControl1_Load);
			// 
			// ChartControlLabel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.labelTwo);
			this.Controls.Add(this.labelOne);
			this.Controls.Add(this.chartContainerControl1);
			this.Name = "ChartControlLabel";
			this.Size = new System.Drawing.Size(182, 148);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.Label labelOne;
		public System.Windows.Forms.Label labelTwo;
		public ChartControls.ChartContainerControl chartContainerControl1;
	}
}
