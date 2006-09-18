using com.calitha.commons;
using com.calitha.goldparser;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mockingbird.HP.Parser
{

    public enum CalculatorModel
    {
        HP35 = 35,
        HP67 = 67,
        HP97 = 97
    }

    /// <summary>
    /// A class to read parser tables from a resource.
    /// </summary>
    public class Reader : CGTReader
    {

        #region Private Data

        private CalculatorModel model;
        private string modelString;
        private int modelStringLength;

        // For performance, the public operations of this package build dictionaries the first time
        // they are called, and read from the dictionaries afterwards.
        private Dictionary<string, Symbol> symbolNameToSymbol = null;
        private Dictionary<int, string> symbolIdToTag = null;
        private Dictionary<int, string> symbolIdToString = null;
        private Dictionary<SymbolConstants, Symbol> symbolIdToSymbol = null;

        #endregion

        #region Constructors & Destructors

        public Reader (Stream stream, CalculatorModel model, string [] tags)
            : base (stream)
        {
            TerminalToken token;
            StringTokenizer tokenizer = CreateNewTokenizer ();

            this.model = model;
            modelString = ((int) model).ToString ();
            modelStringLength = modelString.Length;
            symbolIdToTag = new Dictionary<int, string> ();
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

        public Reader (string filename, CalculatorModel model, string [] tags)
            :
            this (new FileStream (filename, FileMode.Open, FileAccess.Read), model, tags)
        {
        }

        public Reader
            (string baseName, string resourceName, CalculatorModel model, string [] tags)
            :
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

        #endregion

        #region Private Operations

        private List<string> UnparseToWords (Symbol symbol)
        {
            bool found = false;
            List<string> sWords;
            List<string> words = new List<string> ();

            if (symbol is SymbolTerminal)
            {
                string tag;

                if (symbolIdToTag.TryGetValue (symbol.Id, out tag))
                {
                    words.Add (tag);
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
                            foreach (string w in sWords)
                            {
                                if (w.Substring (0, modelStringLength) == modelString)
                                {
                                    words.Add (w);
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

        #endregion

        #region Public Operations

        public CalculatorModel Model
        {
            get
            {
                return model;
            }
        }

        public Symbol ToSymbol (SymbolConstants id)
        {
            if (symbolIdToSymbol == null)
            {
                symbolIdToSymbol = new Dictionary<SymbolConstants, Symbol> ();
                foreach (Symbol s in Symbols)
                {
                    symbolIdToSymbol.Add ((SymbolConstants) s.Id, s);
                }
            }
            return symbolIdToSymbol [id];
        }

        public Symbol ToSymbol (string name)
        {

            // When persisting a program, we store the symbol names rather than the symbol ids
            // because they are supposed to be more resilient in the face of changes to the
            // grammar.  To read a program, we must be able to convert the name back to a symbol.
            if (symbolNameToSymbol == null)
            {
                symbolNameToSymbol = new Dictionary<string, Symbol> ();
                foreach (Symbol s in Symbols)
                {
                    symbolNameToSymbol.Add (s.Name, s);
                }
            }
            return symbolNameToSymbol [name];
        }

        public string Unparse (Symbol symbol)
        {
            bool first = true;
            string result = null;

            if (symbolIdToString == null)
            {
                symbolIdToString = new Dictionary<int, string> ();
            }

            if (! symbolIdToString.TryGetValue (symbol.Id, out result))
            {
                foreach (string w in UnparseToWords (symbol))
                {
                    string word = w.Substring (modelStringLength);

                    if (first)
                    {
                        first = false;
                    }
                    else if (word [0] != '-') // - acts as a separator.
                    {
                        result += " ";
                    }
                    result += word;
                }
                symbolIdToString [symbol.Id] = result;
                return result;
            }
            else
            {
                return result;
            }
        }

        #endregion

    }
}
