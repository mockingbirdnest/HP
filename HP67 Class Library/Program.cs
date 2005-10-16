using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using HP67_Control_Library;
using HP67_Parser;
using HP67_Persistence;

using System;
using System.Data;
using System.Diagnostics;

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
			e = 19
		}

		private const int noStep = -1;

		private static Instruction r_s;

		private Instruction [] instructions;

		// TODO: This is not correct because there can be more than one label with a given name.
		private int [] labels; 

		private int next;
		private int [] returns;
		private Display theDisplay;

		#region Constructors & Destructors

		public Program (Display display)
		{
			Token [] r_s_tokens;

			theDisplay = display;

			r_s_tokens = new Token [1] {new TerminalToken (
										   new SymbolTerminal ((int) SymbolConstants.SYMBOL_R_S, "R_S"),
										   "",
										   new Location (0, 0, 0))};
			r_s = new Instruction ("84", r_s_tokens);

			instructions = new Instruction [224];
			Clear ();

			labels = new int [(int) LetterLabel.e - 0 + 1];
			for (int i = 0; i < labels.Length; i++) 
			{
				labels [i] = noStep;
			}
			returns = new int [3] {noStep, noStep, noStep};
			Card.ReadFromDataset += new Card.DatasetImporterDelegate (ReadFromDataset);
			Card.WriteToDataset += new Card.DatasetExporterDelegate (WriteToDataset);
		}

		#endregion

		#region Event Handlers

		public  void ReadFromDataset (CardDataset cds, Parser parser)
		{
			// Beware, the XML file uses 1-based step numbers, but we must go back to 0-based
			// numbers internally.
			CardDataset.ArgumentRow [] ars;
			CardDataset.CardRow cr;
			CardDataset.InstructionRow [] irs;
			CardDataset.LabelRow [] lrs;
			CardDataset.ProgramRow pr;

			cr = cds.Card [0]; // TODO: I hate these zeros...
			pr = cr.GetProgramRows () [0];
			instructions = new Instruction [pr.InstructionCount];
			irs = pr.GetInstructionRows ();
			foreach (CardDataset.InstructionRow ir in irs) 
			{
				Argument [] arguments = new Argument [ir.ArgumentCount];

				ars = ir.GetArgumentRows ();
				foreach (CardDataset.ArgumentRow ar in ars) 
				{
					Argument argument;
					// TODO: Use object factory?
					if (ar.Type == typeof (Digit).ToString ()) 
					{
						argument = new Digit (byte.Parse (ar.Value));
					}
					else if (ar.Type == typeof (Letter).ToString ())
					{
						argument = new Letter (ar.Value [0]);
					}
					else 
					{
						Trace.Assert (false);
						argument = new Digit (0); // To make the compiler happy.
					}
					arguments [ar.Id] = argument;
				}
				instructions [ir.Step - 1] =
					new Instruction (ir.Text, parser.ToSymbol (ir.Instruction), arguments);				
			}
			labels = new int [pr.LabelCount];
			lrs = pr.GetLabelRows ();
			foreach (CardDataset.LabelRow lr in lrs) 
			{
				labels [lr.Id] = lr.Step - 1;
			}
		}

		public  void WriteToDataset (CardDataset cds)
		{
			// Note that we write 1-based step numbers, in case someone wants to look at the
			// generated XML.
			CardDataset.ArgumentRow ar;
			CardDataset.InstructionRow ir;
			CardDataset.LabelRow lr;
			CardDataset.ProgramRow pr;

			pr = cds.Program.NewProgramRow ();
			pr.InstructionCount = instructions.Length;
			pr.LabelCount = labels.Length;
			pr.CardRow = cds.Card [0]; // TODO: should be passed in.
			cds.Program.AddProgramRow (pr);
			for (int i = 0; i < instructions.Length; i++) {
				ir = cds.Instruction.NewInstructionRow ();
				ir.Step = i + 1;
				ir.Text = instructions [i].ToString ();
				ir.Instruction = instructions [i].Symbol.Name;
				ir.ArgumentCount = instructions [i].Arguments.Length;
				ir.ProgramRow = pr;
				cds.Instruction.AddInstructionRow (ir);
				for (int j = 0; j < instructions [i].Arguments.Length; j++) 
				{
					Argument argument = instructions [i].Arguments [j];

					ar = cds.Argument.NewArgumentRow ();
					ar.Id = j;
					ar.Type = argument.GetType ().ToString ();
					// TODO: Use an object factory.
					if (argument is Digit) 
					{
						ar.Value = (((Digit) argument).Value).ToString ();
					}
					else if (argument is Letter) 
					{
						ar.Value = new String (((Letter) argument).Value, 1);
					}
					else
					{
						Trace.Assert (false);
					}
					ar.InstructionRow = ir;
					cds.Argument.AddArgumentRow (ar);
				}
			}
			for (int i = 0; i < labels.Length; i++) 
			{
				lr = cds.Label.NewLabelRow ();
				lr.Id = i;
				lr.Step = labels [i] + 1;
				lr.ProgramRow = pr;
				cds.Label.AddLabelRow (lr);
			}
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

		private void GotoZeroBasedStep (int step) 
		{
			// Here step is 0-based.  This is used by all the operations in this class, but we
			// maintain the fiction of a 1-based program for the clients.
			next = step;
			if (next == noStep) 
			{
				theDisplay.DisplayInstruction (null, 0);
			}
			else
			{
				theDisplay.DisplayInstruction (instructions [next], next + 1);
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
				GotoZeroBasedStep (next + 1);
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
			GotoZeroBasedStep (this [label]);
		}

		public void Goto (LetterLabel label)
		{
			GotoZeroBasedStep (this [label]);
		}

		public void Return ()
		{
			if (returns [0] == noStep) 
			{
				GotoZeroBasedStep (returns [0]);
				for (int i = 0; i <= returns.Length - 2; i++) 
				{
					returns [i] = returns [i + 1];
				}
				returns [returns.Length - 1] = noStep;
			}
		}

		public void Skip ()
		{
			GotoZeroBasedStep (next + 1);
		}

		#endregion

		#region Editing

		public void Clear ()
		{
			GotoZeroBasedStep (noStep);
			for (int i = 0; i < instructions.Length; i++) 
			{
				instructions [i] = r_s;
			}
		}

		public void Delete ()
		{
			UpdateLabelsForDeletion (next);
			for (int i = next; i < instructions.Length - 1; i++) 
			{
				instructions [i] = instructions [i + 1];
			}
			instructions [instructions.Length - 1] = r_s;
			GotoZeroBasedStep (next); // To redisplay the instruction.
		}

		public void GotoRelative (int displacement)
		{
			GotoZeroBasedStep (next + displacement);
		}

		public void GotoStep (int step)
		{
			// The clients want to see 1-based steps.
			GotoZeroBasedStep (step - 1);
		}

		public void Insert (Instruction instruction)
		{
			UpdateLabelsForDeletion (instructions.Length - 1);
			next++;
			for (int i = instructions.Length - 1; i > next + 1; i--) 
			{
				instructions [i] = instructions [i - 1];
			}
			instructions [next] = instruction;
			GotoZeroBasedStep (next);

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
		}

		#endregion

		#endregion

	}
}
