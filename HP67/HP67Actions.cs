
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

	public class HP67ArgumentDigit : Object
	{

		private byte digit;

		public HP67ArgumentDigit (byte d) 
		{
			digit = d;
		}

		public byte Digit 
		{
			get 
			{
				return digit;
			}
		}

	}

    public class Actions : IActions
    {

		#region Public Operations

        public void RULE_X_AVERAGE_SIGMA_PLUS (Token token, Token [] tokens)
        {
            // <X_Average> ::= 'Sigma_Plus'
        }

        public void RULE_GSB_GTO (Token token, Token [] tokens)
        {
            // <Gsb> ::= Gto
        }

        public void RULE_FIX_DSP (Token token, Token [] tokens)
        {
            // <Fix> ::= Dsp
        }

        public void RULE_RND_SUB_I (Token token, Token [] tokens)
        {
            // <Rnd> ::= 'Sub_I'
        }

        public void RULE_LBL_SST (Token token, Token [] tokens)
        {
            // <Lbl> ::= Sst
        }

        public void RULE_DSZ_STO (Token token, Token [] tokens)
        {
            // <Dsz> ::= Sto
        }

        public void RULE_ISZ_RCL (Token token, Token [] tokens)
        {
            // <Isz> ::= Rcl
        }

        public void RULE_W_DATA_ENTER (Token token, Token [] tokens)
        {
            // <W_Data> ::= Enter
        }

        public void RULE_P_EXCHANGE_S_CHS (Token token, Token [] tokens)
        {
            // <P_Exchange_S> ::= Chs
        }

        public void RULE_CL_REG_EEX (Token token, Token [] tokens)
        {
            // <Cl_Reg> ::= Eex
        }

        public void RULE_CL_PRGM_CLX (Token token, Token [] tokens)
        {
            // <Cl_Prgm> ::= Clx
        }

        public void RULE_X_EQ_0_SUBTRACTION (Token token, Token [] tokens)
        {
            // <X_EQ_0> ::= Subtraction
        }

        public void RULE_LN_SEVEN (Token token, Token [] tokens)
        {
            // <Ln> ::= Seven
        }

        public void RULE_LOG_EIGHT (Token token, Token [] tokens)
        {
            // <Log> ::= Eight
        }

        public void RULE_SQRT_NINE (Token token, Token [] tokens)
        {
            // <Sqrt> ::= Nine
        }

        public void RULE_X_NE_0_ADDITION (Token token, Token [] tokens)
        {
            // <X_NE_0> ::= Addition
        }

        public void RULE_SIN_FOUR (Token token, Token [] tokens)
        {
            // <Sin> ::= Four
        }

        public void RULE_COS_FIVE (Token token, Token [] tokens)
        {
            // <Cos> ::= Five
        }

        public void RULE_TAN_SIX (Token token, Token [] tokens)
        {
            // <Tan> ::= Six
        }

        public void RULE_X_LT_0_MULTIPLICATION (Token token, Token [] tokens)
        {
            // <X_LT_0> ::= Multiplication
        }

        public void RULE_TO_RECTANGULAR_ONE (Token token, Token [] tokens)
        {
            // <To_Rectangular> ::= One
        }

        public void RULE_TO_DEGREES_TWO (Token token, Token [] tokens)
        {
            // <To_Degrees> ::= Two
        }

        public void RULE_TO_HOURS_THREE (Token token, Token [] tokens)
        {
            // <To_Hours> ::= Three
        }

        public void RULE_X_GT_0_DIVISION (Token token, Token [] tokens)
        {
            // <X_GT_0> ::= Division
        }

        public void RULE_PERCENT_ZERO (Token token, Token [] tokens)
        {
            // <Percent> ::= Zero
        }

        public void RULE_INT_PERIOD (Token token, Token [] tokens)
        {
            // <Int> ::= Period
        }

        public void RULE_DISPLAY_X_R_S (Token token, Token [] tokens)
        {
            // <Display_X> ::= 'R_S'
        }

        public void RULE_S_SIGMA_PLUS (Token token, Token [] tokens)
        {
            // <S> ::= 'Sigma_Plus'
        }

        public void RULE_GSB_F_GTO (Token token, Token [] tokens)
        {
            // <Gsb_f> ::= Gto
        }

        public void RULE_SCI_DSP (Token token, Token [] tokens)
        {
            // <Sci> ::= Dsp
        }

        public void RULE_LBL_F_SST (Token token, Token [] tokens)
        {
            // <Lbl_f> ::= Sst
        }

        public void RULE_DSZ_SUB_I_STO (Token token, Token [] tokens)
        {
            // <Dsz_Sub_I> ::= Sto
        }

        public void RULE_ISZ_SUB_I_RCL (Token token, Token [] tokens)
        {
            // <Isz_Sub_I> ::= Rcl
        }

        public void RULE_MERGE_ENTER (Token token, Token [] tokens)
        {
            // <Merge> ::= Enter
        }

        public void RULE_X_EQ_Y_SUBTRACTION (Token token, Token [] tokens)
        {
            // <X_EQ_Y> ::= Subtraction
        }

        public void RULE_EXP_SEVEN (Token token, Token [] tokens)
        {
            // <Exp> ::= Seven
        }

        public void RULE_TEN_TO_THE_XTH_EIGHT (Token token, Token [] tokens)
        {
            // <Ten_To_The_Xth> ::= Eight
        }

        public void RULE_SQUARE_NINE (Token token, Token [] tokens)
        {
            // <Square> ::= Nine
        }

        public void RULE_X_NE_Y_ADDITION (Token token, Token [] tokens)
        {
            // <X_NE_Y> ::= Addition
        }

        public void RULE_ARCSIN_FOUR (Token token, Token [] tokens)
        {
            // <Arcsin> ::= Four
        }

        public void RULE_ARCCOS_FIVE (Token token, Token [] tokens)
        {
            // <Arccos> ::= Five
        }

        public void RULE_ARCTAN_SIX (Token token, Token [] tokens)
        {
            // <Arctan> ::= Six
        }

        public void RULE_X_LE_Y_MULTIPLICATION (Token token, Token [] tokens)
        {
            // <X_LE_Y> ::= Multiplication
        }

        public void RULE_TO_POLAR_ONE (Token token, Token [] tokens)
        {
            // <To_Polar> ::= One
        }

        public void RULE_TO_RADIANS_TWO (Token token, Token [] tokens)
        {
            // <To_Radians> ::= Two
        }

        public void RULE_TO_HMS_THREE (Token token, Token [] tokens)
        {
            // <To_HMS> ::= Three
        }

        public void RULE_X_GT_Y_DIVISION (Token token, Token [] tokens)
        {
            // <X_GT_Y> ::= Division
        }

        public void RULE_PERCENT_CHANGE_ZERO (Token token, Token [] tokens)
        {
            // <Percent_Change> ::= Zero
        }

        public void RULE_FRAC_PERIOD (Token token, Token [] tokens)
        {
            // <Frac> ::= Period
        }

        public void RULE_STK_R_S (Token token, Token [] tokens)
        {
            // <Stk> ::= 'R_S'
        }

        public void RULE_SIGMA_MINUS_SIGMA_PLUS (Token token, Token [] tokens)
        {
            // <Sigma_Minus> ::= 'Sigma_Plus'
        }

        public void RULE_RTN_GTO (Token token, Token [] tokens)
        {
            // <Rtn> ::= Gto
        }

        public void RULE_ENG_DSP (Token token, Token [] tokens)
        {
            // <Eng> ::= Dsp
        }

        public void RULE_X_EXCHANGE_I_SUB_I (Token token, Token [] tokens)
        {
            // <X_Exchange_I> ::= 'Sub_I'
        }

        public void RULE_BST_SST (Token token, Token [] tokens)
        {
            // <Bst> ::= Sst
        }

        public void RULE_ST_I_STO (Token token, Token [] tokens)
        {
            // <St_I> ::= Sto
        }

        public void RULE_RC_I_RCL (Token token, Token [] tokens)
        {
            // <Rc_I> ::= Rcl
        }

        public void RULE_DEG_ENTER (Token token, Token [] tokens)
        {
            // <Deg> ::= Enter
        }

        public void RULE_RAD_CHS (Token token, Token [] tokens)
        {
            // <Rad> ::= Chs
        }

        public void RULE_GRD_EEX (Token token, Token [] tokens)
        {
            // <Grd> ::= Eex
        }

        public void RULE_DEL_CLX (Token token, Token [] tokens)
        {
            // <Del> ::= Clx
        }

        public void RULE_SF_SUBTRACTION (Token token, Token [] tokens)
        {
            // <SF> ::= Subtraction
        }

        public void RULE_X_EXCHANGE_Y_SEVEN (Token token, Token [] tokens)
        {
            // <X_Exchange_Y> ::= Seven
        }

        public void RULE_R_DOWN_EIGHT (Token token, Token [] tokens)
        {
            // <R_Down> ::= Eight
        }

        public void RULE_R_UP_NINE (Token token, Token [] tokens)
        {
            // <R_Up> ::= Nine
        }

        public void RULE_CF_ADDITION (Token token, Token [] tokens)
        {
            // <CF> ::= Addition
        }

        public void RULE_RECIPROCAL_FOUR (Token token, Token [] tokens)
        {
            // <Reciprocal> ::= Four
        }

        public void RULE_Y_TO_THE_XTH_FIVE (Token token, Token [] tokens)
        {
            // <Y_To_The_Xth> ::= Five
        }

        public void RULE_ABS_SIX (Token token, Token [] tokens)
        {
            // <Abs> ::= Six
        }

        public void RULE_F_TEST_MULTIPLICATION (Token token, Token [] tokens)
        {
            // <F_Test> ::= Multiplication
        }

        public void RULE_PAUSE_ONE (Token token, Token [] tokens)
        {
            // <Pause> ::= One
        }

        public void RULE_PI_TWO (Token token, Token [] tokens)
        {
            // <Pi> ::= Two
        }

        public void RULE_REG_THREE (Token token, Token [] tokens)
        {
            // <Reg> ::= Three
        }

        public void RULE_FACTORIAL_DIVISION (Token token, Token [] tokens)
        {
            // <Factorial> ::= Division
        }

        public void RULE_LST_X_ZERO (Token token, Token [] tokens)
        {
            // <Lst_X> ::= Zero
        }

        public void RULE_HMS_PLUS_PERIOD (Token token, Token [] tokens)
        {
            // <HMS_Plus> ::= Period
        }

        public void RULE_SPACE_R_S (Token token, Token [] tokens)
        {
            // <Space> ::= 'R_S'
        }

        public void RULE_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Instruction> ::= <Command>
        }

        public void RULE_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Instruction> ::= <Shortcut>
		}

        public void RULE_INSTRUCTION3 (Token token, Token [] tokens)
        {
            // <Instruction> ::= <Unshifted_Instruction>
		}

        public void RULE_INSTRUCTION4 (Token token, Token [] tokens)
        {
            // <Instruction> ::= <F_Shifted_Instruction>
		}

        public void RULE_INSTRUCTION5 (Token token, Token [] tokens)
        {
            // <Instruction> ::= <G_Shifted_Instruction>
		}

        public void RULE_INSTRUCTION6 (Token token, Token [] tokens)
        {
            // <Instruction> ::= <H_Shifted_Instruction>
		}

        public void RULE_COMMAND_SST (Token token, Token [] tokens)
        {
            // <Command> ::= Sst
			HP67Execution.Execute (tokens);
		}

        public void RULE_COMMAND_H (Token token, Token [] tokens)
        {
            // <Command> ::= h <Bst>
			HP67Execution.Execute (tokens);
		}

        public void RULE_COMMAND_H2 (Token token, Token [] tokens)
        {
            // <Command> ::= h <Del>
			HP67Execution.Execute (tokens);
		}

        public void RULE_COMMAND_F (Token token, Token [] tokens)
        {
            // <Command> ::= f <Cl_Prgm>
			HP67Execution.Execute (tokens);
		}

        public void RULE_COMMAND_GTO_PERIOD (Token token, Token [] tokens)
        {
            // <Command> ::= Gto Period <Digit> <Digit> <Digit>
			HP67Execution.Execute (tokens);
		}

        public void RULE_SHORTCUT (Token token, Token [] tokens)
        {
            // <Shortcut> ::= <Unshifted_Shortcut>
        }

        public void RULE_SHORTCUT2 (Token token, Token [] tokens)
        {
            // <Shortcut> ::= <F_Shifted_Shortcut>
        }

        public void RULE_UNSHIFTED_SHORTCUT (Token token, Token [] tokens)
        {
            // <Unshifted_Shortcut> ::= <Gsb_Shortcut>
			HP67Execution.Execute (tokens);
		}

        public void RULE_UNSHIFTED_SHORTCUT2 (Token token, Token [] tokens)
        {
            // <Unshifted_Shortcut> ::= <Memory_Shortcut>
			HP67Execution.Execute (tokens);
		}

        public void RULE_F_SHIFTED_SHORTCUT_F (Token token, Token [] tokens)
        {
            // <F_Shifted_Shortcut> ::= f <Gsb_Shortcut>
			HP67Execution.Execute (tokens);
		}

        public void RULE_GSB_SHORTCUT (Token token, Token [] tokens)
        {
            // <Gsb_Shortcut> ::= <Letter>
        }

        public void RULE_MEMORY_SHORTCUT_SUB_I (Token token, Token [] tokens)
        {
            // <Memory_Shortcut> ::= 'Sub_I'
        }

        public void RULE_UNSHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Unshifted_Instruction> ::= <Nullary_Unshifted_Instruction>
        }

        public void RULE_UNSHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Unshifted_Instruction> ::= <Unary_Unshifted_Instruction>
        }

        public void RULE_UNSHIFTED_INSTRUCTION3 (Token token, Token [] tokens)
        {
            // <Unshifted_Instruction> ::= <Binary_Unshifted_Instruction>
        }

        public void RULE_F_SHIFTED_INSTRUCTION_F (Token token, Token [] tokens)
        {
            // <F_Shifted_Instruction> ::= f <Nullary_F_Shifted_Instruction>
        }

        public void RULE_F_SHIFTED_INSTRUCTION_F2 (Token token, Token [] tokens)
        {
            // <F_Shifted_Instruction> ::= f <Unary_F_Shifted_Instruction>
        }

        public void RULE_G_SHIFTED_INSTRUCTION_G (Token token, Token [] tokens)
        {
            // <G_Shifted_Instruction> ::= g <Nullary_G_Shifted_Instruction>
        }

        public void RULE_G_SHIFTED_INSTRUCTION_G2 (Token token, Token [] tokens)
        {
            // <G_Shifted_Instruction> ::= g <Unary_G_Shifted_Instruction>
        }

        public void RULE_H_SHIFTED_INSTRUCTION_H (Token token, Token [] tokens)
        {
            // <H_Shifted_Instruction> ::= h <Nullary_H_Shifted_Instruction>
        }

        public void RULE_H_SHIFTED_INSTRUCTION_H2 (Token token, Token [] tokens)
        {
            // <H_Shifted_Instruction> ::= h <Unary_H_Shifted_Instruction>
        }

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION_SIGMA_PLUS (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= 'Sigma_Plus'
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION_ENTER (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Enter
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION_CHS (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Chs
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION_EEX (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Eex
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION_CLX (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Clx
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= <Digit>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION_SUBTRACTION (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Subtraction
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION_ADDITION (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Addition
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION_MULTIPLICATION (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Multiplication
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION_DIVISION (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Division
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION_PERIOD (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= Period
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_UNSHIFTED_INSTRUCTION_R_S (Token token, Token [] tokens)
        {
            // <Nullary_Unshifted_Instruction> ::= 'R_S'
			HP67Execution.Execute (tokens);
		}

        public void RULE_UNARY_UNSHIFTED_INSTRUCTION_GTO (Token token, Token [] tokens)
        {
            // <Unary_Unshifted_Instruction> ::= Gto <Label>
			HP67Execution.Execute (tokens);
		}

        public void RULE_UNARY_UNSHIFTED_INSTRUCTION_DSP (Token token, Token [] tokens)
        {
            // <Unary_Unshifted_Instruction> ::= Dsp <Digit>
			HP67Execution.Execute (tokens);
		}

        public void RULE_UNARY_UNSHIFTED_INSTRUCTION_STO (Token token, Token [] tokens)
        {
            // <Unary_Unshifted_Instruction> ::= Sto <Memory>
			HP67Execution.Execute (tokens);
		}

        public void RULE_UNARY_UNSHIFTED_INSTRUCTION_RCL (Token token, Token [] tokens)
        {
            // <Unary_Unshifted_Instruction> ::= Rcl <Memory>
			HP67Execution.Execute (tokens);
		}

        public void RULE_BINARY_UNSHIFTED_INSTRUCTION_STO (Token token, Token [] tokens)
        {
            // <Binary_Unshifted_Instruction> ::= Sto <Operator> <Operable_Memory>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <X_Average>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Fix>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION3 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Rnd>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION4 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Dsz>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION5 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Isz>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION6 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <W_Data>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION7 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <P_Exchange_S>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION8 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Cl_Reg>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION9 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <X_EQ_0>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION10 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Ln>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION11 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Log>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION12 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Sqrt>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION13 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <X_NE_0>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION14 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Sin>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION15 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Cos>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION16 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Tan>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION17 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <X_LT_0>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION18 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <To_Rectangular>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION19 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <To_Degrees>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION20 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <To_Hours>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION21 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <X_GT_0>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION22 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Percent>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION23 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Int>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_F_SHIFTED_INSTRUCTION24 (Token token, Token [] tokens)
        {
            // <Nullary_F_Shifted_Instruction> ::= <Display_X>
			HP67Execution.Execute (tokens);
		}

        public void RULE_UNARY_F_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Unary_F_Shifted_Instruction> ::= <Gsb> <Label>
			HP67Execution.Execute (tokens);
		}

        public void RULE_UNARY_F_SHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Unary_F_Shifted_Instruction> ::= <Lbl> <Label>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <S>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Sci>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION3 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Dsz_Sub_I>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION4 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Isz_Sub_I>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION5 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Merge>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION6 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <X_EQ_Y>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION7 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Exp>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION8 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Ten_To_The_Xth>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION9 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Square>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION10 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <X_NE_Y>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION11 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Arcsin>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION12 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Arccos>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION13 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Arctan>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION14 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <X_LE_Y>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION15 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <To_Polar>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION16 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <To_Radians>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION17 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <To_HMS>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION18 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <X_GT_Y>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION19 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Percent_Change>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION20 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Frac>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_G_SHIFTED_INSTRUCTION21 (Token token, Token [] tokens)
        {
            // <Nullary_G_Shifted_Instruction> ::= <Stk>
			HP67Execution.Execute (tokens);
		}

        public void RULE_UNARY_G_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Unary_G_Shifted_Instruction> ::= <Gsb_f> <Letter_Label>
			HP67Execution.Execute (tokens);
		}

        public void RULE_UNARY_G_SHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Unary_G_Shifted_Instruction> ::= <Lbl_f> <Letter_Label>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Sigma_Minus>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION2 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Rtn>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION3 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Eng>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION4 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_I>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION5 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <St_I>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION6 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Rc_I>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION7 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Deg>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION8 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Rad>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION9 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Grd>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION10 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <SF>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION11 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_Y>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION12 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <R_Down>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION13 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <R_Up>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION14 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <CF>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION15 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Reciprocal>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION16 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Y_To_The_Xth>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION17 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Abs>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION18 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <F_Test>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION19 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Pause>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION20 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Pi>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION21 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Reg>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION22 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Factorial>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION23 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Lst_X>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION24 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <HMS_Plus>
			HP67Execution.Execute (tokens);
		}

        public void RULE_NULLARY_H_SHIFTED_INSTRUCTION25 (Token token, Token [] tokens)
        {
            // <Nullary_H_Shifted_Instruction> ::= <Space>
			HP67Execution.Execute (tokens);
		}

        public void RULE_UNARY_H_SHIFTED_INSTRUCTION (Token token, Token [] tokens)
        {
            // <Unary_H_Shifted_Instruction> ::= 
        }

        public void RULE_OPERATOR_SUBTRACTION (Token token, Token [] tokens)
        {
            // <Operator> ::= Subtraction
			
		}

        public void RULE_OPERATOR_ADDITION (Token token, Token [] tokens)
        {
            // <Operator> ::= Addition
			// TODO: Argument
		}

        public void RULE_OPERATOR_MULTIPLICATION (Token token, Token [] tokens)
        {
            // <Operator> ::= Multiplication
			// TODO: Argument
		}

        public void RULE_OPERATOR_DIVISION (Token token, Token [] tokens)
        {
            // <Operator> ::= Division
			// TODO: Argument
		}

        public void RULE_DIGIT_ZERO (Token token, Token [] tokens)
        {
            // <Digit> ::= Zero
			token.UserObject = new HP67ArgumentDigit (0);
		}

        public void RULE_DIGIT_ONE (Token token, Token [] tokens)
        {
            // <Digit> ::= One
			token.UserObject = new HP67ArgumentDigit (1);
		}

        public void RULE_DIGIT_TWO (Token token, Token [] tokens)
        {
            // <Digit> ::= Two
			token.UserObject = new HP67ArgumentDigit (2);
		}

        public void RULE_DIGIT_THREE (Token token, Token [] tokens)
        {
            // <Digit> ::= Three
			token.UserObject = new HP67ArgumentDigit (3);
		}

        public void RULE_DIGIT_FOUR (Token token, Token [] tokens)
        {
            // <Digit> ::= Four
			token.UserObject = new HP67ArgumentDigit (4);
		}

        public void RULE_DIGIT_FIVE (Token token, Token [] tokens)
        {
            // <Digit> ::= Five
			token.UserObject = new HP67ArgumentDigit (5);
		}

        public void RULE_DIGIT_SIX (Token token, Token [] tokens)
        {
            // <Digit> ::= Six
			token.UserObject = new HP67ArgumentDigit (6);
		}

        public void RULE_DIGIT_SEVEN (Token token, Token [] tokens)
        {
            // <Digit> ::= Seven
			token.UserObject = new HP67ArgumentDigit (7);
		}

        public void RULE_DIGIT_EIGHT (Token token, Token [] tokens)
        {
            // <Digit> ::= Eight
			token.UserObject = new HP67ArgumentDigit (8);
		}

        public void RULE_DIGIT_NINE (Token token, Token [] tokens)
        {
            // <Digit> ::= Nine
			token.UserObject = new HP67ArgumentDigit (9);
		}

        public void RULE_LETTER_A (Token token, Token [] tokens)
        {
            // <Letter> ::= A
			// TODO: Argument
		}

        public void RULE_LETTER_B (Token token, Token [] tokens)
        {
            // <Letter> ::= B
			// TODO: Argument
		}

        public void RULE_LETTER_C (Token token, Token [] tokens)
        {
            // <Letter> ::= C
			// TODO: Argument
		}

        public void RULE_LETTER_D (Token token, Token [] tokens)
        {
            // <Letter> ::= D
			// TODO: Argument
		}

        public void RULE_LETTER_E (Token token, Token [] tokens)
        {
            // <Letter> ::= E
			// TODO: Argument
		}

        public void RULE_LETTER_LABEL (Token token, Token [] tokens)
        {
            // <Letter_Label> ::= <Letter>
        }

        public void RULE_DIGIT_LABEL (Token token, Token [] tokens)
        {
            // <Digit_Label> ::= <Digit>
        }

        public void RULE_LABEL (Token token, Token [] tokens)
        {
            // <Label> ::= <Digit_Label>
        }

        public void RULE_LABEL2 (Token token, Token [] tokens)
        {
            // <Label> ::= <Letter_Label>
        }

        public void RULE_OPERABLE_MEMORY (Token token, Token [] tokens)
        {
            // <Operable_Memory> ::= <Digit>
        }

        public void RULE_OPERABLE_MEMORY_SUB_I (Token token, Token [] tokens)
        {
            // <Operable_Memory> ::= 'Sub_I'
			// TODO: Argument
		}

        public void RULE_MEMORY (Token token, Token [] tokens)
        {
            // <Memory> ::= <Operable_Memory>
        }

        public void RULE_MEMORY2 (Token token, Token [] tokens)
        {
            // <Memory> ::= <Letter>
        }

		#endregion

    }

}
