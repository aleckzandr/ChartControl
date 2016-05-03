namespace ChartControls
{
	partial class ChartContainerControl
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
			this.gradControlPanel = new GradiantPanel();
			this.gbTitle = new GelButton();
			this.gradControlPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// gradControlPanel
			// 
			this.gradControlPanel.BackColor = System.Drawing.Color.Transparent;
			this.gradControlPanel.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.gradControlPanel.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
			this.gradControlPanel.ColorAngle = -90F;
			this.gradControlPanel.Controls.Add(this.gbTitle);
			this.gradControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gradControlPanel.Location = new System.Drawing.Point(0, 0);
			this.gradControlPanel.Name = "gradControlPanel";
			this.gradControlPanel.Size = new System.Drawing.Size(175, 167);
			this.gradControlPanel.TabIndex = 0;
			// 
			// gbTitle
			// 
			this.gbTitle.BackColor = System.Drawing.Color.Transparent;
			this.gbTitle.CornerRadiusScaler = 3;
			this.gbTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbTitle.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbTitle.ForeColor = System.Drawing.Color.White;
			this.gbTitle.GradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gbTitle.GradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.gbTitle.HighlightColor = System.Drawing.Color.PaleVioletRed;
			this.gbTitle.HighlightRectangleScaler = 3F;
			this.gbTitle.Location = new System.Drawing.Point(0, 0);
			this.gbTitle.Margin = new System.Windows.Forms.Padding(0);
			this.gbTitle.Name = "gbTitle";
			this.gbTitle.Size = new System.Drawing.Size(175, 28);
			this.gbTitle.TabIndex = 6;
			this.gbTitle.Text = "Control Title";
			this.gbTitle.UseVisualStyleBackColor = false;
			// 
			// ChartContainerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.gradControlPanel);
			this.Name = "ChartContainerControl";
			this.Size = new System.Drawing.Size(175, 167);
			this.gradControlPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public GradiantPanel gradControlPanel;
		public GelButton gbTitle;
	}
}
