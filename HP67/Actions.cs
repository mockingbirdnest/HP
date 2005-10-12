
using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using HP67;
using HP67_Class_Library;
using HP67_Control_Library;
using System;
using System.Diagnostics;
using System.IO;

namespace HP67_Parser
{

	public class Actions : IActions
	{

		#region Private Data

		private static TraceSwitch classTraceSwitch = 
			new TraceSwitch ("HP67_Parser.Actions", "Parser actions");

		private Engine theEngine;

		private string remainingText;
		private bool retry = false;

		#endregion

		#region Constructors & Destructors

		public Actions (Engine engine) 
		{
			theEngine = engine;
		}

		#endregion

		#region Public Operations

		public void ParserAccept ()
		{
			Trace.WriteLineIf (classTraceSwitch.TraceInfo,
				"ParserAccept: called",
				classTraceSwitch.DisplayName);

			remainingText = "";
			retry = false;
		}

		public void ParserError (string input, TerminalToken token)
		{
			if (token.Symbol.Id == (int) SymbolConstants.SYMBOL_EOF) 
			{
				Trace.WriteLineIf (classTraceSwitch.TraceInfo,
					"ParserError: error at EOF",
					classTraceSwitch.DisplayName);

				remainingText = input;
				retry = false;
			}
			else 
			{
				Trace.WriteLineIf (classTraceSwitch.TraceInfo,
					"ParserError: error before '" + token.Text + "'",
					classTraceSwitch.DisplayName);
				Trace.Assert (token.Location.Position > 0);

				remainingText = input.Substring (token.Location.Position);
				retry = true;
			}

			Trace.WriteLineIf (classTraceSwitch.TraceInfo,
				"ParserError: preserving '" + remainingText + "'",
				classTraceSwitch.DisplayName);
		}

		public string RemainingText
		{
			get
			{
				return remainingText;
			}
		}
		
		public bool Retry
		{
			get
			{
				return retry;
			}
		}
		
		public void ReduceRULE_X_AVERAGE_SIGMA_PLUS (string input, Token token, Token [] tokens)
		{
			// <X_Average> ::= 'Sigma_Plus'
		}

		public void ReduceRULE_GSB_GTO (string input, Token token, Token [] tokens)
		{
			// <Gsb> ::= Gto
		}

		public void ReduceRULE_FIX_DSP (string input, Token token, Token [] tokens)
		{
			// <Fix> ::= Dsp
		}

		public void ReduceRULE_RND_SUB_I (string input, Token token, Token [] tokens)
		{
			// <Rnd> ::= 'Sub_I'
		}

		public void ReduceRULE_LBL_SST (string input, Token token, Token [] tokens)
		{
			// <Lbl> ::= Sst
		}

		public void ReduceRULE_DSZ_STO (string input, Token token, Token [] tokens)
		{
			// <Dsz> ::= Sto
		}

		public void ReduceRULE_ISZ_RCL (string input, Token token, Token [] tokens)
		{
			// <Isz> ::= Rcl
		}

		public void ReduceRULE_W_DATA_ENTER (string input, Token token, Token [] tokens)
		{
			// <W_Data> ::= Enter
		}

		public void ReduceRULE_P_EXCHANGE_S_CHS (string input, Token token, Token [] tokens)
		{
			// <P_Exchange_S> ::= Chs
		}

		public void ReduceRULE_CL_REG_EEX (string input, Token token, Token [] tokens)
		{
			// <Cl_Reg> ::= Eex
		}

		public void ReduceRULE_CL_PRGM_CLX (string input, Token token, Token [] tokens)
		{
			// <Cl_Prgm> ::= Clx
		}

		public void ReduceRULE_X_EQ_0_SUBTRACTION (string input, Token token, Token [] tokens)
		{
			// <X_EQ_0> ::= Subtraction
		}

		public void ReduceRULE_LN_SEVEN (string input, Token token, Token [] tokens)
		{
			// <Ln> ::= Seven
		}

		public void ReduceRULE_LOG_EIGHT (string input, Token token, Token [] tokens)
		{
			// <Log> ::= Eight
		}

		public void ReduceRULE_SQRT_NINE (string input, Token token, Token [] tokens)
		{
			// <Sqrt> ::= Nine
		}

		public void ReduceRULE_X_NE_0_ADDITION (string input, Token token, Token [] tokens)
		{
			// <X_NE_0> ::= Addition
		}

		public void ReduceRULE_SIN_FOUR (string input, Token token, Token [] tokens)
		{
			// <Sin> ::= Four
		}

