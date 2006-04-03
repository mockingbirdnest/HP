
using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using HP67;
using HP67_Class_Library;
using HP67_Control_Library;
using HP_Parser;
using System;
using System.Diagnostics;
using System.IO;

namespace HP67
{

	public class Actions : IActions
	{

		#region Private Data

		private static TraceSwitch classTraceSwitch = 
			new TraceSwitch ("HP67_Parser.Actions", "Parser actions");

		private Engine engine;
		private KeystrokeMotion motion;

		private string remainingText;
		private bool retry = false;

		#endregion

		#region Constructors & Destructors

		public Actions (Engine engine, KeystrokeMotion motion) 
		{
			this.engine = engine;
			this.motion = motion;
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
		
		public void ReduceRULE_A_A67 (string input, Token token, Token [] tokens)
		{
			// <A> ::= 'A67'
		}

		public void ReduceRULE_A_A97 (string input, Token token, Token [] tokens)
		{
			// <A> ::= 'A97'
		}

		public void ReduceRULE_ABS_H67_SIX67 (string input, Token token, Token [] tokens)
		{
			// <Abs> ::= 'h67' 'Six67'
		}

		public void ReduceRULE_ABS_F97_Y_TO_THE_XTH97 (string input, Token token, Token [] tokens)
		{
			// <Abs> ::= 'f97' 'Y_To_The_Xth97'
		}

		public void ReduceRULE_ADDITION_ADDITION67 (string input, Token token, Token [] tokens)
		{
			// <Addition> ::= 'Addition67'
		}

		public void ReduceRULE_ADDITION_ADDITION97 (string input, Token token, Token [] tokens)
		{
			// <Addition> ::= 'Addition97'
		}

		public void ReduceRULE_ARCCOS_G67_FIVE67 (string input, Token token, Token [] tokens)
		{
			// <Arccos> ::= 'g67' 'Five67'
		}

		public void ReduceRULE_ARCCOS_F97_COS97 (string input, Token token, Token [] tokens)
		{
			// <Arccos> ::= 'f97' 'Cos97'
		}

		public void ReduceRULE_ARCSIN_G67_FOUR67 (string input, Token token, Token [] tokens)
		{
			// <Arcsin> ::= 'g67' 'Four67'
		}

		public void ReduceRULE_ARCSIN_F97_SIN97 (string input, Token token, Token [] tokens)
		{
			// <Arcsin> ::= 'f97' 'Sin97'
		}

		public void ReduceRULE_ARCTAN_G67_SIX67 (string input, Token token, Token [] tokens)
		{
			// <Arctan> ::= 'g67' 'Six67'
		}

		public void ReduceRULE_ARCTAN_F97_TAN97 (string input, Token token, Token [] tokens)
		{
			// <Arctan> ::= 'f97' 'Tan97'
		}

		public void ReduceRULE_B_B67 (string input, Token token, Token [] tokens)
		{
			// <B> ::= 'B67'
		}

		public void ReduceRULE_B_B97 (string input, Token token, Token [] tokens)
		{
			// <B> ::= 'B97'
		}

		public void ReduceRULE_BST_H67_SST67 (string input, Token token, Token [] tokens)
		{
			// <Bst> ::= 'h67' 'Sst67'
		}

		public void ReduceRULE_BST_BST97 (string input, Token token, Token [] tokens)
		{
			// <Bst> ::= 'Bst97'
		}

		public void ReduceRULE_C_C67 (string input, Token token, Token [] tokens)
		{
			// <C> ::= 'C67'
		}

		public void ReduceRULE_C_C97 (string input, Token token, Token [] tokens)
		{
			// <C> ::= 'C97'
		}

		public void ReduceRULE_CF_H67_ADDITION67 (string input, Token token, Token [] tokens)
		{
			// <CF> ::= 'h67' 'Addition67'
		}

		public void ReduceRULE_CF_F97_GTO97 (string input, Token token, Token [] tokens)
		{
			// <CF> ::= 'f97' 'Gto97'
		}

		public void ReduceRULE_CHS_CHS67 (string input, Token token, Token [] tokens)
		{
			// <Chs> ::= 'Chs67'
		}

		public void ReduceRULE_CHS_CHS97 (string input, Token token, Token [] tokens)
		{
			// <Chs> ::= 'Chs97'
		}

		public void ReduceRULE_CL_PRGM_F67_CLX67 (string input, Token token, Token [] tokens)
		{
			// <Cl_Prgm> ::= 'f67' 'Clx67'
		}

		public void ReduceRULE_CL_PRGM_F97_THREE97 (string input, Token token, Token [] tokens)
		{
			// <Cl_Prgm> ::= 'f97' 'Three97'
		}

		public void ReduceRULE_CL_REG_F67_EEX67 (string input, Token token, Token [] tokens)
		{
			// <Cl_Reg> ::= 'f67' 'Eex67'
		}

		public void ReduceRULE_CL_REG_F97_TWO97 (string input, Token token, Token [] tokens)
		{
			// <Cl_Reg> ::= 'f97' 'Two97'
		}

		public void ReduceRULE_CLX_CLX67 (string input, Token token, Token [] tokens)
		{
			// <Clx> ::= 'Clx67'
		}

		public void ReduceRULE_CLX_CLX97 (string input, Token token, Token [] tokens)
		{
			// <Clx> ::= 'Clx97'
		}

		public void ReduceRULE_COS_F67_FIVE67 (string input, Token token, Token [] tokens)
		{
			// <Cos> ::= 'f67' 'Five67'
		}

		public void ReduceRULE_COS_COS97 (string input, Token token, Token [] tokens)
		{
			// <Cos> ::= 'Cos97'
		}

		public void ReduceRULE_D_D67 (string input, Token token, Token [] tokens)
		{
			// <D> ::= 'D67'
		}

		public void ReduceRULE_D_D97 (string input, Token token, Token [] tokens)
		{
			// <D> ::= 'D97'
		}

		public void ReduceRULE_DEG_H67_ENTER67 (string input, Token token, Token [] tokens)
		{
			// <Deg> ::= 'h67' 'Enter67'
		}

		public void ReduceRULE_DEG_F97_ENTER97 (string input, Token token, Token [] tokens)
		{
			// <Deg> ::= 'f97' 'Enter97'
		}

		public void ReduceRULE_DEL_H67_CLX67 (string input, Token token, Token [] tokens)
		{
			// <Del> ::= 'h67' 'Clx67'
		}

		public void ReduceRULE_DEL_F97_ONE97 (string input, Token token, Token [] tokens)
		{
			// <Del> ::= 'f97' 'One97'
		}

		public void ReduceRULE_DISPLAY_X_F67_R_S67 (string input, Token token, Token [] tokens)
		{
			// <Display_X> ::= 'f67' 'R_S67'
		}

		public void ReduceRULE_DISPLAY_X_DISPLAY_X97 (string input, Token token, Token [] tokens)
		{
			// <Display_X> ::= 'Display_X97'
		}

		public void ReduceRULE_DIVISION_DIVISION67 (string input, Token token, Token [] tokens)
		{
			// <Division> ::= 'Division67'
		}

		public void ReduceRULE_DIVISION_DIVISION97 (string input, Token token, Token [] tokens)
		{
			// <Division> ::= 'Division97'
		}

		public void ReduceRULE_DSP_DSP67 (string input, Token token, Token [] tokens)
		{
			// <Dsp> ::= 'Dsp67'
		}

		public void ReduceRULE_DSP_DSP97 (string input, Token token, Token [] tokens)
		{
			// <Dsp> ::= 'Dsp97'
		}

		public void ReduceRULE_DSZ_SUB_I_G67_STO67 (string input, Token token, Token [] tokens)
		{
			// <Dsz_Sub_I> ::= 'g67' 'Sto67'
		}

		public void ReduceRULE_DSZ_SUB_I_F97_BST97_SUB_I97 (string input, Token token, Token [] tokens)
		{
			// <Dsz_Sub_I> ::= 'f97' 'Bst97' 'Sub_I97'
		}

		public void ReduceRULE_DSZ_F67_STO67 (string input, Token token, Token [] tokens)
		{
			// <Dsz> ::= 'f67' 'Sto67'
		}

		public void ReduceRULE_DSZ_F97_BST97_I97 (string input, Token token, Token [] tokens)
		{
			// <Dsz> ::= 'f97' 'Bst97' 'I97'
		}

		public void ReduceRULE_E_E67 (string input, Token token, Token [] tokens)
		{
			// <E> ::= 'E67'
		}

		public void ReduceRULE_E_E97 (string input, Token token, Token [] tokens)
		{
			// <E> ::= 'E97'
		}

		public void ReduceRULE_EEX_EEX67 (string input, Token token, Token [] tokens)
		{
			// <Eex> ::= 'Eex67'
		}

		public void ReduceRULE_EEX_EEX97 (string input, Token token, Token [] tokens)
		{
			// <Eex> ::= 'Eex97'
		}

		public void ReduceRULE_EIGHT_EIGHT67 (string input, Token token, Token [] tokens)
		{
			// <Eight> ::= 'Eight67'
		}

		public void ReduceRULE_EIGHT_EIGHT97 (string input, Token token, Token [] tokens)
		{
			// <Eight> ::= 'Eight97'
		}

		public void ReduceRULE_ENG_H67_DSP67 (string input, Token token, Token [] tokens)
		{
			// <Eng> ::= 'h67' 'Dsp67'
		}

		public void ReduceRULE_ENG_ENG97 (string input, Token token, Token [] tokens)
		{
			// <Eng> ::= 'Eng97'
		}

		public void ReduceRULE_ENTER_ENTER67 (string input, Token token, Token [] tokens)
		{
			// <Enter> ::= 'Enter67'
		}

		public void ReduceRULE_ENTER_ENTER97 (string input, Token token, Token [] tokens)
		{
			// <Enter> ::= 'Enter97'
		}

		public void ReduceRULE_EXP_G67_SEVEN67 (string input, Token token, Token [] tokens)
		{
			// <Exp> ::= 'g67' 'Seven67'
		}

		public void ReduceRULE_EXP_EXP97 (string input, Token token, Token [] tokens)
		{
			// <Exp> ::= 'Exp97'
		}

		public void ReduceRULE_F_F67 (string input, Token token, Token [] tokens)
		{
			// <f> ::= 'f67'
		}

		public void ReduceRULE_F_F97 (string input, Token token, Token [] tokens)
		{
			// <f> ::= 'f97'
		}

		public void ReduceRULE_F_TEST_H67_MULTIPLICATION67 (string input, Token token, Token [] tokens)
		{
			// <F_Test> ::= 'h67' 'Multiplication67'
		}

		public void ReduceRULE_F_TEST_F97_GSB97 (string input, Token token, Token [] tokens)
		{
			// <F_Test> ::= 'f97' 'Gsb97'
		}

		public void ReduceRULE_FACTORIAL_H67_DIVISION67 (string input, Token token, Token [] tokens)
		{
			// <Factorial> ::= 'h67' 'Division67'
		}

		public void ReduceRULE_FACTORIAL_F97_RECIPROCAL97 (string input, Token token, Token [] tokens)
		{
			// <Factorial> ::= 'f97' 'Reciprocal97'
		}

		public void ReduceRULE_FIVE_FIVE67 (string input, Token token, Token [] tokens)
		{
			// <Five> ::= 'Five67'
		}

		public void ReduceRULE_FIVE_FIVE97 (string input, Token token, Token [] tokens)
		{
			// <Five> ::= 'Five97'
		}

		public void ReduceRULE_FIX_F67_DSP67 (string input, Token token, Token [] tokens)
		{
			// <Fix> ::= 'f67' 'Dsp67'
		}

		public void ReduceRULE_FIX_FIX97 (string input, Token token, Token [] tokens)
		{
			// <Fix> ::= 'Fix97'
		}

		public void ReduceRULE_FOUR_FOUR67 (string input, Token token, Token [] tokens)
		{
			// <Four> ::= 'Four67'
		}

		public void ReduceRULE_FOUR_FOUR97 (string input, Token token, Token [] tokens)
		{
			// <Four> ::= 'Four97'
		}

		public void ReduceRULE_FRAC_G67_PERIOD67 (string input, Token token, Token [] tokens)
		{
			// <Frac> ::= 'g67' 'Period67'
		}

		public void ReduceRULE_FRAC_F97_TO_RECTANGULAR97 (string input, Token token, Token [] tokens)
		{
			// <Frac> ::= 'f97' 'To_Rectangular97'
		}

		public void ReduceRULE_GRD_H67_EEX67 (string input, Token token, Token [] tokens)
		{
			// <Grd> ::= 'h67' 'Eex67'
		}

		public void ReduceRULE_GRD_F97_EEX97 (string input, Token token, Token [] tokens)
		{
			// <Grd> ::= 'f97' 'Eex97'
		}

		public void ReduceRULE_GSB_F_G67_GTO67 (string input, Token token, Token [] tokens)
		{
			// <Gsb_f> ::= 'g67' 'Gto67'
		}

		public void ReduceRULE_GSB_F67_GTO67 (string input, Token token, Token [] tokens)
		{
			// <Gsb> ::= 'f67' 'Gto67'
		}

		public void ReduceRULE_GSB_GSB97 (string input, Token token, Token [] tokens)
		{
			// <Gsb> ::= 'Gsb97'
		}

		public void ReduceRULE_GTO_GTO67 (string input, Token token, Token [] tokens)
		{
			// <Gto> ::= 'Gto67'
		}

		public void ReduceRULE_GTO_GTO97 (string input, Token token, Token [] tokens)
		{
			// <Gto> ::= 'Gto97'
		}

		public void ReduceRULE_HMS_PLUS_H67_PERIOD67 (string input, Token token, Token [] tokens)
		{
			// <HMS_Plus> ::= 'h67' 'Period67'
		}

		public void ReduceRULE_HMS_PLUS_F97_ADDITION97 (string input, Token token, Token [] tokens)
		{
			// <HMS_Plus> ::= 'f97' 'Addition97'
		}

		public void ReduceRULE_INT_F67_PERIOD67 (string input, Token token, Token [] tokens)
		{
			// <Int> ::= 'f67' 'Period67'
		}

		public void ReduceRULE_INT_F97_TO_POLAR97 (string input, Token token, Token [] tokens)
		{
			// <Int> ::= 'f97' 'To_Polar97'
		}

		public void ReduceRULE_ISZ_SUB_I_G67_RCL67 (string input, Token token, Token [] tokens)
		{
			// <Isz_Sub_I> ::= 'g67' 'Rcl67'
		}

		public void ReduceRULE_ISZ_SUB_I_F97_SST97_SUB_I97 (string input, Token token, Token [] tokens)
		{
			// <Isz_Sub_I> ::= 'f97' 'Sst97' 'Sub_I97'
		}

		public void ReduceRULE_ISZ_F67_RCL67 (string input, Token token, Token [] tokens)
		{
			// <Isz> ::= 'f67' 'Rcl67'
		}

		public void ReduceRULE_ISZ_F97_SST97_I97 (string input, Token token, Token [] tokens)
		{
			// <Isz> ::= 'f97' 'Sst97' 'I97'
		}

		public void ReduceRULE_LBL_F_G67_SST67 (string input, Token token, Token [] tokens)
		{
			// <Lbl_f> ::= 'g67' 'Sst67'
		}

		public void ReduceRULE_LBL_F67_SST67 (string input, Token token, Token [] tokens)
		{
			// <Lbl> ::= 'f67' 'Sst67'
		}

		public void ReduceRULE_LBL_LBL97 (string input, Token token, Token [] tokens)
		{
			// <Lbl> ::= 'Lbl97'
		}

		public void ReduceRULE_LN_F67_SEVEN67 (string input, Token token, Token [] tokens)
		{
			// <Ln> ::= 'f67' 'Seven67'
		}

		public void ReduceRULE_LN_LN97 (string input, Token token, Token [] tokens)
		{
			// <Ln> ::= 'Ln97'
		}

		public void ReduceRULE_LOG_F67_EIGHT67 (string input, Token token, Token [] tokens)
		{
			// <Log> ::= 'f67' 'Eight67'
		}

		public void ReduceRULE_LOG_F97_LN97 (string input, Token token, Token [] tokens)
		{
			// <Log> ::= 'f97' 'Ln97'
		}

		public void ReduceRULE_LST_X_H67_ZERO67 (string input, Token token, Token [] tokens)
		{
			// <Lst_X> ::= 'h67' 'Zero67'
		}

		public void ReduceRULE_LST_X_F97_DSP97 (string input, Token token, Token [] tokens)
		{
			// <Lst_X> ::= 'f97' 'Dsp97'
		}

		public void ReduceRULE_MERGE_G67_ENTER67 (string input, Token token, Token [] tokens)
		{
			// <Merge> ::= 'g67' 'Enter67'
		}

		public void ReduceRULE_MERGE_F97_PERIOD97 (string input, Token token, Token [] tokens)
		{
			// <Merge> ::= 'f97' 'Period97'
		}

		public void ReduceRULE_MULTIPLICATION_MULTIPLICATION67 (string input, Token token, Token [] tokens)
		{
			// <Multiplication> ::= 'Multiplication67'
		}

		public void ReduceRULE_MULTIPLICATION_MULTIPLICATION97 (string input, Token token, Token [] tokens)
		{
			// <Multiplication> ::= 'Multiplication97'
		}

		public void ReduceRULE_NINE_NINE67 (string input, Token token, Token [] tokens)
		{
			// <Nine> ::= 'Nine67'
		}

		public void ReduceRULE_NINE_NINE97 (string input, Token token, Token [] tokens)
		{
			// <Nine> ::= 'Nine97'
		}

		public void ReduceRULE_ONE_ONE67 (string input, Token token, Token [] tokens)
		{
			// <One> ::= 'One67'
		}

		public void ReduceRULE_ONE_ONE97 (string input, Token token, Token [] tokens)
		{
			// <One> ::= 'One97'
		}

		public void ReduceRULE_P_EXCHANGE_S_F67_CHS67 (string input, Token token, Token [] tokens)
		{
			// <P_Exchange_S> ::= 'f67' 'Chs67'
		}

		public void ReduceRULE_P_EXCHANGE_S_F97_CLX97 (string input, Token token, Token [] tokens)
		{
			// <P_Exchange_S> ::= 'f97' 'Clx97'
		}

		public void ReduceRULE_PAUSE_H67_ONE67 (string input, Token token, Token [] tokens)
		{
			// <Pause> ::= 'h67' 'One67'
		}

		public void ReduceRULE_PAUSE_F97_R_S97 (string input, Token token, Token [] tokens)
		{
			// <Pause> ::= 'f97' 'R_S97'
		}

		public void ReduceRULE_PERCENT_CHANGE_G67_ZERO67 (string input, Token token, Token [] tokens)
		{
			// <Percent_Change> ::= 'g67' 'Zero67'
		}

		public void ReduceRULE_PERCENT_CHANGE_F97_PERCENT97 (string input, Token token, Token [] tokens)
		{
			// <Percent_Change> ::= 'f97' 'Percent97'
		}

		public void ReduceRULE_PERCENT_F67_ZERO67 (string input, Token token, Token [] tokens)
		{
			// <Percent> ::= 'f67' 'Zero67'
		}

		public void ReduceRULE_PERCENT_PERCENT97 (string input, Token token, Token [] tokens)
		{
			// <Percent> ::= 'Percent97'
		}

		public void ReduceRULE_PERIOD_PERIOD67 (string input, Token token, Token [] tokens)
		{
			// <Period> ::= 'Period67'
		}

		public void ReduceRULE_PERIOD_PERIOD97 (string input, Token token, Token [] tokens)
		{
			// <Period> ::= 'Period97'
		}

		public void ReduceRULE_PI_H67_TWO67 (string input, Token token, Token [] tokens)
		{
			// <Pi> ::= 'h67' 'Two67'
		}

		public void ReduceRULE_PI_F97_DIVISION97 (string input, Token token, Token [] tokens)
		{
			// <Pi> ::= 'f97' 'Division97'
		}

		public void ReduceRULE_PRINT_PRGM_F97_SCI97 (string input, Token token, Token [] tokens)
		{
			// <Print_Prgm> ::= 'f97' 'Sci97'
		}

		public void ReduceRULE_R_DOWN_H67_EIGHT67 (string input, Token token, Token [] tokens)
		{
			// <R_Down> ::= 'h67' 'Eight67'
		}

		public void ReduceRULE_R_DOWN_R_DOWN97 (string input, Token token, Token [] tokens)
		{
			// <R_Down> ::= 'R_Down97'
		}

		public void ReduceRULE_R_S_R_S67 (string input, Token token, Token [] tokens)
		{
			// <R_S> ::= 'R_S67'
		}

		public void ReduceRULE_R_S_R_S97 (string input, Token token, Token [] tokens)
		{
			// <R_S> ::= 'R_S97'
		}

		public void ReduceRULE_R_UP_H67_NINE67 (string input, Token token, Token [] tokens)
		{
			// <R_Up> ::= 'h67' 'Nine67'
		}

		public void ReduceRULE_R_UP_F97_R_DOWN97 (string input, Token token, Token [] tokens)
		{
			// <R_Up> ::= 'f97' 'R_Down97'
		}

		public void ReduceRULE_RAD_H67_CHS67 (string input, Token token, Token [] tokens)
		{
			// <Rad> ::= 'h67' 'Chs67'
		}

		public void ReduceRULE_RAD_F97_CHS97 (string input, Token token, Token [] tokens)
		{
			// <Rad> ::= 'f97' 'Chs97'
		}

		public void ReduceRULE_RC_I_H67_RCL67 (string input, Token token, Token [] tokens)
		{
			// <Rc_I> ::= 'h67' 'Rcl67'
		}

		public void ReduceRULE_RC_I_RCL97_I97 (string input, Token token, Token [] tokens)
		{
			// <Rc_I> ::= 'Rcl97' 'I97'
		}

		public void ReduceRULE_RCL_RCL67 (string input, Token token, Token [] tokens)
		{
			// <Rcl> ::= 'Rcl67'
		}

		public void ReduceRULE_RCL_RCL97 (string input, Token token, Token [] tokens)
		{
			// <Rcl> ::= 'Rcl97'
		}

		public void ReduceRULE_RECIPROCAL_H67_FOUR67 (string input, Token token, Token [] tokens)
		{
			// <Reciprocal> ::= 'h67' 'Four67'
		}

		public void ReduceRULE_RECIPROCAL_RECIPROCAL97 (string input, Token token, Token [] tokens)
		{
			// <Reciprocal> ::= 'Reciprocal97'
		}

		public void ReduceRULE_REG_H67_THREE67 (string input, Token token, Token [] tokens)
		{
			// <Reg> ::= 'h67' 'Three67'
		}

		public void ReduceRULE_REG_F97_ENG97 (string input, Token token, Token [] tokens)
		{
			// <Reg> ::= 'f97' 'Eng97'
		}

		public void ReduceRULE_RND_F67_SUB_I67 (string input, Token token, Token [] tokens)
		{
			// <Rnd> ::= 'f67' 'Sub_I67'
		}

		public void ReduceRULE_RND_F97_RTN97 (string input, Token token, Token [] tokens)
		{
			// <Rnd> ::= 'f97' 'Rtn97'
		}

		public void ReduceRULE_RTN_H67_GTO67 (string input, Token token, Token [] tokens)
		{
			// <Rtn> ::= 'h67' 'Gto67'
		}

		public void ReduceRULE_RTN_RTN97 (string input, Token token, Token [] tokens)
		{
			// <Rtn> ::= 'Rtn97'
		}

		public void ReduceRULE_S_G67_SIGMA_PLUS67 (string input, Token token, Token [] tokens)
		{
			// <S> ::= 'g67' 'Sigma_Plus67'
		}

		public void ReduceRULE_S_F97_SQRT97 (string input, Token token, Token [] tokens)
		{
			// <S> ::= 'f97' 'Sqrt97'
		}

		public void ReduceRULE_SCI_G67_DSP67 (string input, Token token, Token [] tokens)
		{
			// <Sci> ::= 'g67' 'Dsp67'
		}

		public void ReduceRULE_SCI_SCI97 (string input, Token token, Token [] tokens)
		{
			// <Sci> ::= 'Sci97'
		}

		public void ReduceRULE_SEVEN_SEVEN67 (string input, Token token, Token [] tokens)
		{
			// <Seven> ::= 'Seven67'
		}

		public void ReduceRULE_SEVEN_SEVEN97 (string input, Token token, Token [] tokens)
		{
			// <Seven> ::= 'Seven97'
		}

		public void ReduceRULE_SF_H67_SUBTRACTION67 (string input, Token token, Token [] tokens)
		{
			// <SF> ::= 'h67' 'Subtraction67'
		}

		public void ReduceRULE_SF_F97_LBL97 (string input, Token token, Token [] tokens)
		{
			// <SF> ::= 'f97' 'Lbl97'
		}

		public void ReduceRULE_SIGMA_MINUS_H67_SIGMA_PLUS67 (string input, Token token, Token [] tokens)
		{
			// <Sigma_Minus> ::= 'h67' 'Sigma_Plus67'
		}

		public void ReduceRULE_SIGMA_MINUS_F97_SIGMA_PLUS97 (string input, Token token, Token [] tokens)
		{
			// <Sigma_Minus> ::= 'f97' 'Sigma_Plus97'
		}

		public void ReduceRULE_SIGMA_PLUS_SIGMA_PLUS67 (string input, Token token, Token [] tokens)
		{
			// <Sigma_Plus> ::= 'Sigma_Plus67'
		}

		public void ReduceRULE_SIGMA_PLUS_SIGMA_PLUS97 (string input, Token token, Token [] tokens)
		{
			// <Sigma_Plus> ::= 'Sigma_Plus97'
		}

		public void ReduceRULE_SIN_F67_FOUR67 (string input, Token token, Token [] tokens)
		{
			// <Sin> ::= 'f67' 'Four67'
		}

		public void ReduceRULE_SIN_SIN97 (string input, Token token, Token [] tokens)
		{
			// <Sin> ::= 'Sin97'
		}

		public void ReduceRULE_SIX_SIX67 (string input, Token token, Token [] tokens)
		{
			// <Six> ::= 'Six67'
		}

		public void ReduceRULE_SIX_SIX97 (string input, Token token, Token [] tokens)
		{
			// <Six> ::= 'Six97'
		}

		public void ReduceRULE_SPACE_H67_R_S67 (string input, Token token, Token [] tokens)
		{
			// <Space> ::= 'h67' 'R_S67'
		}

		public void ReduceRULE_SPACE_F97_FIX97 (string input, Token token, Token [] tokens)
		{
			// <Space> ::= 'f97' 'Fix97'
		}

		public void ReduceRULE_SQRT_F67_NINE67 (string input, Token token, Token [] tokens)
		{
			// <Sqrt> ::= 'f67' 'Nine67'
		}

		public void ReduceRULE_SQRT_SQRT97 (string input, Token token, Token [] tokens)
		{
			// <Sqrt> ::= 'Sqrt97'
		}

		public void ReduceRULE_SQUARE_G67_NINE67 (string input, Token token, Token [] tokens)
		{
			// <Square> ::= 'g67' 'Nine67'
		}

		public void ReduceRULE_SQUARE_SQUARE97 (string input, Token token, Token [] tokens)
		{
			// <Square> ::= 'Square97'
		}

		public void ReduceRULE_SST_SST67 (string input, Token token, Token [] tokens)
		{
			// <Sst> ::= 'Sst67'
		}

		public void ReduceRULE_SST_SST97 (string input, Token token, Token [] tokens)
		{
			// <Sst> ::= 'Sst97'
		}

		public void ReduceRULE_ST_I_H67_STO67 (string input, Token token, Token [] tokens)
		{
			// <St_I> ::= 'h67' 'Sto67'
		}

		public void ReduceRULE_ST_I_STO97_I97 (string input, Token token, Token [] tokens)
		{
			// <St_I> ::= 'Sto97' 'I97'
		}

		public void ReduceRULE_STK_G67_R_S67 (string input, Token token, Token [] tokens)
		{
			// <Stk> ::= 'g67' 'R_S67'
		}

		public void ReduceRULE_STK_F97_DIPLAY_X97 (string input, Token token, Token [] tokens)
		{
			// <Stk> ::= 'f97' 'Diplay_X97'
		}

		public void ReduceRULE_STO_STO67 (string input, Token token, Token [] tokens)
		{
			// <Sto> ::= 'Sto67'
		}

		public void ReduceRULE_STO_STO97 (string input, Token token, Token [] tokens)
		{
			// <Sto> ::= 'Sto97'
		}

		public void ReduceRULE_SUB_I_SUB_I67 (string input, Token token, Token [] tokens)
		{
			// <Sub_I> ::= 'Sub_I67'
		}

		public void ReduceRULE_SUB_I_SUB_I97 (string input, Token token, Token [] tokens)
		{
			// <Sub_I> ::= 'Sub_I97'
		}

		public void ReduceRULE_SUBTRACTION_SUBTRACTION67 (string input, Token token, Token [] tokens)
		{
			// <Subtraction> ::= 'Subtraction67'
		}

		public void ReduceRULE_SUBTRACTION_SUBTRACTION97 (string input, Token token, Token [] tokens)
		{
			// <Subtraction> ::= 'Subtraction97'
		}

		public void ReduceRULE_TAN_F67_SIX67 (string input, Token token, Token [] tokens)
		{
			// <Tan> ::= 'f67' 'Six67'
		}

		public void ReduceRULE_TAN_TAN97 (string input, Token token, Token [] tokens)
		{
			// <Tan> ::= 'Tan97'
		}

		public void ReduceRULE_TEN_TO_THE_XTH_G67_EIGHT67 (string input, Token token, Token [] tokens)
		{
			// <Ten_To_The_Xth> ::= 'g67' 'Eight67'
		}

		public void ReduceRULE_TEN_TO_THE_XTH_F97_EXP97 (string input, Token token, Token [] tokens)
		{
			// <Ten_To_The_Xth> ::= 'f97' 'Exp97'
		}

		public void ReduceRULE_THREE_THREE67 (string input, Token token, Token [] tokens)
		{
			// <Three> ::= 'Three67'
		}

		public void ReduceRULE_THREE_THREE97 (string input, Token token, Token [] tokens)
		{
			// <Three> ::= 'Three97'
		}

		public void ReduceRULE_TO_DEGREES_F67_TWO67 (string input, Token token, Token [] tokens)
		{
			// <To_Degrees> ::= 'f67' 'Two67'
		}

		public void ReduceRULE_TO_DEGREES_F97_I97 (string input, Token token, Token [] tokens)
		{
			// <To_Degrees> ::= 'f97' 'I97'
		}

		public void ReduceRULE_TO_HMS_G67_THREE67 (string input, Token token, Token [] tokens)
		{
			// <To_HMS> ::= 'g67' 'Three67'
		}

		public void ReduceRULE_TO_HMS_F97_STO97 (string input, Token token, Token [] tokens)
		{
			// <To_HMS> ::= 'f97' 'Sto97'
		}

		public void ReduceRULE_TO_HOURS_F67_THREE67 (string input, Token token, Token [] tokens)
		{
			// <To_Hours> ::= 'f67' 'Three67'
		}

		public void ReduceRULE_TO_HOURS_F97_RCL97 (string input, Token token, Token [] tokens)
		{
			// <To_Hours> ::= 'f97' 'Rcl97'
		}

		public void ReduceRULE_TO_POLAR_G67_ONE67 (string input, Token token, Token [] tokens)
		{
			// <To_Polar> ::= 'g67' 'One67'
		}

		public void ReduceRULE_TO_POLAR_TO_POLAR97 (string input, Token token, Token [] tokens)
		{
			// <To_Polar> ::= 'To_Polar97'
		}

		public void ReduceRULE_TO_RADIANS_G67_TWO67 (string input, Token token, Token [] tokens)
		{
			// <To_Radians> ::= 'g67' 'Two67'
		}

		public void ReduceRULE_TO_RADIANS_F97_SUB_I97 (string input, Token token, Token [] tokens)
		{
			// <To_Radians> ::= 'f97' 'Sub_I97'
		}

		public void ReduceRULE_TO_RECTANGULAR_F67_ONE67 (string input, Token token, Token [] tokens)
		{
			// <To_Rectangular> ::= 'f67' 'One67'
		}

		public void ReduceRULE_TO_RECTANGULAR_TO_RECTANGULAR97 (string input, Token token, Token [] tokens)
		{
			// <To_Rectangular> ::= 'To_Rectangular97'
		}

		public void ReduceRULE_TWO_TWO67 (string input, Token token, Token [] tokens)
		{
			// <Two> ::= 'Two67'
		}

		public void ReduceRULE_TWO_TWO97 (string input, Token token, Token [] tokens)
		{
			// <Two> ::= 'Two97'
		}

		public void ReduceRULE_W_DATA_F67_ENTER67 (string input, Token token, Token [] tokens)
		{
			// <W_Data> ::= 'f67' 'Enter67'
		}

		public void ReduceRULE_W_DATA_F97_ZERO97 (string input, Token token, Token [] tokens)
		{
			// <W_Data> ::= 'f97' 'Zero97'
		}

		public void ReduceRULE_X_AVERAGE_F67_SIGMA_PLUS67 (string input, Token token, Token [] tokens)
		{
			// <X_Average> ::= 'f67' 'Sigma_Plus67'
		}

		public void ReduceRULE_X_AVERAGE_F97_SQUARE97 (string input, Token token, Token [] tokens)
		{
			// <X_Average> ::= 'f97' 'Square97'
		}

		public void ReduceRULE_X_EQ_0_F67_SUBTRACTION67 (string input, Token token, Token [] tokens)
		{
			// <X_EQ_0> ::= 'f67' 'Subtraction67'
		}

		public void ReduceRULE_X_EQ_0_F97_FIVE97 (string input, Token token, Token [] tokens)
		{
			// <X_EQ_0> ::= 'f97' 'Five97'
		}

		public void ReduceRULE_X_EQ_Y_G67_SUBTRACTION67 (string input, Token token, Token [] tokens)
		{
			// <X_EQ_Y> ::= 'g67' 'Subtraction67'
		}

		public void ReduceRULE_X_EQ_Y_F97_EIGHT97 (string input, Token token, Token [] tokens)
		{
			// <X_EQ_Y> ::= 'f97' 'Eight97'
		}

		public void ReduceRULE_X_EXCHANGE_I_H67_SUB_I67 (string input, Token token, Token [] tokens)
		{
			// <X_Exchange_I> ::= 'h67' 'Sub_I67'
		}

		public void ReduceRULE_X_EXCHANGE_I_F97_X_EXCHANGE_Y97 (string input, Token token, Token [] tokens)
		{
			// <X_Exchange_I> ::= 'f97' 'X_Exchange_Y97'
		}

		public void ReduceRULE_X_EXCHANGE_Y_H67_SEVEN67 (string input, Token token, Token [] tokens)
		{
			// <X_Exchange_Y> ::= 'h67' 'Seven67'
		}

		public void ReduceRULE_X_EXCHANGE_Y_X_EXCHANGE_97 (string input, Token token, Token [] tokens)
		{
			// <X_Exchange_Y> ::= 'X_Exchange_97'
		}

		public void ReduceRULE_X_GT_0_F67_DIVISION67 (string input, Token token, Token [] tokens)
		{
			// <X_GT_0> ::= 'f67' 'Division67'
		}

		public void ReduceRULE_X_GT_0_F97_SIX97 (string input, Token token, Token [] tokens)
		{
			// <X_GT_0> ::= 'f97' 'Six97'
		}

		public void ReduceRULE_X_GT_Y_G67_DIVISION67 (string input, Token token, Token [] tokens)
		{
			// <X_GT_Y> ::= 'g67' 'Division67'
		}

		public void ReduceRULE_X_GT_Y_F97_NINE97 (string input, Token token, Token [] tokens)
		{
			// <X_GT_Y> ::= 'f97' 'Nine97'
		}

		public void ReduceRULE_X_LE_Y_G67_MULTIPLICATION67 (string input, Token token, Token [] tokens)
		{
			// <X_LE_Y> ::= 'g67' 'Multiplication67'
		}

		public void ReduceRULE_X_LE_Y_F97_MULTIPLICATION97 (string input, Token token, Token [] tokens)
		{
			// <X_LE_Y> ::= 'f97' 'Multiplication97'
		}

		public void ReduceRULE_X_LT_0_F67_MULTIPLICATION67 (string input, Token token, Token [] tokens)
		{
			// <X_LT_0> ::= 'f67' 'Multiplication67'
		}

		public void ReduceRULE_X_LT_0_F97_SUBTRACTION97 (string input, Token token, Token [] tokens)
		{
			// <X_LT_0> ::= 'f97' 'Subtraction97'
		}

		public void ReduceRULE_X_NE_0_F67_ADDITION67 (string input, Token token, Token [] tokens)
		{
			// <X_NE_0> ::= 'f67' 'Addition67'
		}

		public void ReduceRULE_X_NE_0_F97_FOUR97 (string input, Token token, Token [] tokens)
		{
			// <X_NE_0> ::= 'f97' 'Four97'
		}

		public void ReduceRULE_X_NE_Y_G67_ADDITION67 (string input, Token token, Token [] tokens)
		{
			// <X_NE_Y> ::= 'g67' 'Addition67'
		}

		public void ReduceRULE_X_NE_Y_F97_SEVEN97 (string input, Token token, Token [] tokens)
		{
			// <X_NE_Y> ::= 'f97' 'Seven97'
		}

		public void ReduceRULE_Y_TO_THE_XTH_H67_FIVE67 (string input, Token token, Token [] tokens)
		{
			// <Y_To_The_Xth> ::= 'h67' 'Five67'
		}

		public void ReduceRULE_Y_TO_THE_XTH_Y_TO_THE_XTH (string input, Token token, Token [] tokens)
		{
			// <Y_To_The_Xth> ::= 'Y_To_The_Xth'
		}

		public void ReduceRULE_ZERO_ZERO67 (string input, Token token, Token [] tokens)
		{
			// <Zero> ::= 'Zero67'
		}

		public void ReduceRULE_ZERO_ZERO97 (string input, Token token, Token [] tokens)
		{
			// <Zero> ::= 'Zero97'
		}

		public void ReduceRULE_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Instruction> ::= <Shortcut>
		}

