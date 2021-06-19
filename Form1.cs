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
using System.Collections;
using System.Timers;
using System.Globalization;

namespace Mining_App_Core
{
	public partial class Form1 : Form
	{
		static string topLevelDirectory = @"c:\Program Files";
		static public string operatingDirectory = System.IO.Path.Combine(topLevelDirectory, "Automatic Mining");
		static public string preferenceFilePath = System.IO.Path.Combine(operatingDirectory, "Preferences.txt");
		private int closeMin { get; set; } = 0;
		List<string> preferences;
		Task result;
		System.Diagnostics.Process miningProcess = null;
		int processId = -1;
		bool savedThisSession = false;
		bool miningWindowOpen = false;
		private static System.Timers.Timer aTimer;
		TimeScroll openScroller;
		TimeScroll closeScroller;

		enum RecommendedAction
		{
			Open,
			Close,
			None
		}


		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			System.IO.Directory.CreateDirectory(operatingDirectory);
			openScroller = new TimeScroll(new Point(62, 480), "Start Time", this);
			closeScroller = new TimeScroll(new Point(813, 480), "End Time", this);
			LoadSettings();
			SetTimer();
		}

		void LoadSettings()
		{
			if (FileIO.PrefFileExists())
			{
				preferences = FileIO.ReadPreferences();
				exeTextBox.Text = preferences[0];
				optionsTextBox.Text = preferences[1];
				openScroller.Time = Convert.ToInt32(preferences[2]);
				closeScroller.Time = Convert.ToInt32(preferences[3]);
			}
		}

		private void runButton_Click(object sender, EventArgs e)
		{
			if (savedThisSession)
			{
				preferences = FileIO.ReadPreferences();
			}
			AttemptRunMiningCommand(preferences);
		}

		private void AttemptRunMiningCommand(List<string> preferences)
		{
			if (preferences != null && preferences.Count == 4 && !miningWindowOpen)
			{
				miningProcess = System.Diagnostics.Process.Start(preferences[0], preferences[1]);
				processId = miningProcess.Id;
				miningWindowOpen = true;
			}
			else
			{
				ErrorWindow("no valid exe and arguments found in" + preferenceFilePath);
			}
		}

		private void saveTime_Click(object sender, EventArgs e)
		{
			savedThisSession = true;
			List<string> preferences = FileIO.ReadPreferences();
			preferences[2] = openScroller.Time.ToString();
			preferences[3] = closeScroller.Time.ToString();
			//preferences[3] = closeMin.ToString();
			FileIO.WritePreferences(preferences);
		}

		private void SaveCommand_Click(object sender, EventArgs e)
		{
			List<string> preferences = FileIO.ReadPreferences();
			preferences[0] = exeTextBox.Text;
			preferences[1] = optionsTextBox.Text;
			FileIO.WritePreferences(preferences);
		}

		private void SetTimer()
		{
			// Create a timer with a two second interval.
			aTimer = new System.Timers.Timer(2000);
			// Hook up the Elapsed event for the timer. 
			aTimer.Elapsed += OnTimedEvent;
			aTimer.AutoReset = true;
			aTimer.Enabled = true;
		}

		private void OnTimedEvent(Object source, ElapsedEventArgs e)
		{
			if (miningProcess != null)
			{
				processId = miningProcess.Id;
				miningWindowOpen = !miningProcess.HasExited;
			}
			if (savedThisSession)
			{
				preferences = FileIO.ReadPreferences();
			}
			RecommendedAction action = CheckTime();
			switch (action)
			{
				case RecommendedAction.Open:
					AttemptRunMiningCommand(preferences);
					break;
				case RecommendedAction.Close:
					AttemptStopMining();
					break;
				case RecommendedAction.None:
					break;
			}
		}
		
		private RecommendedAction CheckTime()
		{
			string localDate = DateTime.Now.ToString(new CultureInfo("en-GB"));
			string localTime = localDate.Split(' ')[1];
			string[] time = localTime.Split(':');
			int hour = Convert.ToInt32(time[0]);
			int minute = Convert.ToInt32(time[1]);
			if (hour >= closeScroller.Time)
			{
				return RecommendedAction.Close;
			}
			else if (hour >= openScroller.Time)
			{
				return RecommendedAction.Open;
			}
			else { 
				return RecommendedAction.None;
			}
		}

		private void AttemptStopMining()
		{
			if (miningProcess != null)
			{
				//miningProcess.Close();
				miningProcess.Kill();
			}
		}

		private void ErrorWindow(string errorMessage)
		{
			Rectangle errorWindow = new Rectangle();
			errorWindow.X = ((int)this.StartPosition);

			//unfinished
		}

		//called when form1 instance is destroyed
		~Form1()
		{
			aTimer.Stop();
			aTimer.Dispose();
		}
	}
}
