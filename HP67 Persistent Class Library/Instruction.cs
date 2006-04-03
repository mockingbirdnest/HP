﻿using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using HP_Parser;
using System;
using System.Diagnostics;
using System.Globalization;

namespace HP67_Class_Library
{
	/// <summary>
	/// An instruction in the program memory of the HP67 calculator.
	/// </summary>
	public class Instruction
	{

		private const string digitTemplate = "00";

		private Argument [] arguments;
		private Symbol instruction;
		private string text;

		public Instruction (string input, Symbol symbol, Argument [] args)
		{
			instruction = symbol;
			arguments = args;

			// Beware! This must occurs last, as it causes the text to be patched.  Logically we
			// should be able to assign to text here, but some old XML files have the digits
			// unnormalized.
			PrivateText = input;
		}

		public Instruction (string input, Token [] tokens)
		{
			if (tokens [0] is NonterminalToken) 
			{
				instruction = ((NonterminalToken) tokens [0]).Symbol;
			}
			else if (tokens [0] is TerminalToken)
			{
				instruction = ((TerminalToken) tokens [0]).Symbol;
			}
			else 
			{
				Trace.Assert (false);
				instruction = ((TerminalToken) tokens [0]).Symbol; // To make the compiler happy.
			}

			switch ((SymbolConstants) instruction.Id) {
				case SymbolConstants.SYMBOL_DIGIT :
				case SymbolConstants.SYMBOL_GSB_SHORTCUT :

					// Somewhat ugly.  There are a few instructions where the argument is borne by
					// the instruction symbol itself.  Pretend that it is a separate argument for
					// uniformity.
					arguments = new Argument [1] {(Argument) tokens [0].UserObject};
					break;
				default:
					arguments = new Argument [tokens.Length - 1];
					for (int i = 0; i < arguments.Length; i++) 
					{
						arguments [i] = (Argument) tokens [i + 1].UserObject;
					}
					break;
			}

			// Beware! This must occurs last, as it causes the text to be patched.
			PrivateText = input;
		}

		private string PrivateText
		{
			// We would really want to call this property Text, and to have the set accessor
			// private and the get accessor public.  But the silly language won't let us do that.
			// Sigh.  Hence the ugly name PrivateText: we keep the good name Text for the clients.
			set 
			{
				// If the last argument is a digit, it must be displayed as its numeric value,
				// and not using its key tag.  We do the patching here.  The operations which need
				// this must assign Text *after* they set the arguments.
				text = value.Trim ();
				if (arguments.Length > 0) 
				{
					if (arguments [arguments.Length - 1] is Digit) 
					{
						byte b = ((Digit) arguments [arguments.Length - 1]).Value;
						string bImage = b.ToString (digitTemplate, NumberFormatInfo.InvariantInfo);

						text = text.Substring (0, text.Length - bImage.Length) + bImage;
					}
				}
				//TODO: This is ugly and temporary and it will go away any day now.
				text = text.Replace ("67", "");
			}
		}

		public Argument [] Arguments
		{
			get
			{
				return arguments;
			}
		}

