using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mining_App_Core
{
	//This class handles File I/O
	public class FileIO
	{
		public static bool PrefFileExists()
		{
			if (File.Exists(Form1.preferenceFilePath))
			{
				return true;
			}
			else {
				return false;
			}
		}
		public static async Task WritePreferences(List<string> lines)
		{
			await File.WriteAllLinesAsync(Form1.preferenceFilePath, lines);
		}
		public static List<string> ReadPreferences()
		{
			String line;
			var preferences = new List<string>();
			try
			{
				StreamReader sr = new StreamReader(Form1.preferenceFilePath);
				line = sr.ReadLine();
				preferences.Add(line);
				while (line != null)
				{
					line = sr.ReadLine();
					if(line is not null) { 
						preferences.Add(line);
					}
				}
				sr.Close();
			}
			catch (Exception)
			{
				return null;
			}
			return preferences;
		}
	}
}
	