		public void ReduceRULE_INSTRUCTION2 (string input, Token token, Token [] tokens)
		{
			// <Instruction> ::= <Nullary_Instruction>
		}

		public void ReduceRULE_INSTRUCTION3 (string input, Token token, Token [] tokens)
		{
			// <Instruction> ::= <Unary_Instruction>
		}

		public void ReduceRULE_INSTRUCTION4 (string input, Token token, Token [] tokens)
		{
			// <Instruction> ::= <Binary_Instruction>
		}

		public void ReduceRULE_INSTRUCTION5 (string input, Token token, Token [] tokens)
		{
			// <Instruction> ::= <Ternary_Instruction>
		}

		public void ReduceRULE_SHORTCUT (string input, Token token, Token [] tokens)
		{
			// <Shortcut> ::= <Gsb_Shortcut>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_SHORTCUT2 (string input, Token token, Token [] tokens)
		{
			// <Shortcut> ::= <Memory_Shortcut>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_GSB_SHORTCUT (string input, Token token, Token [] tokens)
		{
			// <Gsb_Shortcut> ::= <Letter_Label>
		}

		public void ReduceRULE_MEMORY_SHORTCUT (string input, Token token, Token [] tokens)
		{
			// <Memory_Shortcut> ::= <Sub_I>
		}

		public void ReduceRULE_NULLARY_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Abs>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION2 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Addition>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION3 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Arccos>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION4 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Arcsin>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION5 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Arctan>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION6 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Bst>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION7 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Chs>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION8 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Cl_Prgm>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION9 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Cl_Reg>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION10 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Clx>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION11 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Cos>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION12 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Deg>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION13 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Del>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION14 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Digit>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION15 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Display_X>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION16 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Division>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION17 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Dsz_Sub_I>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION18 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Dsz>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION19 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Eex>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION20 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Eng>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION21 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Enter>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION22 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Exp>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION23 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Factorial>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION24 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Fix>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION25 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Frac>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION26 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Grd>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION27 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <HMS_Plus>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION28 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Int>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION29 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Isz_Sub_I>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION30 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Isz>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION31 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Ln>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION32 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Log>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION33 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Lst_X>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION34 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Merge>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION35 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Multiplication>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION36 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <P_Exchange_S>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION37 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Pause>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION38 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Percent_Change>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION39 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Percent>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION40 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Period>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION41 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Pi>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION42 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Print_Prgm>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION43 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <R_Down>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION44 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <R_S>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION45 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <R_Up>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION46 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Rad>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION47 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Rc_I>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION48 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Rcl_Sigma_Plus>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION49 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Reciprocal>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION50 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Reg>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION51 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Rnd>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION52 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Rtn>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION53 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <S>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION54 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Sci>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION55 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Sigma_Minus>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION56 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Sigma_Plus>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION57 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Sin>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION58 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Space>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION59 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Sqrt>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION60 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Square>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION61 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Sst>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION62 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <St_I>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION63 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Stk>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION64 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Subtraction>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION65 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Tan>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION66 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Ten_To_The_Xth>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION67 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <To_Degrees>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION68 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <To_HMS>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION69 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <To_Hours>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION70 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <To_Polar>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION71 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <To_Radians>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION72 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <To_Rectangular>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION73 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <W_Data>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION74 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <X_Average>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION75 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <X_EQ_0>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION76 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <X_EQ_Y>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION77 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <X_Exchange_I>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION78 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <X_Exchange_Y>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION79 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <X_GT_0>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION80 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <X_GT_Y>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION81 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <X_LE_Y>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION82 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <X_LT_0>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION83 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <X_NE_0>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION84 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <X_NE_Y>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION85 (string input, Token token, Token [] tokens)
		{
			// <Nullary_Instruction> ::= <Y_To_The_Xth>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= <CF> <Flag>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION2 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= <Dsp> <Digit_Count>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION3 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= <F_Test> <Flag>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION4 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= <Gsb> <Non_Lowercase_Label>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION5 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= <Gsb_f> <Uppercase_Letter_Label>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION_GSB97 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= 'Gsb97' <Lowercase_Letter_Label>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION6 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= <Gto> <Label>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION7 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= <Lbl> <Non_Lowercase_Label>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION8 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= <Lbl_f> <Uppercase_Letter_Label>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION_LBL97 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= 'Lbl97' <Lowercase_Letter_Label>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION9 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= <Rcl> <Memory>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION10 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= <SF> <Flag>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION11 (string input, Token token, Token [] tokens)
		{
			// <Unary_Instruction> ::= <Sto> <Memory>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_BINARY_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Binary_Instruction> ::= <Sto> <Operator> <Operable_Memory>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_TERNARY_INSTRUCTION (string input, Token token, Token [] tokens)
		{
			// <Ternary_Instruction> ::= <Gto_Period> <Digit> <Digit> <Digit>
			engine.Process (new Instruction (input, tokens), motion);
		}

		public void ReduceRULE_RCL_SIGMA_PLUS (string input, Token token, Token [] tokens)
		{
			// <Rcl_Sigma_Plus> ::= <Rcl> <Sigma_Plus>
		}

		public void ReduceRULE_GTO_PERIOD (string input, Token token, Token [] tokens)
		{
			// <Gto_Period> ::= <Gto> <Period>
		}

		public void ReduceRULE_OPERATOR (string input, Token token, Token [] tokens)
		{
			// <Operator> ::= <Subtraction>
			token.UserObject = new Operator (new Memory.Operator(Operator.Subtraction));
		}

		public void ReduceRULE_OPERATOR2 (string input, Token token, Token [] tokens)
		{
			// <Operator> ::= <Addition>
			token.UserObject = new Operator (new Memory.Operator(Operator.Addition));
		}

		public void ReduceRULE_OPERATOR3 (string input, Token token, Token [] tokens)
		{
			// <Operator> ::= <Multiplication>
			token.UserObject = new Operator (new Memory.Operator(Operator.Multiplication));
		}

		public void ReduceRULE_OPERATOR4 (string input, Token token, Token [] tokens)
		{
			// <Operator> ::= <Division>
			token.UserObject = new Operator (new Memory.Operator(Operator.Division));
		}

		public void ReduceRULE_DIGIT (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= <Zero>
			token.UserObject = new Digit (0);
		}

		public void ReduceRULE_DIGIT2 (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= <One>
			token.UserObject = new Digit (1);
		}

		public void ReduceRULE_DIGIT3 (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= <Two>
			token.UserObject = new Digit (2);
		}

		public void ReduceRULE_DIGIT4 (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= <Three>
			token.UserObject = new Digit (3);
		}

		public void ReduceRULE_DIGIT5 (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= <Four>
			token.UserObject = new Digit (4);
		}

		public void ReduceRULE_DIGIT6 (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= <Five>
			token.UserObject = new Digit (5);
		}

		public void ReduceRULE_DIGIT7 (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= <Six>
			token.UserObject = new Digit (6);
		}

		public void ReduceRULE_DIGIT8 (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= <Seven>
			token.UserObject = new Digit (7);
		}

		public void ReduceRULE_DIGIT9 (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= <Eight>
			token.UserObject = new Digit (8);
		}

		public void ReduceRULE_DIGIT10 (string input, Token token, Token [] tokens)
		{
			// <Digit> ::= <Nine>
			token.UserObject = new Digit (9);
		}

		public void ReduceRULE_DIGIT_COUNT (string input, Token token, Token [] tokens)
		{
			// <Digit_Count> ::= <Digit>
		}

		public void ReduceRULE_DIGIT_COUNT2 (string input, Token token, Token [] tokens)
		{
			// <Digit_Count> ::= <Sub_I>
			token.UserObject = new Indexed ();
		}

		public void ReduceRULE_FLAG (string input, Token token, Token [] tokens)
		{
			// <Flag> ::= <Zero>
			token.UserObject = new Digit (0);
		}

		public void ReduceRULE_FLAG2 (string input, Token token, Token [] tokens)
		{
			// <Flag> ::= <One>
			token.UserObject = new Digit (1);
		}

		public void ReduceRULE_FLAG3 (string input, Token token, Token [] tokens)
		{
			// <Flag> ::= <Two>
			token.UserObject = new Digit (2);
		}

		public void ReduceRULE_FLAG4 (string input, Token token, Token [] tokens)
		{
			// <Flag> ::= <Three>
			token.UserObject = new Digit (3);
		}

		public void ReduceRULE_LETTER (string input, Token token, Token [] tokens)
		{
			// <Letter> ::= <A>
			token.UserObject = new Letter ('A');
		}

		public void ReduceRULE_LETTER2 (string input, Token token, Token [] tokens)
		{
			// <Letter> ::= <B>
			token.UserObject = new Letter ('B');
		}

		public void ReduceRULE_LETTER3 (string input, Token token, Token [] tokens)
		{
			// <Letter> ::= <C>
			token.UserObject = new Letter ('C');
		}

		public void ReduceRULE_LETTER4 (string input, Token token, Token [] tokens)
		{
			// <Letter> ::= <D>
			token.UserObject = new Letter ('D');
		}

		public void ReduceRULE_LETTER5 (string input, Token token, Token [] tokens)
		{
			// <Letter> ::= <E>
			token.UserObject = new Letter ('E');
		}

		public void ReduceRULE_UPPERCASE_LETTER_LABEL (string input, Token token, Token [] tokens)
		{
			// <Uppercase_Letter_Label> ::= <Letter>
		}

		public void ReduceRULE_LOWERCASE_LETTER_LABEL (string input, Token token, Token [] tokens)
		{
			// <Lowercase_Letter_Label> ::= <f> <Letter>
			token.UserObject = tokens [1].UserObject;
			((Letter) token.UserObject).ToLower ();
		}

		public void ReduceRULE_LETTER_LABEL (string input, Token token, Token [] tokens)
		{
			// <Letter_Label> ::= <Lowercase_Letter_Label>
		}

		public void ReduceRULE_LETTER_LABEL2 (string input, Token token, Token [] tokens)
		{
			// <Letter_Label> ::= <Uppercase_Letter_Label>
		}

		public void ReduceRULE_DIGIT_LABEL (string input, Token token, Token [] tokens)
		{
			// <Digit_Label> ::= <Digit>
		}

		public void ReduceRULE_NON_LOWERCASE_LABEL (string input, Token token, Token [] tokens)
		{
			// <Non_Lowercase_Label> ::= <Digit_Label>
		}

		public void ReduceRULE_NON_LOWERCASE_LABEL2 (string input, Token token, Token [] tokens)
		{
			// <Non_Lowercase_Label> ::= <Uppercase_Letter_Label>
		}

		public void ReduceRULE_NON_LOWERCASE_LABEL3 (string input, Token token, Token [] tokens)
		{
			// <Non_Lowercase_Label> ::= <Sub_I>
		}

		public void ReduceRULE_LABEL (string input, Token token, Token [] tokens)
		{
			// <Label> ::= <Digit_Label>
		}

		public void ReduceRULE_LABEL2 (string input, Token token, Token [] tokens)
		{
			// <Label> ::= <Letter_Label>
		}

		public void ReduceRULE_LABEL3 (string input, Token token, Token [] tokens)
		{
			// <Label> ::= <Sub_I>
			token.UserObject = new Indexed ();
		}

		public void ReduceRULE_OPERABLE_MEMORY (string input, Token token, Token [] tokens)
		{
			// <Operable_Memory> ::= <Digit>
		}

		public void ReduceRULE_OPERABLE_MEMORY2 (string input, Token token, Token [] tokens)
		{
			// <Operable_Memory> ::= <Sub_I>
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