		public string PrintableText 
		{
			get
			{
				string result;

				switch ((SymbolConstants) Symbol.Id) 
				{
					case SymbolConstants.SYMBOL_ADDITION :
						result = "+";
						break;
					case SymbolConstants.SYMBOL_ARCCOS :
						result = "COS⁻¹";
						break;
					case SymbolConstants.SYMBOL_ARCSIN :
						result = "SIN⁻¹";
						break;
					case SymbolConstants.SYMBOL_ARCTAN :
						result = "TAN⁻¹";
						break;
					case SymbolConstants.SYMBOL_CLX :
						result = "CLx";
						break;
					case SymbolConstants.SYMBOL_DIGIT :
						result = "";
						break;
					case SymbolConstants.SYMBOL_DISPLAY_X :
						result = "—x—";
						break;
					case SymbolConstants.SYMBOL_DIVISION :
						result = "÷";
						break;
					case SymbolConstants.SYMBOL_EXP :
						result = "eˣ";
						break;
					case SymbolConstants.SYMBOL_F_TEST :
						result = "F?";
						break;
					case SymbolConstants.SYMBOL_FACTORIAL :
						result = "N!";
						break;
					case SymbolConstants.SYMBOL_GSB_F :
					case SymbolConstants.SYMBOL_GSB_SHORTCUT :
						result = "GSB";
						break;
					case SymbolConstants.SYMBOL_HMS_PLUS :
						result = "H.MS+";
						break;
					case SymbolConstants.SYMBOL_LBL_F :
						result = "LBL";
						break;
					case SymbolConstants.SYMBOL_LST_X :
						result = "LST x";
						break;
					case SymbolConstants.SYMBOL_MULTIPLICATION :
						result = "×";
						break;
					case SymbolConstants.SYMBOL_P_EXCHANGE_S :
						result = "P⇄S";
						break;
					case SymbolConstants.SYMBOL_PERCENT :
						result = "%";
						break;
					case SymbolConstants.SYMBOL_PERCENT_CHANGE :
						result = "%CH";
						break;
					case SymbolConstants.SYMBOL_PERIOD :
						result = "⋅";
						break;
					case SymbolConstants.SYMBOL_PI :
						result = "π";
						break;
					case SymbolConstants.SYMBOL_R_DOWN :
						result = "R↓";
						break;
					case SymbolConstants.SYMBOL_R_S :
						result = "R/S";
						break;
					case SymbolConstants.SYMBOL_R_UP :
						result = "R↑";
						break;
					case SymbolConstants.SYMBOL_RCL_SIGMA_PLUS :
						result = "RCL Σ+";
						break;
					case SymbolConstants.SYMBOL_RECIPROCAL :
						result = "1/x";
						break;
					case SymbolConstants.SYMBOL_S :
						result = "s";
						break;
					case SymbolConstants.SYMBOL_SIGMA_MINUS :
						result = "Σ-";
						break;
					case SymbolConstants.SYMBOL_SIGMA_PLUS :
						result = "Σ+";
						break;
					case SymbolConstants.SYMBOL_SQRT :
						result = "√̄̄̄̄x̄";
						break;
					case SymbolConstants.SYMBOL_SQUARE :
						result = "x²";
						break;
					case SymbolConstants.SYMBOL_SUBTRACTION :
						result = "-";
						break;
					case SymbolConstants.SYMBOL_TEN_TO_THE_XTH :
						result = "10ˣ";
						break;
					case SymbolConstants.SYMBOL_TO_DEGREES :
						result = "D←";
						break;
					case SymbolConstants.SYMBOL_TO_HMS :
						result = "→H.MS";
						break;
					case SymbolConstants.SYMBOL_TO_HOURS :
						result = "H←";
						break;
					case SymbolConstants.SYMBOL_TO_POLAR :
						result = "→P";
						break;
					case SymbolConstants.SYMBOL_TO_RADIANS :
						result = "→R";
						break;
					case SymbolConstants.SYMBOL_TO_RECTANGULAR :
						result = "R←";
						break;
					case SymbolConstants.SYMBOL_W_DATA :
						result = "W/DATA";
						break;
					case SymbolConstants.SYMBOL_X_AVERAGE :
						result = "x̄";
						break;
					case SymbolConstants.SYMBOL_X_EQ_0 :
						result = "x=0?";
						break;
					case SymbolConstants.SYMBOL_X_EQ_Y :
						result = "x=y?";
						break;
					case SymbolConstants.SYMBOL_X_EXCHANGE_I :
						result = "x⇄I";
						break;
					case SymbolConstants.SYMBOL_X_EXCHANGE_Y :
						result = "x⇄y";
						break;
					case SymbolConstants.SYMBOL_X_GT_0 :
						result = "x>0?";
						break;
					case SymbolConstants.SYMBOL_X_GT_Y :
						result = "x>y?";
						break;
					case SymbolConstants.SYMBOL_X_LE_Y :
						result = "x≤y?";
						break;
					case SymbolConstants.SYMBOL_X_LT_0 :
						result = "x<0?";
						break;
					case SymbolConstants.SYMBOL_X_NE_0 :
						result = "x≠0?";
						break;
					case SymbolConstants.SYMBOL_X_NE_Y :
						result = "x≠y?";
						break;
					case SymbolConstants.SYMBOL_Y_TO_THE_XTH :
						result = "yˣ";
						break;
					default:
						result = Symbol.Name.ToUpper ().Replace ('_', ' ');
						break;
				}
				for (int i = 0; i < arguments.Length; i++) 
				{
					result += " " + arguments [i].PrintableText;
				}
				return result;
			}
		}

		public Symbol Symbol
		{
			get
			{
				return instruction;
			}
		}

		public string Text
		{
			get 
			{
				return text;
			}
		}
	}
}
