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

	public class Engine
	{

		#region Private Data

		private static Display theDisplay;
		private static Memory theMemory;
		private static Stack theStack;

		#endregion

		#region Constructors & Destructors

		static Engine () 
		{
			theDisplay = new Display ();
			theMemory = new Memory ();
			theStack = new Stack ();
		}

		#endregion

		#region Public Operations

		public static bool Execute (Token [] tokens) 
		{
			Symbol instruction;
			double x, y;

			if (tokens [0].GetType () == typeof (NonterminalToken)) 
			{
				instruction = ((NonterminalToken) tokens [0]).Symbol;
			}
			else if (tokens [0].GetType () == typeof (TerminalToken)) 
			{
				instruction = ((TerminalToken) tokens [0]).Symbol;
			}
			else 
			{
				Trace.Assert (false);
				instruction = ((TerminalToken) tokens [0]).Symbol; // To make the compiler happy.
			}
			switch (instruction.Id) 
			{
				case (int)SymbolConstants.SYMBOL_ADDITION :
					theStack.Get (out x, out y);
					theStack.X = y + x;
					break;
				case (int)SymbolConstants.SYMBOL_CHS :
					break;
				case (int)SymbolConstants.SYMBOL_CLX :
					theStack.X = 0.0;
					break;
				case (int)SymbolConstants.SYMBOL_DIVISION :
					theStack.Get (out x, out y);
					if (x == 0)
					{
						return false;
					}
					theStack.X = y / x;
					break;
				case (int)SymbolConstants.SYMBOL_DSP :
					theDisplay.Digits = ((Digit) tokens [1].UserObject).Value;
					break;
				case (int)SymbolConstants.SYMBOL_EEX :
					break;
				case (int)SymbolConstants.SYMBOL_ENTER :
					theStack.Enter ();
					break;
				case (int)SymbolConstants.SYMBOL_GTO :
					break;
				case (int)SymbolConstants.SYMBOL_MULTIPLICATION :
					theStack.Get (out x, out y);
					theStack.X = y * x;
					break;
				case (int)SymbolConstants.SYMBOL_PERIOD :
					break;
				case (int)SymbolConstants.SYMBOL_R_S :
					break;
				case (int)SymbolConstants.SYMBOL_RCL :
					break;
				case (int)SymbolConstants.SYMBOL_SIGMA_PLUS :
					// TODO: Define property Y in Stack.
					// theMemory.ΣPlus (theStack.X, theStack.Y);
					break;
				case (int)SymbolConstants.SYMBOL_SST :
					break;
				case (int)SymbolConstants.SYMBOL_STO :
					break;
				case (int)SymbolConstants.SYMBOL_SUB_I :
					break;
				case (int)SymbolConstants.SYMBOL_SUBTRACTION :
					theStack.Get (out x, out y);
					theStack.X = y - x;
					break;
				case (int)SymbolConstants.SYMBOL_ABS :
					theStack.Get (out x);
					theStack.X = Math.Abs (x);
					break;
				case (int)SymbolConstants.SYMBOL_ARCCOS :
					theStack.Get (out x);
					theStack.X = Math.Acos (x);
					break;
				case (int)SymbolConstants.SYMBOL_ARCSIN :
					theStack.Get (out x);
					theStack.X = Math.Asin (x);
					break;
				case (int)SymbolConstants.SYMBOL_ARCTAN :
					theStack.Get (out x);
					theStack.X = Math.Atan (x);
					break;
				case (int)SymbolConstants.SYMBOL_BINARY_UNSHIFTED_INSTRUCTION :
					break;
				case (int)SymbolConstants.SYMBOL_BST :
					break;
				case (int)SymbolConstants.SYMBOL_CF :
					break;
				case (int)SymbolConstants.SYMBOL_CL_PRGM :
					break;
				case (int)SymbolConstants.SYMBOL_CL_REG :
					theMemory.ClearRegisters ();
					break;
				case (int)SymbolConstants.SYMBOL_COMMAND :
					break;
				case (int)SymbolConstants.SYMBOL_COS :
					theStack.Get (out x);
					theStack.X = Math.Cos (x);
					break;
				case (int)SymbolConstants.SYMBOL_DEG :
					break;
				case (int)SymbolConstants.SYMBOL_DEL :
					break;
				case (int)SymbolConstants.SYMBOL_DIGIT :
					break;
				case (int)SymbolConstants.SYMBOL_DIGIT_LABEL :
					break;
				case (int)SymbolConstants.SYMBOL_DISPLAY_X :
					break;
				case (int)SymbolConstants.SYMBOL_DSZ :
					break;
				case (int)SymbolConstants.SYMBOL_DSZ_SUB_I :
					break;
				case (int)SymbolConstants.SYMBOL_ENG :
					theDisplay.Format = DisplayFormat.Engineering;
					break;
				case (int)SymbolConstants.SYMBOL_EXP :
					theStack.Get (out x);
					theStack.X = Math.Exp (x);
					break;
				case (int)SymbolConstants.SYMBOL_F_SHIFTED_INSTRUCTION :
					break;
				case (int)SymbolConstants.SYMBOL_F_SHIFTED_SHORTCUT :
					break;
				case (int)SymbolConstants.SYMBOL_F_TEST :
					break;
				case (int)SymbolConstants.SYMBOL_FACTORIAL :
					double xFact;
					long xLong;

					theStack.Get (out x);
					xLong = (long) x;
					if (x >= 0 && (double) xLong == x) 
					{
						for (xFact = 1.0; xLong > 1; xLong--) 
						{
							xFact = xFact * (double) xLong;
						}
						theStack.X = xFact;
					}
					else 
					{
						return false;
					}
					break;
				case (int)SymbolConstants.SYMBOL_FIX :
					theDisplay.Format = DisplayFormat.Fixed;
					break;
				case (int)SymbolConstants.SYMBOL_FRAC :
					break;
				case (int)SymbolConstants.SYMBOL_GRD :
					break;
				case (int)SymbolConstants.SYMBOL_GSB :
					break;
				case (int)SymbolConstants.SYMBOL_GSB_F :
					break;
				case (int)SymbolConstants.SYMBOL_GSB_SHORTCUT :
					break;
				case (int)SymbolConstants.SYMBOL_HMS_PLUS :
					break;
				case (int)SymbolConstants.SYMBOL_INT :
					break;
				case (int)SymbolConstants.SYMBOL_ISZ :
					break;
				case (int)SymbolConstants.SYMBOL_ISZ_SUB_I :
					break;
				case (int)SymbolConstants.SYMBOL_LABEL :
					break;
				case (int)SymbolConstants.SYMBOL_LBL :
					break;
				case (int)SymbolConstants.SYMBOL_LBL_F :
					break;
				case (int)SymbolConstants.SYMBOL_LETTER_LABEL :
					break;
				case (int)SymbolConstants.SYMBOL_LN :
					theStack.Get (out x);
					theStack.X = Math.Log (x);
					break;
				case (int)SymbolConstants.SYMBOL_LOG :
					theStack.Get (out x);
					theStack.X = Math.Log10 (x);
					break;
				case (int)SymbolConstants.SYMBOL_LST_X :
					break;
				case (int)SymbolConstants.SYMBOL_MEMORY :
					break;
				case (int)SymbolConstants.SYMBOL_MEMORY_SHORTCUT :
					break;
				case (int)SymbolConstants.SYMBOL_MERGE :
					break;
				case (int)SymbolConstants.SYMBOL_OPERABLE_MEMORY :
					break;
				case (int)SymbolConstants.SYMBOL_OPERATOR :
					break;
				case (int)SymbolConstants.SYMBOL_P_EXCHANGE_S :
					break;
				case (int)SymbolConstants.SYMBOL_PAUSE :
					break;
				case (int)SymbolConstants.SYMBOL_PERCENT :
					break;
				case (int)SymbolConstants.SYMBOL_PERCENT_CHANGE :
					break;
				case (int)SymbolConstants.SYMBOL_PI :
					theStack.X = Math.PI;
					break;
				case (int)SymbolConstants.SYMBOL_R_DOWN :
					theStack.RollDown ();
					break;
				case (int)SymbolConstants.SYMBOL_R_UP :
					theStack.RollUp ();
					break;
				case (int)SymbolConstants.SYMBOL_RAD :
					break;
				case (int)SymbolConstants.SYMBOL_RC_I :
					break;
				case (int)SymbolConstants.SYMBOL_RECIPROCAL :
					theStack.Get (out x);
					theStack.X = 1.0 / x;
					break;
				case (int)SymbolConstants.SYMBOL_REG :
					break;
				case (int)SymbolConstants.SYMBOL_RND :
					break;
				case (int)SymbolConstants.SYMBOL_RTN :
					break;
				case (int)SymbolConstants.SYMBOL_S :
					break;
				case (int)SymbolConstants.SYMBOL_SCI :
					theDisplay.Format = DisplayFormat.Scientific;
					break;
				case (int)SymbolConstants.SYMBOL_SF :
					break;
				case (int)SymbolConstants.SYMBOL_SHORTCUT :
					break;
				case (int)SymbolConstants.SYMBOL_SIGMA_MINUS :
					// TODO: Define property Y in class Stack.
					// theMemory.ΣMinus (theStack.X, theStack.Y);
					break;
				case (int)SymbolConstants.SYMBOL_SIN :
					theStack.Get (out x);
					theStack.X = Math.Sin (x);
					break;
				case (int)SymbolConstants.SYMBOL_SPACE :
					break;
				case (int)SymbolConstants.SYMBOL_SQRT :
					theStack.Get (out x);
					theStack.X = Math.Sqrt (x);
					break;
				case (int)SymbolConstants.SYMBOL_SQUARE :
					theStack.Get (out x);
					theStack.X = x * x;
					break;
				case (int)SymbolConstants.SYMBOL_ST_I :
					break;
				case (int)SymbolConstants.SYMBOL_STK :
					break;
				case (int)SymbolConstants.SYMBOL_TAN :
					theStack.Get (out x);
					theStack.X = Math.Tan (x);
					break;
				case (int)SymbolConstants.SYMBOL_TEN_TO_THE_XTH :
					theStack.Get (out x);
					theStack.X = Math.Pow (10.0, x);
					break;
				case (int)SymbolConstants.SYMBOL_TO_DEGREES :
					break;
				case (int)SymbolConstants.SYMBOL_TO_HMS :
					break;
				case (int)SymbolConstants.SYMBOL_TO_HOURS :
					break;
				case (int)SymbolConstants.SYMBOL_TO_POLAR :
					break;
				case (int)SymbolConstants.SYMBOL_TO_RADIANS :
					break;
				case (int)SymbolConstants.SYMBOL_TO_RECTANGULAR :
					break;
				case (int)SymbolConstants.SYMBOL_W_DATA :
					break;
				case (int)SymbolConstants.SYMBOL_X_AVERAGE :
					break;
				case (int)SymbolConstants.SYMBOL_X_EQ_0 :
					break;
				case (int)SymbolConstants.SYMBOL_X_EQ_Y :
					break;
				case (int)SymbolConstants.SYMBOL_X_EXCHANGE_I :
					break;
				case (int)SymbolConstants.SYMBOL_X_EXCHANGE_Y :
					break;
				case (int)SymbolConstants.SYMBOL_X_GT_0 :
					break;
				case (int)SymbolConstants.SYMBOL_X_GT_Y :
					break;
				case (int)SymbolConstants.SYMBOL_X_LE_Y :
					break;
				case (int)SymbolConstants.SYMBOL_X_LT_0 :
					break;
				case (int)SymbolConstants.SYMBOL_X_NE_0 :
					break;
				case (int)SymbolConstants.SYMBOL_X_NE_Y :
					break;
				case (int)SymbolConstants.SYMBOL_Y_TO_THE_XTH :
					theStack.Get (out x, out y);
					theStack.X = Math.Pow (y, x);
					break;
				default:
					return false;
			}
			return true;
		}

		#endregion

	}

}