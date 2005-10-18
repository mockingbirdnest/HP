using HP67_Control_Library;
using HP67_Persistence;
using System;
using System.Diagnostics;
using System.Reflection;

namespace HP67_Class_Library
{

	#region Root & Interfaces for Arguments

	/// <summary>
	/// An argument for HP67 instructions.
	/// </summary>
	public abstract class Argument : Object
	{
		protected abstract string PersistableText
		{
			get;
		}

		public abstract string PrintableText
		{
			get;
		}

		public static object ReadFromArgumentRow (CardDataset.ArgumentRow ar)
		{
			Type type = Type.GetType (ar.Type);
			ConstructorInfo [] constructors =
				type.GetConstructors (
					BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

			// To build an instance of argument we favor parameterless constructors and
			// constructors that take a single character.  This could be modified if needed.
			foreach (ConstructorInfo c in constructors) 
			{
				ParameterInfo [] parameters = c.GetParameters ();
				switch (parameters.Length) 
				{
					case 0:
						return c.Invoke (new object [0]);
					case 1:
						if (parameters [0].ParameterType == typeof (char))
						{
							char ch = ar.Value [0];
							return c.Invoke (new object [1] {ch});
						}
						break;
					default:
						Trace.Assert (false);
						return null;
				}
			}
			Trace.Assert (false);
			return null;
		}

		public void WriteToArgumentRow (CardDataset.ArgumentRow ar)
		{
			ar.Type = this.GetType ().ToString ();
			ar.Value = PersistableText;
		}
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
		void Goto (Memory m, Program p);
		void Gosub (Memory m, Program p);
	}

	#endregion

	#region Concrete Arguments

	public class Digit : Argument, IAddress, IDigits, ILabel
	{
		private byte digit;

		private Digit (char c)
		{
			digit = byte.Parse (new String (c, 1));
		}

		public Digit (byte d) 
		{
			digit = d;
		}

		protected override string PersistableText
		{
			get
			{
				return digit.ToString ();
			}
		}

		public override string PrintableText
		{
			get
			{
				return PersistableText;
			}
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

		public void Goto (Memory m, Program p)
		{
			p.Goto (digit);
		}

		public void Gosub (Memory m, Program p)
		{
			p.Gosub (digit);
		}
	}

	public class Indexed : Argument, IAddress, IDigits, ILabel
	{
		public Indexed () 
		{
		}

		protected override string PersistableText
		{
			get 
			{
				return "";
			}
		}

		public override string PrintableText
		{
			get
			{
				return "(i)";
			}
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

		public void Goto (Memory m, Program p)
		{
			byte label = (byte) Math.Floor (Math.Abs (m.Recall (Memory.LetterRegister.I)));
			p.Goto (label);
		}

		public void Gosub (Memory m, Program p)
		{
			byte label = (byte) Math.Floor (Math.Abs (m.Recall (Memory.LetterRegister.I)));
			p.Gosub (label);
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

		protected override string PersistableText
		{
			get 
			{
				return new String (letter, 1);
			}
		}

		public override string PrintableText
		{
			get
			{
				return PersistableText;
			}
		}

		public char Value 
		{
			get 
			{
				return letter;
			}
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
			// A letter is not an operable memory.
			Trace.Assert (false);
		}

		public void Goto (Memory m, Program p)
		{
			p.Goto ((Program.LetterLabel) Enum.Parse
				(typeof (Program.LetterLabel), new String (letter, 1)));
		}

		public void Gosub (Memory m, Program p)
		{
			p.Gosub ((Program.LetterLabel) Enum.Parse
				(typeof (Program.LetterLabel), new String (letter, 1)));
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

		private Operator (char c) 
		{
			switch (c) 
			{
				case '+' :
					op = new Memory.Operator (Addition);
					break;
				case '-' :
					op = new Memory.Operator (Subtraction);
					break;
				case '*' :
					op = new Memory.Operator (Multiplication);
					break;
				case '/' :
					op = new Memory.Operator (Division);
					break;
			}
		}

		public Operator (Memory.Operator o)
		{
			op = o;
		}

		protected override string PersistableText
		{
			get 
			{
				if (op == new Memory.Operator (Addition))
				{
					return "+";
				}
				else if (op == new Memory.Operator (Subtraction))
				{
					return "-";
				}
				else if (op == new Memory.Operator (Multiplication))
				{
					return "*";
				}
				else if (op == new Memory.Operator (Division))
				{
					return "/";
				}
				else
				{
					Trace.Assert (false);
					return ""; // To make the compiler happy.
				}
			}
		}

		public override string PrintableText
		{
			get
			{
				return PersistableText;
			}
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
