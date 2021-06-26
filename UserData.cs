using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mining_App_Core
{
	public class UserData
	{
		public Preferences Prefs { get; set; }
	}
	public class Preferences
	{
		public string command;
		public string arguments;
		public string openTime;
		public string closeTime;
	}
}
