
using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using HP67;
using HP67_Class_Library;
using HP67_Control_Library;
using System;
using System.Diagnostics;
using System.IO;

namespace HP67Parser
{

	public class Digit : Object
	{

		private byte digit;

		public Digit (byte d) 
		{
			digit = d;
		}

		public byte Value 
		{
			get 
			{
				return digit;
			}
		}

	}

    public class Actions : IActions
    {

		#region Private Data

		private static TraceSwitch classTraceSwitch = 
			new TraceSwitch ("HP67Parser.Actions", "Parser actions");

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
		
		public void ReduceRULE_X_AVERAGE_SIGMA_PLUS (Token token, Token [] tokens)
        {
            // <X_Average> ::= 'Sigma_Plus'
        }

        public void ReduceRULE_GSB_GTO (Token token, Token [] tokens)
        {
            // <Gsb> ::= Gto
        }

        public void ReduceRULE_FIX_DSP (Token token, Token [] tokens)
        {
            // <Fix> ::= Dsp
        }

        public void ReduceRULE_RND_SUB_I (Token token, Token [] tokens)
        {
            // <Rnd> ::= 'Sub_I'
        }

        public void ReduceRULE_LBL_SST (Token token, Token [] tokens)
        {
            // <Lbl> ::= Sst
        }

        public void ReduceRULE_DSZ_STO (Token token, Token [] tokens)
        {
            // <Dsz> ::= Sto
        }

        public void ReduceRULE_ISZ_RCL (Token token, Token [] tokens)
        {
            // <Isz> ::= Rcl
        }

        public void ReduceRULE_W_DATA_ENTER (Token token, Token [] tokens)
        {
            // <W_Data> ::= Enter
        }

        public void ReduceRULE_P_EXCHANGE_S_CHS (Token token, Token [] tokens)
        {
            // <P_Exchange_S> ::= Chs
        }

        public void ReduceRULE_CL_REG_EEX (Token token, Token [] tokens)
        {
            // <Cl_Reg> ::= Eex
        }

        public void ReduceRULE_CL_PRGM_CLX (Token token, Token [] tokens)
        {
            // <Cl_Prgm> ::= Clx
        }

        public void ReduceRULE_X_EQ_0_SUBTRACTION (Token token, Token [] tokens)
        {
            // <X_EQ_0> ::= Subtraction
        }

        public void ReduceRULE_LN_SEVEN (Token token, Token [] tokens)
        {
            // <Ln> ::= Seven
        }

        public void ReduceRULE_LOG_EIGHT (Token token, Token [] tokens)
        {
            // <Log> ::= Eight
        }

        public void ReduceRULE_SQRT_NINE (Token token, Token [] tokens)
        {
            // <Sqrt> ::= Nine
        }

        public void ReduceRULE_X_NE_0_ADDITION (Token token, Token [] tokens)
        {
            // <X_NE_0> ::= Addition
        }

        public void ReduceRULE_SIN_FOUR (Token token, Token [] tokens)
        {
            // <Sin> ::= Four
        }

        public void ReduceRULE_COS_FIVE (Token token, Token [] tokens)
        {
            // <Cos> ::= Five
        }

        public void ReduceRULE_TAN_SIX (Token token, Token [] tokens)
        {
            // <Tan> ::= Six
        }

        public void ReduceRULE_X_LT_0_MULTIPLICATION (Token token, Token [] tokens)
        {
            // <X_LT_0> ::= Multiplication
        }

        public void ReduceRULE_TO_RECTANGULAR_ONE (Token token, Token [] tokens)
        {
            // <To_Rectangular> ::= One
        }

        public void ReduceRULE_TO_DEGREES_TWO (Token token, Token [] tokens)
        {
            // <To_Degrees> ::= Two
        }

        public void ReduceRULE_TO_HOURS_THREE (Token token, Token [] tokens)
        {
            // <To_Hours> ::= Three
        }

        public void ReduceRULE_X_GT_0_DIVISION (Token token, Token [] tokens)
        {
            // <X_GT_0> ::= Division
        }

