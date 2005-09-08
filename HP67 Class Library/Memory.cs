using System;
using System.Diagnostics;

namespace HP67_Class_Library
{
	/// <summary>
	/// Description résumée de Memory.
	/// </summary>
	public class Memory
	{
		private double[] Registry;

		public System.ApplicationException BadIndex;
		public enum  LetterRegistry
		{
			A = 20,
			B = 21,
			C = 22,
			D = 23,
			E = 24,
			I = 25
		}
		public delegate double Operator(double X, double Y);


		public Memory()
		{
			Registry = new double[25];
			for (int i = 0; i < Registry.Length; i++)
			{
				Registry[i] = 0.0;
			}
		}
		public void SPlus (double X, double Y)
		{
			Registry[19]++;
			Registry[18] += X * Y;
			Registry[17] += Y * Y;
			Registry[16] += Y;
			Registry[15] += X * X;
			Registry[14] += X;
		}
		public void SMinus (double X, double Y)
		{
			Registry[19]--;
			Registry[18] -= X * Y;
			Registry[17] -= Y * Y;
			Registry[16] -= Y;
			Registry[15] -= X * X;
			Registry[14] -= X;
		}
		public void PrimarySecondaryExchange()
		{
			double temp;
			
			for (int i = 0; i < 9; i++)
			{
				temp = Registry[i];
				Registry[i] = Registry[i + 10];
				Registry[i + 10] = temp;
			}

		}
		public void Store(double Value, Int16 Index)
		{
			Trace.Assert(Index < 9);
			Registry[Index] = Value;
		}
		public void Store(double Value, Int16 Index, Operator Modifier)
		{
			Trace.Assert(Index < 9);
			Registry[Index] = Modifier(Registry[Index], Value);
		}
		public double Recall(Int16 Index)
		{
			Trace.Assert(Index < 9);
			return Registry[Index];
		}
		public void StoreIndexed(double Value)
		{
			if (Registry[(int)LetterRegistry.I] < 0  | Registry[(int)LetterRegistry.I] > 25){throw BadIndex;}
			Registry[(int)LetterRegistry.I] = Value;
		}
		public void StoreIndexed(double Value, Operator Modifier)
		{
			if (Registry[(int)LetterRegistry.I] < 0  | Registry[(int)LetterRegistry.I] > 25){throw BadIndex;}
			Registry[(int)LetterRegistry.I] = Modifier(Registry[(int)LetterRegistry.I], Value);
		}
		public double RecallIndexed()
		{
			if (Registry[(int)LetterRegistry.I] < 0  | Registry[(int)LetterRegistry.I] > 25){throw BadIndex;}
			return Registry[(int)LetterRegistry.I];
		}
	}
}
