using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using HP67Parser;
using HP67_Class_Library;
using HP67_Control_Library;
using System;
using System.Diagnostics;
using System.IO;

namespace HP67
{ 

	enum AngleUnit 
	{
		Grade,
		Degree,
		Radian
	}

	public class Engine
	{

		#region Private Data

		private const double degreeToRadian = Math.PI / 180.0;
		private const double gradeToRadian = Math.PI / 200.0;
		private const double radianToDegree = 180.0 / Math.PI;
		private const double radianToGrade = 200.0 / Math.PI;

		private bool stackLift = false;
		private AngleUnit unit;

		private Display theDisplay;
		private Memory theMemory;
		private Stack theStack;

		#endregion

		#region Constructors & Destructors

		public Engine (Display display) 
		{
			unit = AngleUnit.Degree;
			theDisplay = display;
			theDisplay.EnteringNumber += new Display.EnteringNumberEvent (Enter);
			theMemory = new Memory ();
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
			double fact;
			for (fact = 1.0; x > 1; x--) 
			{
				fact = fact * (double) x;
			}
			return fact;
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

		private Symbol GetSymbol (Token token) 
		{
			if (token is NonterminalToken) 
			{
				return ((NonterminalToken) token).Symbol;
			}
			else if (token is TerminalToken)
			{
				return ((TerminalToken) token).Symbol;
			}
			else 
			{
				Trace.Assert (false);
				return ((TerminalToken) token).Symbol; // To make the compiler happy.
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

		public void Execute (Token [] tokens) 
		{
			bool neutral = stackLift;
			double x, y;

			stackLift = true; // Applies to most operations.
			switch (GetSymbol(tokens [0]).Id) 
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
					// TODO: Execution.
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
					// TODO: Execution.
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_CL_REG :
					theMemory.ClearRegisters ();
					break;
				case (int)SymbolConstants.SYMBOL_CLX :
					theStack.X = 0.0;
					stackLift = false;
					break;
				case (int)SymbolConstants.SYMBOL_COMMAND :
					// TODO: Execution.
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
					theDisplay.EnterDigit (((Digit) tokens [0].UserObject).Value);
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
					((IDigits) tokens [1].UserObject).SetDigits (theMemory, theDisplay);
					stackLift = neutral;
					break;
				case (int)SymbolConstants.SYMBOL_DSZ :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_DSZ_SUB_I :
					// TODO: Execution.
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
					// TODO: Execution.
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
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_GSB_F :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_GSB_SHORTCUT :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_GTO :
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
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_ISZ_SUB_I :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_LBL :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_LBL_F :
					// TODO: Execution.
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
					// TODO: Execution.
					break;
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
					theStack.X = ((IAddress) tokens [1].UserObject).Recall (theMemory);
					break;
				case (int)SymbolConstants.SYMBOL_RCL_SIGMA_PLUS :
					// TODO: Execution.
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
					// TODO: Execution.
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
					// TODO: Execution.
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
					if (tokens.Length == 3) 
					{
						((IAddress) tokens [2].UserObject).Store
							(theMemory, theStack.X,
							((Operator) tokens [1].UserObject).Value);
					}
					else
					{
						Trace.Assert (tokens.Length == 2);
						((IAddress) tokens [1].UserObject).Store (theMemory, theStack.X);
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
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_X_EQ_Y :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_X_EXCHANGE_I :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_X_EXCHANGE_Y :
					theStack.XExchangeY ();
					break;
				case (int)SymbolConstants.SYMBOL_X_GT_0 :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_X_GT_Y :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_X_LE_Y :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_X_LT_0 :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_X_NE_0 :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_X_NE_Y :
					// TODO: Execution.
					break;
				case (int)SymbolConstants.SYMBOL_Y_TO_THE_XTH :
					theStack.Get (out x, out y);
					theStack.X = Math.Pow (y, x);
					break;
				default:
					throw new Error ();
			}
		}

		#endregion

	}

}