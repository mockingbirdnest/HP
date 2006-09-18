using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using Mockingbird.HP.Parser;
using System;
using System.Diagnostics;

namespace Mockingbird.HP.Class_Library
{
	/// <summary>
	/// An instruction in the program memory of an HP calculator.
	/// </summary>
	public class Instruction
	{

		private Argument [] arguments;
		private Symbol instruction;
		private string text;

		public Instruction (Reader reader, Symbol symbol, Argument [] args)
		{
			instruction = symbol;
			arguments = args;
			SetText (reader);
		}

		public Instruction (Reader reader, Token [] tokens)
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

			switch ((SymbolConstants) instruction.Id) 
			{
				case SymbolConstants.SYMBOL_DIGIT :

					// Somewhat ugly.  For this instruction the argument is borne by the
					// instruction symbol itself.  Pretend that it is a separate argument for
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

			SetText (reader);
		}

		private void SetText (Reader reader)
		{
			bool isNonstandard = false;

			text = "";
			switch ((SymbolConstants) instruction.Id) {
				case SymbolConstants.SYMBOL_DIGIT :
					// The argument is the instruction.
					break;
				case SymbolConstants.SYMBOL_GSB :
				case SymbolConstants.SYMBOL_LBL :
					// On the HP-67, use a nonstandard syntax if the argument is lowercase.
					if (reader.Model == CalculatorModel.HP67 &&
						arguments [0] is Letter &&
						((Letter) arguments [0]).IsLower) 
					{
						isNonstandard = true;
						text = reader.Unparse (reader.ToSymbol (instruction.Name + "_LC_67"));
					}
					else 
					{
						text = reader.Unparse (instruction);
					}
					break;
				default :
					text = reader.Unparse (instruction);
					break;
			}
			foreach (Argument argument in arguments) 
			{
				if (text.Length > 0) 
				{
					text += " ";
				}
				if (isNonstandard) 
				{
					// In the nonstandard syntax, the argument is uppercase.
					Letter uppercaseArgument =
						new Letter (char.ToUpper (((Letter) argument).Value));
					text += uppercaseArgument.Unparse (reader);
				}
				else 
				{
					text += argument.Unparse (reader);
				}
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
					case SymbolConstants.SYMBOL_HMS_PLUS :
						result = "H.MS+";
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

        public string TraceableText
        {
            get
            {
                string result;

                switch ((SymbolConstants) Symbol.Id)
                {
                    case SymbolConstants.SYMBOL_ADDITION:
                        result = "+";
                        break;
                    case SymbolConstants.SYMBOL_ARCCOS:
                        result = "COS⁻¹";
                        break;
                    case SymbolConstants.SYMBOL_ARCSIN:
                        result = "SIN⁻¹";
                        break;
                    case SymbolConstants.SYMBOL_ARCTAN:
                        result = "TAN⁻¹";
                        break;
                    case SymbolConstants.SYMBOL_CL_REG:
                        result = "CLRG";
                        break;
                    case SymbolConstants.SYMBOL_CLX:
                        result = "CLX";
                        break;
                    case SymbolConstants.SYMBOL_DIGIT:
                        result = "";
                        break;
                    case SymbolConstants.SYMBOL_DISPLAY_X:
                        result = "PRTX";
                        break;
                    case SymbolConstants.SYMBOL_DIVISION:
                        result = "÷";
                        break;
                    case SymbolConstants.SYMBOL_ENTER:
                        result = "ENT↑";
                        break;
                    case SymbolConstants.SYMBOL_EXP:
                        result = "eˣ";
                        break;
                    case SymbolConstants.SYMBOL_F_TEST:
                        result = "F";
                        break;
                    case SymbolConstants.SYMBOL_FACTORIAL:
                        result = "N!";
                        break;
                    case SymbolConstants.SYMBOL_GRD:
                        result = "GRAD";
                        break;
                    case SymbolConstants.SYMBOL_HMS_PLUS:
                        result = "HMS+";
                        break;
                    case SymbolConstants.SYMBOL_LBL:
                        result = "*LBL";
                        break;
                    case SymbolConstants.SYMBOL_LST_X:
                        result = "LSTX";
                        break;
                    case SymbolConstants.SYMBOL_MERGE:
                        result = "MRG";
                        break;
                    case SymbolConstants.SYMBOL_MULTIPLICATION:
                        result = "×";
                        break;
                    case SymbolConstants.SYMBOL_P_EXCHANGE_S:
                        result = "P⇄S";
                        break;
                    case SymbolConstants.SYMBOL_PAUSE:
                        result = "PSE";
                        break;
                    case SymbolConstants.SYMBOL_PERCENT:
                        result = "%";
                        break;
                    case SymbolConstants.SYMBOL_PERCENT_CHANGE:
                        result = "%CH";
                        break;
                    case SymbolConstants.SYMBOL_PERIOD:
                        result = "⋅";
                        break;
                    case SymbolConstants.SYMBOL_PI:
                        result = "Pi";
                        break;
                    case SymbolConstants.SYMBOL_R_DOWN:
                        result = "R↓";
                        break;
                    case SymbolConstants.SYMBOL_R_S:
                        result = "R/S";
                        break;
                    case SymbolConstants.SYMBOL_R_UP:
                        result = "R↑";
                        break;
                    case SymbolConstants.SYMBOL_RC_I:
                        result = "RCLI";
                        break;
                    case SymbolConstants.SYMBOL_RCL_SIGMA_PLUS:
                        result = "RCLΣ";
                        break;
                    case SymbolConstants.SYMBOL_RECIPROCAL:
                        result = "1/X";
                        break;
                    case SymbolConstants.SYMBOL_REG:
                        result = "PREG";
                        break;
                    case SymbolConstants.SYMBOL_S:
                        result = "S";
                        break;
                    case SymbolConstants.SYMBOL_SIGMA_MINUS:
                        result = "Σ-";
                        break;
                    case SymbolConstants.SYMBOL_SIGMA_PLUS:
                        result = "Σ+";
                        break;
                    case SymbolConstants.SYMBOL_SPACE:
                        result = "SPC";
                        break;
                    case SymbolConstants.SYMBOL_SQRT:
                        result = "√X";
                        break;
                    case SymbolConstants.SYMBOL_SQUARE:
                        result = "X²";
                        break;
                    case SymbolConstants.SYMBOL_ST_I:
                        result = "STOI";
                        break;
                    case SymbolConstants.SYMBOL_STO:
                        if (arguments.Length > 1)
                        {
                            result = "ST";
                        }
                        else
                        {
                            result = "STO";
                        }
                        break;
                    case SymbolConstants.SYMBOL_STK:
                        result = "PRST";
                        break;
                    case SymbolConstants.SYMBOL_SUBTRACTION:
                        result = "-";
                        break;
                    case SymbolConstants.SYMBOL_TEN_TO_THE_XTH:
                        result = "10ˣ";
                        break;
                    case SymbolConstants.SYMBOL_TO_DEGREES:
                        result = "D←";
                        break;
                    case SymbolConstants.SYMBOL_TO_HMS:
                        result = "→HMS";
                        break;
                    case SymbolConstants.SYMBOL_TO_HOURS:
                        result = "HMS→";
                        break;
                    case SymbolConstants.SYMBOL_TO_POLAR:
                        result = "→P";
                        break;
                    case SymbolConstants.SYMBOL_TO_RADIANS:
                        result = "D→R";
                        break;
                    case SymbolConstants.SYMBOL_TO_RECTANGULAR:
                        result = "→R";
                        break;
                    case SymbolConstants.SYMBOL_W_DATA:
                        result = "WDTA";
                        break;
                    case SymbolConstants.SYMBOL_X_AVERAGE:
                        result = "̄̄̄̄X̄";
                        break;
                    case SymbolConstants.SYMBOL_X_EQ_0:
                        result = "X=0?";
                        break;
                    case SymbolConstants.SYMBOL_X_EQ_Y:
                        result = "X=Y?";
                        break;
                    case SymbolConstants.SYMBOL_X_EXCHANGE_I:
                        result = "X⇄I";
                        break;
                    case SymbolConstants.SYMBOL_X_EXCHANGE_Y:
                        result = "X⇄Y";
                        break;
                    case SymbolConstants.SYMBOL_X_GT_0:
                        result = "X>0?";
                        break;
                    case SymbolConstants.SYMBOL_X_GT_Y:
                        result = "X>Y?";
                        break;
                    case SymbolConstants.SYMBOL_X_LE_Y:
                        result = "X≤Y?";
                        break;
                    case SymbolConstants.SYMBOL_X_LT_0:
                        result = "X<0?";
                        break;
                    case SymbolConstants.SYMBOL_X_NE_0:
                        result = "X≠0?";
                        break;
                    case SymbolConstants.SYMBOL_X_NE_Y:
                        result = "X≠Y?";
                        break;
                    case SymbolConstants.SYMBOL_Y_TO_THE_XTH:
                        result = "Yˣ";
                        break;
                    default:
                        result = Symbol.Name.ToUpper ().Replace ('_', ' ');
                        break;
                }
                for (int i = 0; i < arguments.Length; i++)
                {
                    result += arguments [i].TraceableText;
                }
                switch ((SymbolConstants) Symbol.Id)
                {
                    case SymbolConstants.SYMBOL_F_TEST:
                        result += "?";
                        break;
                }
                return result;
            }
        }

    }
}
