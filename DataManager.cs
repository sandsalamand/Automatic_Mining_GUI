using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Mining_App_Core
{
	public class DataManager
	{
		//Creates path C:\Program Files\Automatic Mining\Preferences.txt
		static string topLevelDirectory = @"c:\Program Files";
		//static string topLevelDirectory = Application.UserAppDataPath;
		static public string operatingDirectory = System.IO.Path.Combine(topLevelDirectory, "Automatic Mining");
		static public string preferenceFilePath = System.IO.Path.Combine(operatingDirectory, "Preferences.xml");
		UserData userData;


		//constructor method
		public DataManager()
		{

		}
		public void SetupNew()
		{
			userData = new UserData
			{
				Prefs = new Preferences
				{
					command = " ",
					arguments = " ",
					openTime = " ",
					closeTime = " ",
				}
			};
			XmlHelper.ToXmlFile(userData, preferenceFilePath);
		}
		
		public void RefreshData()
		{
			userData = XmlHelper.FromXmlFile<UserData>(preferenceFilePath);
		}
		public void WriteLineToData(string alias, string value)
		{
			userData = XmlHelper.FromXmlFile<UserData>(preferenceFilePath);
			userData.Prefs.command = "testaa!"; //testing
			XmlHelper.ToXmlFile(userData, preferenceFilePath);
			SetStringFromProperty(value, GetPropertyValue(userData, "Preferences"), "command");
		}
		//public string ReadLineOfData(int propIndex)
		//{
			//GetStringFromProperty()
		//}
		private void SetStringFromProperty(string input, object target, string propertyName)
		{
			if (!string.IsNullOrEmpty(input))
			{
				var prop = target.GetType().GetProperty(propertyName);
				prop.SetValue(target, input);
			}
		}
		public object GetPropertyValue(object obj, string propertyName)
		{
			var objType = obj.GetType();
			var prop = objType.GetProperty(propertyName);

			return prop.GetValue(obj, null);
		}
	}
}
