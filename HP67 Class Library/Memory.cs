﻿using System;
using System.Diagnostics;

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

		public void StoreIndexed (double Value)
		{
			if (this [LetterRegister.I] < 0  || this [LetterRegister.I] > 25)
			{
				throw BadIndex;
			}
			this [LetterRegister.I] = Value;
		}

		public void StoreIndexed (double Value, Operator Modifier)
		{
			if (this [LetterRegister.I] < 0  || this [LetterRegister.I] > 25)
			{
				throw BadIndex;
			}
			this [LetterRegister.I] = Modifier (this [LetterRegister.I], Value);
		}

		public double RecallIndexed ()
		{
			if (this [LetterRegister.I] < 0  || this [LetterRegister.I] > 25)
			{
				throw BadIndex;
			}
			return this [LetterRegister.I];
		}

		#endregion
	}
}
