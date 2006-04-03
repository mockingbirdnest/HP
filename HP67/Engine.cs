using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using HP67_Class_Library;
using HP67_Control_Library;
using HP_Parser;
using HP67_Persistence;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace HP67
{ 

	public enum AngleUnit 
	{
		Degree,
		Grade,
		Radian
	}

	public enum EngineMode
	{
		Run,
		WriteProgram
	}

	public class Engine
	{

		#region Private Data

		private static TraceSwitch classTraceSwitch = 
			new TraceSwitch ("HP67.Engine", "Execution engine");

		private const double degreeToRadian = Math.PI / 180.0;
		private const double gradeToRadian = Math.PI / 200.0;
		private const double radianToDegree = 180.0 / Math.PI;
		private const double radianToGrade = 200.0 / Math.PI;

		private bool enableBlur;
		private EngineMode mode;
		private bool running = false;
		private bool stackLift = false;
		private bool stepping = false;

		private bool [] flags;
		private AngleUnit unit;

		private AutoResetEvent keyWasTyped;
		private Display theDisplay;
		private Memory theMemory;
		private Program theProgram;
		private Stack theStack;

		#endregion

		#region Constructors & Destructors

		public Engine (Display display,
						Memory memory,
						Program program,
						Stack stack,
						AutoResetEvent keyWasTyped) 
		{
			string [] appSettingsEnableBlur =
				System.Configuration.ConfigurationSettings.AppSettings.GetValues
				("EnableBlur");
			if (appSettingsEnableBlur == null) 
			{
				enableBlur = true;
			}
			else
			{
				enableBlur = bool.Parse (appSettingsEnableBlur [0]);
			}

			flags = new bool [4];
			unit = AngleUnit.Degree;
			theDisplay = display;
			theDisplay.EnteringNumber += new Display.DisplayEvent (Enter);
			theMemory = memory;
			theProgram = program;
			theStack = stack;
			this.keyWasTyped = keyWasTyped;
			Card.ReadFromDataset += new Card.DatasetImporterDelegate (ReadFromDataset);
			Card.WriteToDataset += new Card.DatasetExporterDelegate (WriteToDataset);
		}

		#endregion

		#region Event Handlers

		public void ReadFromDataset (CardDataset cds, Reader reader)
		{
			CardDataset.CardRow cr;
			CardDataset.EngineRow er;
			CardDataset.EngineRow [] ers;
			CardDataset.FlagRow [] frs;

			cr = cds.Card [0];
			ers = cr.GetEngineRows ();
			if (ers.Length > 0) 
			{
				er = ers [0];
				unit = (AngleUnit) Enum.Parse (typeof (AngleUnit), er.AngleUnit);
				flags = new bool [er.FlagCount];
				frs = er.GetFlagRows ();
				foreach (CardDataset.FlagRow fr in frs) 
				{
					flags [fr.Id] = fr.Value;
				}
			}
		}

		public void WriteToDataset (CardDataset cds, CardPart part)
		{
			if (part == CardPart.Program) 
			{
				CardDataset.EngineRow er;
				CardDataset.FlagRow fr;

				for (int i = 0; i < cds.Engine.Count; i++)
				{
					cds.Engine.RemoveEngineRow (cds.Engine [i]);
				}
				er = cds.Engine.NewEngineRow ();
				er.AngleUnit = unit.ToString ();
				er.FlagCount = flags.Length;
				er.CardRow = cds.Card [0];
				cds.Engine.AddEngineRow (er);
				for (int i = 0; i < flags.Length; i++) 
				{
					fr = cds.Flag.NewFlagRow ();
					fr.Id = i;
					fr.Value = flags [i];
					fr.EngineRow = er;
					cds.Flag.AddFlagRow (fr);
				}
			}
		}

		#endregion

		#region Private Operations

		private void Enter (object sender) 
		{
			if (stackLift) 
			{
				theStack.Enter ();
			}
		}

		private double Factorial (long x)
		{
			double factorial;
			for (factorial = 1.0; x > 1; x--) 
			{
				factorial = factorial * (double) x;
			}
			return factorial;
		}

		private double FromRadian (double angle) 
		{
			switch (unit) 
			{
				case AngleUnit.Degree:
					return angle * radianToDegree;
				case AngleUnit.Grade:
					return angle * radianToGrade;
				case AngleUnit.Radian:
					return angle;
				default:
					Trace.Assert (false);
					return 0.0;
			}
		}

		private double ToH (double x) 
		{
			double absX = Math.Abs (x);
			double h = Math.Floor (absX);
			double m = Math.Floor ((absX - h) * 100.0);
			double s = (absX - h - m / 100.0) * 10000.0;
			if (x < 0.0) 
			{
				return -h - m / 60.0 - s / 3600.0;
			}
			else
			{
				return h + m / 60.0 + s / 3600.0;
			}
		}

		private double ToHMS (double x)
		{
			double absX = Math.Abs (x);
			double h = Math.Floor (absX);
			double m = Math.Floor ((absX - h) * 60.0);
			double s = (absX - h - m / 60.0) * 3600.0;
			if (x < 0.0) 
			{
				return -h - m / 100.0 - s / 10000.0;
			}
			else
			{
				return h + m / 100.0 + s / 10000.0;
			}
		}

		private double ToRadian (double angle) 
		{
			switch (unit) 
			{
				case AngleUnit.Degree:
					return angle * degreeToRadian;
				case AngleUnit.Grade:
					return angle * gradeToRadian;
				case AngleUnit.Radian:
					return angle;
				default:
					Trace.Assert (false);
					return 0.0;
			}
		}

		#endregion

		#region Public Operations

		public EngineMode Mode
		{
			set
			{
				mode = value;
				switch (mode)
				{
					case EngineMode.Run :
						theDisplay.Mode = DisplayMode.Numeric;
						break;
					case EngineMode.WriteProgram :
						theDisplay.Mode = DisplayMode.Instruction;
						break;
				}
			}
		}

		public void Execute (Instruction instruction) 
		{
			HP67 form = (HP67) theDisplay.TopLevelControl;
			bool neutral = stackLift;
			double x, y;

			Trace.WriteLineIf (classTraceSwitch.TraceInfo,
				"Execute: " + instruction.PrintableText,
				classTraceSwitch.DisplayName);

			// Most operations terminate digit entry.  The only ones that don't are those that are
			// used to construct digits, and SST which does not change the state of the engine at
			// all.
			switch ((SymbolConstants) instruction.Symbol.Id) 
			{
				case SymbolConstants.SYMBOL_CHS :
				case SymbolConstants.SYMBOL_DIGIT :
				case SymbolConstants.SYMBOL_EEX :
				case SymbolConstants.SYMBOL_PERIOD:
				case SymbolConstants.SYMBOL_SST :
					break;
				default :
					theDisplay.DoneEntering ();
					break;
			}

			switch ((SymbolConstants) instruction.Symbol.Id) 
			{
				case SymbolConstants.SYMBOL_ABS :
					theStack.Get (out x);
					theStack.X = Math.Abs (x);
					break;
				case SymbolConstants.SYMBOL_ADDITION :
					theStack.Get (out x, out y);
					theStack.X = y + x;
					break;
				case SymbolConstants.SYMBOL_ARCCOS :
					theStack.Get (out x);
					if (Math.Abs (x) > 1.0) 
					{
						throw new Error ();
					}
					else 
					{
						theStack.X = FromRadian (Math.Acos (x));
					}
					break;
				case SymbolConstants.SYMBOL_ARCSIN :
					theStack.Get (out x);
					if (Math.Abs (x) > 1.0) 
					{
						throw new Error ();
					}
					else 
					{
						theStack.X = FromRadian (Math.Asin (x));
					}
					break;
				case SymbolConstants.SYMBOL_ARCTAN :
					theStack.Get (out x);
					theStack.X = FromRadian (Math.Atan (x));
					break;
				case SymbolConstants.SYMBOL_BST :
					// Does nothing, moved backward on MouseDown.
					break;
				case SymbolConstants.SYMBOL_CF :
					flags [((Digit) instruction.Arguments [0]).Value] = false;
					break;
				case SymbolConstants.SYMBOL_CHS :
					bool changeSignDone;
					theDisplay.ChangeSign (out changeSignDone);
					if (! changeSignDone) 
					{
						theStack.X = -theStack.X;
					}
					break;
				case SymbolConstants.SYMBOL_CL_PRGM :
					// Cancels the f key.
					break;
				case SymbolConstants.SYMBOL_CL_REG :
					theMemory.Clear ();
					break;
				case SymbolConstants.SYMBOL_CLX :
					theStack.X = 0.0;
					break;
				case SymbolConstants.SYMBOL_COS :
					theStack.Get (out x);
					theStack.X = Math.Cos (ToRadian (x));
					break;
				case SymbolConstants.SYMBOL_DEG :
					unit = AngleUnit.Degree;
					break;
				case SymbolConstants.SYMBOL_DEL :
					// Cancel the h key.
					break;
				case SymbolConstants.SYMBOL_DIGIT :
					theDisplay.EnterDigit (((Digit) instruction.Arguments [0]).Value);
					if (! running) 
					{
						// Flag 3 is the data entry flag.
						flags [3] = true;
					}
					break;
				case SymbolConstants.SYMBOL_DISPLAY_X :
					theDisplay.PauseAndBlink (5000);
					break;
				case SymbolConstants.SYMBOL_DIVISION :
					theStack.Get (out x, out y);
					if (x == 0.0)
					{
						throw new Error ();
					}
					else 
					{
						theStack.X = y / x;
					}
					break;
				case SymbolConstants.SYMBOL_DSP :
					((IDigits) instruction.Arguments [0]).SetDigits (theMemory, theDisplay);
					break;
				case SymbolConstants.SYMBOL_DSZ :
					if (theMemory.DecrementAndSkipIfZero ())
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_DSZ_SUB_I :
					if (theMemory.DecrementAndSkipIfZeroIndexed ())
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_EEX :
					theDisplay.EnterExponent ();
					break;
				case SymbolConstants.SYMBOL_ENG :
					theDisplay.Format = DisplayFormat.Engineering;
					break;
				case SymbolConstants.SYMBOL_ENTER :
					theStack.Enter ();
					break;
				case SymbolConstants.SYMBOL_EXP :
					theStack.Get (out x);
					theStack.X = Math.Exp (x);
					break;
				case SymbolConstants.SYMBOL_F_TEST :
					byte flagId = ((Digit) instruction.Arguments [0]).Value;
					if (! flags [flagId]) 
					{
						theProgram.Skip ();
					}
					switch (flagId) 
					{
						case 0 :
						case 1 :
							break;
						case 2 :
						case 3 :
							flags [flagId] = false;
							break;
					}
					break;
				case SymbolConstants.SYMBOL_FACTORIAL :
					theStack.Get (out x);
					if (x >= 0 && x == Math.Floor (x)) 
					{
						theStack.X = Factorial ((long) x);
					}
					else 
					{
						throw new Error ();
					}
					break;
				case SymbolConstants.SYMBOL_FIX :
					theDisplay.Format = DisplayFormat.Fixed;
					break;
				case SymbolConstants.SYMBOL_FRAC :
					theStack.Get (out x);
					if (x < 0.0) 
					{
						theStack.X = x + Math.Floor (-x);
					}
					else 
					{
						theStack.X = x - Math.Floor (x);
					}
					break;
				case SymbolConstants.SYMBOL_GRD :
					unit = AngleUnit.Grade;
					break;
				case SymbolConstants.SYMBOL_GSB :
				case SymbolConstants.SYMBOL_GSB_SHORTCUT :
				case SymbolConstants.SYMBOL_GSB_F :
					if (running) 
					{
						((ILabel) instruction.Arguments [0]).Gosub (theMemory, theProgram);
					}
					else if (stepping) 
					{
						theProgram.Segregate ();
						((ILabel) instruction.Arguments [0]).Gosub (theMemory, theProgram);
						running = true;
					}
					else 
					{
						((ILabel) instruction.Arguments [0]).Goto (theMemory, theProgram);
						theProgram.Reset ();
						Trace.WriteLineIf (classTraceSwitch.TraceInfo,
							"Running",
							classTraceSwitch.DisplayName);
						running = true;
					}
					break;
				case SymbolConstants.SYMBOL_GTO :
					((ILabel) instruction.Arguments [0]).Goto (theMemory, theProgram);
					break;
				case SymbolConstants.SYMBOL_GTO_PERIOD :
					byte b0, b1, b2;
					b0 = ((Digit) instruction.Arguments [0]).Value;
					b1 = ((Digit) instruction.Arguments [1]).Value;
					b2 = ((Digit) instruction.Arguments [2]).Value;
					theProgram.GotoStep (100 * (int) b0 + 10 * (int) b1 + (int) b2);
					break;
				case SymbolConstants.SYMBOL_HMS_PLUS :
					theStack.Get (out x, out y);
					theStack.X = ToHMS (ToH (y) + ToH (x));
					break;
				case SymbolConstants.SYMBOL_INT :
					theStack.Get (out x);
					if (x < 0.0) 
					{
						theStack.X = -Math.Floor (-x);
					}
					else 
					{
						theStack.X = Math.Floor (x);
					}
					break;
				case SymbolConstants.SYMBOL_ISZ :
					if (theMemory.IncrementAndSkipIfZero ()) 
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_ISZ_SUB_I :
					if (theMemory.IncrementAndSkipIfZeroIndexed ())
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_LBL :
				case SymbolConstants.SYMBOL_LBL_F :
					break;
				case SymbolConstants.SYMBOL_LN :
					theStack.Get (out x);
					if (x <= 0.0) 
					{
						throw new Error ();
					}
					else
					{
						theStack.X = Math.Log (x);
					}
					break;
				case SymbolConstants.SYMBOL_LOG :
					theStack.Get (out x);
					if (x <= 0.0) 
					{
						throw new Error ();
					}
					else
					{
						theStack.X = Math.Log10 (x);
					}
					break;
				case SymbolConstants.SYMBOL_LST_X :
					theStack.Enter ();
					theStack.X = theStack.LastX;
					break;
				case SymbolConstants.SYMBOL_MEMORY_SHORTCUT :
					Enter (this);
					theStack.X = theMemory.RecallIndexed ();
					break;
				case SymbolConstants.SYMBOL_MERGE :
					if (! (bool) form.Invoke
						(new ExecutionThread.CrossThreadOperation (form.CrossThreadMerge))) 
					{
						throw new Error ();
					}
					break;
				case SymbolConstants.SYMBOL_MULTIPLICATION :
					theStack.Get (out x, out y);
					theStack.X = y * x;
					break;
				case SymbolConstants.SYMBOL_P_EXCHANGE_S :
					theMemory.PrimarySecondaryExchange ();
					break;
				case SymbolConstants.SYMBOL_PAUSE :
					theDisplay.PauseAndAcceptKeystrokes (1000);
					break;
				case SymbolConstants.SYMBOL_PERCENT :
					theStack.Get (out x);
					theStack.X = theStack.Y * x / 100.0;
					break;
				case SymbolConstants.SYMBOL_PERCENT_CHANGE :
					theStack.Get (out x, out y);
					if (y == 0) 
					{
						throw new Error ();
					}
					else 
					{
						theStack.X = (x - y) * 100.0 / y;
					}
					break;
				case SymbolConstants.SYMBOL_PERIOD :
					theDisplay.EnterPeriod ();
					break;
				case SymbolConstants.SYMBOL_PI :
					Enter (this);
					theStack.X = Math.PI;
					break;
				case SymbolConstants.SYMBOL_R_DOWN :
					theStack.RollDown ();
					break;
				case SymbolConstants.SYMBOL_R_S :
					if (running) 
					{
						running = false;
					}
					else if (stepping) 
					{
					}
					else
					{
						Trace.WriteLineIf (classTraceSwitch.TraceInfo,
							"Running",
							classTraceSwitch.DisplayName);
						running = true;
					}
					break;
				case SymbolConstants.SYMBOL_R_UP :
					theStack.RollUp ();
					break;
				case SymbolConstants.SYMBOL_RAD :
					unit = AngleUnit.Radian;
					break;
				case SymbolConstants.SYMBOL_RC_I :
					Enter (this);
					theStack.X = theMemory.Recall (Memory.LetterRegister.I);
					break;
				case SymbolConstants.SYMBOL_RCL :
					Enter (this);
					theStack.X = ((IAddress) instruction.Arguments [0]).Recall (theMemory);
					break;
				case SymbolConstants.SYMBOL_RCL_SIGMA_PLUS :
					theStack.Get (out x);
					theMemory.RecallΣPlus (out x, out y);
					theStack.X = x;
					theStack.Y = y;
					break;
				case SymbolConstants.SYMBOL_RECIPROCAL :
					theStack.Get (out x);
					if (x == 0.0) 
					{
						throw new Error ();
					}
					else 
					{
						theStack.X = 1.0 / x;
					}
					break;
				case SymbolConstants.SYMBOL_REG :
					theMemory.Display ();
					break;
				case SymbolConstants.SYMBOL_RND :
					theDisplay.Round ();
					break;
				case SymbolConstants.SYMBOL_RTN :
					bool stop;
					theProgram.Return (out stop);
					if (stop) 
					{
						running = false;
					}
					break;
				case SymbolConstants.SYMBOL_S :
					theStack.Get (out x);
					theMemory.S (out x, out y);
					theStack.X = x;
					theStack.Y = y;
					break;
				case SymbolConstants.SYMBOL_SCI :
					theDisplay.Format = DisplayFormat.Scientific;
					break;
				case SymbolConstants.SYMBOL_SF :
					flags [((Digit) instruction.Arguments [0]).Value] = true;
					break;
				case SymbolConstants.SYMBOL_SIGMA_MINUS :
					theStack.Get (out x);
					theMemory.ΣMinus (x, theStack.Y);
					theStack.X = theMemory.N;
					break;
				case SymbolConstants.SYMBOL_SIGMA_PLUS :
					theStack.Get (out x);
					theMemory.ΣPlus (x, theStack.Y);
					theStack.X = theMemory.N;
					break;
				case SymbolConstants.SYMBOL_SIN :
					theStack.Get (out x);
					theStack.X = Math.Sin (ToRadian (x));
					break;
				case SymbolConstants.SYMBOL_SPACE :
					// No-op on HP67.
					break;
				case SymbolConstants.SYMBOL_SQRT :
					theStack.Get (out x);
					if (x < 0.0) 
					{
						throw new Error ();
					}
					else
					{
						theStack.X = Math.Sqrt (x);
					}
					break;
				case SymbolConstants.SYMBOL_SQUARE :
					theStack.Get (out x);
					theStack.X = x * x;
					break;
				case SymbolConstants.SYMBOL_SST :
					break;
				case SymbolConstants.SYMBOL_ST_I :
					theMemory.Store (theStack.X, Memory.LetterRegister.I);
					break;
				case SymbolConstants.SYMBOL_STK :
					theStack.Display ();
					break;
				case SymbolConstants.SYMBOL_STO :
					if (instruction.Arguments.Length == 2) 
					{
						((IAddress) instruction.Arguments [1]).Store
							(theMemory, theStack.X,
							((Operator) instruction.Arguments [0]).Value);
					}
					else
					{
						Trace.Assert (instruction.Arguments.Length == 1);
						((IAddress) instruction.Arguments [0]).Store (theMemory, theStack.X);
					}
					break;
				case SymbolConstants.SYMBOL_SUBTRACTION :
					theStack.Get (out x, out y);
					theStack.X = y - x;
					break;
				case SymbolConstants.SYMBOL_TAN :
					theStack.Get (out x);
					theStack.X = Math.Tan (ToRadian (x));
					break;
				case SymbolConstants.SYMBOL_TEN_TO_THE_XTH :
					theStack.Get (out x);
					theStack.X = Math.Pow (10.0, x);
					break;
				case SymbolConstants.SYMBOL_TO_DEGREES :
					theStack.Get (out x);
					theStack.X = x * radianToDegree;
					break;
				case SymbolConstants.SYMBOL_TO_HMS :
					theStack.Get (out x);
					theStack.X = ToHMS (x);
					break;
				case SymbolConstants.SYMBOL_TO_HOURS :
					theStack.Get (out x);
					theStack.X = ToH (x);
					break;
				case SymbolConstants.SYMBOL_TO_POLAR :
					theStack.Get (out x);
					y = theStack.Y;
					theStack.X = Math.Sqrt (x * x + y * y);
					theStack.Y = FromRadian (Math.Atan2 (y, x));
					break;
				case SymbolConstants.SYMBOL_TO_RADIANS :
					theStack.Get (out x);
					theStack.X = x * degreeToRadian;
					break;
				case SymbolConstants.SYMBOL_TO_RECTANGULAR :
					double θ = theStack.Y;
					double r;
					theStack.Get (out r);
					theStack.X = r * Math.Cos (ToRadian (θ));
					theStack.Y = r * Math.Sin (ToRadian (θ));
					break;
				case SymbolConstants.SYMBOL_W_DATA :
					if (! (bool) form.Invoke
									(new ExecutionThread.CrossThreadOperation
										(form.CrossThreadSaveDataAs))) 
					{
						throw new Error ();
					}
					break;
				case SymbolConstants.SYMBOL_X_AVERAGE :
					theStack.Get (out x);
					theMemory.X̄ (out x, out y);
					theStack.X = x;
					theStack.Y = y;
					break;
				case SymbolConstants.SYMBOL_X_EQ_0 :
					if (theStack.X != 0.0) 
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_X_EQ_Y :
					if (theStack.X != theStack.Y) 
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_X_EXCHANGE_I :
					double i = theMemory.Recall (Memory.LetterRegister.I);
					theMemory.Store(theStack.X, Memory.LetterRegister.I);
					theStack.X = i;
					break;
				case SymbolConstants.SYMBOL_X_EXCHANGE_Y :
					theStack.XExchangeY ();
					break;
				case SymbolConstants.SYMBOL_X_GT_0 :
					if (theStack.X <= 0.0) 
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_X_GT_Y :
					if (theStack.X <= theStack.Y) 
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_X_LE_Y :
					if (theStack.X > theStack.Y) 
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_X_LT_0 :
					if (theStack.X >= 0.0) 
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_X_NE_0 :
					if (theStack.X == 0.0) 
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_X_NE_Y :
					if (theStack.X == theStack.Y) 
					{
						theProgram.Skip ();
					}
					break;
				case SymbolConstants.SYMBOL_Y_TO_THE_XTH :
					theStack.Get (out x, out y);
					if (y == 0.0 && x <= 0.0) 
					{
						throw new Error ();
					}
					else if (y < 0 && x != Math.Floor (x)) 
					{
						throw new Error ();
					}
					else 
					{
						theStack.X = Math.Pow (y, x);
					}
					break;
				default :
					throw new Error ();
			}

			// Set the stack lift as specified in Appendix D of the Programming Guide.
			switch ((SymbolConstants) instruction.Symbol.Id) 
			{
				case SymbolConstants.SYMBOL_SST :
					// Don't change the stack lift, not even to neutral: the necessary changes have
					// been done by the instruction called by SST.
					stepping = true;
					break;
				case SymbolConstants.SYMBOL_CLX :
				case SymbolConstants.SYMBOL_ENTER :
				case SymbolConstants.SYMBOL_SIGMA_MINUS :
				case SymbolConstants.SYMBOL_SIGMA_PLUS :
					stackLift = false;
					stepping = false;
					break;
				case SymbolConstants.SYMBOL_CL_PRGM :
				case SymbolConstants.SYMBOL_DEL :
				case SymbolConstants.SYMBOL_DISPLAY_X :
				case SymbolConstants.SYMBOL_DSP :
				case SymbolConstants.SYMBOL_ENG :
				case SymbolConstants.SYMBOL_FIX :
				case SymbolConstants.SYMBOL_MERGE :
				case SymbolConstants.SYMBOL_REG :
				case SymbolConstants.SYMBOL_SCI :
				case SymbolConstants.SYMBOL_SPACE :
				case SymbolConstants.SYMBOL_STK :
					stackLift = neutral;
					stepping = false;
					break;
				default :
					stackLift = true;
					stepping = false;
					break;
			}

			// Now check if some key was typed while we were executing the instruction.  If it was,
			// stop the computation.  Note that this is done synchronously to make sure that we can
			// resume execution with the proper state if the user types R/S again.
			if (keyWasTyped.WaitOne (0, false))
			{
				//TODO: Wrong, this could be the up keystroke.
				throw new Interrupt ();
			}
		}

		public void ExecuteSequence (Instruction instruction) 
		{
			try 
			{
				Trace.Assert (! running);
				for (;;) 
				{
					Execute (instruction);
					if (! running && ! stepping) 
					{
						break;
					}
					instruction = theProgram.Instruction;
					if (enableBlur) 
					{

						// The display mode will be reset at the end of the execution of the
						// program, so we can freely change it here.
						theDisplay.ShowBlur ();
					}
				}
			}
			catch (ApplicationException e)
			{
				Trace.WriteLineIf (classTraceSwitch.TraceInfo,
					"Process: Exception " + e.ToString (),
					classTraceSwitch.DisplayName);
				throw;
			}
			finally 
			{
				running = false;
			}
		}

		public Instruction ExpandShortcut (Instruction instruction) 
		{
			Letter letter = (Letter) instruction.Arguments [0];
			Argument [] no_args = new Argument [0];
			Symbol symbol;
			switch (letter.Value) 
			{
				case 'A' :
					symbol = new SymbolTerminal ((int) SymbolConstants.SYMBOL_RECIPROCAL, "Reciprocal");
					return new Instruction ("35 62", symbol, no_args);
				case 'B' :
					symbol = new SymbolTerminal ((int) SymbolConstants.SYMBOL_SQRT, "Sqrt");
					return new Instruction ("31 54", symbol, no_args);
				case 'C' :
					symbol = new SymbolTerminal ((int) SymbolConstants.SYMBOL_Y_TO_THE_XTH, "Y_To_The_Xth");
					return new Instruction ("35 63", symbol, no_args);
				case 'D' :
					symbol = new SymbolTerminal ((int) SymbolConstants.SYMBOL_R_DOWN, "R_Down");
					return new Instruction ("35 53", symbol, no_args);
				case 'E' :
					symbol = new SymbolTerminal ((int) SymbolConstants.SYMBOL_X_EXCHANGE_Y, "X_Exchange_Y");
					return new Instruction ("35 52", symbol, no_args);
				case 'a' :
				case 'b' :
				case 'c' :
				case 'd' :
				case 'e' :
					return instruction;
				default :
					Trace.Assert (false);
					return null;
			}
		}

		public void Process (Instruction instruction, KeystrokeMotion motion) 
		{
			Trace.WriteLineIf (classTraceSwitch.TraceInfo,
				"Process: " + motion.ToString () + " " +
				instruction.Symbol.Name + " " + instruction.ToString (),
				classTraceSwitch.DisplayName);

			// When the program memory is empty, the keys A to E have a different function, both
			// in RUN mode and in W/PRGM mode.  Perform the substitution here.
			if (theProgram.IsEmpty &&
				(SymbolConstants) instruction.Symbol.Id == SymbolConstants.SYMBOL_GSB_SHORTCUT) 
			{
				instruction = ExpandShortcut (instruction);
			}

			switch (mode) 
			{
				case EngineMode.Run :
					switch (motion) 
					{
						case KeystrokeMotion.Down :
							switch ((SymbolConstants) instruction.Symbol.Id) 
							{
								case SymbolConstants.SYMBOL_BST :
									theProgram.GotoRelative (-1);
									theDisplay.Mode = DisplayMode.Instruction;
									theProgram.PreviewInstruction ();									
									break;
								case SymbolConstants.SYMBOL_R_S :
								case SymbolConstants.SYMBOL_SST :

									// The display mode will be reset by EnableOpenOrSave after
									// execution of the next instruction (i.e., when the key goes
									// up).
									theDisplay.Mode = DisplayMode.Instruction;
									theProgram.PreviewInstruction ();
									break;
								default:
									ExecuteSequence (instruction);
									break;
							};
							break;
						case KeystrokeMotion.Up :
							switch ((SymbolConstants) instruction.Symbol.Id) 
							{
								case SymbolConstants.SYMBOL_BST :
								case SymbolConstants.SYMBOL_R_S :
								case SymbolConstants.SYMBOL_SST :
									ExecuteSequence (instruction);
									break;
								default :
									break;
							}
							break;
					}
					break;

				case EngineMode.WriteProgram :
					switch (motion) 
					{
						case KeystrokeMotion.Down :
							switch ((SymbolConstants) instruction.Symbol.Id) 
							{
								case SymbolConstants.SYMBOL_BST :
									theProgram.GotoRelative (-1);
									break;
								case SymbolConstants.SYMBOL_CL_PRGM :
									theProgram.Clear ();
									break;
								case SymbolConstants.SYMBOL_DEL :
									theProgram.Delete ();
									break;
								case SymbolConstants.SYMBOL_GTO_PERIOD :
									Execute (instruction);
									break;
								case SymbolConstants.SYMBOL_SST :
									theProgram.GotoRelative (+1);
									break;
								default :
									theProgram.Insert (instruction);
									break;
							}
							break;
						case KeystrokeMotion.Up :
							break;
					}
					break;
			}
		}

		#endregion

	}

}