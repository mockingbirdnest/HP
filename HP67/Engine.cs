﻿using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using HP67_Parser;
using HP67_Class_Library;
using HP67_Control_Library;
using System;
using System.Diagnostics;
using System.IO;

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

		private EngineMode mode;
		private bool running = false;
		private bool stackLift = false;

		private bool [] flags;
		private AngleUnit unit;

		private Display theDisplay;
		private Memory theMemory;
		private Program theProgram;
		private Stack theStack;

		#endregion

		#region Constructors & Destructors

		public Engine (Display display) 
		{
			flags = new bool [4];
			unit = AngleUnit.Degree;
			theDisplay = display;
			theDisplay.EnteringNumber += new Display.EnteringNumberEvent (Enter);
			theMemory = new Memory ();
			theProgram = new Program (display);
			theStack = new Stack (display);
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
			bool neutral = stackLift;
			double x, y;

			Trace.WriteLineIf (classTraceSwitch.TraceInfo,
				"Execute: " + instruction.Symbol.Name + " " + instruction.ToString (),
				classTraceSwitch.DisplayName);

			// Applies to most operations.  Set to neutral below when an operation doesn't change
			// the stack lift after all.
			stackLift = true;

			switch (instruction.Symbol.Id) 
			{
				case (int)SymbolConstants.SYMBOL_ABS :
					theStack.Get (out x);
					theStack.X = Math.Abs (x);
					break;
				case (int)SymbolConstants.SYMBOL_ADDITION :
					theStack.Get (out x, out y);
					theStack.X = y + x;
					break;
				case (int)SymbolConstants.SYMBOL_ARCCOS :
					theStack.Get (out x);
					theStack.X = FromRadian (Math.Acos (x));
					break;
				case (int)SymbolConstants.SYMBOL_ARCSIN :
					theStack.Get (out x);
					theStack.X = FromRadian (Math.Asin (x));
					break;
				case (int)SymbolConstants.SYMBOL_ARCTAN :
					theStack.Get (out x);
					theStack.X = FromRadian (Math.Atan (x));
					break;
				case (int)SymbolConstants.SYMBOL_BST :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_CF :
					flags [((Digit) instruction.Arguments [0]).Value] = false;
					break;
				case (int)SymbolConstants.SYMBOL_CHS :
					bool changeSignDone;
					stackLift = neutral;
					theDisplay.ChangeSign (out changeSignDone);
					if (! changeSignDone) 
					{
						theStack.X = -theStack.X;
					}
					break;
				case (int)SymbolConstants.SYMBOL_CL_PRGM :
					stackLift = neutral;
					theProgram.Clear ();
					break;
				case (int)SymbolConstants.SYMBOL_CL_REG :
					theMemory.Clear ();
					break;
				case (int)SymbolConstants.SYMBOL_CLX :
					theStack.X = 0.0;
					stackLift = false;
					break;
				case (int)SymbolConstants.SYMBOL_COS :
					theStack.Get (out x);
					theStack.X = Math.Cos (ToRadian (x));
					break;
				case (int)SymbolConstants.SYMBOL_DEG :
					unit = AngleUnit.Degree;
					break;
				case (int)SymbolConstants.SYMBOL_DEL :
					// TODO: Execution.
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_DIGIT :
					stackLift = neutral;
					theDisplay.EnterDigit (((Digit) instruction.Arguments [0]).Value);
					break;
				case (int)SymbolConstants.SYMBOL_DISPLAY_X :
					theDisplay.PauseAndBlink (5000);
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_DIVISION :
					theStack.Get (out x, out y);
					if (x == 0.0)
					{
						throw new Error ();
					}
					theStack.X = y / x;
					break;
				case (int)SymbolConstants.SYMBOL_DSP :
					((IDigits) instruction.Arguments [0]).SetDigits (theMemory, theDisplay);
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_DSZ :
					if (theMemory.DecrementAndSkipIfZero ())
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_DSZ_SUB_I :
					if (theMemory.DecrementAndSkipIfZeroIndexed ())
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_EEX :
					stackLift = neutral;
					theDisplay.EnterExponent ();
					break;
				case (int)SymbolConstants.SYMBOL_ENG :
					theDisplay.Format = DisplayFormat.Engineering;
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_ENTER :
					theStack.Enter ();
					stackLift = false;
					break;
				case (int)SymbolConstants.SYMBOL_EXP :
					theStack.Get (out x);
					theStack.X = Math.Exp (x);
					break;
				case (int)SymbolConstants.SYMBOL_F_TEST :
					byte flagId = ((Digit) instruction.Arguments [0]).Value;
					switch (flagId) 
					{
						case 0 :
						case 1 :
							if (! flags [flagId]) 
							{
								theProgram.Skip ();
							}
							break;
						case 2 :
						case 3 :
							if (! flags [flagId])
							{
								theProgram.Skip ();
							}
							flags [flagId] = false;
							// TODO: F3 is set by data entry (digit) or when SST encounters a
							// digit.
							break;
						default :
							// TODO: Not quite right.  This should behave as a syntax error.
							Trace.Assert (false);
							break;
					}
					break;
				case (int)SymbolConstants.SYMBOL_FACTORIAL :
					long xLong;

					theStack.Get (out x);
					xLong = (long) x;
					if (x >= 0 && (double) xLong == x) 
					{
						theStack.X = Factorial (xLong);
					}
					else 
					{
						throw new Error ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_FIX :
					theDisplay.Format = DisplayFormat.Fixed;
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_FRAC :
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
				case (int)SymbolConstants.SYMBOL_GRD :
					unit = AngleUnit.Grade;
					break;
				case (int)SymbolConstants.SYMBOL_GSB :
				case (int)SymbolConstants.SYMBOL_GSB_F :
					((ILabel) instruction.Arguments [0]).Gosub (theMemory, theProgram);
					Run ();
					break;
				case (int)SymbolConstants.SYMBOL_GSB_SHORTCUT :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_GTO :
					((ILabel) instruction.Arguments [0]).Goto (theMemory, theProgram);
					break;
				case (int)SymbolConstants.SYMBOL_HMS_PLUS :
					theStack.Get (out x, out y);
					theStack.X = ToHMS (ToH (y) + ToH (x));
					break;
				case (int)SymbolConstants.SYMBOL_INT :
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
				case (int)SymbolConstants.SYMBOL_ISZ :
					if (theMemory.IncrementAndSkipIfZero ()) 
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_ISZ_SUB_I :
					if (theMemory.IncrementAndSkipIfZeroIndexed ())
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_LBL :
				case (int)SymbolConstants.SYMBOL_LBL_F :
					break;
				case (int)SymbolConstants.SYMBOL_LN :
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
				case (int)SymbolConstants.SYMBOL_LOG :
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
				case (int)SymbolConstants.SYMBOL_LST_X :
					theStack.Enter ();
					theStack.X = theStack.LastX;
					break;
				case (int)SymbolConstants.SYMBOL_MEMORY_SHORTCUT :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_MERGE :
					// TODO: Execution.
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_MULTIPLICATION :
					theStack.Get (out x, out y);
					theStack.X = y * x;
					break;
				case (int)SymbolConstants.SYMBOL_P_EXCHANGE_S :
					theMemory.PrimarySecondaryExchange ();
					break;
				case (int)SymbolConstants.SYMBOL_PAUSE :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_PERCENT :
					theStack.Get (out x, out y);
					theStack.X = y * x / 100.0;
					break;
				case (int)SymbolConstants.SYMBOL_PERCENT_CHANGE :
					theStack.Get (out x, out y);
					theStack.X = (x - y) * 100.0 / y;
					break;
				case (int)SymbolConstants.SYMBOL_PERIOD :
					stackLift = neutral;
					theDisplay.EnterPeriod ();
					break;
				case (int)SymbolConstants.SYMBOL_PI :
					theStack.X = Math.PI;
					break;
				case (int)SymbolConstants.SYMBOL_R_DOWN :
					theStack.RollDown ();
					break;
				case (int)SymbolConstants.SYMBOL_R_S :
					throw new Stop ();
				case (int)SymbolConstants.SYMBOL_R_UP :
					theStack.RollUp ();
					break;
				case (int)SymbolConstants.SYMBOL_RAD :
					unit = AngleUnit.Radian;
					break;
				case (int)SymbolConstants.SYMBOL_RC_I :
					theStack.X = theMemory.Recall (Memory.LetterRegister.I);
					break;
				case (int)SymbolConstants.SYMBOL_RCL :
					theStack.Enter ();
					theStack.X = ((IAddress) instruction.Arguments [0]).Recall (theMemory);
					break;
				case (int)SymbolConstants.SYMBOL_RCL_SIGMA_PLUS :
					theStack.Get (out x);
					theMemory.RecallΣPlus (out x, out y);
					theStack.X = x;
					theStack.Y = y;
					break;
				case (int)SymbolConstants.SYMBOL_RECIPROCAL :
					theStack.Get (out x);
					theStack.X = 1.0 / x;
					break;
				case (int)SymbolConstants.SYMBOL_REG :
					// TODO: Execution.
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_RND :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_RTN :
					theProgram.Return ();
					break;
				case (int)SymbolConstants.SYMBOL_S :
					theStack.Get (out x);
					theMemory.S (out x, out y);
					theStack.X = x;
					theStack.Y = y;
					break;
				case (int)SymbolConstants.SYMBOL_SCI :
					theDisplay.Format = DisplayFormat.Scientific;
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_SF :
					flags [((Digit) instruction.Arguments [0]).Value] = true;
					break;
				case (int)SymbolConstants.SYMBOL_SIGMA_MINUS :
					theStack.Get (out x);
					theMemory.ΣMinus (x, theStack.Y);
					theStack.X = theMemory.N;
					stackLift = false;
					break;
				case (int)SymbolConstants.SYMBOL_SIGMA_PLUS :
					theStack.Get (out x);
					theMemory.ΣPlus (x, theStack.Y);
					theStack.X = theMemory.N;
					stackLift = false;
					break;
				case (int)SymbolConstants.SYMBOL_SIN :
					theStack.Get (out x);
					theStack.X = Math.Sin (ToRadian (x));
					break;
				case (int)SymbolConstants.SYMBOL_SPACE :
					// TODO: Execution.
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_SQRT :
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
				case (int)SymbolConstants.SYMBOL_SQUARE :
					theStack.Get (out x);
					theStack.X = x * x;
					break;
				case (int)SymbolConstants.SYMBOL_SST :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_ST_I :
					theMemory.Store (theStack.X, Memory.LetterRegister.I);
					break;
				case (int)SymbolConstants.SYMBOL_STK :
					theStack.Display ();
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_STO :
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
				case (int)SymbolConstants.SYMBOL_SUB_I :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_SUBTRACTION :
					theStack.Get (out x, out y);
					theStack.X = y - x;
					break;
				case (int)SymbolConstants.SYMBOL_TAN :
					theStack.Get (out x);
					theStack.X = Math.Tan (ToRadian (x));
					break;
				case (int)SymbolConstants.SYMBOL_TEN_TO_THE_XTH :
					theStack.Get (out x);
					theStack.X = Math.Pow (10.0, x);
					break;
				case (int)SymbolConstants.SYMBOL_TO_DEGREES :
					theStack.Get (out x);
					theStack.X = x * radianToDegree;
					break;
				case (int)SymbolConstants.SYMBOL_TO_HMS :
					theStack.Get (out x);
					theStack.X = ToHMS (x);
					break;
				case (int)SymbolConstants.SYMBOL_TO_HOURS :
					theStack.Get (out x);
					theStack.X = ToH (x);
					break;
				case (int)SymbolConstants.SYMBOL_TO_POLAR :
					theStack.Get (out x);
					y = theStack.Y;
					theStack.X = Math.Sqrt (x * x + y * y);
					theStack.Y = FromRadian (Math.Atan2 (y, x));
					break;
				case (int)SymbolConstants.SYMBOL_TO_RADIANS :
					theStack.Get (out x);
					theStack.X = x * degreeToRadian;
					break;
				case (int)SymbolConstants.SYMBOL_TO_RECTANGULAR :
					double θ = theStack.Y;
					double r;
					theStack.Get (out r);
					theStack.X = r * Math.Cos (ToRadian (θ));
					theStack.Y = r * Math.Sin (ToRadian (θ));
					break;
				case (int)SymbolConstants.SYMBOL_W_DATA :
					break;
				case (int)SymbolConstants.SYMBOL_X_AVERAGE :
					theStack.Get (out x);
					theMemory.X̄ (out x, out y);
					theStack.X = x;
					theStack.Y = y;
					break;
				case (int)SymbolConstants.SYMBOL_X_EQ_0 :
					if (theStack.X != 0.0) 
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_X_EQ_Y :
					if (theStack.X != theStack.Y) 
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_X_EXCHANGE_I :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_X_EXCHANGE_Y :
					theStack.XExchangeY ();
					break;
				case (int)SymbolConstants.SYMBOL_X_GT_0 :
					if (theStack.X <= 0.0) 
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_X_GT_Y :
					if (theStack.X <= theStack.Y) 
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_X_LE_Y :
					if (theStack.X > theStack.Y) 
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_X_LT_0 :
					if (theStack.X <= 0.0) 
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_X_NE_0 :
					if (theStack.X == 0.0) 
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_X_NE_Y :
					if (theStack.X == theStack.Y) 
					{
						theProgram.Skip ();
					}
					break;
				case (int)SymbolConstants.SYMBOL_Y_TO_THE_XTH :
					theStack.Get (out x, out y);
					theStack.X = Math.Pow (y, x);
					break;
				default:
					throw new Error ();
			}
		}

		public void Process (Instruction instruction) 
		{
			switch (mode) 
			{
				case EngineMode.Run :
					Execute (instruction);
					break;

				case EngineMode.WriteProgram :
					Trace.WriteLineIf (classTraceSwitch.TraceInfo,
						"Process: " + instruction.Symbol.Name + " " + instruction.ToString (),
						classTraceSwitch.DisplayName);

					switch (instruction.Symbol.Id) 
					{
						case (int) SymbolConstants.SYMBOL_BST :
							theProgram.GotoRelative (-1);
							break;
						case (int) SymbolConstants.SYMBOL_CL_PRGM :
							theProgram.Clear ();
							break;
						case (int) SymbolConstants.SYMBOL_DEL :
							theProgram.Delete ();
							break;
						case (int) SymbolConstants.SYMBOL_GTO_PERIOD :
							byte b0, b1, b2;
							b0 = ((Digit) instruction.Arguments [0]).Value;
							b1 = ((Digit) instruction.Arguments [1]).Value;
							b2 = ((Digit) instruction.Arguments [2]).Value;
							theProgram.GotoStep (100 * (int) b0 + 10 * (int) b1 + (int) b2);
							break;
						case (int) SymbolConstants.SYMBOL_SST :
							theProgram.GotoRelative (+1);
							break;
						default :
							theProgram.Insert (instruction);
							break;
					}
					break;
			}
		}

		public void Run ()
		{
			Instruction instruction;

			if (! running) 
			{
				try 
				{
					Trace.WriteLineIf (classTraceSwitch.TraceInfo,
						"Run: starting",
						classTraceSwitch.DisplayName);

					// This is to end any number entry.
					double x = theStack.X;

					for (;;) 
					{
						running = true;
						instruction = theProgram.Instruction;
						Execute (instruction);
					}
				}
				catch (Stop)
				{
					Trace.WriteLineIf (classTraceSwitch.TraceInfo,
						"Run: stopping",
						classTraceSwitch.DisplayName);

					running = false;
					return;
				}
			}
		}

		#endregion

	}

}