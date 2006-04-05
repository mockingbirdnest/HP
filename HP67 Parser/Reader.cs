using com.calitha.commons;
using com.calitha.goldparser;
using System;
using System.Collections;
using System.IO;

namespace HP_Parser
{
	/// <summary>
	/// A class to read parser tables from a resource.
	/// </summary>
	public class Reader : CGTReader
	{
		private string model;
		private int modelLength;

		// For performance, the public operations of this package build hashtables the first time
		// they are called, and read from the hashtable afterwards.
		private Hashtable symbolNameToSymbol = null;
		private Hashtable symbolIdToTag = null;
		private Hashtable symbolIdToString = null;

		public Reader (Stream stream, string model, string [] tags) : base (stream)
		{
			TerminalToken token;
			StringTokenizer tokenizer = CreateNewTokenizer ();

			this.model = model;
			modelLength = model.Length;
			symbolIdToTag = new Hashtable ();
			foreach (string tag in tags) 
			{
				if (tag != null) 
				{
					tokenizer.SetInput (tag);
					token = tokenizer.RetrieveToken ();
					symbolIdToTag [token.Symbol.Id] = tag;
				}
			}
			stream.Close ();
		}

		public Reader (string filename, string model, string [] tags) :
			this (new FileStream (filename, FileMode.Open, FileAccess.Read), model, tags)
		{
		}

		public Reader (string baseName, string resourceName, string model, string [] tags) :
			this (
				new MemoryStream
					(ResourceUtil.GetByteArrayResource
						(System.Reflection.Assembly.GetExecutingAssembly (),
						baseName,
						resourceName)),
				model,
				tags)
		{
		}

		private ArrayList UnparseToWords (Symbol symbol) 
		{
			bool found = false;
			ArrayList sWords;
			ArrayList words = new ArrayList ();

			if (symbol is SymbolTerminal) 
			{
				if (symbolIdToTag [symbol.Id] != null) 
				{
					words.Add (symbolIdToTag [symbol.Id]);
				}
			}
			else 
			{
				foreach (Rule r in Rules) 
				{
					if (r.Lhs.Id == symbol.Id) 
					{
						foreach (Symbol s in r.Rhs) 
						{
							sWords = UnparseToWords (s);
							found = sWords.Count > 0;
							foreach (object w in sWords) 
							{
								if (((string) w).Substring (0, modelLength) == model) 
								{
									words.Add ((string) w);
								}
								else 
								{
									// If one word doesn't match the model, the entire
									// reconstruction is ignored.
									found = false;
									break;
								}
							}
						}
					}
					if (found) 
					{
						// Stop at the first reconstruction found.
						break;
					}
				}
			}
			return words;
		}

		public Symbol ToSymbol (string name)
		{

			// When persisting a program, we store the symbol names rather than the symbol ids
			// because they are supposed to be more resilient in the face of changes to the
			// grammar.  To read a program, we must be able to convert the name back to a symbol.
			if (symbolNameToSymbol == null)
			{
				symbolNameToSymbol = new Hashtable ();
				foreach (Symbol s in Symbols) 
				{
					symbolNameToSymbol.Add (s.Name, s);
				}
			}
			return (Symbol) symbolNameToSymbol [name];
		}

		public string Unparse (Symbol symbol) 
		{
			bool first = true;
			string result = null;

			if (symbolIdToString == null) 
			{
				symbolIdToString = new Hashtable ();
			}

			result = (string) symbolIdToString [symbol.Id];
			if (result == null) 
			{
				foreach (object w in UnparseToWords (symbol)) 
				{
					if (first) 
					{
						first = false;
					}
					else
					{
						result += " ";
					}
					result += ((string) w).Substring (modelLength);
				}
				symbolIdToString [symbol.Id] = result;
				return result;
			}
			else 
			{
				return result;
			}
		}
	}
}
