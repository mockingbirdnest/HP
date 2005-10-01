using System;
using System.Diagnostics;
using System.Xml;

namespace HP67_Class_Library
{
	/// <summary>
	/// Description résumée de Memory.
	/// </summary>
	public class Memory
	{
		public System.ApplicationException BadIndex;

		public enum LetterRegister
		{
			A = 20,
			B = 21,
			C = 22,
			D = 23,
			E = 24,
			I = 25
		}

		public delegate double Operator (double X, double Y);

		#region Private Declarations

		private double[] registers;

		private enum ΣRegister
		{
			Σx = 14,
			Σx2 = 15,
			Σy = 16,
			Σy2 = 17,
			Σxy = 18,
			n = 19
		}

		private void CheckIndex ()
		{
			if (System.Math.Abs(System.Math.Floor(this [LetterRegister.I])) > (int) LetterRegister.I)
			{
				throw BadIndex;
			}
		}

		#endregion

		#region Constructors & Destructors

		public Memory()
		{
			registers = new double [25];
			for (int i = 0; i < registers.Length; i++)
			{
				registers[i] = 0.0;
			}
		}

		#endregion

		#region Private Operations

		private double this [int r] 
		{
			get
			{
				return registers [r];
			}
			set
			{
				registers [r] = value;
			}
		}

		private double this [LetterRegister r] 
		{
			get
			{
				return this [r];
			}
			set
			{
				this [r] = value;
			}
		}

		private double this [ΣRegister r] 
		{
			get
			{
				return this [r];
			}
			set
			{
				this [r] = value;
			}
		}

		private double this [double r] 
		{
			get
			{
				return this [r];
			}
			set
			{
				this [r] = value;
			}
		}

		#endregion

		#region Public Operations

		public void ΣPlus (double X, double Y)
		{
			this [ΣRegister.n]++;
			this [ΣRegister.Σxy] += X * Y;
			this [ΣRegister.Σy2] += Y * Y;
			this [ΣRegister.Σy]  += Y;
			this [ΣRegister.Σx2] += X * X;
			this [ΣRegister.Σx]  += X;
		}

		public void ΣMinus (double X, double Y)
		{
			this [ΣRegister.n]--;
			this [ΣRegister.Σxy] -= X * Y;
			this [ΣRegister.Σy2] -= Y * Y;
			this [ΣRegister.Σy]  -= Y;
			this [ΣRegister.Σx2] -= X * X;
			this [ΣRegister.Σx]  -= X;
		}

		public void X̄ (out double x, out double y)
		{
			x =  this [ΣRegister.Σx] / this [ΣRegister.n];
			y =  this [ΣRegister.Σy] / this [ΣRegister.n];
		}

		public double S()
		{
			return Math.Sqrt((this [ΣRegister.Σx2] - (this [ΣRegister.Σx] * this [ΣRegister.Σx])/
			this [ΣRegister.n]) / (this [ΣRegister.n] -1));
		}

		public void PrimarySecondaryExchange ()
		{
			double temp;
			
			for (int i = 0; i < 9; i++)
			{
				temp = registers [i];
				registers [i] = registers [i + 10];
				registers [i + 10] = temp;
			}
		}

		public void Store (double Value, Byte Index)
		{
			Trace.Assert(Index < 9);
			registers [Index] = Value;
		}

		public void Store (double Value, Byte Index, Operator Modifier)
		{
			Trace.Assert(Index < 9);
			registers [Index] = Modifier (registers [Index], Value);
		}

		public double Recall (Byte Index)
		{
			Trace.Assert(Index < 9);
			return registers [Index];
		}

		public void Store (double Value, LetterRegister Index)
		{
			this [Index] = Value;
		}

		public void Store (double Value, LetterRegister Index, Operator Modifier)
		{
			this [Index] = Modifier (this [Index], Value);
		}

		public double Recall (LetterRegister Index)
		{
			return this [Index];
		}

		public void StoreIndexed (double Value)
		{
			CheckIndex ();
			this [System.Math.Abs(System.Math.Floor(this [LetterRegister.I]))] = Value;
		}

		public void StoreIndexed (double Value, Operator Modifier)
		{
			CheckIndex ();
			this [System.Math.Abs(System.Math.Floor(this [LetterRegister.I]))] = 
			Modifier (System.Math.Abs(System.Math.Floor(this [LetterRegister.I])), Value);
		}

		public double RecallIndexed ()
		{
			CheckIndex ();
			return this [System.Math.Abs(System.Math.Floor(this [LetterRegister.I]))];
		}

		public bool IncrementAndSkipIfZero ()
		{
			this [LetterRegister.I]++;
			return this [LetterRegister.I] == 0.0;
		}

		public bool IncrementAndSkipIfZeroIndexed ()
		{
			CheckIndex ();
			this [System.Math.Abs(System.Math.Floor(this [LetterRegister.I]))]++;
			return this [System.Math.Abs(System.Math.Floor(this [LetterRegister.I]))] == 0.0;
		}

		public bool DecrementAndSkipIfZero ()
		{
			this [LetterRegister.I]--;
			return this [LetterRegister.I] == 0.0;
		}

		public bool DecrementAndSkipIfZeroIndexed ()
		{
			CheckIndex ();
			this [System.Math.Abs(System.Math.Floor(this [LetterRegister.I]))]--;
			return this [System.Math.Abs(System.Math.Floor(this [LetterRegister.I]))] == 0.0;
		}

		public void ClearRegisters ()
		{
			for (int i = 0; i <= 9; i++)
			{
				this [i] = 0.0;
			}
			for (LetterRegister i = LetterRegister.A; i <= LetterRegister.I; i++)
			{
				this [i] = 0.0;
			}
		}

		#endregion

		public void GiveRegisters()
		{

		}

	}
}