        public void ReduceRULE_PERCENT_ZERO (Token token, Token [] tokens)
        {
            // <Percent> ::= Zero
        }

        public void ReduceRULE_INT_PERIOD (Token token, Token [] tokens)
        {
            // <Int> ::= Period
        }

        public void ReduceRULE_DISPLAY_X_R_S (Token token, Token [] tokens)
        {
            // <Display_X> ::= 'R_S'
        }

        public void ReduceRULE_S_SIGMA_PLUS (Token token, Token [] tokens)
        {
            // <S> ::= 'Sigma_Plus'
        }

        public void ReduceRULE_GSB_F_GTO (Token token, Token [] tokens)
        {
            // <Gsb_f> ::= Gto
        }

        public void ReduceRULE_SCI_DSP (Token token, Token [] tokens)
        {
            // <Sci> ::= Dsp
        }

        public void ReduceRULE_LBL_F_SST (Token token, Token [] tokens)
        {
            // <Lbl_f> ::= Sst
        }

        public void ReduceRULE_DSZ_SUB_I_STO (Token token, Token [] tokens)
        {
            // <Dsz_Sub_I> ::= Sto
        }

        public void ReduceRULE_ISZ_SUB_I_RCL (Token token, Token [] tokens)
        {
            // <Isz_Sub_I> ::= Rcl
        }

        public void ReduceRULE_MERGE_ENTER (Token token, Token [] tokens)
        {
            // <Merge> ::= Enter
        }

        public void ReduceRULE_X_EQ_Y_SUBTRACTION (Token token, Token [] tokens)
        {
            // <X_EQ_Y> ::= Subtraction
        }

        public void ReduceRULE_EXP_SEVEN (Token token, Token [] tokens)
        {
            // <Exp> ::= Seven
        }

        public void ReduceRULE_TEN_TO_THE_XTH_EIGHT (Token token, Token [] tokens)
        {
            // <Ten_To_The_Xth> ::= Eight
        }

        public void ReduceRULE_SQUARE_NINE (Token token, Token [] tokens)
        {
            // <Square> ::= Nine
        }

        public void ReduceRULE_X_NE_Y_ADDITION (Token token, Token [] tokens)
        {
            // <X_NE_Y> ::= Addition
        }

        public void ReduceRULE_ARCSIN_FOUR (Token token, Token [] tokens)
        {
            // <Arcsin> ::= Four
        }

        public void ReduceRULE_ARCCOS_FIVE (Token token, Token [] tokens)
        {
            // <Arccos> ::= Five
        }

        public void ReduceRULE_ARCTAN_SIX (Token token, Token [] tokens)
        {
            // <Arctan> ::= Six
        }

        public void ReduceRULE_X_LE_Y_MULTIPLICATION (Token token, Token [] tokens)
        {
            // <X_LE_Y> ::= Multiplication
        }

        public void ReduceRULE_TO_POLAR_ONE (Token token, Token [] tokens)
        {
            // <To_Polar> ::= One
        }

        public void ReduceRULE_TO_RADIANS_TWO (Token token, Token [] tokens)
        {
            // <To_Radians> ::= Two
        }

        public void ReduceRULE_TO_HMS_THREE (Token token, Token [] tokens)
        {
            // <To_HMS> ::= Three
        }

        public void ReduceRULE_X_GT_Y_DIVISION (Token token, Token [] tokens)
        {
            // <X_GT_Y> ::= Division
        }

        public void ReduceRULE_PERCENT_CHANGE_ZERO (Token token, Token [] tokens)
        {
            // <Percent_Change> ::= Zero
        }

        public void ReduceRULE_FRAC_PERIOD (Token token, Token [] tokens)
        {
            // <Frac> ::= Period
        }

        public void ReduceRULE_STK_R_S (Token token, Token [] tokens)
        {
            // <Stk> ::= 'R_S'
        }

        public void ReduceRULE_SIGMA_MINUS_SIGMA_PLUS (Token token, Token [] tokens)
        {
            // <Sigma_Minus> ::= 'Sigma_Plus'
        }

