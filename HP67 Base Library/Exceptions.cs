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
	}

	/// <summary>
	/// The end of the execution of a program.
	/// </summary>
	public class Stop : ApplicationException
	{
		public Stop ()
		{
		}
	}
}
