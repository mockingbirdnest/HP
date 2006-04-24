using com.calitha.goldparser;
using System;

namespace HP67_Class_Library
{
	/// <summary>
	/// An error during the execution of an instruction.
	/// </summary>
	public class Error : ApplicationException
	{
		public Error ()
		{
		}
		public override string ToString () 
		{
			return this.GetType ().FullName +
				": " + Localization.GetString (Localization.ErrorDescription);
		}
	}

	/// <summary>
	/// Asynchronously ends the execution of a program.
	/// </summary>
	public class Interrupt : ApplicationException
	{
		public Interrupt ()
		{
		}
		public override string ToString () 
		{
			return this.GetType ().FullName +
				": " + Localization.GetString (Localization.InterruptDescription);
		}
	}

	/// <summary>
	/// Immediate termination of the entire application.
	/// </summary>
	public class Shutdown : ApplicationException
	{
		public Shutdown ()
		{
		}
		public override string ToString () 
		{
			return this.GetType ().FullName +
				": " + Localization.GetString (Localization.ShutdownDescription);
		}
	}

	/// <summary>
	/// Interrupts parsing.
	/// </summary>
	public class SyntaxError : ApplicationException
	{
		private TerminalToken token;

		public SyntaxError (TerminalToken token) 
		{
			this.token = token;
		}
		public TerminalToken UnexpectedToken
		{
			get
			{
				return token;
			}
		}	
	}

}