        public void ReduceRULE_RTN_GTO (Token token, Token [] tokens)
        {
            // <Rtn> ::= Gto
        }

        public void ReduceRULE_ENG_DSP (Token token, Token [] tokens)
        {
            // <Eng> ::= Dsp
        }

        public void ReduceRULE_X_EXCHANGE_I_SUB_I (Token token, Token [] tokens)
        {
            // <X_Exchange_I> ::= 'Sub_I'
        }

        public void ReduceRULE_BST_SST (Token token, Token [] tokens)
        {
            // <Bst> ::= Sst
        }

        public void ReduceRULE_ST_I_STO (Token token, Token [] tokens)
        {
            // <St_I> ::= Sto
        }

        public void ReduceRULE_RC_I_RCL (Token token, Token [] tokens)
        {
            // <Rc_I> ::= Rcl
        }

        public void ReduceRULE_DEG_ENTER (Token token, Token [] tokens)
        {
            // <Deg> ::= Enter
        }

        public void ReduceRULE_RAD_CHS (Token token, Token [] tokens)
        {
            // <Rad> ::= Chs
        }

        public void ReduceRULE_GRD_EEX (Token token, Token [] tokens)
        {
            // <Grd> ::= Eex
        }

        public void ReduceRULE_DEL_CLX (Token token, Token [] tokens)
        {
            // <Del> ::= Clx
        }

        public void ReduceRULE_SF_SUBTRACTION (Token token, Token [] tokens)
        {
            // <SF> ::= Subtraction
        }

        public void ReduceRULE_X_EXCHANGE_Y_SEVEN (Token token, Token [] tokens)
        {
            // <X_Exchange_Y> ::= Seven
        }

        public void ReduceRULE_R_DOWN_EIGHT (Token token, Token [] tokens)
        {
            // <R_Down> ::= Eight
        }

        public void ReduceRULE_R_UP_NINE (Token token, Token [] tokens)
        {
            // <R_Up> ::= Nine
        }

        public void ReduceRULE_CF_ADDITION (Token token, Token [] tokens)
        {
            // <CF> ::= Addition
        }

        public void ReduceRULE_RECIPROCAL_FOUR (Token token, Token [] tokens)
        {
            // <Reciprocal> ::= Four
        }

        public void ReduceRULE_Y_TO_THE_XTH_FIVE (Token token, Token [] tokens)
        {
            // <Y_To_The_Xth> ::= Five
        }

        public void ReduceRULE_ABS_SIX (Token token, Token [] tokens)
        {
            // <Abs> ::= Six
        }

        public void ReduceRULE_F_TEST_MULTIPLICATION (Token token, Token [] tokens)
        {
            // <F_Test> ::= Multiplication
        }

        public void ReduceRULE_PAUSE_ONE (Token token, Token [] tokens)
        {
            // <Pause> ::= One
        }

        public void ReduceRULE_PI_TWO (Token token, Token [] tokens)
        {
            // <Pi> ::= Two
        }

        public void ReduceRULE_REG_THREE (Token token, Token [] tokens)
        {
            // <Reg> ::= Three
        }

        public void ReduceRULE_FACTORIAL_DIVISION (Token token, Token [] tokens)
        {
            // <Factorial> ::= Division
        }

        public void ReduceRULE_LST_X_ZERO (Token token, Token [] tokens)
        {
            // <Lst_X> ::= Zero
        }

        public void ReduceRULE_HMS_PLUS_PERIOD (Token token, Token [] tokens)
        {
            // <HMS_Plus> ::= Period
        }

        public void ReduceRULE_SPACE_R_S (Token token, Token [] tokens)
        {
            // <Space> ::= 'R_S'
        }

        public void ReduceRULE_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Instruction> ::= <Command>
        }

