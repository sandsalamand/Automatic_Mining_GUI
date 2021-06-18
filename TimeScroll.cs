﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Mining_App_Core
{
	public class TimeScroll
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Label title;
		private System.Windows.Forms.Label displayAMPM;
		private System.Windows.Forms.Label valueDisplay;
		private System.Windows.Forms.TrackBar trackBar;
		private int trackTime = 0;
		public int Time {
			get { return trackTime; }
			set
			{
				this.trackTime = value;
				this.trackBar.Value = value;
				if (value > 12)
				{
					displayAMPM.Text = "PM";
					valueDisplay.Text = (value - 12).ToString();
				}
				else if (this.Time == 12)
				{
					displayAMPM.Text = "P.M.";
					valueDisplay.Text = this.Time.ToString();
				}
				else
				{
					displayAMPM.Text = "A.M.";
					valueDisplay.Text = this.Time.ToString();
				}
			}
		}

		public TimeScroll (Point position, string title, Form form)
		{
			this.title = initLabel(new Point(position.X + 40, position.Y - 100), title, "titleLabel");
			this.displayAMPM = initLabel(new Point(position.X + 80, position.Y - 60), "AM", "amPMLabel");
			this.valueDisplay = initLabel(new Point(position.X + 40, position.Y - 60), "0", "valueLabel");
			this.trackBar = initTrackBar(new Point(position.X, position.Y), 24, "trackBarName", new System.EventHandler(this.trackBar_Scroll), form);
			form.Controls.Add(this.title);
			form.Controls.Add(this.displayAMPM);
			form.Controls.Add(this.valueDisplay);
			form.Controls.Add(this.trackBar);
		}

		private Label initLabel(Point position, string text, string labelName)
		{
			Label label = new Label();
			label.AutoSize = true;
			label.Location = position;
			label.Name = labelName;
			label.Size = new System.Drawing.Size(147, 37);
			label.TabIndex = 8;
			label.Text = text;
			//prob need to add size as parameter
			return label;
		}

		private TrackBar initTrackBar(Point position, int max, string name, EventHandler eventHandler, Form form)
		{
			TrackBar trackBar = new TrackBar();
			((System.ComponentModel.ISupportInitialize)(trackBar)).BeginInit();
			form.SuspendLayout();
			trackBar.LargeChange = 1;
			trackBar.Location = position;
			trackBar.Maximum = max;
			trackBar.Name = name;
			trackBar.Size = new System.Drawing.Size(508, 69);
			trackBar.TabIndex = 4;
			trackBar.Scroll += eventHandler;
			((System.ComponentModel.ISupportInitialize)(trackBar)).EndInit();
			form.ResumeLayout();
			return trackBar;
		}
		private void trackBar_Scroll(object sender, EventArgs e)
		{
			this.Time = this.trackBar.Value;
		}

	}
}