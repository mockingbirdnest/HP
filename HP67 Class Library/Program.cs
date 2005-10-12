using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using HP67_Control_Library;
using HP67_Parser;
using System;

namespace HP67_Class_Library
{
	/// <summary>
	/// The program memory of the HP67 calculator.
	/// </summary>
	public class Program
	{

		public enum LetterLabel
		{
			A = 10,
			B = 11,
			C = 12,
			D = 13,
			E = 14,
			a = 15,
			b = 16,
			c = 17,
			d = 18,
			e = 19,
		}

		private const int noStep = -1;

		private static Instruction r_s;

		private Instruction [] instructions;
		private int [] labels;
		private int next;
		private int [] returns;
		private Display theDisplay;
		private bool visible;

		#region Constructors & Destructors

		public Program (Display display)
		{
			Token [] r_s_tokens;

			r_s_tokens = new Token [1] {new TerminalToken (
									   new SymbolTerminal ((int) SymbolConstants.SYMBOL_R_S, ""),
									   "",
									   new Location (0, 0, 0))};
			r_s = new Instruction ("84", r_s_tokens);

			instructions = new Instruction [224];
			ClearProgram ();

			labels = new int [(int) LetterLabel.E - 0 + 1];
			returns = new int [3] {noStep, noStep, noStep};
			theDisplay = display;
			visible = false;
		}

		#endregion

		#region Private Operations

		private int this [byte label] 
		{
			get 
			{
				return labels [label];
			}
			set
			{
				labels [label] = value;
			}
		}

		private int this [LetterLabel label] 
		{
			get
			{
				return labels [(int) label];
			}
			set
			{
				labels [(int) label] = value;
			}
		}

		private void SaveReturnAddress ()
		{
			for (int i = returns.Length - 1; i > 0; i--)
			{
				returns [i] = returns [i - 1];
			}
			returns [0] = next;
		}

		private void UpdateLabelsForDeletion (int step) 
		{
			for (int i = 0; i < labels.Length; i++) 
			{
				if (labels [i] > step) 
				{
					labels [i]--;
				}
				else if (labels [i] == step)
				{
					labels [i] = noStep;
				}
			}
		}

		private void UpdateLabelsForInsertion (int step) 
		{
			for (int i = 0; i < labels.Length; i++) 
			{
				if (labels [i] > step) 
				{
					labels [i]++;
				}
			}
		}

		#endregion

		#region Public Operations

		#region Execution

		public Instruction Instruction
		{
			get 
			{
				Instruction i = instructions [next];
				next++;
				return i;
			}
		}

		public void Gosub (byte label)
		{
			SaveReturnAddress ();
			Goto (label);
		}

		public void Gosub (LetterLabel label)
		{
			SaveReturnAddress ();
			Goto (label);
		}

		public void Goto (byte label)
		{
			next = this [label];
		}

		public void Goto (LetterLabel label)
		{
			next = this [label];
		}

		public void Return ()
		{
			if (returns [0] == noStep) 
			{
				next = returns [0];
				for (int i = 0; i <= returns.Length - 2; i++) 
				{
					returns [i] = returns [i + 1];
				}
				returns [returns.Length - 1] = noStep;
			}
		}

		public void Skip ()
		{
			next++;
		}

		#endregion

		#region Editing

		public void ClearProgram ()
		{
			next = noStep;
			for (int i = 0; i < instructions.Length; i++) 
			{
				instructions [i] = r_s;
			}
			Visible = Visible;
		}

		public void Delete ()
		{
			UpdateLabelsForDeletion (next);
			for (int i = next; i < instructions.Length; i++) 
			{
				instructions [i] = instructions [i + 1];
			}
			instructions [instructions.Length - 1] = r_s;
			Visible = Visible;
		}

		public void GotoStep (int step) 
		{
			next = step;
			Visible = Visible;
		}

		public void Insert (Instruction instruction)
		{
			UpdateLabelsForDeletion (instructions.Length - 1);
			for (int i = instructions.Length - 1; i > next + 1; i--) 
			{
				instructions [i] = instructions [i - 1];
			}
			instructions [next] = instruction;

			switch (instruction.Symbol.Id) 
			{
				case (int) SymbolConstants.SYMBOL_LBL :
				case (int) SymbolConstants.SYMBOL_LBL_F :
					Argument arg = instruction.Arguments [0];

					if (arg is Digit) 
					{
						this [((Digit) arg).Value] = next;
					}
					else if (arg is Letter) 
					{
						this [(LetterLabel) Enum.Parse
							(typeof (LetterLabel), new String (((Letter) arg).Value, 1))] = next;
					}
					break;
			}

			UpdateLabelsForInsertion (next);
			Visible = Visible;
		}

		public bool Visible
		{
			get
			{
				return visible;
			}
			set 
			{
				visible = value;
				if (visible) 
				{
					if (next == noStep) 
					{
						theDisplay.DisplayInstruction (instruction, 0);
					}
					else
					{
						theDisplay.DisplayInstruction (instructions [next], next + 1);
					}
				}
			}
		}

		#endregion

		#endregion

	}
}