        public void ReduceRULE_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Instruction> ::= <Shortcut>
		}

        public void ReduceRULE_INSTRUCTION3 (Token token, Token [] tokens)
        {
            // <Instruction> ::= <Unshifted_Instruction>
		}

        public void ReduceRULE_INSTRUCTION4 (Token token, Token [] tokens)
        {
            // <Instruction> ::= <F_Shifted_Instruction>
		}

        public void ReduceRULE_INSTRUCTION5 (Token token, Token [] tokens)
        {
            // <Instruction> ::= <G_Shifted_Instruction>
		}

        public void ReduceRULE_INSTRUCTION6 (Token token, Token [] tokens)
        {
            // <Instruction> ::= <H_Shifted_Instruction>
		}

        public void ReduceRULE_COMMAND_SST (Token token, Token [] tokens)
        {
            // <Command> ::= Sst
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_COMMAND_H (Token token, Token [] tokens)
        {
            // <Command> ::= h <Bst>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_COMMAND_H2 (Token token, Token [] tokens)
        {
            // <Command> ::= h <Del>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_COMMAND_F (Token token, Token [] tokens)
        {
            // <Command> ::= f <Cl_Prgm>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_COMMAND_GTO_PERIOD (Token token, Token [] tokens)
        {
            // <Command> ::= Gto Period <Digit> <Digit> <Digit>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_SHORTCUT (Token token, Token [] tokens)
        {
            // <Shortcut> ::= <Unshifted_Shortcut>
        }

        public void ReduceRULE_SHORTCUT2 (Token token, Token [] tokens)
        {
            // <Shortcut> ::= <F_Shifted_Shortcut>
        }

        public void ReduceRULE_UNSHIFTED_SHORTCUT (Token token, Token [] tokens)
        {
            // <Unshifted_Shortcut> ::= <Gsb_Shortcut>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_UNSHIFTED_SHORTCUT2 (Token token, Token [] tokens)
        {
            // <Unshifted_Shortcut> ::= <Memory_Shortcut>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_F_SHIFTED_SHORTCUT_F (Token token, Token [] tokens)
        {
            // <F_Shifted_Shortcut> ::= f <Gsb_Shortcut>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_GSB_SHORTCUT (Token token, Token [] tokens)
        {
            // <Gsb_Shortcut> ::= <Letter>
        }

        public void ReduceRULE_MEMORY_SHORTCUT_SUB_I (Token token, Token [] tokens)
        {
            // <Memory_Shortcut> ::= 'Sub_I'
        }

        public void ReduceRULE_UNSHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Unshifted_Instruction> ::= <Nullary_Unshifted_Instruction>
        }

        public void ReduceRULE_UNSHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Unshifted_Instruction> ::= <Unary_Unshifted_Instruction>
        }

        public void ReduceRULE_UNSHIFTED_INSTRUCTION3 (Token token, Token [] tokens)
        {
            // <Unshifted_Instruction> ::= <Binary_Unshifted_Instruction>
        }

        public void ReduceRULE_F_SHIFTED_INSTRUCTION_F (Token token, Token [] tokens)
        {
            // <F_Shifted_Instruction> ::= f <Nullary_F_Shifted_Instruction>
        }

        public void ReduceRULE_F_SHIFTED_INSTRUCTION_F2 (Token token, Token [] tokens)
        {
            // <F_Shifted_Instruction> ::= f <Unary_F_Shifted_Instruction>
        }

        public void ReduceRULE_G_SHIFTED_INSTRUCTION_G (Token token, Token [] tokens)
        {
            // <G_Shifted_Instruction> ::= g <Nullary_G_Shifted_Instruction>
        }

        public void ReduceRULE_G_SHIFTED_INSTRUCTION_G2 (Token token, Token [] tokens)
        {
            // <G_Shifted_Instruction> ::= g <Unary_G_Shifted_Instruction>
        }

        public void ReduceRULE_H_SHIFTED_INSTRUCTION_H (Token token, Token [] tokens)
        {
            // <H_Shifted_Instruction> ::= h <Nullary_H_Shifted_Instruction>
        }

        public void ReduceRULE_H_SHIFTED_INSTRUCTION_H2 (Token token, Token [] tokens)
        {
            // <H_Shifted_Instruction> ::= h <Unary_H_Shifted_Instruction>
        }

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_SIGMA_PLUS (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= 'Sigma_Plus'
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_ENTER (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Enter
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_CHS (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Chs
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_EEX (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Eex
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_CLX (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Clx
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= <Digit>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_SUBTRACTION (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Subtraction
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_ADDITION (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Addition
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_MULTIPLICATION (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Multiplication
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_DIVISION (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Division
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_PERIOD (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Period
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_R_S (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= 'R_S'
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_GTO (Token token, Token [] tokens)
        {
            // <Unary_Unshifted_Instruction> ::= Gto <Label>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_DSP (Token token, Token [] tokens)
        {
            // <Unary_Unshifted_Instruction> ::= Dsp <Digit>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_STO (Token token, Token [] tokens)
        {
            // <Unary_Unshifted_Instruction> ::= Sto <Memory>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_RCL (Token token, Token [] tokens)
        {
            // <Unary_Unshifted_Instruction> ::= Rcl <Memory>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_BINARY_UNSHIFTED_INSTRUCTION_STO (Token token, Token [] tokens)
        {
            // <Binary_Unshifted_Instruction> ::= Sto <Operator> <Operable_Memory>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <X_Average>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Fix>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION3 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Rnd>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION4 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Dsz>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION5 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Isz>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION6 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <W_Data>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION7 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <P_Exchange_S>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION8 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Cl_Reg>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION9 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <X_EQ_0>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION10 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Ln>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION11 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Log>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION12 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Sqrt>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION13 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <X_NE_0>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION14 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Sin>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION15 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Cos>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION16 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Tan>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION17 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <X_LT_0>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION18 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <To_Rectangular>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION19 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <To_Degrees>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION20 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <To_Hours>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION21 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <X_GT_0>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION22 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Percent>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION23 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Int>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION24 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Display_X>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_UNARY_F_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Unary_F_Shifted_Instruction> ::= <Gsb> <Label>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_UNARY_F_SHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Unary_F_Shifted_Instruction> ::= <Lbl> <Label>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <S>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Sci>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION3 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Dsz_Sub_I>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION4 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Isz_Sub_I>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION5 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Merge>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION6 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <X_EQ_Y>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION7 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Exp>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION8 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Ten_To_The_Xth>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION9 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Square>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION10 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <X_NE_Y>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION11 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Arcsin>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION12 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Arccos>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION13 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Arctan>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION14 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <X_LE_Y>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION15 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <To_Polar>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION16 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <To_Radians>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION17 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <To_HMS>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION18 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <X_GT_Y>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION19 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Percent_Change>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION20 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Frac>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION21 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Stk>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_UNARY_G_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Unary_G_Shifted_Instruction> ::= <Gsb_f> <Letter_Label>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_UNARY_G_SHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Unary_G_Shifted_Instruction> ::= <Lbl_f> <Letter_Label>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Sigma_Minus>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Rtn>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION3 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Eng>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION4 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_I>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION5 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <St_I>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION6 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Rc_I>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION7 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Deg>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION8 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Rad>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION9 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Grd>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION10 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <SF>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION11 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_Y>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION12 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <R_Down>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION13 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <R_Up>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION14 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <CF>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION15 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Reciprocal>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION16 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Y_To_The_Xth>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION17 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Abs>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION18 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <F_Test>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION19 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Pause>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION20 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Pi>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION21 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Reg>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION22 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Factorial>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION23 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Lst_X>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION24 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <HMS_Plus>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION25 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Space>
			theEngine.Execute (tokens);
		}

        public void ReduceRULE_UNARY_H_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Unary_H_Shifted_Instruction> ::= 
        }

        public void ReduceRULE_OPERATOR_SUBTRACTION (Token token, Token [] tokens)
        {
            // <Operator> ::= Subtraction
			
		}

        public void ReduceRULE_OPERATOR_ADDITION (Token token, Token [] tokens)
        {
            // <Operator> ::= Addition
			// TODO: Argument
		}

        public void ReduceRULE_OPERATOR_MULTIPLICATION (Token token, Token [] tokens)
        {
            // <Operator> ::= Multiplication
			// TODO: Argument
		}

        public void ReduceRULE_OPERATOR_DIVISION (Token token, Token [] tokens)
        {
            // <Operator> ::= Division
			// TODO: Argument
		}

        public void ReduceRULE_DIGIT_ZERO (Token token, Token [] tokens)
        {
            // <Digit> ::= Zero
			token.UserObject = new Digit (0);
		}

        public void ReduceRULE_DIGIT_ONE (Token token, Token [] tokens)
        {
            // <Digit> ::= One
			token.UserObject = new Digit (1);
		}

        public void ReduceRULE_DIGIT_TWO (Token token, Token [] tokens)
        {
            // <Digit> ::= Two
			token.UserObject = new Digit (2);
		}

        public void ReduceRULE_DIGIT_THREE (Token token, Token [] tokens)
        {
            // <Digit> ::= Three
			token.UserObject = new Digit (3);
		}

        public void ReduceRULE_DIGIT_FOUR (Token token, Token [] tokens)
        {
            // <Digit> ::= Four
			token.UserObject = new Digit (4);
		}

        public void ReduceRULE_DIGIT_FIVE (Token token, Token [] tokens)
        {
            // <Digit> ::= Five
			token.UserObject = new Digit (5);
		}

        public void ReduceRULE_DIGIT_SIX (Token token, Token [] tokens)
        {
            // <Digit> ::= Six
			token.UserObject = new Digit (6);
		}

        public void ReduceRULE_DIGIT_SEVEN (Token token, Token [] tokens)
        {
            // <Digit> ::= Seven
			token.UserObject = new Digit (7);
		}

        public void ReduceRULE_DIGIT_EIGHT (Token token, Token [] tokens)
        {
            // <Digit> ::= Eight
			token.UserObject = new Digit (8);
		}

        public void ReduceRULE_DIGIT_NINE (Token token, Token [] tokens)
        {
            // <Digit> ::= Nine
			token.UserObject = new Digit (9);
		}

        public void ReduceRULE_LETTER_A (Token token, Token [] tokens)
        {
            // <Letter> ::= A
			// TODO: Argument
		}

        public void ReduceRULE_LETTER_B (Token token, Token [] tokens)
        {
            // <Letter> ::= B
			// TODO: Argument
		}

        public void ReduceRULE_LETTER_C (Token token, Token [] tokens)
        {
            // <Letter> ::= C
			// TODO: Argument
		}

        public void ReduceRULE_LETTER_D (Token token, Token [] tokens)
        {
            // <Letter> ::= D
			// TODO: Argument
		}

        public void ReduceRULE_LETTER_E (Token token, Token [] tokens)
        {
            // <Letter> ::= E
			// TODO: Argument
		}

        public void ReduceRULE_LETTER_LABEL (Token token, Token [] tokens)
        {
            // <Letter_Label> ::= <Letter>
        }

        public void ReduceRULE_DIGIT_LABEL (Token token, Token [] tokens)
        {
            // <Digit_Label> ::= <Digit>
        }

        public void ReduceRULE_LABEL (Token token, Token [] tokens)
        {
            // <Label> ::= <Digit_Label>
        }

        public void ReduceRULE_LABEL2 (Token token, Token [] tokens)
        {
            // <Label> ::= <Letter_Label>
        }

        public void ReduceRULE_OPERABLE_MEMORY (Token token, Token [] tokens)
        {
            // <Operable_Memory> ::= <Digit>
        }

        public void ReduceRULE_OPERABLE_MEMORY_SUB_I (Token token, Token [] tokens)
        {
            // <Operable_Memory> ::= 'Sub_I'
			// TODO: Argument
		}

        public void ReduceRULE_MEMORY (Token token, Token [] tokens)
        {
            // <Memory> ::= <Operable_Memory>
        }

        public void ReduceRULE_MEMORY2 (Token token, Token [] tokens)
        {
            // <Memory> ::= <Letter>
        }

		#endregion

    }

}
