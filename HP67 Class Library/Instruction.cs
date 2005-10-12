using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using HP67_Parser;
using System;
using System.Diagnostics;

namespace HP67_Class_Library
{
	/// <summary>
	/// An instruction in the program memory of the HP67 calculator.
	/// </summary>
	public class Instruction
	{

		private Argument [] arguments;
		private Symbol instruction;
		private string text;

		public Instruction(string input, Token [] tokens)
		{
			text = input;
			
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

			if (instruction.Id == (int) SymbolConstants.SYMBOL_DIGIT) 
			{

				// Somewhat ugly.  In the case of the DIGIT instruction, the argument is borne by
				// the instruction symbol itself.  Pretend that it is a separate argument for
				// uniformity.
				arguments = new Argument [1] {(Argument) tokens [0].UserObject};
			}
			else 
			{
				arguments = new Argument [tokens.Length - 1];
				for (int i = 0; i < arguments.Length; i++) 
				{
					arguments [i] = (Argument) tokens [i + 1].UserObject;
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

		public Symbol Symbol
		{
			get
			{
				return instruction;
			}
		}

		public override string ToString ()
		{
			return text;
		}
	}
}
