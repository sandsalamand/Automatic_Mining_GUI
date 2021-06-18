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
		Task result;
		public Form1()
		{
			InitializeComponent();
			System.IO.Directory.CreateDirectory(operatingDirectory);

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.runButton.Click += new EventHandler(runButton_Click);
			this.saveButton.Click += new EventHandler(saveButton_Click);
		}
		private void runButton_Click(object sender, EventArgs e)
		{
			var preferences = new List<string>(FileIO.ReadPreferences());
			//exeTextBox.Text = preferences[1];
			if (preferences != null && preferences.Count == 4)
			{
				RunMiningCommand(preferences);
			}	
		}

		private void RunMiningCommand(List<string> preferences)
		{
			int processId = System.Diagnostics.Process.Start(preferences[0], preferences[1]).Id; // for some reason this triggers lolminer's anti-hack
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			List<string> preferences = FileIO.ReadPreferences();
			preferences[2] = openMin.ToString();
			preferences[3] = closeMin.ToString();
			FileIO.WritePreferences(preferences);
		}

		private void openTrackBar_Scroll(object sender, EventArgs e)
		{
			openMin = openTrackBar.Value;

			if (openMin > 12)
			{
				openAMPM.Text = "P.M.";
				openValueDisplay.Text = (openMin - 12).ToString();
			}
			else if (openMin == 12)
			{
				openAMPM.Text = "P.M.";
				openValueDisplay.Text = openMin.ToString();
			}
			else
			{ 
				openAMPM.Text = "A.M.";
				openValueDisplay.Text = openMin.ToString();
			}
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
	}
}
