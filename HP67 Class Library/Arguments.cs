using HP67_Control_Library;
using System;
using System.Diagnostics;

namespace HP67_Class_Library
{

	#region Root & Interfaces for Arguments

	/// <summary>
	/// An argument for HP67 instructions.
	/// </summary>
	public abstract class Argument : Object
	{
	}

	public interface IAddress 
	{
		double Recall (Memory m);
		void Store (Memory m, double x);
		void Store (Memory m, double x, Memory.Operator o);
	}

	public interface IDigits
	{
		void SetDigits (Memory m, Display d);
	}

	public interface ILabel
	{
		void Goto ();
		void Gosub ();
	}

	#endregion

	#region Concrete Arguments

	public class Digit : Argument, IAddress, IDigits, ILabel
	{
		private byte digit;

		public Digit (byte d) 
		{
			digit = d;
		}

		public byte Value 
		{
			get 
			{
				return digit;
			}
		}

		public double Recall (Memory m) 
		{
			return m.Recall (digit);
		}

		public void Store (Memory m, double x)
		{
			m.Store (x, digit);
		}

		public void Store (Memory m, double x, Memory.Operator o)
		{
			m.Store (x, digit, o);
		}

		public void SetDigits (Memory m, Display d)
		{
			d.Digits = digit;
		}

		public void Goto ()
		{
			// TODO:  Add Digit.Goto implementation
		}

		public void Gosub ()
		{
			// TODO:  Add Digit.Gosub implementation
		}
	}

	public class Indexed : Argument, IAddress, IDigits
	{
		public Indexed () 
		{
		}

		public double Recall (Memory m) 
		{
			return m.RecallIndexed ();
		}

		public void Store (Memory m, double x)
		{
			m.StoreIndexed (x);
		}

		public void Store (Memory m, double x, Memory.Operator o)
		{
			m.StoreIndexed (x, o);
		}

		public void SetDigits (Memory m, Display d)
		{
			byte digits = (byte) Math.Floor (Math.Abs (m.Recall (Memory.LetterRegister.I)));
			if (digits > 9) 
			{
				throw new Error ();
			}
			else 
			{
				d.Digits = digits;
			}
		}
	}

	public class Letter : Argument, IAddress, ILabel
	{
		private char letter;

		public Letter (char l) 
		{
			Trace.Assert (l >= 'A' && l <= 'E');
			letter = l;
		}

		public double Recall (Memory m) 
		{
			return m.Recall ((Memory.LetterRegister) Enum.Parse
				(typeof (Memory.LetterRegister), new String (letter, 1)));
		}

		public void Store (Memory m, double x)
		{
			m.Store (x, (Memory.LetterRegister) Enum.Parse
				(typeof (Memory.LetterRegister), new String (letter, 1)));
		}

		public void Store (Memory m, double x, Memory.Operator o)
		{
			m.Store (x, (Memory.LetterRegister) Enum.Parse
				(typeof (Memory.LetterRegister), new String (letter, 1)), o);
		}

		public void Goto()
		{
			// TODO:  Add Letter.Goto implementation
		}

		public void Gosub()
		{
			// TODO:  Add Letter.Gosub implementation
		}
	}

	public class Operator : Argument
	{
		private Memory.Operator op;

		static public double Addition (double x, double y)
		{
			return x + y;
		}

		static public double Subtraction (double x, double y)
		{
			return x - y;
		}

		static public double Multiplication (double x, double y)
		{
			return x * y;
		}

		static public double Division (double x, double y)
		{
			if (y == 0.0) 
			{
				throw new Error ();
			}
			else
			{
				return x / y;
			}
		}

		public Operator (Memory.Operator o)
		{
			op = o;
		}

		public Memory.Operator Value
		{
			get
			{
				return op;
			}
		}
	}


	#endregion

}
