
using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Parser;
using System;
using System.Diagnostics;
using System.IO;

namespace Mockingbird.HP.HP67
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
		
		public void ReduceRULE_A_A67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <A> ::= 'A67'
		}

		public void ReduceRULE_A_A97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <A> ::= 'A97'
		}

		public void ReduceRULE_ABS_H67_SIX67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Abs> ::= 'h67' 'Six67'
		}

		public void ReduceRULE_ABS_F97_Y_TO_THE_XTH97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Abs> ::= 'f97' 'Y_To_The_Xth97'
		}

		public void ReduceRULE_ADDITION_ADDITION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Addition> ::= 'Addition67'
		}

		public void ReduceRULE_ADDITION_ADDITION97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Addition> ::= 'Addition97'
		}

		public void ReduceRULE_ARCCOS_G67_FIVE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Arccos> ::= 'g67' 'Five67'
		}

		public void ReduceRULE_ARCCOS_F97_COS97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Arccos> ::= 'f97' 'Cos97'
		}

		public void ReduceRULE_ARCSIN_G67_FOUR67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Arcsin> ::= 'g67' 'Four67'
		}

		public void ReduceRULE_ARCSIN_F97_SIN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Arcsin> ::= 'f97' 'Sin97'
		}

		public void ReduceRULE_ARCTAN_G67_SIX67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Arctan> ::= 'g67' 'Six67'
		}

		public void ReduceRULE_ARCTAN_F97_TAN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Arctan> ::= 'f97' 'Tan97'
		}

		public void ReduceRULE_B_B67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <B> ::= 'B67'
		}

		public void ReduceRULE_B_B97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <B> ::= 'B97'
		}

		public void ReduceRULE_BST_H67_SST67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Bst> ::= 'h67' 'Sst67'
		}

		public void ReduceRULE_BST_BST97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Bst> ::= 'Bst97'
		}

		public void ReduceRULE_C_C67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <C> ::= 'C67'
		}

		public void ReduceRULE_C_C97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <C> ::= 'C97'
		}

		public void ReduceRULE_CF_H67_ADDITION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <CF> ::= 'h67' 'Addition67'
		}

		public void ReduceRULE_CF_F97_GTO97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <CF> ::= 'f97' 'Gto97'
		}

		public void ReduceRULE_CHS_CHS67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Chs> ::= 'Chs67'
		}

		public void ReduceRULE_CHS_CHS97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Chs> ::= 'Chs97'
		}

		public void ReduceRULE_CL_PRGM_F67_CLX67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Cl_Prgm> ::= 'f67' 'Clx67'
		}

		public void ReduceRULE_CL_PRGM_F97_THREE97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Cl_Prgm> ::= 'f97' 'Three97'
		}

		public void ReduceRULE_CL_REG_F67_EEX67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Cl_Reg> ::= 'f67' 'Eex67'
		}

		public void ReduceRULE_CL_REG_F97_TWO97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Cl_Reg> ::= 'f97' 'Two97'
		}

		public void ReduceRULE_CLX_CLX67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Clx> ::= 'Clx67'
		}

		public void ReduceRULE_CLX_CLX97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Clx> ::= 'Clx97'
		}

		public void ReduceRULE_COS_F67_FIVE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Cos> ::= 'f67' 'Five67'
		}

		public void ReduceRULE_COS_COS97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Cos> ::= 'Cos97'
		}

		public void ReduceRULE_D_D67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <D> ::= 'D67'
		}

		public void ReduceRULE_D_D97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <D> ::= 'D97'
		}

		public void ReduceRULE_DEG_H67_ENTER67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Deg> ::= 'h67' 'Enter67'
		}

		public void ReduceRULE_DEG_F97_ENTER97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Deg> ::= 'f97' 'Enter97'
		}

		public void ReduceRULE_DEL_H67_CLX67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Del> ::= 'h67' 'Clx67'
		}

		public void ReduceRULE_DEL_F97_ONE97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Del> ::= 'f97' 'One97'
		}

		public void ReduceRULE_DISPLAY_X_F67_R_S67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Display_X> ::= 'f67' 'R_S67'
		}

		public void ReduceRULE_DISPLAY_X_DISPLAY_X97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Display_X> ::= 'Display_X97'
		}

		public void ReduceRULE_DIVISION_DIVISION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Division> ::= 'Division67'
		}

		public void ReduceRULE_DIVISION_DIVISION97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Division> ::= 'Division97'
		}

		public void ReduceRULE_DSP_DSP67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Dsp> ::= 'Dsp67'
		}

		public void ReduceRULE_DSP_DSP97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Dsp> ::= 'Dsp97'
		}

		public void ReduceRULE_DSZ_SUB_I_G67_STO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Dsz_Sub_I> ::= 'g67' 'Sto67'
		}

		public void ReduceRULE_DSZ_SUB_I_F97_BST97_SUB_I97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Dsz_Sub_I> ::= 'f97' 'Bst97' 'Sub_I97'
		}

		public void ReduceRULE_DSZ_F67_STO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Dsz> ::= 'f67' 'Sto67'
		}

		public void ReduceRULE_DSZ_F97_BST97_I97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Dsz> ::= 'f97' 'Bst97' 'I97'
		}

		public void ReduceRULE_E_E67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <E> ::= 'E67'
		}

		public void ReduceRULE_E_E97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <E> ::= 'E97'
		}

		public void ReduceRULE_EEX_EEX67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Eex> ::= 'Eex67'
		}

		public void ReduceRULE_EEX_EEX97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Eex> ::= 'Eex97'
		}

		public void ReduceRULE_EIGHT_EIGHT67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Eight> ::= 'Eight67'
		}

		public void ReduceRULE_EIGHT_EIGHT97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Eight> ::= 'Eight97'
		}

		public void ReduceRULE_ENG_H67_DSP67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Eng> ::= 'h67' 'Dsp67'
		}

		public void ReduceRULE_ENG_ENG97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Eng> ::= 'Eng97'
		}

		public void ReduceRULE_ENTER_ENTER67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Enter> ::= 'Enter67'
		}

		public void ReduceRULE_ENTER_ENTER97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Enter> ::= 'Enter97'
		}

		public void ReduceRULE_EXP_G67_SEVEN67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Exp> ::= 'g67' 'Seven67'
		}

		public void ReduceRULE_EXP_EXP97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Exp> ::= 'Exp97'
		}

		public void ReduceRULE_F_F67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <f> ::= 'f67'
		}

		public void ReduceRULE_F_F97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <f> ::= 'f97'
		}

		public void ReduceRULE_F_TEST_H67_MULTIPLICATION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <F_Test> ::= 'h67' 'Multiplication67'
		}

		public void ReduceRULE_F_TEST_F97_GSB97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <F_Test> ::= 'f97' 'Gsb97'
		}

		public void ReduceRULE_FACTORIAL_H67_DIVISION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Factorial> ::= 'h67' 'Division67'
		}

		public void ReduceRULE_FACTORIAL_F97_RECIPROCAL97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Factorial> ::= 'f97' 'Reciprocal97'
		}

		public void ReduceRULE_FIVE_FIVE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Five> ::= 'Five67'
		}

		public void ReduceRULE_FIVE_FIVE97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Five> ::= 'Five97'
		}

		public void ReduceRULE_FIX_F67_DSP67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Fix> ::= 'f67' 'Dsp67'
		}

		public void ReduceRULE_FIX_FIX97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Fix> ::= 'Fix97'
		}

		public void ReduceRULE_FOUR_FOUR67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Four> ::= 'Four67'
		}

		public void ReduceRULE_FOUR_FOUR97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Four> ::= 'Four97'
		}

		public void ReduceRULE_FRAC_G67_PERIOD67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Frac> ::= 'g67' 'Period67'
		}

		public void ReduceRULE_FRAC_F97_TO_RECTANGULAR97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Frac> ::= 'f97' 'To_Rectangular97'
		}

		public void ReduceRULE_GRD_H67_EEX67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Grd> ::= 'h67' 'Eex67'
		}

		public void ReduceRULE_GRD_F97_EEX97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Grd> ::= 'f97' 'Eex97'
		}

		public void ReduceRULE_GSB_LC_67_G67_GTO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Gsb_LC_67> ::= 'g67' 'Gto67'
		}

		public void ReduceRULE_GSB_F67_GTO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Gsb> ::= 'f67' 'Gto67'
		}

		public void ReduceRULE_GSB_GSB97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Gsb> ::= 'Gsb97'
		}

		public void ReduceRULE_GTO_GTO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Gto> ::= 'Gto67'
		}

		public void ReduceRULE_GTO_GTO97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Gto> ::= 'Gto97'
		}

		public void ReduceRULE_HMS_PLUS_H67_PERIOD67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <HMS_Plus> ::= 'h67' 'Period67'
		}

		public void ReduceRULE_HMS_PLUS_F97_ADDITION97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <HMS_Plus> ::= 'f97' 'Addition97'
		}

		public void ReduceRULE_INT_F67_PERIOD67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Int> ::= 'f67' 'Period67'
		}

		public void ReduceRULE_INT_F97_TO_POLAR97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Int> ::= 'f97' 'To_Polar97'
		}

		public void ReduceRULE_ISZ_SUB_I_G67_RCL67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Isz_Sub_I> ::= 'g67' 'Rcl67'
		}

		public void ReduceRULE_ISZ_SUB_I_F97_SST97_SUB_I97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Isz_Sub_I> ::= 'f97' 'Sst97' 'Sub_I97'
		}

		public void ReduceRULE_ISZ_F67_RCL67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Isz> ::= 'f67' 'Rcl67'
		}

		public void ReduceRULE_ISZ_F97_SST97_I97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Isz> ::= 'f97' 'Sst97' 'I97'
		}

		public void ReduceRULE_LBL_LC_67_G67_SST67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Lbl_LC_67> ::= 'g67' 'Sst67'
		}

		public void ReduceRULE_LBL_F67_SST67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Lbl> ::= 'f67' 'Sst67'
		}

		public void ReduceRULE_LBL_LBL97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Lbl> ::= 'Lbl97'
		}

		public void ReduceRULE_LN_F67_SEVEN67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Ln> ::= 'f67' 'Seven67'
		}

		public void ReduceRULE_LN_LN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Ln> ::= 'Ln97'
		}

		public void ReduceRULE_LOG_F67_EIGHT67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Log> ::= 'f67' 'Eight67'
		}

		public void ReduceRULE_LOG_F97_LN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Log> ::= 'f97' 'Ln97'
		}

		public void ReduceRULE_LST_X_H67_ZERO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Lst_X> ::= 'h67' 'Zero67'
		}

		public void ReduceRULE_LST_X_F97_DSP97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Lst_X> ::= 'f97' 'Dsp97'
		}

		public void ReduceRULE_MERGE_G67_ENTER67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Merge> ::= 'g67' 'Enter67'
		}

		public void ReduceRULE_MERGE_F97_PERIOD97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Merge> ::= 'f97' 'Period97'
		}

		public void ReduceRULE_MULTIPLICATION_MULTIPLICATION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Multiplication> ::= 'Multiplication67'
		}

		public void ReduceRULE_MULTIPLICATION_MULTIPLICATION97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Multiplication> ::= 'Multiplication97'
		}

		public void ReduceRULE_NINE_NINE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nine> ::= 'Nine67'
		}

		public void ReduceRULE_NINE_NINE97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nine> ::= 'Nine97'
		}

		public void ReduceRULE_ONE_ONE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <One> ::= 'One67'
		}

		public void ReduceRULE_ONE_ONE97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <One> ::= 'One97'
		}

		public void ReduceRULE_P_EXCHANGE_S_F67_CHS67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <P_Exchange_S> ::= 'f67' 'Chs67'
		}

		public void ReduceRULE_P_EXCHANGE_S_F97_CLX97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <P_Exchange_S> ::= 'f97' 'Clx97'
		}

		public void ReduceRULE_PAUSE_H67_ONE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Pause> ::= 'h67' 'One67'
		}

		public void ReduceRULE_PAUSE_F97_R_S97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Pause> ::= 'f97' 'R_S97'
		}

		public void ReduceRULE_PERCENT_CHANGE_G67_ZERO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Percent_Change> ::= 'g67' 'Zero67'
		}

		public void ReduceRULE_PERCENT_CHANGE_F97_PERCENT97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Percent_Change> ::= 'f97' 'Percent97'
		}

		public void ReduceRULE_PERCENT_F67_ZERO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Percent> ::= 'f67' 'Zero67'
		}

		public void ReduceRULE_PERCENT_PERCENT97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Percent> ::= 'Percent97'
		}

		public void ReduceRULE_PERIOD_PERIOD67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Period> ::= 'Period67'
		}

		public void ReduceRULE_PERIOD_PERIOD97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Period> ::= 'Period97'
		}

		public void ReduceRULE_PI_H67_TWO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Pi> ::= 'h67' 'Two67'
		}

		public void ReduceRULE_PI_F97_DIVISION97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Pi> ::= 'f97' 'Division97'
		}

		public void ReduceRULE_PRINT_PRGM_F97_SCI97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Print_Prgm> ::= 'f97' 'Sci97'
		}

		public void ReduceRULE_R_DOWN_H67_EIGHT67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <R_Down> ::= 'h67' 'Eight67'
		}

		public void ReduceRULE_R_DOWN_R_DOWN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <R_Down> ::= 'R_Down97'
		}

		public void ReduceRULE_R_S_R_S67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <R_S> ::= 'R_S67'
		}

		public void ReduceRULE_R_S_R_S97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <R_S> ::= 'R_S97'
		}

		public void ReduceRULE_R_UP_H67_NINE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <R_Up> ::= 'h67' 'Nine67'
		}

		public void ReduceRULE_R_UP_F97_R_DOWN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <R_Up> ::= 'f97' 'R_Down97'
		}

		public void ReduceRULE_RAD_H67_CHS67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rad> ::= 'h67' 'Chs67'
		}

		public void ReduceRULE_RAD_F97_CHS97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rad> ::= 'f97' 'Chs97'
		}

		public void ReduceRULE_RC_I_H67_RCL67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rc_I> ::= 'h67' 'Rcl67'
		}

		public void ReduceRULE_RC_I_RCL97_I97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rc_I> ::= 'Rcl97' 'I97'
		}

		public void ReduceRULE_RCL_RCL67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rcl> ::= 'Rcl67'
		}

		public void ReduceRULE_RCL_RCL97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rcl> ::= 'Rcl97'
		}

		public void ReduceRULE_RECIPROCAL_H67_FOUR67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Reciprocal> ::= 'h67' 'Four67'
		}

		public void ReduceRULE_RECIPROCAL_RECIPROCAL97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Reciprocal> ::= 'Reciprocal97'
		}

		public void ReduceRULE_REG_H67_THREE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Reg> ::= 'h67' 'Three67'
		}

		public void ReduceRULE_REG_F97_ENG97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Reg> ::= 'f97' 'Eng97'
		}

		public void ReduceRULE_RND_F67_SUB_I67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rnd> ::= 'f67' 'Sub_I67'
		}

		public void ReduceRULE_RND_F97_RTN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rnd> ::= 'f97' 'Rtn97'
		}

		public void ReduceRULE_RTN_H67_GTO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rtn> ::= 'h67' 'Gto67'
		}

		public void ReduceRULE_RTN_RTN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rtn> ::= 'Rtn97'
		}

		public void ReduceRULE_S_G67_SIGMA_PLUS67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <S> ::= 'g67' 'Sigma_Plus67'
		}

		public void ReduceRULE_S_F97_SQRT97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <S> ::= 'f97' 'Sqrt97'
		}

		public void ReduceRULE_SCI_G67_DSP67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sci> ::= 'g67' 'Dsp67'
		}

		public void ReduceRULE_SCI_SCI97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sci> ::= 'Sci97'
		}

		public void ReduceRULE_SEVEN_SEVEN67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Seven> ::= 'Seven67'
		}

		public void ReduceRULE_SEVEN_SEVEN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Seven> ::= 'Seven97'
		}

		public void ReduceRULE_SF_H67_SUBTRACTION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <SF> ::= 'h67' 'Subtraction67'
		}

		public void ReduceRULE_SF_F97_LBL97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <SF> ::= 'f97' 'Lbl97'
		}

		public void ReduceRULE_SIGMA_MINUS_H67_SIGMA_PLUS67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sigma_Minus> ::= 'h67' 'Sigma_Plus67'
		}

		public void ReduceRULE_SIGMA_MINUS_F97_SIGMA_PLUS97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sigma_Minus> ::= 'f97' 'Sigma_Plus97'
		}

		public void ReduceRULE_SIGMA_PLUS_SIGMA_PLUS67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sigma_Plus> ::= 'Sigma_Plus67'
		}

		public void ReduceRULE_SIGMA_PLUS_SIGMA_PLUS97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sigma_Plus> ::= 'Sigma_Plus97'
		}

		public void ReduceRULE_SIN_F67_FOUR67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sin> ::= 'f67' 'Four67'
		}

		public void ReduceRULE_SIN_SIN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sin> ::= 'Sin97'
		}

		public void ReduceRULE_SIX_SIX67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Six> ::= 'Six67'
		}

		public void ReduceRULE_SIX_SIX97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Six> ::= 'Six97'
		}

		public void ReduceRULE_SPACE_H67_R_S67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Space> ::= 'h67' 'R_S67'
		}

		public void ReduceRULE_SPACE_F97_FIX97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Space> ::= 'f97' 'Fix97'
		}

		public void ReduceRULE_SQRT_F67_NINE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sqrt> ::= 'f67' 'Nine67'
		}

		public void ReduceRULE_SQRT_SQRT97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sqrt> ::= 'Sqrt97'
		}

		public void ReduceRULE_SQUARE_G67_NINE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Square> ::= 'g67' 'Nine67'
		}

		public void ReduceRULE_SQUARE_SQUARE97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Square> ::= 'Square97'
		}

		public void ReduceRULE_SST_SST67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sst> ::= 'Sst67'
		}

		public void ReduceRULE_SST_SST97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sst> ::= 'Sst97'
		}

		public void ReduceRULE_ST_I_H67_STO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <St_I> ::= 'h67' 'Sto67'
		}

		public void ReduceRULE_ST_I_STO97_I97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <St_I> ::= 'Sto97' 'I97'
		}

		public void ReduceRULE_STK_G67_R_S67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Stk> ::= 'g67' 'R_S67'
		}

		public void ReduceRULE_STK_F97_DISPLAY_X97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Stk> ::= 'f97' 'Display_X97'
		}

		public void ReduceRULE_STO_STO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sto> ::= 'Sto67'
		}

		public void ReduceRULE_STO_STO97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sto> ::= 'Sto97'
		}

		public void ReduceRULE_SUB_I_SUB_I67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sub_I> ::= 'Sub_I67'
		}

		public void ReduceRULE_SUB_I_SUB_I97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Sub_I> ::= 'Sub_I97'
		}

		public void ReduceRULE_SUBTRACTION_SUBTRACTION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Subtraction> ::= 'Subtraction67'
		}

		public void ReduceRULE_SUBTRACTION_SUBTRACTION97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Subtraction> ::= 'Subtraction97'
		}

		public void ReduceRULE_TAN_F67_SIX67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Tan> ::= 'f67' 'Six67'
		}

		public void ReduceRULE_TAN_TAN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Tan> ::= 'Tan97'
		}

		public void ReduceRULE_TEN_TO_THE_XTH_G67_EIGHT67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Ten_To_The_Xth> ::= 'g67' 'Eight67'
		}

		public void ReduceRULE_TEN_TO_THE_XTH_F97_EXP97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Ten_To_The_Xth> ::= 'f97' 'Exp97'
		}

		public void ReduceRULE_THREE_THREE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Three> ::= 'Three67'
		}

		public void ReduceRULE_THREE_THREE97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Three> ::= 'Three97'
		}

		public void ReduceRULE_TO_DEGREES_F67_TWO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_Degrees> ::= 'f67' 'Two67'
		}

		public void ReduceRULE_TO_DEGREES_F97_I97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_Degrees> ::= 'f97' 'I97'
		}

		public void ReduceRULE_TO_HMS_G67_THREE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_HMS> ::= 'g67' 'Three67'
		}

		public void ReduceRULE_TO_HMS_F97_STO97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_HMS> ::= 'f97' 'Sto97'
		}

		public void ReduceRULE_TO_HOURS_F67_THREE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_Hours> ::= 'f67' 'Three67'
		}

		public void ReduceRULE_TO_HOURS_F97_RCL97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_Hours> ::= 'f97' 'Rcl97'
		}

		public void ReduceRULE_TO_POLAR_G67_ONE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_Polar> ::= 'g67' 'One67'
		}

		public void ReduceRULE_TO_POLAR_TO_POLAR97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_Polar> ::= 'To_Polar97'
		}

		public void ReduceRULE_TO_RADIANS_G67_TWO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_Radians> ::= 'g67' 'Two67'
		}

		public void ReduceRULE_TO_RADIANS_F97_SUB_I97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_Radians> ::= 'f97' 'Sub_I97'
		}

		public void ReduceRULE_TO_RECTANGULAR_F67_ONE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_Rectangular> ::= 'f67' 'One67'
		}

		public void ReduceRULE_TO_RECTANGULAR_TO_RECTANGULAR97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <To_Rectangular> ::= 'To_Rectangular97'
		}

		public void ReduceRULE_TWO_TWO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Two> ::= 'Two67'
		}

		public void ReduceRULE_TWO_TWO97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Two> ::= 'Two97'
		}

		public void ReduceRULE_W_DATA_F67_ENTER67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <W_Data> ::= 'f67' 'Enter67'
		}

		public void ReduceRULE_W_DATA_F97_ZERO97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <W_Data> ::= 'f97' 'Zero97'
		}

		public void ReduceRULE_X_AVERAGE_F67_SIGMA_PLUS67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_Average> ::= 'f67' 'Sigma_Plus67'
		}

		public void ReduceRULE_X_AVERAGE_F97_SQUARE97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_Average> ::= 'f97' 'Square97'
		}

		public void ReduceRULE_X_EQ_0_F67_SUBTRACTION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_EQ_0> ::= 'f67' 'Subtraction67'
		}

		public void ReduceRULE_X_EQ_0_F97_FIVE97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_EQ_0> ::= 'f97' 'Five97'
		}

		public void ReduceRULE_X_EQ_Y_G67_SUBTRACTION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_EQ_Y> ::= 'g67' 'Subtraction67'
		}

		public void ReduceRULE_X_EQ_Y_F97_EIGHT97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_EQ_Y> ::= 'f97' 'Eight97'
		}

		public void ReduceRULE_X_EXCHANGE_I_H67_SUB_I67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_Exchange_I> ::= 'h67' 'Sub_I67'
		}

		public void ReduceRULE_X_EXCHANGE_I_F97_X_EXCHANGE_Y97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_Exchange_I> ::= 'f97' 'X_Exchange_Y97'
		}

		public void ReduceRULE_X_EXCHANGE_Y_H67_SEVEN67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_Exchange_Y> ::= 'h67' 'Seven67'
		}

		public void ReduceRULE_X_EXCHANGE_Y_X_EXCHANGE_Y97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_Exchange_Y> ::= 'X_Exchange_Y97'
		}

		public void ReduceRULE_X_GT_0_F67_DIVISION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_GT_0> ::= 'f67' 'Division67'
		}

		public void ReduceRULE_X_GT_0_F97_SIX97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_GT_0> ::= 'f97' 'Six97'
		}

		public void ReduceRULE_X_GT_Y_G67_DIVISION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_GT_Y> ::= 'g67' 'Division67'
		}

		public void ReduceRULE_X_GT_Y_F97_NINE97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_GT_Y> ::= 'f97' 'Nine97'
		}

		public void ReduceRULE_X_LE_Y_G67_MULTIPLICATION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_LE_Y> ::= 'g67' 'Multiplication67'
		}

		public void ReduceRULE_X_LE_Y_F97_MULTIPLICATION97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_LE_Y> ::= 'f97' 'Multiplication97'
		}

		public void ReduceRULE_X_LT_0_F67_MULTIPLICATION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_LT_0> ::= 'f67' 'Multiplication67'
		}

		public void ReduceRULE_X_LT_0_F97_SUBTRACTION97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_LT_0> ::= 'f97' 'Subtraction97'
		}

		public void ReduceRULE_X_NE_0_F67_ADDITION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_NE_0> ::= 'f67' 'Addition67'
		}

		public void ReduceRULE_X_NE_0_F97_FOUR97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_NE_0> ::= 'f97' 'Four97'
		}

		public void ReduceRULE_X_NE_Y_G67_ADDITION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_NE_Y> ::= 'g67' 'Addition67'
		}

		public void ReduceRULE_X_NE_Y_F97_SEVEN97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <X_NE_Y> ::= 'f97' 'Seven97'
		}

		public void ReduceRULE_Y_TO_THE_XTH_H67_FIVE67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Y_To_The_Xth> ::= 'h67' 'Five67'
		}

		public void ReduceRULE_Y_TO_THE_XTH_Y_TO_THE_XTH97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Y_To_The_Xth> ::= 'Y_To_The_Xth97'
		}

		public void ReduceRULE_ZERO_ZERO67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Zero> ::= 'Zero67'
		}

		public void ReduceRULE_ZERO_ZERO97 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Zero> ::= 'Zero97'
		}

		public void ReduceRULE_INSTRUCTION (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Instruction> ::= <Nullary_Instruction>
		}

		public void ReduceRULE_INSTRUCTION2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Instruction> ::= <Unary_Instruction>
		}

		public void ReduceRULE_INSTRUCTION3 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Instruction> ::= <Binary_Instruction>
		}

		public void ReduceRULE_INSTRUCTION4 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Instruction> ::= <Ternary_Instruction>
		}

		public void ReduceRULE_GSB_LC_SHORTCUT (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Gsb_LC_Shortcut> ::= <Lowercase_Letter_Label>
		}

		public void ReduceRULE_GSB_UC_SHORTCUT (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Gsb_UC_Shortcut> ::= <Uppercase_Letter_Label>
		}

		public void ReduceRULE_RCL_SUB_I_SHORTCUT (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rcl_Sub_I_Shortcut> ::= <Sub_I>
		}

		public void ReduceRULE_NULLARY_INSTRUCTION (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Abs>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Addition>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION3 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Arccos>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION4 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Arcsin>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION5 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Arctan>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION6 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Bst>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION7 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Chs>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION8 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Cl_Prgm>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION9 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Cl_Reg>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION10 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Clx>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION11 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Cos>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION12 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Deg>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION13 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Del>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION14 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Digit>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION15 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Display_X>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION16 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Division>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION17 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Dsz_Sub_I>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION18 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Dsz>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION19 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Eex>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION20 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Eng>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION21 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Enter>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION22 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Exp>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION23 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Factorial>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION24 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Fix>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION25 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Frac>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION26 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Grd>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION27 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <HMS_Plus>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION28 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Int>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION29 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Isz_Sub_I>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION30 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Isz>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION31 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Ln>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION32 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Log>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION33 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Lst_X>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION34 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Merge>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION35 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Multiplication>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION36 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <P_Exchange_S>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION37 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Pause>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION38 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Percent_Change>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION39 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Percent>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION40 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Period>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION41 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Pi>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION42 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Print_Prgm>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION43 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <R_Down>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION44 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <R_S>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION45 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <R_Up>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION46 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Rad>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION47 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Rc_I>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION48 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Rcl_Sigma_Plus>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION49 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Rcl_Sub_I_Shortcut>
			engine.Process
				(new Instruction
				(reader,
				reader.ToSymbol (SymbolConstants.SYMBOL_RCL),
				new Argument [] {(Argument) tokens [0].UserObject}),
				motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION50 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Reciprocal>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION51 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Reg>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION52 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Rnd>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION53 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Rtn>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION54 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <S>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION55 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Sci>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION56 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Sigma_Minus>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION57 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Sigma_Plus>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION58 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Sin>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION59 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Space>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION60 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Sqrt>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION61 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Square>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION62 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Sst>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION63 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <St_I>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION64 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Stk>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION65 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Subtraction>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION66 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Tan>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION67 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Ten_To_The_Xth>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION68 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <To_Degrees>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION69 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <To_HMS>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION70 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <To_Hours>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION71 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <To_Polar>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION72 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <To_Radians>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION73 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <To_Rectangular>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION74 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <W_Data>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION75 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <X_Average>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION76 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <X_EQ_0>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION77 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <X_EQ_Y>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION78 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <X_Exchange_I>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION79 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <X_Exchange_Y>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION80 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <X_GT_0>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION81 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <X_GT_Y>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION82 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <X_LE_Y>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION83 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <X_LT_0>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION84 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <X_NE_0>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION85 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <X_NE_Y>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_NULLARY_INSTRUCTION86 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Nullary_Instruction> ::= <Y_To_The_Xth>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <CF> <Flag>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <Dsp> <Digit_Count>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION3 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <F_Test> <Flag>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION4 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <Gsb> <Label>
			if (reader.Model == CalculatorModel.HP67 &&
				tokens [1].UserObject is Letter &&
				((Letter) tokens [1].UserObject).IsLower) 
			{
				// The grammar allows sequences like GSB f A which are illegal on the HP-67.  Detect
				// this case and stop parsing.
				Token errorToken = tokens [1];
				while (errorToken is NonterminalToken) 
				{
					errorToken = ((NonterminalToken) errorToken).Tokens [0];
				}
				throw new SyntaxError ((TerminalToken) errorToken);
			}
			else 
			{
				engine.Process (new Instruction (reader, tokens), motion);
			}
		}

		public void ReduceRULE_UNARY_INSTRUCTION5 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <Gsb_LC_67> <Uppercase_Letter_Label>
			((Letter) tokens [1].UserObject).ToLower ();
			engine.Process (
				new Instruction (
					reader,
					reader.ToSymbol (SymbolConstants.SYMBOL_GSB),
					new Argument [] {(Argument) tokens [1].UserObject}),
					motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION6 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <Gsb_LC_Shortcut>
			((Letter) tokens [0].UserObject).ToLower ();
			engine.Process
				(new Instruction
					(reader,
					reader.ToSymbol (SymbolConstants.SYMBOL_GSB),
					new Argument [] {(Argument) tokens [0].UserObject}),
					motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION7 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <Gsb_UC_Shortcut>
			bool programIsEmpty = ((Program) state).IsEmpty;

			// When the program memory is empty, the keys A to E have a different function, both
			// in RUN mode and in W/PRGM mode.  Perform the substitution here.
			if (programIsEmpty) 
			{
				Letter letter = (Letter) tokens [0].UserObject;
				Symbol symbol = null;

				switch (letter.Value) 
				{
					case 'A' :
						symbol = reader.ToSymbol (SymbolConstants.SYMBOL_RECIPROCAL);
						break;
					case 'B' :
						symbol = reader.ToSymbol (SymbolConstants.SYMBOL_SQRT);
						break;
					case 'C' :
						symbol = reader.ToSymbol (SymbolConstants.SYMBOL_Y_TO_THE_XTH);
						break;
					case 'D' :
						symbol = reader.ToSymbol (SymbolConstants.SYMBOL_R_DOWN);
						break;
					case 'E' :
						symbol = reader.ToSymbol (SymbolConstants.SYMBOL_X_EXCHANGE_Y);
						break;
					default :
						Trace.Assert (false);
						break;
				}
				engine.Process (new Instruction (reader, symbol, new Argument [0]), motion);
			}
			else 
			{
				engine.Process
					(new Instruction
					(reader,
					reader.ToSymbol (SymbolConstants.SYMBOL_GSB),
					new Argument [] {(Argument) tokens [0].UserObject}),
					motion);
			}
		}

		public void ReduceRULE_UNARY_INSTRUCTION8 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <Gto> <Label>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION9 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <Lbl> <Label>
			if (reader.Model == CalculatorModel.HP67 &&
				tokens [1].UserObject is Letter &&
				((Letter) tokens [1].UserObject).IsLower) 
			{
				// The grammar allows sequences like LBL f A which are illegal on the HP-67.  Detect
				// this case and stop parsing.
				Token errorToken = tokens [1];
				while (errorToken is NonterminalToken) 
				{
					errorToken = ((NonterminalToken) errorToken).Tokens [0];
				}
				throw new SyntaxError ((TerminalToken) errorToken);
			}
			else 
			{
				engine.Process (new Instruction (reader, tokens), motion);
			}
		}

		public void ReduceRULE_UNARY_INSTRUCTION10 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <Lbl_LC_67> <Uppercase_Letter_Label>
			((Letter) tokens [1].UserObject).ToLower ();
			engine.Process (
				new Instruction (
				reader,
				reader.ToSymbol (SymbolConstants.SYMBOL_LBL),
				new Argument [] {(Argument) tokens [1].UserObject}),
				motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION11 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <Rcl> <Memory>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION12 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <SF> <Flag>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_UNARY_INSTRUCTION13 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Unary_Instruction> ::= <Sto> <Memory>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_BINARY_INSTRUCTION (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Binary_Instruction> ::= <Sto> <Operator> <Operable_Memory>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_TERNARY_INSTRUCTION (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Ternary_Instruction> ::= <Gto_Period> <Digit> <Digit> <Digit>
			engine.Process (new Instruction (reader, tokens), motion);
		}

		public void ReduceRULE_RCL_SIGMA_PLUS (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Rcl_Sigma_Plus> ::= <Rcl> <Sigma_Plus>
		}

		public void ReduceRULE_GTO_PERIOD (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Gto_Period> ::= <Gto> <Period>
		}

		public void ReduceRULE_OPERATOR (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Operator> ::= <Subtraction>
			token.UserObject = new Operator (new Memory.Operator(Operator.Subtraction));
		}

		public void ReduceRULE_OPERATOR2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Operator> ::= <Addition>
			token.UserObject = new Operator (new Memory.Operator(Operator.Addition));
		}

		public void ReduceRULE_OPERATOR3 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Operator> ::= <Multiplication>
			token.UserObject = new Operator (new Memory.Operator(Operator.Multiplication));
		}

		public void ReduceRULE_OPERATOR4 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Operator> ::= <Division>
			token.UserObject = new Operator (new Memory.Operator(Operator.Division));
		}

		public void ReduceRULE_DIGIT (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit> ::= <Zero>
			token.UserObject = new Digit (0);
		}

		public void ReduceRULE_DIGIT2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit> ::= <One>
			token.UserObject = new Digit (1);
		}

		public void ReduceRULE_DIGIT3 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit> ::= <Two>
			token.UserObject = new Digit (2);
		}

		public void ReduceRULE_DIGIT4 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit> ::= <Three>
			token.UserObject = new Digit (3);
		}

		public void ReduceRULE_DIGIT5 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit> ::= <Four>
			token.UserObject = new Digit (4);
		}

		public void ReduceRULE_DIGIT6 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit> ::= <Five>
			token.UserObject = new Digit (5);
		}

		public void ReduceRULE_DIGIT7 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit> ::= <Six>
			token.UserObject = new Digit (6);
		}

		public void ReduceRULE_DIGIT8 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit> ::= <Seven>
			token.UserObject = new Digit (7);
		}

		public void ReduceRULE_DIGIT9 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit> ::= <Eight>
			token.UserObject = new Digit (8);
		}

		public void ReduceRULE_DIGIT10 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit> ::= <Nine>
			token.UserObject = new Digit (9);
		}

		public void ReduceRULE_DIGIT_COUNT (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit_Count> ::= <Digit>
		}

		public void ReduceRULE_DIGIT_COUNT2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit_Count> ::= <Sub_I>
			token.UserObject = new Indexed ();
		}

		public void ReduceRULE_FLAG (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Flag> ::= <Zero>
			token.UserObject = new Digit (0);
		}

		public void ReduceRULE_FLAG2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Flag> ::= <One>
			token.UserObject = new Digit (1);
		}

		public void ReduceRULE_FLAG3 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Flag> ::= <Two>
			token.UserObject = new Digit (2);
		}

		public void ReduceRULE_FLAG4 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Flag> ::= <Three>
			token.UserObject = new Digit (3);
		}

		public void ReduceRULE_UPPERCASE_LETTER (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Uppercase_Letter> ::= <A>
			token.UserObject = new Letter ('A');
		}

		public void ReduceRULE_UPPERCASE_LETTER2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Uppercase_Letter> ::= <B>
			token.UserObject = new Letter ('B');
		}

		public void ReduceRULE_UPPERCASE_LETTER3 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Uppercase_Letter> ::= <C>
			token.UserObject = new Letter ('C');
		}

		public void ReduceRULE_UPPERCASE_LETTER4 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Uppercase_Letter> ::= <D>
			token.UserObject = new Letter ('D');
		}

		public void ReduceRULE_UPPERCASE_LETTER5 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Uppercase_Letter> ::= <E>
			token.UserObject = new Letter ('E');
		}

		public void ReduceRULE_LC_A (Reader reader, Token token, Token [] tokens, object state)
		{
			// <LC_a> ::= <f> <A>
			token.UserObject = new Letter ('a');
		}

		public void ReduceRULE_LC_B (Reader reader, Token token, Token [] tokens, object state)
		{
			// <LC_b> ::= <f> <B>
			token.UserObject = new Letter ('b');
		}

		public void ReduceRULE_LC_C (Reader reader, Token token, Token [] tokens, object state)
		{
			// <LC_c> ::= <f> <C>
			token.UserObject = new Letter ('c');
		}

		public void ReduceRULE_LC_D (Reader reader, Token token, Token [] tokens, object state)
		{
			// <LC_d> ::= <f> <D>
			token.UserObject = new Letter ('d');
		}

		public void ReduceRULE_LC_E (Reader reader, Token token, Token [] tokens, object state)
		{
			// <LC_e> ::= <f> <E>			
			token.UserObject = new Letter ('e');
		}

		public void ReduceRULE_UPPERCASE_LETTER_LABEL (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Uppercase_Letter_Label> ::= <Uppercase_Letter>
		}

		public void ReduceRULE_LOWERCASE_LETTER_LABEL (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Lowercase_Letter_Label> ::= <LC_a>
		}

		public void ReduceRULE_LOWERCASE_LETTER_LABEL2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Lowercase_Letter_Label> ::= <LC_b>
		}

		public void ReduceRULE_LOWERCASE_LETTER_LABEL3 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Lowercase_Letter_Label> ::= <LC_c>
		}

		public void ReduceRULE_LOWERCASE_LETTER_LABEL4 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Lowercase_Letter_Label> ::= <LC_d>
		}

		public void ReduceRULE_LOWERCASE_LETTER_LABEL5 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Lowercase_Letter_Label> ::= <LC_e>
		}

		public void ReduceRULE_LETTER_LABEL (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Letter_Label> ::= <Lowercase_Letter_Label>
		}

		public void ReduceRULE_LETTER_LABEL2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Letter_Label> ::= <Uppercase_Letter_Label>
		}

		public void ReduceRULE_DIGIT_LABEL (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Digit_Label> ::= <Digit>
		}

		public void ReduceRULE_LABEL (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Label> ::= <Digit_Label>
		}

		public void ReduceRULE_LABEL2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Label> ::= <Letter_Label>
		}

		public void ReduceRULE_LABEL3 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Label> ::= <Sub_I>
			token.UserObject = new Indexed ();
		}

		public void ReduceRULE_OPERABLE_MEMORY (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Operable_Memory> ::= <Digit>
		}

		public void ReduceRULE_OPERABLE_MEMORY2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Operable_Memory> ::= <Sub_I>
			token.UserObject = new Indexed ();
		}

		public void ReduceRULE_MEMORY (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Memory> ::= <Operable_Memory>
		}

		public void ReduceRULE_MEMORY2 (Reader reader, Token token, Token [] tokens, object state)
		{
			// <Memory> ::= <Uppercase_Letter>
		}

		#endregion

	}

}
