using System;
using System.Configuration;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace Mockingbird.HP.Class_Library
{
	/// <summary>
	/// Localization services for the HP calculators.
	/// </summary>
	public class Localization
	{
		public const string CannotOpenFile = "CANNOT OPEN FILE";
		public const string EditMenuItem = "EDIT MENU ITEM";
		public const string Error = "ERROR";
		public const string ErrorDescription = "ERROR DESCRIPTION";
		public const string ErrorDuringOpen = "ERROR DURING OPEN";//
		public const string ErrorDuringSave = "ERROR DURING SAVE";//
		public const string ExceptionOpeningFile = "EXCEPTION OPENING FILE";//
		public const string ExceptionSavingFile = "EXCEPTION SAVING FILE";//
		public const string FileHasVersion = "FILE HAS VERSION";
		public const string FileNotFound = "FILE NOT FOUND"; 
		public const string IncompatibleVersion = "INCOMPATIBLE VERSION";
		public const string IncorrectArgumentCount = "INCORRECT ARGUMENT COUNT"; 
		public const string IncorrectCommand = "INCORRECT COMMAND";
		public const string IncorrectCommandLineArguments = "INCORRECT COMMAND LINE ARGUMENTS";
		public const string InterruptDescription = "INTERRUPT DESCRIPTION";
		public const string OpenMenuItem = "OPEN MENU ITEM";
		public const string PrintMenuItem = "PRINT MENU ITEM";
		public const string RtfMenuItem = "RTF MENU ITEM";
		public const string SaveAsMenuItem = "SAVE AS MENU ITEM";
		public const string SaveMenuItem = "SAVE MENU ITEM";
		public const string ShutdownDescription = "SHUTDOWN DESCRIPTION";
		public const string StopDescription = "STOP DESCRIPTION";
		public const string SyntaxErrorDescription = "SYNTAX ERROR DESCRIPTION";
		public const string UntitledFileName = "UNTITLED FILE NAME";

		private const string cultureAppSetting = "Culture";
		private const string resourceBase = "Mockingbird.HP.Class_Library.Localization";

		private static CultureInfo theCulture;
		private static ResourceManager theResources;

		static Localization ()
		{
			String cultureName;

			theResources = new ResourceManager (resourceBase, typeof (Localization).Assembly);
			theCulture = Thread.CurrentThread.CurrentCulture;
			cultureName = ConfigurationManager.AppSettings.GetValues(cultureAppSetting) [0];
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