		public void ReduceRULE_COS_FIVE (string input, Token token, Token [] tokens)
		{
			// <Cos> ::= Five
		}

		public void ReduceRULE_TAN_SIX (string input, Token token, Token [] tokens)
		{
			// <Tan> ::= Six
		}

		public void ReduceRULE_X_LT_0_MULTIPLICATION (string input, Token token, Token [] tokens)
		{
			// <X_LT_0> ::= Multiplication
		}

		public void ReduceRULE_TO_RECTANGULAR_ONE (string input, Token token, Token [] tokens)
		{
			// <To_Rectangular> ::= One
		}

		public void ReduceRULE_TO_DEGREES_TWO (string input, Token token, Token [] tokens)
		{
			// <To_Degrees> ::= Two
		}

		public void ReduceRULE_TO_HOURS_THREE (string input, Token token, Token [] tokens)
		{
			// <To_Hours> ::= Three
		}

		public void ReduceRULE_X_GT_0_DIVISION (string input, Token token, Token [] tokens)
		{
			// <X_GT_0> ::= Division
		}

		public void ReduceRULE_PERCENT_ZERO (string input, Token token, Token [] tokens)
		{
			// <Percent> ::= Zero
		}

		public void ReduceRULE_INT_PERIOD (string input, Token token, Token [] tokens)
		{
			// <Int> ::= Period
		}

		public void ReduceRULE_DISPLAY_X_R_S (string input, Token token, Token [] tokens)
		{
			// <Display_X> ::= 'R_S'
		}

		public void ReduceRULE_S_SIGMA_PLUS (string input, Token token, Token [] tokens)
		{
			// <S> ::= 'Sigma_Plus'
		}

		public void ReduceRULE_GSB_F_GTO (string input, Token token, Token [] tokens)
		{
			// <Gsb_f> ::= Gto
		}

		public void ReduceRULE_SCI_DSP (string input, Token token, Token [] tokens)
		{
			// <Sci> ::= Dsp
		}

		public void ReduceRULE_LBL_F_SST (string input, Token token, Token [] tokens)
		{
			// <Lbl_f> ::= Sst
		}

		public void ReduceRULE_DSZ_SUB_I_STO (string input, Token token, Token [] tokens)
		{
			// <Dsz_Sub_I> ::= Sto
		}

		public void ReduceRULE_ISZ_SUB_I_RCL (string input, Token token, Token [] tokens)
		{
			// <Isz_Sub_I> ::= Rcl
		}

		public void ReduceRULE_MERGE_ENTER (string input, Token token, Token [] tokens)
		{
			// <Merge> ::= Enter
		}

		public void ReduceRULE_X_EQ_Y_SUBTRACTION (string input, Token token, Token [] tokens)
		{
			// <X_EQ_Y> ::= Subtraction
		}

		public void ReduceRULE_EXP_SEVEN (string input, Token token, Token [] tokens)
		{
			// <Exp> ::= Seven
		}

		public void ReduceRULE_TEN_TO_THE_XTH_EIGHT (string input, Token token, Token [] tokens)
		{
			// <Ten_To_The_Xth> ::= Eight
		}

		public void ReduceRULE_SQUARE_NINE (string input, Token token, Token [] tokens)
		{
			// <Square> ::= Nine
		}

		public void ReduceRULE_X_NE_Y_ADDITION (string input, Token token, Token [] tokens)
		{
			// <X_NE_Y> ::= Addition
		}

		public void ReduceRULE_ARCSIN_FOUR (string input, Token token, Token [] tokens)
		{
			// <Arcsin> ::= Four
		}

		public void ReduceRULE_ARCCOS_FIVE (string input, Token token, Token [] tokens)
		{
			// <Arccos> ::= Five
		}

		public void ReduceRULE_ARCTAN_SIX (string input, Token token, Token [] tokens)
		{
			// <Arctan> ::= Six
		}

		public void ReduceRULE_X_LE_Y_MULTIPLICATION (string input, Token token, Token [] tokens)
		{
			// <X_LE_Y> ::= Multiplication
		}

		public void ReduceRULE_TO_POLAR_ONE (string input, Token token, Token [] tokens)
		{
			// <To_Polar> ::= One
		}

		public void ReduceRULE_TO_RADIANS_TWO (string input, Token token, Token [] tokens)
		{
			// <To_Radians> ::= Two
		}

		public void ReduceRULE_TO_HMS_THREE (string input, Token token, Token [] tokens)
		{
			// <To_HMS> ::= Three
		}

