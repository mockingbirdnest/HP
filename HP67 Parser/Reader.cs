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
		private Hashtable hashtable = null;

		public Reader (string filename) : base (filename)
		{
		}

		public Reader (Stream stream) : base (stream)
		{
			stream.Close ();
		}

		public Reader (string baseName, string resourceName) :
			this (
				new MemoryStream
					(ResourceUtil.GetByteArrayResource
						(System.Reflection.Assembly.GetExecutingAssembly (),
						baseName,
						resourceName)))
		{
		}

		public Symbol ToSymbol (string name)
		{

			// When persisting a program, we store the symbol names rather than the symbol ids
			// because they are supposed to be more resilient in the face of changes to the
			// grammar.  To read a program, we must be able to convert the name back to a symbol.
			// This subprogram does that.  For performance, it builds a dictionary the first
			// type it is called, and later does look up in this dictionary.
			if (hashtable == null)
			{
				hashtable = new Hashtable ();
				foreach (Symbol s in Symbols) 
				{
					hashtable.Add (s.Name, s);
				}
			}
			return (Symbol) hashtable [name];
		}
	}
}
