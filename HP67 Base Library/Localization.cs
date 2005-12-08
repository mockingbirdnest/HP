using System;
using System.Configuration;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace HP67_Class_Library
{
	/// <summary>
	/// Localization services for the HP67 calculator
	/// </summary>
	public class Localization
	{
		public const string EditMenuItem = "EDIT MENU ITEM";
		public const string FileHasVersion = "FILE HAS VERSION";
		public const string IncompatibleVersion = "INCOMPATIBLE VERSION";
		public const string OpenMenuItem = "OPEN MENU ITEM";
		public const string PrintMenuItem = "PRINT MENU ITEM";
		public const string RtfMenuItem = "RTF MENU ITEM";
		public const string SaveAsMenuItem = "SAVE AS MENU ITEM";
		public const string SaveMenuItem = "SAVE MENU ITEM";
		public const string UntitledFileName = "UNTITLED FILE NAME";

		private const string cultureAppSetting = "Culture";
		private const string resourceBase = "HP67_Class_Library.Localization";

		private static CultureInfo theCulture;
		private static ResourceManager theResources;

		static Localization ()
		{
			String cultureName;

			theResources = new ResourceManager (resourceBase, typeof (Localization).Assembly);
			theCulture = Thread.CurrentThread.CurrentCulture;
			cultureName = ConfigurationSettings.AppSettings.GetValues(cultureAppSetting) [0];
			if (cultureName != "") 
			{
				try 
				{
					theCulture = new CultureInfo (cultureName);
				}
				catch (ArgumentException)
				{
				}
			}
		}

		public static String GetString (String resourceName)
		{
			return theResources.GetString (resourceName, theCulture);
		}

	}
}
