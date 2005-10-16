using System;
using System.Diagnostics;
using System.Xml;

namespace HP67_Class_Library
{
	/// <summary>
	/// The data registers of the HP67 calculator.
	/// </summary>
	public class Memory
	{
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
				throw new Error ();
			}
		}

		#endregion

		#region Constructors & Destructors

		public Memory()
		{
			registers = new double [(int) LetterRegister.I - 0 + 1];
			for (int i = 0; i < registers.Length; i++)
			{
				registers[i] = 0.0;
			}
			Card.ReadFromDataset += new Card.DatasetIODelegate (ReadFromDataset);
			Card.WriteToDataset += new Card.DatasetIODelegate (WriteToDataset);
		}

		#endregion

		#region Event Handlers

		public  void ReadFromDataset (CardDataset cds)
		{
			CardDataset.CardRow cr;
			CardDataset.MemoryRow mr;
			CardDataset.RegisterRow [] rrs;

			cr = cds.Card [0];
			mr = cr.GetMemoryRows () [0];
			registers = new double [mr.RegisterCount];
			rrs = mr.GetRegisterRows ();
			foreach (CardDataset.RegisterRow rr in rrs) 
			{
				registers [rr.Id] = rr.Value;
			}
		}

		public  void WriteToDataset (CardDataset cds)
		{
			CardDataset.MemoryRow mr;
			CardDataset.RegisterRow rr;

			mr = cds.Memory.NewMemoryRow ();
			mr.RegisterCount = registers.Length;
			mr.CardRow = cds.Card [0]; // TODO: Should be passed in.
			cds.Memory.AddMemoryRow (mr);
			for (int i = 0; i < registers.Length; i++) 
			{
				rr = cds.Register.NewRegisterRow ();
				rr.Id = i;
				rr.Value = registers [i];
				rr.MemoryRow = mr;
				cds.Register.AddRegisterRow (rr);
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
				return registers [(int) r];
			}
			set
			{
				registers [(int) r] = value;
			}
		}

		private double this [ΣRegister r] 
		{
			get
			{
				return registers [(int) r];
			}
			set
			{
				registers [(int) r] = value;
			}
		}

		private double this [double r] 
		{
			get
			{
				return registers [(int) r];
			}
			set
			{
				registers [(int) r] = value;
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

		public void S(out double x, out double y)
		{
			x = Math.Sqrt((this [ΣRegister.Σx2] - (this [ΣRegister.Σx] * this [ΣRegister.Σx])/
				this [ΣRegister.n]) / (this [ΣRegister.n] -1));
			y = Math.Sqrt((this [ΣRegister.Σy2] - (this [ΣRegister.Σy] * this [ΣRegister.Σy])/
				this [ΣRegister.n]) / (this [ΣRegister.n] -1));
		}

		public double N 
		{
			get 
			{
				return this [ΣRegister.n];
			}
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

		public void Store (double Value, LetterRegister Index)
		{
			this [Index] = Value;
		}

		public void Store (double Value, Byte Index, Operator Modifier)
		{
			Trace.Assert(Index < 9);
			registers [Index] = Modifier (registers [Index], Value);
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

		public double Recall (Byte Index)
		{
			Trace.Assert(Index < 9);
			return registers [Index];
		}

		public double Recall (LetterRegister Index)
		{
			return this [Index];
		}

		public double RecallIndexed ()
		{
			CheckIndex ();
			return this [System.Math.Abs(System.Math.Floor(this [LetterRegister.I]))];
		}

		public void RecallΣPlus (out double x, out double y)
		{
			x = this [ΣRegister.Σx];
			y = this [ΣRegister.Σy];
		}

		public bool IncrementAndSkipIfZero ()
		{
			this [LetterRegister.I]++;
			return Math.Abs (this [LetterRegister.I]) < 1.0;
		}

		public bool IncrementAndSkipIfZeroIndexed ()
		{
			CheckIndex ();
			this [System.Math.Abs(System.Math.Floor(this [LetterRegister.I]))]++;
			return Math.Abs (
				this [System.Math.Abs (System.Math.Floor (this [LetterRegister.I]))]) < 1.0;
		}

		public bool DecrementAndSkipIfZero ()
		{
			this [LetterRegister.I]--;
			return Math.Abs (this [LetterRegister.I]) < 1.0;
		}

		public bool DecrementAndSkipIfZeroIndexed ()
		{
			CheckIndex ();
			this [System.Math.Abs(System.Math.Floor(this [LetterRegister.I]))]--;
			return Math.Abs (
				this [System.Math.Abs(System.Math.Floor(this [LetterRegister.I]))]) < 1.0;
		}

		public void Clear ()
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

	}
}
