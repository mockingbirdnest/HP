using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using HP67_Control_Library;
using HP67_Parser;
using HP67_Persistence;

using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;

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

		private const string nInstructionTemplate = "00 00 00"; // Not really a template.
		private const int noStep = -1;
		private const string stepTemplate = "000"; // Same declaration in Display.  Groan.
		private const float spacingFactor = 0.5F;
		private const string tInstructionTemplate = "HHH H H"; // Not really a template.

		private static Instruction r_s;

		private Instruction [] instructions;

		// TODO: This is not correct because there can be more than one label with a given name.
		private int [] labels; 

		private int lastPrinted;
		private int next;
		private int [] returns;
		private Display theDisplay;

		#region Constructors & Destructors

		public Program (Display display)
		{
			Symbol r_s_symbol = new SymbolTerminal ((int) SymbolConstants.SYMBOL_R_S, "R_S");
			Argument [] r_s_args = new Argument [0];

			theDisplay = display;

			r_s = new Instruction ("84", r_s_symbol, r_s_args);
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
					argument = (Argument) Argument.ReadFromArgumentRow (ar);
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
				ir.Text = instructions [i].Text;
				ir.Instruction = instructions [i].Symbol.Name;
				ir.ArgumentCount = instructions [i].Arguments.Length;
				ir.ProgramRow = pr;
				cds.Instruction.AddInstructionRow (ir);
				for (int j = 0; j < instructions [i].Arguments.Length; j++) 
				{
					Argument argument = instructions [i].Arguments [j];

					ar = cds.Argument.NewArgumentRow ();
					ar.Id = j;
					argument.WriteToArgumentRow (ar);
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
				theDisplay.ShowInstruction ("", 0);
			}
			else
			{
				theDisplay.ShowInstruction (instructions [next].Text, next + 1);
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
				if (next == noStep) 
				{
					// This is useful when we hit R/S at the beginning of the program memory.
					next = 0;
				}
				Instruction i = instructions [next];
				GotoZeroBasedStep (next + 1);
				return i;
			}
		}

		public void Abort ()
		{
			for (int i = 0; i <= returns.Length - 1; i++) 
			{
				returns [i] = noStep;
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
				Stop ();
			}
			else
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

		public void Stop ()
		{
			for (int i = 0; i <= returns.Length - 1; i++) 
			{
				returns [i] = noStep;
			}
			throw new Stop ();
		}

		#endregion

		#region Editing

		public void Clear ()
		{
			lastPrinted = noStep;
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
			GotoZeroBasedStep (next - 1); // To redisplay the instruction.
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

			// Make room for insertion.
			next++;
			for (int i = instructions.Length - 1; i > next; i--) 
			{
				instructions [i] = instructions [i - 1];
			}

			// For labels, update the labels lookup tables.
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
						this [(LetterLabel) Enum.Parse (typeof (LetterLabel), 
							new String (((Letter) arg).Value, 1))] = next;
					}
					break;
			}

			// For shortcuts, substitute the expanded form for the short form.  Otherwise, merely
			// store the instruction.
			switch (instruction.Symbol.Id) 
			{
				case (int) SymbolConstants.SYMBOL_GSB_SHORTCUT :
					Symbol gsb_symbol =
						new SymbolTerminal ((int) SymbolConstants.SYMBOL_GSB, "GSB");
					Instruction gsb = new Instruction
											("31 22 " + instruction.Text,
											 gsb_symbol,
											 instruction.Arguments);
					instructions [next] = gsb;
					break;
				case (int) SymbolConstants.SYMBOL_GSB_F_SHORTCUT :
					String [] args = instruction.Text.Split (' ');
					Trace.Assert (args.Length == 2);
					Symbol gsb_f_symbol =
						new SymbolTerminal ((int) SymbolConstants.SYMBOL_GSB_F, "GSB_F");
					Instruction gsb_f = new Instruction
												("32 22 " + args [1],
												 gsb_f_symbol,
												 instruction.Arguments);
					instructions [next] = gsb_f;
					break;
				case (int) SymbolConstants.SYMBOL_MEMORY_SHORTCUT :
					Symbol rcl_symbol =
						new SymbolTerminal ((int) SymbolConstants.SYMBOL_RCL, "RCL");
					Argument [] rcl_args = new Argument [1] {new Indexed ()};
					Instruction rcl = new Instruction ("34 24", rcl_symbol, rcl_args);
					instructions [next] = rcl;
					break;
				default :
					instructions [next] = instruction;
					break;
			}

			GotoZeroBasedStep (next);
			UpdateLabelsForInsertion (next);
		}

		#endregion

		#region Printing

		public void PrintOnePage (PrintPageEventArgs e, Font font) 
		{
			float fontHeight = font.GetHeight (e.Graphics);
			string instructionImage;
			int last;
			int linesPerPage;
			int leftMargin = e.MarginBounds.Left;
			Point p1;
			Point p2;
			int step;
			string stepImage;
			Pen thickPen = new Pen (Color.Black, 1.0F);
			float [] thinPenDashes = {1, 1};
			Pen thinPen = new Pen (Color.Black, 0.5F);
			int topMargin = e.MarginBounds.Top;
			float x;
			float xLineWidth;
			float xSpacing;
			float xStepWidth;
			float xNInstructionWidth;
			float xTInstructionWidth;
			float y;

			thickPen.StartCap = LineCap.NoAnchor;
			thickPen.EndCap = LineCap.ArrowAnchor;
			thinPen.DashPattern = thinPenDashes;

			// Don't print the trailing R/S instructions.
			last = instructions.Length - 1;
			for (int i = instructions.Length - 1; i >= 0; i--) 
			{
				if (instructions [i].Symbol.Id != (int) SymbolConstants.SYMBOL_R_S) 
				{
					last = i;
					break;
				}
			}

			// Compute the horizontal position of the various columns.
			xStepWidth = e.Graphics.MeasureString (stepTemplate, font).Width;
			xLineWidth = xStepWidth;
			xTInstructionWidth = e.Graphics.MeasureString (tInstructionTemplate, font).Width;
			xNInstructionWidth = e.Graphics.MeasureString (nInstructionTemplate, font).Width;
			xSpacing = spacingFactor * xStepWidth;

			linesPerPage = (int) (e.MarginBounds.Height / fontHeight);
			for (int i = 0; i < 2; i++) 
			{
				for (int j = 0; j < linesPerPage; j++) 
				{
					y = topMargin + (j * fontHeight);
					//step = j + i * linesPerPage;
					step = lastPrinted + 1;
					if (step > last + 1 || step >= instructions.Length) 
					{
						goto donePrinting;
					}
					lastPrinted = step;
					stepImage = (step + 1).ToString
						(stepTemplate, NumberFormatInfo.InvariantInfo);

					// Step number.
					x = leftMargin + i * e.MarginBounds.Width / 2.0F;
					e.Graphics.DrawString (stepImage, font, Brushes.Black, x, y);

					// Horizontal line every five steps.
					x += xStepWidth + xSpacing;
					if ((step + 1) % 5 == 0) 
					{
						p1 = new Point ((int) x, (int) (y + fontHeight / 2.0F));
						p2 = new Point
							((int) (x + xLineWidth), (int) (y + fontHeight / 2.0F));
						e.Graphics.DrawLine (thinPen, p1, p2);
					}

					// Frame for labels.
					x += xLineWidth + xSpacing;
					switch (instructions [step].Symbol.Id) 
					{
						case (int) SymbolConstants.SYMBOL_LBL :
						case (int) SymbolConstants.SYMBOL_LBL_F :
							e.Graphics.DrawRectangle
								(thickPen,
								x,
								y,
								xTInstructionWidth + xSpacing + xNInstructionWidth,
								fontHeight);
							break;
					}

					// Instruction in text form.  This field is right-justified, so it's a bit
					// more delicate.
					instructionImage = instructions [step].PrintableText;
					e.Graphics.DrawString
						(instructionImage,
						font,
						Brushes.Black,
						x + xTInstructionWidth -
							e.Graphics.MeasureString (instructionImage, font).Width,
						y);

					// Instruction in numeric form, left-justified.
					x += xTInstructionWidth + xSpacing;
					e.Graphics.DrawString 
						(instructions [step].Text, font, Brushes.Black, x, y);
				}
			}
			e.HasMorePages = true;
			return;
			donePrinting:
			lastPrinted = noStep;
			e.HasMorePages = false ;
		}

		#endregion

		#endregion

	}
}