		public void ReduceRULE_X_GT_Y_DIVISION (string input, Token token, Token [] tokens)
		{
			// <X_GT_Y> ::= Division
		}

		public void ReduceRULE_PERCENT_CHANGE_ZERO (string input, Token token, Token [] tokens)
		{
			// <Percent_Change> ::= Zero
		}

		public void ReduceRULE_FRAC_PERIOD (string input, Token token, Token [] tokens)
		{
			// <Frac> ::= Period
		}

		public void ReduceRULE_STK_R_S (string input, Token token, Token [] tokens)
		{
			// <Stk> ::= 'R_S'
		}

		public void ReduceRULE_SIGMA_MINUS_SIGMA_PLUS (string input, Token token, Token [] tokens)
		{
			// <Sigma_Minus> ::= 'Sigma_Plus'
		}

		public void ReduceRULE_RTN_GTO (string input, Token token, Token [] tokens)
		{
			// <Rtn> ::= Gto
		}

		public void ReduceRULE_ENG_DSP (string input, Token token, Token [] tokens)
		{
			// <Eng> ::= Dsp
		}

		public void ReduceRULE_X_EXCHANGE_I_SUB_I (string input, Token token, Token [] tokens)
		{
			// <X_Exchange_I> ::= 'Sub_I'
		}

		public void ReduceRULE_BST_SST (string input, Token token, Token [] tokens)
		{
			// <Bst> ::= Sst
		}

		public void ReduceRULE_ST_I_STO (string input, Token token, Token [] tokens)
		{
			// <St_I> ::= Sto
		}

		public void ReduceRULE_RC_I_RCL (string input, Token token, Token [] tokens)
		{
			// <Rc_I> ::= Rcl
		}

		public void ReduceRULE_DEG_ENTER (string input, Token token, Token [] tokens)
		{
			// <Deg> ::= Enter
		}

		public void ReduceRULE_RAD_CHS (string input, Token token, Token [] tokens)
		{
			// <Rad> ::= Chs
		}

		public void ReduceRULE_GRD_EEX (string input, Token token, Token [] tokens)
		{
			// <Grd> ::= Eex
		}

		public void ReduceRULE_DEL_CLX (string input, Token token, Token [] tokens)
		{
			// <Del> ::= Clx
		}

		public void ReduceRULE_SF_SUBTRACTION (string input, Token token, Token [] tokens)
		{
			// <SF> ::= Subtraction
		}

		public void ReduceRULE_X_EXCHANGE_Y_SEVEN (string input, Token token, Token [] tokens)
		{
			// <X_Exchange_Y> ::= Seven
		}

		public void ReduceRULE_R_DOWN_EIGHT (string input, Token token, Token [] tokens)
		{
			// <R_Down> ::= Eight
		}

		public void ReduceRULE_R_UP_NINE (string input, Token token, Token [] tokens)
		{
			// <R_Up> ::= Nine
		}

		public void ReduceRULE_CF_ADDITION (string input, Token token, Token [] tokens)
		{
			// <CF> ::= Addition
		}

		public void ReduceRULE_RECIPROCAL_FOUR (string input, Token token, Token [] tokens)
		{
			// <Reciprocal> ::= Four
		}

		public void ReduceRULE_Y_TO_THE_XTH_FIVE (string input, Token token, Token [] tokens)
		{
			// <Y_To_The_Xth> ::= Five
		}

		public void ReduceRULE_ABS_SIX (string input, Token token, Token [] tokens)
		{
			// <Abs> ::= Six
		}

		public void ReduceRULE_F_TEST_MULTIPLICATION (string input, Token token, Token [] tokens)
		{
			// <F_Test> ::= Multiplication
		}

		public void ReduceRULE_PAUSE_ONE (string input, Token token, Token [] tokens)
		{
			// <Pause> ::= One
		}

		public void ReduceRULE_PI_TWO (string input, Token token, Token [] tokens)
		{
			// <Pi> ::= Two
		}

		public void ReduceRULE_REG_THREE (string input, Token token, Token [] tokens)
		{
			// <Reg> ::= Three
		}

		public void ReduceRULE_FACTORIAL_DIVISION (string input, Token token, Token [] tokens)
		{
			// <Factorial> ::= Division
		}

		public void ReduceRULE_LST_X_ZERO (string input, Token token, Token [] tokens)
		{
			// <Lst_X> ::= Zero
		}

		public void ReduceRULE_HMS_PLUS_PERIOD (string input, Token token, Token [] tokens)
		{
			// <HMS_Plus> ::= Period
		}

