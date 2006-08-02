using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;

namespace Mockingbird.HP.Class_Library
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
		private ArrayList [] labels; 
		private int [] returns;

		private Display display;
		private bool isEmpty;
		private int lastPrinted;
		private int next;
		private Reader reader;
		private bool segregated;
		private int segregation;

		#region Constructors & Destructors

		public Program (Display display, Reader reader)
		{
			Symbol r_s_symbol = new SymbolNonterminal ((int) SymbolConstants.SYMBOL_R_S, "R_S");
			Argument [] r_s_args = new Argument [0];

			this.display = display;
			this.reader = reader;

			r_s = new Instruction (reader, r_s_symbol, r_s_args);
			instructions = new Instruction [224];

			labels = new ArrayList [(int) LetterLabel.e - 0 + 1];
			for (int i = 0; i < labels.Length; i++) 
			{
				labels [i] = new ArrayList ();
			}
			returns = new int [3] {noStep, noStep, noStep};

			Clear ();
			Card.MergeFromDataset += new Card.DatasetImporterDelegate (MergeFromDataset);
			Card.ReadFromDataset += new Card.DatasetImporterDelegate (ReadFromDataset);
			Card.WriteToDataset += new Card.DatasetExporterDelegate (WriteToDataset);
		}

		#endregion

		#region Event Handlers

		public void MergeFromDataset (CardDataset cds, Reader reader)
		{
			CardDataset.ArgumentRow [] ars;
			CardDataset.CardRow cr;
			CardDataset.InstructionRow [] irs;
			CardDataset.ProgramRow pr;
			CardDataset.ProgramRow [] prs;
			bool sourceProgramIsEmpty;

			cr = cds.Card [0];
			prs = cr.GetProgramRows ();
			if (prs.Length > 0) 
			{
				pr = prs [0];
				irs = pr.GetInstructionRows ();

				// A source program that only contains R/S is considered empty.  No merge takes
				// place in this case.
				sourceProgramIsEmpty = true;
				foreach (CardDataset.InstructionRow ir in irs) 
				{
					if (reader.ToSymbol (ir.Instruction).Id != (int) SymbolConstants.SYMBOL_R_S) 
					{
						sourceProgramIsEmpty = false;
						break;
					}
				}

				if (! sourceProgramIsEmpty) 
				{
					foreach (CardDataset.InstructionRow ir in irs) 
					{
						Argument [] arguments = new Argument [ir.ArgumentCount];

						if (next == instructions.Length - 1) 
						{
							break;
						}
						ars = ir.GetArgumentRows ();
						foreach (CardDataset.ArgumentRow ar in ars) 
						{
							Argument argument;
							argument = (Argument) Argument.ReadFromArgumentRow (ar);
							arguments [ar.Id] = argument;
						}

						// We have to go through instruction insertion to make sure that the label
						// table is properly updated.
						Insert (new Instruction (reader,
												reader.ToSymbol (ir.Instruction),
												arguments));	
					}
					isEmpty = false;
				}
			}
		}

		public void ReadFromDataset (CardDataset cds, Reader reader)
		{
			// Beware, the XML file uses 1-based step numbers, but we must go back to 0-based
			// numbers internally.
			CardDataset.ArgumentRow [] ars;
			CardDataset.CardRow cr;
			CardDataset.InstructionRow [] irs;
			CardDataset.LabelRow [] lrs;
			CardDataset.ProgramRow pr;
			CardDataset.ProgramRow [] prs;
			CardDataset.StepRow [] srs;

			cr = cds.Card [0];
			prs = cr.GetProgramRows ();
			isEmpty = true;
			if (prs.Length > 0) 
			{
				pr = prs [0];
				instructions = new Instruction [pr.InstructionCount];
				irs = pr.GetInstructionRows ();
				foreach (CardDataset.InstructionRow ir in irs) 
				{
					Argument [] arguments = new Argument [ir.ArgumentCount];

					if (reader.ToSymbol (ir.Instruction).Id != (int) SymbolConstants.SYMBOL_R_S) 
					{
						isEmpty = false;
					}
					ars = ir.GetArgumentRows ();
					foreach (CardDataset.ArgumentRow ar in ars) 
					{
						Argument argument;
						argument = (Argument) Argument.ReadFromArgumentRow (ar);
						arguments [ar.Id] = argument;
					}
					instructions [ir.Step - 1] =
						new Instruction (reader, reader.ToSymbol (ir.Instruction), arguments);				
				}
				labels = new ArrayList [pr.LabelCount];
				lrs = pr.GetLabelRows ();
				foreach (CardDataset.LabelRow lr in lrs) 
				{
					labels [lr.Id] = new ArrayList ();
					srs = lr.GetStepRows ();
					foreach (CardDataset.StepRow sr in srs) 
					{
						labels [lr.Id].Add (sr.Step - 1);
					}

					// Should already be sorted, but just to be safe...
					labels [lr.Id].Sort ();
				}
			}
		}

		public void WriteToDataset (CardDataset cds, CardPart part)
		{
			if (part == CardPart.Program) 
			{

				// Note that we write 1-based step numbers, in case someone wants to look at the
				// generated XML.
				CardDataset.ArgumentRow ar;
				CardDataset.InstructionRow ir;
				CardDataset.LabelRow lr;
				CardDataset.ProgramRow pr;
				CardDataset.StepRow sr;

				for (int i = 0; i < cds.Program.Count; i++)
				{
					cds.Program.RemoveProgramRow (cds.Program [i]);
				}
				pr = cds.Program.NewProgramRow ();
				pr.InstructionCount = instructions.Length;
				pr.LabelCount = labels.Length;
				pr.CardRow = cds.Card [0];
				cds.Program.AddProgramRow (pr);
				for (int i = 0; i < instructions.Length; i++) 
				{
					ir = cds.Instruction.NewInstructionRow ();
					ir.Step = i + 1;
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
					lr.StepCount = labels [i].Count;
					lr.ProgramRow = pr;
					cds.Label.AddLabelRow (lr);
					for (int j = 0; j < labels [i].Count; j++) 
					{
						sr = cds.Step.NewStepRow ();
						sr.Step = (int) labels [i] [j] + 1;
						sr.LabelRow = lr;
						cds.Step.AddStepRow (sr);
					}
				}
			}
		}

		#endregion

		#region Private Operations

		private int this [byte label] 
		{
			get 
			{
				ArrayList a = labels [label];
				int pos = a.BinarySearch (next);

				if (pos >= 0) 
				{
					return (int) a [pos]; // next found in the array.
				}
				else if (~pos < a.Count) 
				{
					return (int) a [~pos]; // next not found in the array, return the next higher.
				}
				else if (a.Count == 0)
				{
					throw new Error (); // empty array.
				}
				else
				{
					return (int) a [0]; // wrap around.
				}
			}
			set
			{
				ArrayList a = labels [label];

				Trace.Assert (! a.Contains (value));
				a.Add (value);
				a.Sort ();
			}
		}

		private int this [LetterLabel label] 
		{
			get
			{
				ArrayList a = labels [(int) label];
				int pos = a.BinarySearch (next);

				if (pos >= 0) 
				{
					return (int) a [pos]; // next found in the array.
				}
				else if (~pos < a.Count) 
				{
					return (int) a [~pos]; // next not found in the array, return the next higher.
				}
				else if (a.Count == 0)
				{
					throw new Error (); // empty array.
				}
				else
				{
					return (int) a [0]; // wrap around.
				}
			}
			set
			{
				ArrayList a = labels [(int) label];

				Trace.Assert (! a.Contains (value));
				a.Add (value);
				a.Sort ();
			}
		}

		private void GotoBegin ()
		{
			next = noStep;
			display.ShowInstruction ("", 0, false);
		}

		private void GotoZeroBasedStep (int step) 
		{
			// Here step is 0-based.  This is used by all the operations in this class, but we
			// maintain the fiction of a 1-based program for the clients.  This subprogram also
			// implements the wrap-around whereby step 224 is followed by step 1.
			if (step <= noStep) 
			{
				next = step;
				do 
				{
					next += instructions.Length;
				}
				while (next <= noStep);
			}
			else if (step >= instructions.Length) 
			{
				next = 0;
			}
			else 
			{
				next = step;
			}
			display.ShowInstruction (instructions [next].Text, next + 1, false);
		}

		private void SaveReturnAddress ()
		{
			for (int i = returns.Length - 1; i > 0; i--)
			{
				returns [i] = returns [i - 1];
			}
			returns [0] = next;
			if (segregated) 
			{
				segregation++;
			}
		}

		private void UpdateLabelsForDeletion (int step) 
		{
			for (int i = 0; i < labels.Length; i++) 
			{
				ArrayList a = labels [i];

				a.Remove (step);
				for (int j = 0; j < a.Count; j++) 
				{
					if ((int) a [j] > step) 
					{
						a [j] = (int) a [j] - 1;
					}
				}
			}
		}

		private void UpdateLabelsForInsertion (int step) 
		{
			for (int i = 0; i < labels.Length; i++) 
			{
				ArrayList a = labels [i];

				for (int j = 0; j < a.Count; j++) 
				{
					if ((int) a [j] >= step) 
					{
						a [j] = (int) a [j] + 1;
					}
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

		public void GosubRelative (int displacement)
		{
			SaveReturnAddress ();
			GotoRelative (displacement);
		}

		public void Goto (byte label)
		{
			GotoZeroBasedStep (this [label]);
		}

		public void Goto (LetterLabel label)
		{
			GotoZeroBasedStep (this [label]);
		}

		public void GotoRelative (int displacement)
		{
			GotoZeroBasedStep (next + displacement);
		}

		public void PreviewInstruction ()
		{

			// Don't preview the beginning of the program, show the first instruction instead.
			if (next == noStep) 
			{
				next++;
			}
			GotoZeroBasedStep (next);
		}

		public void Reset () 
		{

			// Prepare for a new execution by clearing the call stack.
			for (int i = 0; i <= returns.Length - 1; i++) 
			{
				returns [i] = noStep;
			}
		}

		public void Return (out bool stop)
		{
			stop = false;
			if (returns [0] == noStep)
			{
				segregated = false;
				stop = true;
			}
			else
			{
				GotoZeroBasedStep (returns [0]);
				for (int i = 0; i <= returns.Length - 2; i++) 
				{
					returns [i] = returns [i + 1];
				}
				returns [returns.Length - 1] = noStep;

				if (segregated) 
				{
					segregation--;
					if (segregation == 0)
					{
						segregated = false;
						stop = true;
					}
				}
			}
		}

		public void Segregate () 
		{
			if (! segregated) 
			{
				segregated = true;
				segregation = 0;
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
			isEmpty = true;
			lastPrinted = noStep;
			segregated = false;
			GotoBegin ();
			for (int i = 0; i < instructions.Length; i++) 
			{
				instructions [i] = r_s;
			}
			for (int i = 0; i < labels.Length; i++) 
			{
				labels [i].Clear ();
			}
		}

		public void Delete ()
		{
			// Note that this doesn't cause the program to become empty, even if this is the last
			// instruction.
			if (next != noStep) 
			{
				UpdateLabelsForDeletion (next);
				for (int i = next; i < instructions.Length - 1; i++) 
				{
					instructions [i] = instructions [i + 1];
				}
				instructions [instructions.Length - 1] = r_s;

				// Redisplay the instruction.
				if (next - 1 == noStep) 
				{
					GotoBegin ();
				}
				else 
				{
					GotoZeroBasedStep (next - 1);
				}
			}
		}

		public void GotoStep (int step)
		{
			// This is used by GTO . nnn, and it wants to see 1-based steps.
			if (step == 0) 
			{
				GotoBegin ();
			}
			else 
			{
				GotoZeroBasedStep (step - 1);
			}
		}

		public void Insert (Instruction instruction)
		{

			// The program becomes non-empty, even if the instruction is a R/S.
			isEmpty = false;
			UpdateLabelsForDeletion (instructions.Length - 1);

			// Make room for insertion and update the label tables.
			next++;
			for (int i = instructions.Length - 1; i > next; i--) 
			{
				instructions [i] = instructions [i - 1];
			}
			UpdateLabelsForInsertion (next);

			// For labels, update the labels lookup tables.
			switch ((SymbolConstants) instruction.Symbol.Id) 
			{
				case SymbolConstants.SYMBOL_LBL :
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

			// Store the instruction.
			instructions [next] = instruction;

			GotoZeroBasedStep (next);
		}

		public bool IsEmpty
		{
			get 
			{
				return isEmpty;
			}
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
					switch ((SymbolConstants) instructions [step].Symbol.Id) 
					{
						case SymbolConstants.SYMBOL_LBL :
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
