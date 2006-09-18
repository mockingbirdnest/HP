using com.calitha.goldparser;
using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace Mockingbird.HP.Class_Library
{

    #region Root & Interfaces for Arguments

    /// <summary>
    /// An argument for an instructions of an HP calculator.
    /// </summary>
    public abstract class Argument : Object
    {
        protected abstract string PersistableText
        {
            get;
        }

        public abstract string PrintableText
        {
            get;
        }

        public abstract string TraceableText
        {
            get;
        }

        public abstract string Unparse (Reader reader);

        public static object ReadFromArgumentRow (CardDataset.ArgumentRow ar)
        {
            Type type = Type.GetType (ar.Type);
            ConstructorInfo [] constructors =
                type.GetConstructors (
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            // To build an instance of argument we favor parameterless constructors and
            // constructors that take a single character.  This could be modified if needed.
            foreach (ConstructorInfo c in constructors)
            {
                ParameterInfo [] parameters = c.GetParameters ();
                switch (parameters.Length)
                {
                    case 0:
                        return c.Invoke (new object [0]);
                    case 1:
                        if (parameters [0].ParameterType == typeof (char))
                        {
                            char ch = ar.Value [0];
                            return c.Invoke (new object [1] { ch });
                        }
                        break;
                    default:
                        Trace.Assert (false);
                        return null;
                }
            }
            Trace.Assert (false);
            return null;
        }

        public void WriteToArgumentRow (CardDataset.ArgumentRow ar)
        {
            ar.Type = this.GetType ().ToString ();
            ar.Value = PersistableText;
        }
    }

    public interface IAddress
    {
        double Recall (Memory m);
        void Store (Memory m, double x);
        void Store (Memory m, double x, Memory.Operator o);
    }

    public interface IDigits
    {
        void SetDigits (Memory m, Number.Formatter f);
    }

    public interface ILabel
    {
        void Goto (Memory m, Program p);
        void Gosub (Memory m, Program p);
    }

    #endregion

    #region Concrete Arguments

    public class Digit : Argument, IAddress, IDigits, ILabel
    {
        private const string digitTemplate = "00";
        private byte digit;

        private Digit (char c)
        {
            digit = byte.Parse (new String (c, 1));
        }

        public Digit (byte d)
        {
            digit = d;
        }

        protected override string PersistableText
        {
            get
            {
                return digit.ToString ();
            }
        }

        public override string PrintableText
        {
            get
            {
                return PersistableText;
            }
        }

        public override string TraceableText
        {
            get
            {
                return PersistableText;
            }
        }

        public byte Value
        {
            get
            {
                return digit;
            }
        }

        public override string Unparse (Reader reader)
        {
            return digit.ToString (digitTemplate, NumberFormatInfo.InvariantInfo);
        }

        public double Recall (Memory m)
        {
            return m.Recall (digit);
        }

        public void Store (Memory m, double x)
        {
            m.Store (x, digit);
        }

        public void Store (Memory m, double x, Memory.Operator o)
        {
            m.Store (x, digit, o);
        }

        public void SetDigits (Memory m, Number.Formatter f)
        {
            f.Digits = digit;
        }

        public void Goto (Memory m, Program p)
        {
            p.Goto (digit);
        }

        public void Gosub (Memory m, Program p)
        {
            p.Gosub (digit);
        }
    }

    public class Indexed : Argument, IAddress, IDigits, ILabel
    {
        public Indexed ()
        {
        }

        protected override string PersistableText
        {
            get
            {
                return "";
            }
        }

        public override string PrintableText
        {
            get
            {
                return "(i)";
            }
        }

        public override string TraceableText
        {
            get
            {
                return "i";
            }
        }

        public override string Unparse (Reader reader)
        {
            return reader.Unparse
                (new SymbolNonterminal ((int) SymbolConstants.SYMBOL_SUB_I, "SUB_I"));
        }

        public double Recall (Memory m)
        {
            return m.RecallIndexed ();
        }

        public void Store (Memory m, double x)
        {
            m.StoreIndexed (x);
        }

        public void Store (Memory m, double x, Memory.Operator o)
        {
            m.StoreIndexed (x, o);
        }

        public void SetDigits (Memory m, Number.Formatter f)
        {
            byte digits = (byte) Math.Floor (Math.Abs (m.Recall (Memory.LetterRegister.I)));
            if (digits > 9)
            {
                throw new Error ();
            }
            else
            {
                f.Digits = digits;
            }
        }

        public void Goto (Memory m, Program p)
        {
            int label = (int) Math.Floor (m.Recall (Memory.LetterRegister.I));

            if (label <= -1000 || label >= 20)
            {
                throw new Error ();
            }
            else if (label < 0)
            {
                // The - 1 is because the program counter has already moved to the next
                // instruction.
                p.GotoRelative (label - 1);
            }
            else
            {
                p.Goto ((byte) label);
            }
        }

        public void Gosub (Memory m, Program p)
        {
            int label = (int) Math.Floor (m.Recall (Memory.LetterRegister.I));

            if (label <= -1000 || label >= 20)
            {
                throw new Error ();
            }
            else if (label < 0)
            {
                // The - 1 is because the program counter has already moved to the next
                // instruction.
                p.GosubRelative (label - 1);
            }
            else
            {
                p.Gosub ((byte) label);
            }
        }
    }

    public class Letter : Argument, IAddress, ILabel
    {
        private char letter;

        public Letter (char l)
        {
            // We only expect to get a lower case letter here when reading from a dataset.
            Trace.Assert ((l >= 'A' && l <= 'E') || (l >= 'a' && l <= 'e') || l == 'I');
            letter = l;
        }

        public bool IsLower
        {
            get
            {
                Trace.Assert (letter != 'i');
                return (letter >= 'a' && letter <= 'e');
            }
        }

        protected override string PersistableText
        {
            get
            {
                return new String (letter, 1);
            }
        }

        public override string PrintableText
        {
            get
            {
                return PersistableText;
            }
        }

        public override string TraceableText
        {
            get
            {
                return PersistableText;
            }
        }

        public char Value
        {
            get
            {
                return letter;
            }
        }

        public override string Unparse (Reader reader)
        {
            if (IsLower)
            {
                // Use the special nonterminals of the grammar that represent lowercase letters. 
                return reader.Unparse (reader.ToSymbol ("LC_" + letter));
            }
            else
            {
                return reader.Unparse (reader.ToSymbol (new string (char.ToUpper (letter), 1)));
            }
        }

        public void ToLower ()
        {
            Trace.Assert (letter != 'I');
            letter = char.ToLower (letter);
        }

        public double Recall (Memory m)
        {
            return m.Recall ((Memory.LetterRegister) Enum.Parse
                (typeof (Memory.LetterRegister), new String (letter, 1)));
        }

        public void Store (Memory m, double x)
        {
            m.Store (x, (Memory.LetterRegister) Enum.Parse
                (typeof (Memory.LetterRegister), new String (letter, 1)));
        }

        public void Store (Memory m, double x, Memory.Operator o)
        {
            // A letter is not an operable memory.
            Trace.Assert (false);
        }

        public void Goto (Memory m, Program p)
        {
            p.Goto ((Program.LetterLabel) Enum.Parse
                (typeof (Program.LetterLabel), new String (letter, 1)));
        }

        public void Gosub (Memory m, Program p)
        {
            p.Gosub ((Program.LetterLabel)
                Enum.Parse (typeof (Program.LetterLabel), new String (letter, 1)));
        }
    }

    public class Operator : Argument
    {
        private SymbolNonterminal additionSymbol =
            new SymbolNonterminal ((int) SymbolConstants.SYMBOL_ADDITION, "ADDITION");
        private SymbolNonterminal subtractionSymbol =
            new SymbolNonterminal ((int) SymbolConstants.SYMBOL_SUBTRACTION, "SUBTRACTION");
        private SymbolNonterminal multiplicationSymbol =
            new SymbolNonterminal ((int) SymbolConstants.SYMBOL_MULTIPLICATION, "MULTIPLICATION");
        private SymbolNonterminal divisionSymbol =
            new SymbolNonterminal ((int) SymbolConstants.SYMBOL_DIVISION, "DIVISION");

        private Memory.Operator op;

        static public double Addition (double x, double y)
        {
            return x + y;
        }

        static public double Subtraction (double x, double y)
        {
            return x - y;
        }

        static public double Multiplication (double x, double y)
        {
            return x * y;
        }

        static public double Division (double x, double y)
        {
            if (y == 0.0)
            {
                throw new Error ();
            }
            else
            {
                return x / y;
            }
        }

        private Operator (char c)
        {
            switch (c)
            {
                case '+':
                    op = new Memory.Operator (Addition);
                    break;
                case '-':
                    op = new Memory.Operator (Subtraction);
                    break;
                case '*':
                    op = new Memory.Operator (Multiplication);
                    break;
                case '/':
                    op = new Memory.Operator (Division);
                    break;
            }
        }

        public Operator (Memory.Operator o)
        {
            op = o;
        }

        protected override string PersistableText
        {
            get
            {
                if (op == new Memory.Operator (Addition))
                {
                    return "+";
                }
                else if (op == new Memory.Operator (Subtraction))
                {
                    return "-";
                }
                else if (op == new Memory.Operator (Multiplication))
                {
                    return "*";
                }
                else if (op == new Memory.Operator (Division))
                {
                    return "/";
                }
                else
                {
                    Trace.Assert (false);
                    return ""; // To make the compiler happy.
                }
            }
        }

        public override string PrintableText
        {
            get
            {
                if (op == new Memory.Operator (Addition))
                {
                    return "+";
                }
                else if (op == new Memory.Operator (Subtraction))
                {
                    return "-";
                }
                else if (op == new Memory.Operator (Multiplication))
                {
                    return "×";
                }
                else if (op == new Memory.Operator (Division))
                {
                    return "÷";
                }
                else
                {
                    Trace.Assert (false);
                    return ""; // To make the compiler happy.
                }
            }
        }

        public override string TraceableText
        {
            get
            {
                return PrintableText;
            }
        }

        public Memory.Operator Value
        {
            get
            {
                return op;
            }
        }

        public override string Unparse (Reader reader)
        {
            if (op == new Memory.Operator (Addition))
            {
                return reader.Unparse (additionSymbol);
            }
            else if (op == new Memory.Operator (Subtraction))
            {
                return reader.Unparse (subtractionSymbol);
            }
            else if (op == new Memory.Operator (Multiplication))
            {
                return reader.Unparse (multiplicationSymbol);
            }
            else if (op == new Memory.Operator (Division))
            {
                return reader.Unparse (divisionSymbol);
            }
            else
            {
                Trace.Assert (false);
                return ""; // To make the compiler happy.
            }
        }
    }

    #endregion

}