		public void ReduceRULE_SPACE_R_S (string input, Token token, Token [] tokens)
		{
			// <Space> ::= 'R_S'
		}

		public void ReduceRULE_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Instruction> ::= <Shortcut>
		}

		public void ReduceRULE_INSTRUCTION2 (string input, Token token, Token [] tokens)
		{
			// <Instruction> ::= <Unshifted_Instruction>
		}

		public void ReduceRULE_INSTRUCTION3 (string input, Token token, Token [] tokens)
		{
			// <Instruction> ::= <F_Shifted_Instruction>
		}

		public void ReduceRULE_INSTRUCTION4 (string input, Token token, Token [] tokens)
		{
			// <Instruction> ::= <G_Shifted_Instruction>
		}

		public void ReduceRULE_INSTRUCTION5 (string input, Token token, Token [] tokens)
		{
			// <Instruction> ::= <H_Shifted_Instruction>
		}

		public void ReduceRULE_SHORTCUT (string input, Token token, Token [] tokens)
		{
			// <Shortcut> ::= <Unshifted_Shortcut>
		}

		public void ReduceRULE_SHORTCUT2 (string input, Token token, Token [] tokens)
		{
			// <Shortcut> ::= <F_Shifted_Shortcut>
		}

		public void ReduceRULE_UNSHIFTED_SHORTCUT (string input, Token token, Token [] tokens)
		{
			// <Unshifted_Shortcut> ::= <Gsb_Shortcut>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_UNSHIFTED_SHORTCUT2 (string input, Token token, Token [] tokens)
		{
			// <Unshifted_Shortcut> ::= <Memory_Shortcut>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_F_SHIFTED_SHORTCUT_F (string input, Token token, Token [] tokens)
		{
			// <F_Shifted_Shortcut> ::= f <Gsb_Shortcut>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_GSB_SHORTCUT (string input, Token token, Token [] tokens)
		{
			// <Gsb_Shortcut> ::= <Letter>
		}

		public void ReduceRULE_MEMORY_SHORTCUT_SUB_I (string input, Token token, Token [] tokens)
		{
			// <Memory_Shortcut> ::= 'Sub_I'
		}

		public void ReduceRULE_UNSHIFTED_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Unshifted_Instruction> ::= <Nullary_Unshifted_Instruction>
		}

		public void ReduceRULE_UNSHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens)
		{
			// <Unshifted_Instruction> ::= <Unary_Unshifted_Instruction>
		}

		public void ReduceRULE_UNSHIFTED_INSTRUCTION3 (string input, Token token, Token [] tokens)
		{
			// <Unshifted_Instruction> ::= <Binary_Unshifted_Instruction>
		}

		public void ReduceRULE_F_SHIFTED_INSTRUCTION_F (string input, Token token, Token [] tokens)
		{
			// <F_Shifted_Instruction> ::= f <Nullary_F_Shifted_Instruction>
		}

		public void ReduceRULE_F_SHIFTED_INSTRUCTION_F2 (string input, Token token, Token [] tokens)
		{
			// <F_Shifted_Instruction> ::= f <Unary_F_Shifted_Instruction>
		}

		public void ReduceRULE_G_SHIFTED_INSTRUCTION_G (string input, Token token, Token [] tokens)
		{
			// <G_Shifted_Instruction> ::= g <Nullary_G_Shifted_Instruction>
		}

		public void ReduceRULE_G_SHIFTED_INSTRUCTION_G2 (string input, Token token, Token [] tokens)
		{
			// <G_Shifted_Instruction> ::= g <Unary_G_Shifted_Instruction>
		}

		public void ReduceRULE_H_SHIFTED_INSTRUCTION_H (string input, Token token, Token [] tokens)
		{
			// <H_Shifted_Instruction> ::= h <Nullary_H_Shifted_Instruction>
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_SIGMA_PLUS (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= 'Sigma_Plus'
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= <Rcl_Sigma_Plus>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_SST (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= Sst
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_ENTER (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= Enter
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_CHS (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= Chs
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_EEX (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= Eex
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_CLX (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= Clx
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= <Digit>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_SUBTRACTION (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= Subtraction
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_ADDITION (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= Addition
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_MULTIPLICATION (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= Multiplication
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_DIVISION (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= Division
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_PERIOD (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= Period
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_R_S (string input, Token token, Token [] tokens)
		{
			// <Nullary_Unshifted_Instruction> ::= 'R_S'
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_GTO (string input, Token token, Token [] tokens)
		{
			// <Unary_Unshifted_Instruction> ::= Gto <Label>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_DSP (string input, Token token, Token [] tokens)
		{
			// <Unary_Unshifted_Instruction> ::= Dsp <Digit_Count>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_STO (string input, Token token, Token [] tokens)
		{
			// <Unary_Unshifted_Instruction> ::= Sto <Memory>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_RCL (string input, Token token, Token [] tokens)
		{
			// <Unary_Unshifted_Instruction> ::= Rcl <Memory>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_BINARY_UNSHIFTED_INSTRUCTION_STO (string input, Token token, Token [] tokens)
		{
			// <Binary_Unshifted_Instruction> ::= Sto <Operator> <Operable_Memory>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_TERNARY_UNSHIFTED_INSTRUCTION_GTO_PERIOD (string input, Token token, Token [] tokens)
		{
			// <Ternary_Unshifted_Instruction> ::= Gto Period <Digit> <Digit> <Digit>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <X_Average>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Fix>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION3 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Rnd>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION4 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Dsz>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION5 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Isz>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION6 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <W_Data>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION7 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <P_Exchange_S>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION8 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Cl_Reg>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION9 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Cl_Prgm>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION10 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <X_EQ_0>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION11 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Ln>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION12 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Log>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION13 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Sqrt>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION14 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <X_NE_0>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION15 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Sin>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION16 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Cos>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION17 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Tan>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION18 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <X_LT_0>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION19 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <To_Rectangular>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION20 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <To_Degrees>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION21 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <To_Hours>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION22 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <X_GT_0>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION23 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Percent>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION24 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Int>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION25 (string input, Token token, Token [] tokens)
		{
			// <Nullary_F_Shifted_Instruction> ::= <Display_X>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_UNARY_F_SHIFTED_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Unary_F_Shifted_Instruction> ::= <Gsb> <Label>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_UNARY_F_SHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens)
		{
			// <Unary_F_Shifted_Instruction> ::= <Lbl> <Label>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <S>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Sci>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION3 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Dsz_Sub_I>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION4 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Isz_Sub_I>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION5 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Merge>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION6 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <X_EQ_Y>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION7 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Exp>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION8 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Ten_To_The_Xth>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION9 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Square>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION10 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <X_NE_Y>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION11 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Arcsin>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION12 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Arccos>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION13 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Arctan>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION14 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <X_LE_Y>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION15 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <To_Polar>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION16 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <To_Radians>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION17 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <To_HMS>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION18 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <X_GT_Y>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION19 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Percent_Change>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION20 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Frac>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION21 (string input, Token token, Token [] tokens)
		{
			// <Nullary_G_Shifted_Instruction> ::= <Stk>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_UNARY_G_SHIFTED_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Unary_G_Shifted_Instruction> ::= <Gsb_f> <Letter_Label>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_UNARY_G_SHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens)
		{
			// <Unary_G_Shifted_Instruction> ::= <Lbl_f> <Letter_Label>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Sigma_Minus>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Rtn>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION3 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Eng>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION4 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <X_Exchange_I>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION5 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Bst>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION6 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <St_I>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION7 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Rc_I>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION8 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Deg>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION9 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Rad>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION10 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Grd>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION11 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Del>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION12 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <SF>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION13 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <X_Exchange_Y>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION14 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <R_Down>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION15 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <R_Up>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION16 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <CF>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION17 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Reciprocal>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION18 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Y_To_The_Xth>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION19 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Abs>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION20 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <F_Test>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION21 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Pause>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION22 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Pi>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION23 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Reg>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION24 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Factorial>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION25 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Lst_X>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION26 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <HMS_Plus>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION27 (string input, Token token, Token [] tokens)
		{
			// <Nullary_H_Shifted_Instruction> ::= <Space>
			theEngine.Process (new Instruction (input, tokens));
		}

		public void ReduceRULE_RCL_SIGMA_PLUS_RCL_SIGMA_PLUS (string input, Token token, Token [] tokens)
		{
			// <Rcl_Sigma_Plus> ::= Rcl 'Sigma_Plus'
		}

		public void ReduceRULE_OPERATOR_SUBTRACTION (string input, Token token, Token [] tokens)
		{
			// <Operator> ::= Subtraction
			token.UserObject = new Operator (new Memory.Operator(Operator.Subtraction));
		}

		public void ReduceRULE_OPERATOR_ADDITION (string input, Token token, Token [] tokens)
		{
			// <Operator> ::= Addition
			token.UserObject = new Operator (new Memory.Operator(Operator.Addition));
		}

		public void ReduceRULE_OPERATOR_MULTIPLICATION (string input, Token token, Token [] tokens)
		{
			// <Operator> ::= Multiplication
			token.UserObject = new Operator (new Memory.Operator(Operator.Multiplication));
		}

		public void ReduceRULE_OPERATOR_DIVISION (string input, Token token, Token [] tokens)
		{
			// <Operator> ::= Division
			token.UserObject = new Operator (new Memory.Operator(Operator.Division));
		}

		public void ReduceRULE_DIGIT_ZERO (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= Zero
			token.UserObject = new Digit (0);
		}

		public void ReduceRULE_DIGIT_ONE (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= One
			token.UserObject = new Digit (1);
		}

		public void ReduceRULE_DIGIT_TWO (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= Two
			token.UserObject = new Digit (2);
		}

		public void ReduceRULE_DIGIT_THREE (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= Three
			token.UserObject = new Digit (3);
		}

		public void ReduceRULE_DIGIT_FOUR (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= Four
			token.UserObject = new Digit (4);
		}

		public void ReduceRULE_DIGIT_FIVE (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= Five
			token.UserObject = new Digit (5);
		}

		public void ReduceRULE_DIGIT_SIX (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= Six
			token.UserObject = new Digit (6);
		}

		public void ReduceRULE_DIGIT_SEVEN (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= Seven
			token.UserObject = new Digit (7);
		}

		public void ReduceRULE_DIGIT_EIGHT (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= Eight
			token.UserObject = new Digit (8);
		}

		public void ReduceRULE_DIGIT_NINE (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= Nine
			token.UserObject = new Digit (9);
		}

		public void ReduceRULE_DIGIT_COUNT (string input, Token token, Token [] tokens)
		{
			// <Digit_Count> ::= <Digit>
		}

		public void ReduceRULE_DIGIT_COUNT_SUB_I (string input, Token token, Token [] tokens)
		{
			// <Digit_Count> ::= 'Sub_I'
			token.UserObject = new Indexed ();
		}

		public void ReduceRULE_LETTER_A (string input, Token token, Token [] tokens)
		{
			// <Letter> ::= A
			token.UserObject = new Letter ('A');
		}

		public void ReduceRULE_LETTER_B (string input, Token token, Token [] tokens)
		{
			// <Letter> ::= B
			token.UserObject = new Letter ('B');
		}

		public void ReduceRULE_LETTER_C (string input, Token token, Token [] tokens)
		{
			// <Letter> ::= C
			token.UserObject = new Letter ('C');
		}

		public void ReduceRULE_LETTER_D (string input, Token token, Token [] tokens)
		{
			// <Letter> ::= D
			token.UserObject = new Letter ('D');
		}

		public void ReduceRULE_LETTER_E (string input, Token token, Token [] tokens)
		{
			// <Letter> ::= E
			token.UserObject = new Letter ('E');
		}

		public void ReduceRULE_LETTER_LABEL (string input, Token token, Token [] tokens)
		{
			// <Letter_Label> ::= <Letter>
		}

		public void ReduceRULE_DIGIT_LABEL (string input, Token token, Token [] tokens)
		{
			// <Digit_Label> ::= <Digit>
		}

		public void ReduceRULE_LABEL (string input, Token token, Token [] tokens)
		{
			// <Label> ::= <Digit_Label>
		}

		public void ReduceRULE_LABEL2 (string input, Token token, Token [] tokens)
		{
			// <Label> ::= <Letter_Label>
		}

		public void ReduceRULE_LABEL_SUB_I (string input, Token token, Token [] tokens)
		{
			// <Label> ::= 'Sub_I'
			token.UserObject = new Indexed ();
		}

		public void ReduceRULE_OPERABLE_MEMORY (string input, Token token, Token [] tokens)
		{
			// <Operable_Memory> ::= <Digit>
		}

		public void ReduceRULE_OPERABLE_MEMORY_SUB_I (string input, Token token, Token [] tokens)
		{
			// <Operable_Memory> ::= 'Sub_I'
			token.UserObject = new Indexed ();
		}

		public void ReduceRULE_MEMORY (string input, Token token, Token [] tokens)
		{
			// <Memory> ::= <Operable_Memory>
		}

		public void ReduceRULE_MEMORY2 (string input, Token token, Token [] tokens)
		{
			// <Memory> ::= <Letter>
		}

		#endregion

	}

}
