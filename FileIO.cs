using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace Mining_App_Core
{
	//This class handles File I/O
	public class FileIO
	{
		public static bool PrefFileExists()
		{
			if (File.Exists(DataManager.preferenceFilePath))
			{
				return true;
			}
			else {
				return false;
			}
		}
		public static bool CreateDirectory(string path)
		{
			if (System.IO.Directory.CreateDirectory(Form1.operatingDirectory) != null)
			{
				return true;
			}
			else {
				return false;
			}
		}
		public static bool CreateFile(string path)
		{
			//List<string> emptyLines = new List<string>() { "\n", "\n", "\n", "\n" };
			//if (WritePreferences(emptyLines) != null)
			if(File.Create(path) != null)
			{
				return true;
			}
			else {
				return false;
			}
		}
		public static async Task WritePreferences(List<string> lines)
		{
			await File.WriteAllLinesAsync(Form1.preferenceFilePath, lines, System.Threading.CancellationToken.None);
		}
		public static List<string> ReadPreferences()
		{
			String line;
			var preferences = new List<string>();
			try
			{
				StreamReader sr = new StreamReader(Form1.preferenceFilePath);

				line = sr.ReadLine();
				while (line != null)
				{
					preferences.Add(line);
					line = sr.ReadLine();
				}
				sr.Close();
				if (preferences.Count != 4) //should remove this magic #
				{
					return null;
				}
			}
			catch (Exception)
			{
				return null;
			}
			return preferences;
		}
	}
}
	
