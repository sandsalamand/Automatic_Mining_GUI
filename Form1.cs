using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;

namespace Mining_App_Core
{
	public partial class Form1 : Form
	{
		static string topLevelDirectory = @"c:\Program Files";
		static public string operatingDirectory = System.IO.Path.Combine(topLevelDirectory, "Automatic Mining");
		static public string preferenceFilePath = System.IO.Path.Combine(operatingDirectory, "Preferences.txt");
		private int openMin { get; set; } = 0;
		private int closeMin { get; set; } = 0;
		List<string> preferences;
		Task result;
		bool savedThisSession = false;

		TimeScroll timeScroller;

		public Form1()
		{
			InitializeComponent();
			System.IO.Directory.CreateDirectory(operatingDirectory);

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.runButton.Click += new EventHandler(runButton_Click);
			this.saveButton.Click += new EventHandler(saveButton_Click);
			timeScroller = new TimeScroll(new Point(62, 480), "Open Time", this);
			LoadSettings();
		}
		void LoadSettings()
		{
			if (FileIO.PrefFileExists())
			{
				preferences = FileIO.ReadPreferences();
				exeTextBox.Text = preferences[0];
				optionsTextBox.Text = preferences[1];
				//openTrackBar.Value = Convert.ToInt32(preferences[2]);
				timeScroller.Time = Convert.ToInt32(preferences[2]);
				closeTrackBar.Value = Convert.ToInt32(preferences[3]);
			}
		}
		private void runButton_Click(object sender, EventArgs e)
		{
			if (savedThisSession)
			{
				preferences = FileIO.ReadPreferences();
			}
			//exeTextBox.Text = preferences[1];
			if (preferences != null && preferences.Count == 4)
			{
				RunMiningCommand(preferences);
			}
			else {
				ErrorWindow("no valid exe and arguments found in" + preferenceFilePath);
			}
		}

		private void RunMiningCommand(List<string> preferences)
		{
			int processId = System.Diagnostics.Process.Start(preferences[0], preferences[1]).Id; // for some reason this triggers lolminer's anti-hack
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			savedThisSession = true;
			List<string> preferences = FileIO.ReadPreferences();
			//preferences[2] = openMin.ToString();
			preferences[2] = timeScroller.Time.ToString();
			preferences[3] = closeMin.ToString();
			FileIO.WritePreferences(preferences);
		}

		private void closeTrackBar_Scroll(object sender, EventArgs e)
		{
			closeMin = closeTrackBar.Value;

			if (closeMin > 12)
			{
				closeAMPM.Text = "P.M.";
				closeValueDisplay.Text = (closeMin - 12).ToString();
			}
			else if (closeMin == 12)
			{
				closeAMPM.Text = "P.M.";
				closeValueDisplay.Text = closeMin.ToString();
			}
			else
			{
				closeAMPM.Text = "A.M.";
				closeValueDisplay.Text = closeMin.ToString();
			}
		}

		private void SaveCommand_Click(object sender, EventArgs e)
		{
			List<string> preferences = FileIO.ReadPreferences();
			preferences[0] = exeTextBox.Text;
			preferences[1] = optionsTextBox.Text;
			FileIO.WritePreferences(preferences);
		}

		private void ErrorWindow(string errorMessage)
		{
			Rectangle errorWindow = new Rectangle();
			errorWindow.X = ((int)this.StartPosition);

			//unfinished
		}
	}
}
