using System;
using System.Windows.Forms;

namespace HP67_Class_Library
{

	public enum KeystrokeMotion
	{
		Up,
		Down
	}

	/// <summary>
	/// A key-related event for the HP67 calculator.
	/// </summary>
	public class Keystroke
	{

		private System.Windows.Forms.Control control;
		private System.Windows.Forms.MouseEventArgs e;
		private KeystrokeMotion motion;

		// A pseudo-keystroke that has no effect whatsoever.  Up is important to make sure that the
		// display mode is refreshed.
		public static Keystroke Noop = new Keystroke (null, null, KeystrokeMotion.Up);

		public Keystroke (System.Windows.Forms.Control control,
						System.Windows.Forms.MouseEventArgs e,
						KeystrokeMotion motion)
		{
			this.control = control;
			this.e = e;
			this.motion = motion;
		}

		public System.Windows.Forms.Control Control
		{
			get
			{
				return control;
			}
		}

		public KeystrokeMotion Motion 
		{
			get
			{
				return motion;
			}
		}

		public string Tag 
		{
			get 
			{
				if (control == null) 
				{
					return "";
				}
				else
				{
					return (string) control.Tag;
				}
			}
		}

	}
}
