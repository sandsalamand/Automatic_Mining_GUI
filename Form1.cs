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
	//This class contains all the logic for the main form
	public partial class Form1 : Form
	{
		//Creates path C:\Program Files\Automatic Mining\Preferences.txt
		static string topLevelDirectory = @"c:\Program Files";
		static string operatingDirectory = System.IO.Path.Combine(topLevelDirectory, "Automatic Mining");
		static public string preferenceFilePath = System.IO.Path.Combine(operatingDirectory, "Preferences.txt");

		System.Diagnostics.Process miningProcess = null;
		private static System.Timers.Timer aTimer;
		List<string> preferences;
		int processId = -1;

		TimeScroll openScroller;
		TimeScroll closeScroller;
		enum RecommendedAction
		{
			Open,
			Close,
			None
		}

		//control vars
		bool savedThisSession = false;
		bool miningWindowOpen = false;

		//
		//TODO: Add button to start timer instead of auto-start on form load, GUI Output for status of application (i.e. Mining Script Running), Error Handling
		//



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
				if (preferences != null)
				{
					exeTextBox.Text = preferences[0];
					optionsTextBox.Text = preferences[1];
					openScroller.Time = Convert.ToInt32(preferences[2]);
					closeScroller.Time = Convert.ToInt32(preferences[3]);
				}
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
			if (preferences is not null)
			{
				preferences[2] = openScroller.Time.ToString();
				preferences[3] = closeScroller.Time.ToString();
				FileIO.WritePreferences(preferences);
			}
		}

		private void SaveCommand_Click(object sender, EventArgs e)
		{
			List<string> preferences = FileIO.ReadPreferences();
			if (preferences is not null)
			{
				preferences[0] = exeTextBox.Text;
				preferences[1] = optionsTextBox.Text;
				FileIO.WritePreferences(preferences);
			}
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
			RecommendedAction action = CheckTime();
			switch (action)
			{
				case RecommendedAction.Open:
					if (savedThisSession) {
						preferences = FileIO.ReadPreferences(); }
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
