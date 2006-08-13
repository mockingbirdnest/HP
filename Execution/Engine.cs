using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{

    public enum AngleUnit
    {
        Degree,
        Grade,
        Radian
    }

    public enum EngineMode
    {
        Run,
        WriteProgram
    }

    public class Engine
    {

        #region Private Data

        private static TraceSwitch classTraceSwitch =
            new TraceSwitch ("Mockingbird.HP.Execution.Engine", "Execution engine");

        private const double degreeToRadian = Math.PI / 180.0;
        private const double gradeToRadian = Math.PI / 200.0;
        private const double radianToDegree = 180.0 / Math.PI;
        private const double radianToGrade = 200.0 / Math.PI;

        private bool enableBlur;
        private EngineMode mode;
        private bool running = false;
        private bool stackLift = false;
        private bool stepping = false;

        private bool [] flags;
        private AngleUnit unit;

        private Display display;
        private Memory memory;
        private Program program;
        private Reader reader;
        private Stack stack;

        #endregion

        #region Event Definitions

        public delegate bool TimedKeystrokeEvent (int ms);

        public event TimedKeystrokeEvent WaitForKeystroke;

        #endregion
        
#region Constructors & Destructors

        public Engine (Display display,
                        Memory memory,
                        Program program,
                        Reader reader,
                        Stack stack)
        {
            string [] appSettingsEnableBlur =
                System.Configuration.ConfigurationManager.AppSettings.GetValues
                ("EnableBlur");
            if (appSettingsEnableBlur == null)
            {
                enableBlur = true;
            }
            else
            {
                enableBlur = bool.Parse (appSettingsEnableBlur [0]);
            }

            flags = new bool [4];
            unit = AngleUnit.Degree;
            this.display = display;
            this.display.EnteringNumber += new Display.DisplayStateChangeEvent (Enter);
            this.memory = memory;
            this.program = program;
            this.reader = reader;
            this.stack = stack;
            Card.ReadFromDataset += new Card.DatasetImporterDelegate (ReadFromDataset);
            Card.WriteToDataset += new Card.DatasetExporterDelegate (WriteToDataset);
        }

        #endregion

        #region Event Handlers

        public void ReadFromDataset (CardDataset cds, Reader reader)
        {
            CardDataset.CardRow cr;
            CardDataset.EngineRow er;
            CardDataset.EngineRow [] ers;
            CardDataset.FlagRow [] frs;

            cr = cds.Card [0];
            ers = cr.GetEngineRows ();
            if (ers.Length > 0)
            {
                er = ers [0];
                unit = (AngleUnit) Enum.Parse (typeof (AngleUnit), er.AngleUnit);
                flags = new bool [er.FlagCount];
                frs = er.GetFlagRows ();
                foreach (CardDataset.FlagRow fr in frs)
                {
                    flags [fr.Id] = fr.Value;
                }
            }
        }

        public void WriteToDataset (CardDataset cds, CardPart part)
        {
            if (part == CardPart.Program)
            {
                CardDataset.EngineRow er;
                CardDataset.FlagRow fr;

                for (int i = 0; i < cds.Engine.Count; i++)
                {
                    cds.Engine.RemoveEngineRow (cds.Engine [i]);
                }
                er = cds.Engine.NewEngineRow ();
                er.AngleUnit = unit.ToString ();
                er.FlagCount = flags.Length;
                er.CardRow = cds.Card [0];
                cds.Engine.AddEngineRow (er);
                for (int i = 0; i < flags.Length; i++)
                {
                    fr = cds.Flag.NewFlagRow ();
                    fr.Id = i;
                    fr.Value = flags [i];
                    fr.EngineRow = er;
                    cds.Flag.AddFlagRow (fr);
                }
            }
        }

        #endregion

        #region Private Operations

        private void Enter (object sender)
        {
            if (stackLift)
            {
                stack.Enter ();
            }
        }

        private double Factorial (long x)
        {
            double factorial;
            for (factorial = 1.0; x > 1; x--)
            {
                factorial = factorial * (double) x;
            }
            return factorial;
        }

        private double FromRadian (double angle)
        {
            switch (unit)
            {
                case AngleUnit.Degree:
                    return angle * radianToDegree;
                case AngleUnit.Grade:
                    return angle * radianToGrade;
                case AngleUnit.Radian:
                    return angle;
                default:
                    Trace.Assert (false);
                    return 0.0;
            }
        }

        private double ToH (double x)
        {
            double absX = Math.Abs (x);
            double h = Math.Floor (absX);
            double m = Math.Floor ((absX - h) * 100.0);
            double s = (absX - h - m / 100.0) * 10000.0;
            if (x < 0.0)
            {
                return -h - m / 60.0 - s / 3600.0;
            }
            else
            {
                return h + m / 60.0 + s / 3600.0;
            }
        }

        private double ToHMS (double x)
        {
            double absX = Math.Abs (x);
            double h = Math.Floor (absX);
            double m = Math.Floor ((absX - h) * 60.0);
            double s = (absX - h - m / 60.0) * 3600.0;
            if (x < 0.0)
            {
                return -h - m / 100.0 - s / 10000.0;
            }
            else
            {
                return h + m / 100.0 + s / 10000.0;
            }
        }

        private double ToRadian (double angle)
        {
            switch (unit)
            {
                case AngleUnit.Degree:
                    return angle * degreeToRadian;
                case AngleUnit.Grade:
                    return angle * gradeToRadian;
                case AngleUnit.Radian:
                    return angle;
                default:
                    Trace.Assert (false);
                    return 0.0;
            }
        }

        #endregion

        #region Public Operations

        public EngineMode Mode
        {
            set
            {
                mode = value;
                switch (mode)
                {
                    case EngineMode.Run:
                        display.Mode = DisplayMode.Numeric;
                        break;
                    case EngineMode.WriteProgram:
                        display.Mode = DisplayMode.Instruction;
                        break;
                }
            }
        }

        public void Execute (Instruction instruction)
        {
            CardCalculator form = (CardCalculator) display.TopLevelControl;
            bool neutral = stackLift;
            FileStream stream;
            double x, y;

            Trace.WriteLineIf (classTraceSwitch.TraceInfo,
                "Execute: " + instruction.PrintableText,
                classTraceSwitch.DisplayName);

            // Most operations terminate digit entry.  The only ones that don't are those that are
            // used to construct digits, and SST which does not change the state of the engine at
            // all.
            switch ((SymbolConstants) instruction.Symbol.Id)
            {
                case SymbolConstants.SYMBOL_CHS:
                case SymbolConstants.SYMBOL_DIGIT:
                case SymbolConstants.SYMBOL_EEX:
                case SymbolConstants.SYMBOL_PERIOD:
                case SymbolConstants.SYMBOL_SST:
                    break;
                default:
                    display.DoneEntering ();
                    break;
            }

            switch ((SymbolConstants) instruction.Symbol.Id)
            {
                case SymbolConstants.SYMBOL_ABS:
                    stack.Get (out x);
                    stack.X = Math.Abs (x);
                    break;
                case SymbolConstants.SYMBOL_ADDITION:
                    stack.Get (out x, out y);
                    stack.X = y + x;
                    break;
                case SymbolConstants.SYMBOL_ARCCOS:
                    stack.Get (out x);
                    if (Math.Abs (x) > 1.0)
                    {
                        throw new Error ();
                    }
                    else
                    {
                        stack.X = FromRadian (Math.Acos (x));
                    }
                    break;
                case SymbolConstants.SYMBOL_ARCSIN:
                    stack.Get (out x);
                    if (Math.Abs (x) > 1.0)
                    {
                        throw new Error ();
                    }
                    else
                    {
                        stack.X = FromRadian (Math.Asin (x));
                    }
                    break;
                case SymbolConstants.SYMBOL_ARCTAN:
                    stack.Get (out x);
                    stack.X = FromRadian (Math.Atan (x));
                    break;
                case SymbolConstants.SYMBOL_BST:
                    // Does nothing, moved backward on MouseDown.
                    break;
                case SymbolConstants.SYMBOL_CF:
                    flags [((Digit) instruction.Arguments [0]).Value] = false;
                    break;
                case SymbolConstants.SYMBOL_CHS:
                    bool changeSignDone;
                    display.ChangeSign (out changeSignDone);
                    if (!changeSignDone)
                    {
                        stack.X = -stack.X;
                    }
                    break;
                case SymbolConstants.SYMBOL_CL_PRGM:
                    // Cancels the f key.
                    break;
                case SymbolConstants.SYMBOL_CL_REG:
                    memory.Clear ();
                    break;
                case SymbolConstants.SYMBOL_CLX:
                    stack.X = 0.0;
                    break;
                case SymbolConstants.SYMBOL_COS:
                    stack.Get (out x);
                    stack.X = Math.Cos (ToRadian (x));
                    break;
                case SymbolConstants.SYMBOL_DEG:
                    unit = AngleUnit.Degree;
                    break;
                case SymbolConstants.SYMBOL_DEL:
                    // Cancel the h key.
                    break;
                case SymbolConstants.SYMBOL_DIGIT:
                    display.EnterDigit (((Digit) instruction.Arguments [0]).Value);
                    if (!running)
                    {
                        // Flag 3 is the data entry flag.
                        flags [3] = true;
                    }
                    break;
                case SymbolConstants.SYMBOL_DISPLAY_X:
                    switch (reader.Model) {
                        case CalculatorModel.HP67:
                            display.PauseAndBlink (5000);
                            break;
                        case CalculatorModel.HP97:
                            display.Print ();
                            break;
                    }
                    break;
                case SymbolConstants.SYMBOL_DIVISION:
                    stack.Get (out x, out y);
                    if (x == 0.0)
                    {
                        throw new Error ();
                    }
                    else
                    {
                        stack.X = y / x;
                    }
                    break;
                case SymbolConstants.SYMBOL_DSP:
                    ((IDigits) instruction.Arguments [0]).SetDigits (memory, display);
                    break;
                case SymbolConstants.SYMBOL_DSZ:
                    if (memory.DecrementAndSkipIfZero ())
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_DSZ_SUB_I:
                    if (memory.DecrementAndSkipIfZeroIndexed ())
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_EEX:
                    display.EnterExponent ();
                    break;
                case SymbolConstants.SYMBOL_ENG:
                    display.Format = DisplayFormat.Engineering;
                    break;
                case SymbolConstants.SYMBOL_ENTER:
                    stack.Enter ();
                    break;
                case SymbolConstants.SYMBOL_EXP:
                    stack.Get (out x);
                    stack.X = Math.Exp (x);
                    break;
                case SymbolConstants.SYMBOL_F_TEST:
                    byte flagId = ((Digit) instruction.Arguments [0]).Value;
                    if (!flags [flagId])
                    {
                        program.Skip ();
                    }
                    switch (flagId)
                    {
                        case 0:
                        case 1:
                            break;
                        case 2:
                        case 3:
                            flags [flagId] = false;
                            break;
                    }
                    break;
                case SymbolConstants.SYMBOL_FACTORIAL:
                    stack.Get (out x);
                    if (x >= 0 && x == Math.Floor (x))
                    {
                        stack.X = Factorial ((long) x);
                    }
                    else
                    {
                        throw new Error ();
                    }
                    break;
                case SymbolConstants.SYMBOL_FIX:
                    display.Format = DisplayFormat.Fixed;
                    break;
                case SymbolConstants.SYMBOL_FRAC:
                    stack.Get (out x);
                    if (x < 0.0)
                    {
                        stack.X = x + Math.Floor (-x);
                    }
                    else
                    {
                        stack.X = x - Math.Floor (x);
                    }
                    break;
                case SymbolConstants.SYMBOL_GRD:
                    unit = AngleUnit.Grade;
                    break;
                case SymbolConstants.SYMBOL_GSB:
                    if (running)
                    {
                        ((ILabel) instruction.Arguments [0]).Gosub (memory, program);
                    }
                    else if (stepping)
                    {
                        program.Segregate ();
                        ((ILabel) instruction.Arguments [0]).Gosub (memory, program);
                        running = true;
                    }
                    else
                    {
                        ((ILabel) instruction.Arguments [0]).Goto (memory, program);
                        program.Reset ();
                        Trace.WriteLineIf (classTraceSwitch.TraceInfo,
                            "Running",
                            classTraceSwitch.DisplayName);
                        running = true;
                    }
                    break;
                case SymbolConstants.SYMBOL_GTO:
                    ((ILabel) instruction.Arguments [0]).Goto (memory, program);
                    break;
                case SymbolConstants.SYMBOL_GTO_PERIOD:
                    byte b0, b1, b2;
                    b0 = ((Digit) instruction.Arguments [0]).Value;
                    b1 = ((Digit) instruction.Arguments [1]).Value;
                    b2 = ((Digit) instruction.Arguments [2]).Value;
                    program.GotoStep (100 * (int) b0 + 10 * (int) b1 + (int) b2);
                    break;
                case SymbolConstants.SYMBOL_HMS_PLUS:
                    stack.Get (out x, out y);
                    stack.X = ToHMS (ToH (y) + ToH (x));
                    break;
                case SymbolConstants.SYMBOL_INT:
                    stack.Get (out x);
                    if (x < 0.0)
                    {
                        stack.X = -Math.Floor (-x);
                    }
                    else
                    {
                        stack.X = Math.Floor (x);
                    }
                    break;
                case SymbolConstants.SYMBOL_ISZ:
                    if (memory.IncrementAndSkipIfZero ())
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_ISZ_SUB_I:
                    if (memory.IncrementAndSkipIfZeroIndexed ())
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_LBL:
                    break;
                case SymbolConstants.SYMBOL_LN:
                    stack.Get (out x);
                    if (x <= 0.0)
                    {
                        throw new Error ();
                    }
                    else
                    {
                        stack.X = Math.Log (x);
                    }
                    break;
                case SymbolConstants.SYMBOL_LOG:
                    stack.Get (out x);
                    if (x <= 0.0)
                    {
                        throw new Error ();
                    }
                    else
                    {
                        stack.X = Math.Log10 (x);
                    }
                    break;
                case SymbolConstants.SYMBOL_LST_X:
                    stack.Enter ();
                    stack.X = stack.LastX;
                    break;
                case SymbolConstants.SYMBOL_MERGE:
                    stream = (FileStream) form.Invoke
                        (new Execution.Thread.CrossThreadFileOperation (form.CrossThreadOpen));
                    if (stream == null)
                    {
                        throw new Error ();
                    }
                    else
                    {
                        try
                        {
                            Card.Merge (stream, reader);
                        }
                        finally
                        {
                            stream.Close ();
                        }
                    }
                    break;
                case SymbolConstants.SYMBOL_MULTIPLICATION:
                    stack.Get (out x, out y);
                    stack.X = y * x;
                    break;
                case SymbolConstants.SYMBOL_P_EXCHANGE_S:
                    memory.PrimarySecondaryExchange ();
                    break;
                case SymbolConstants.SYMBOL_PAUSE:
                    display.PauseAndAcceptKeystrokes (1000);
                    break;
                case SymbolConstants.SYMBOL_PERCENT:
                    stack.Get (out x);
                    stack.X = stack.Y * x / 100.0;
                    break;
                case SymbolConstants.SYMBOL_PERCENT_CHANGE:
                    stack.Get (out x, out y);
                    if (y == 0)
                    {
                        throw new Error ();
                    }
                    else
                    {
                        stack.X = (x - y) * 100.0 / y;
                    }
                    break;
                case SymbolConstants.SYMBOL_PERIOD:
                    display.EnterPeriod ();
                    break;
                case SymbolConstants.SYMBOL_PI:
                    Enter (this);
                    stack.X = Math.PI;
                    break;
                case SymbolConstants.SYMBOL_R_DOWN:
                    stack.RollDown ();
                    break;
                case SymbolConstants.SYMBOL_R_S:
                    if (running)
                    {
                        running = false;
                    }
                    else if (stepping)
                    {
                    }
                    else
                    {
                        Trace.WriteLineIf (classTraceSwitch.TraceInfo,
                            "Running",
                            classTraceSwitch.DisplayName);
                        running = true;
                    }
                    break;
                case SymbolConstants.SYMBOL_R_UP:
                    stack.RollUp ();
                    break;
                case SymbolConstants.SYMBOL_RAD:
                    unit = AngleUnit.Radian;
                    break;
                case SymbolConstants.SYMBOL_RC_I:
                    Enter (this);
                    stack.X = memory.Recall (Memory.LetterRegister.I);
                    break;
                case SymbolConstants.SYMBOL_RCL:
                    Enter (this);
                    stack.X = ((IAddress) instruction.Arguments [0]).Recall (memory);
                    break;
                case SymbolConstants.SYMBOL_RCL_SIGMA_PLUS:
                    stack.Get (out x);
                    memory.RecallΣPlus (out x, out y);
                    stack.X = x;
                    stack.Y = y;
                    break;
                case SymbolConstants.SYMBOL_RECIPROCAL:
                    stack.Get (out x);
                    if (x == 0.0)
                    {
                        throw new Error ();
                    }
                    else
                    {
                        stack.X = 1.0 / x;
                    }
                    break;
                case SymbolConstants.SYMBOL_REG:
                    memory.Display ();
                    break;
                case SymbolConstants.SYMBOL_RND:
                    stack.Get (out x); // To set Last X.
                    display.Round ();
                    break;
                case SymbolConstants.SYMBOL_RTN:
                    bool stop;
                    program.Return (out stop);
                    if (stop)
                    {
                        running = false;
                    }
                    break;
                case SymbolConstants.SYMBOL_S:
                    stack.Get (out x);
                    memory.S (out x, out y);
                    stack.X = x;
                    stack.Y = y;
                    break;
                case SymbolConstants.SYMBOL_SCI:
                    display.Format = DisplayFormat.Scientific;
                    break;
                case SymbolConstants.SYMBOL_SF:
                    flags [((Digit) instruction.Arguments [0]).Value] = true;
                    break;
                case SymbolConstants.SYMBOL_SIGMA_MINUS:
                    stack.Get (out x);
                    memory.ΣMinus (x, stack.Y);
                    stack.X = memory.N;
                    break;
                case SymbolConstants.SYMBOL_SIGMA_PLUS:
                    stack.Get (out x);
                    memory.ΣPlus (x, stack.Y);
                    stack.X = memory.N;
                    break;
                case SymbolConstants.SYMBOL_SIN:
                    stack.Get (out x);
                    stack.X = Math.Sin (ToRadian (x));
                    break;
                case SymbolConstants.SYMBOL_SPACE:
                    switch (reader.Model)
                    {
                        case CalculatorModel.HP67:
                            break;
                        case CalculatorModel.HP97:
                            //TODO: Printer.Advance ();
                            break;
                    }
                    break;
                case SymbolConstants.SYMBOL_SQRT:
                    stack.Get (out x);
                    if (x < 0.0)
                    {
                        throw new Error ();
                    }
                    else
                    {
                        stack.X = Math.Sqrt (x);
                    }
                    break;
                case SymbolConstants.SYMBOL_SQUARE:
                    stack.Get (out x);
                    stack.X = x * x;
                    break;
                case SymbolConstants.SYMBOL_SST:
                    break;
                case SymbolConstants.SYMBOL_ST_I:
                    memory.Store (stack.X, Memory.LetterRegister.I);
                    break;
                case SymbolConstants.SYMBOL_STK:
                    stack.Display ();
                    break;
                case SymbolConstants.SYMBOL_STO:
                    if (instruction.Arguments.Length == 2)
                    {
                        ((IAddress) instruction.Arguments [1]).Store
                            (memory, stack.X,
                            ((Operator) instruction.Arguments [0]).Value);
                    }
                    else
                    {
                        Trace.Assert (instruction.Arguments.Length == 1);
                        ((IAddress) instruction.Arguments [0]).Store (memory, stack.X);
                    }
                    break;
                case SymbolConstants.SYMBOL_SUBTRACTION:
                    stack.Get (out x, out y);
                    stack.X = y - x;
                    break;
                case SymbolConstants.SYMBOL_TAN:
                    stack.Get (out x);
                    stack.X = Math.Tan (ToRadian (x));
                    break;
                case SymbolConstants.SYMBOL_TEN_TO_THE_XTH:
                    stack.Get (out x);
                    stack.X = Math.Pow (10.0, x);
                    break;
                case SymbolConstants.SYMBOL_TO_DEGREES:
                    stack.Get (out x);
                    stack.X = x * radianToDegree;
                    break;
                case SymbolConstants.SYMBOL_TO_HMS:
                    stack.Get (out x);
                    stack.X = ToHMS (x);
                    break;
                case SymbolConstants.SYMBOL_TO_HOURS:
                    stack.Get (out x);
                    stack.X = ToH (x);
                    break;
                case SymbolConstants.SYMBOL_TO_POLAR:
                    stack.Get (out x);
                    y = stack.Y;
                    stack.X = Math.Sqrt (x * x + y * y);
                    stack.Y = FromRadian (Math.Atan2 (y, x));
                    break;
                case SymbolConstants.SYMBOL_TO_RADIANS:
                    stack.Get (out x);
                    stack.X = x * degreeToRadian;
                    break;
                case SymbolConstants.SYMBOL_TO_RECTANGULAR:
                    double θ = stack.Y;
                    double r;
                    stack.Get (out r);
                    stack.X = r * Math.Cos (ToRadian (θ));
                    stack.Y = r * Math.Sin (ToRadian (θ));
                    break;
                case SymbolConstants.SYMBOL_W_DATA:
                    stream =
                        (FileStream) form.Invoke (new Execution.Thread.CrossThreadFileOperation
                                        (form.CrossThreadSaveDataAs));
                    if (stream == null)
                    {
                        throw new Error ();
                    }
                    else
                    {
                        try
                        {
                            Card.Write (stream, CardPart.Data);
                        }
                        finally
                        {
                            stream.Close ();
                        }
                    }
                    break;
                case SymbolConstants.SYMBOL_X_AVERAGE:
                    stack.Get (out x);
                    memory.X̄ (out x, out y);
                    stack.X = x;
                    stack.Y = y;
                    break;
                case SymbolConstants.SYMBOL_X_EQ_0:
                    if (stack.X != 0.0)
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_X_EQ_Y:
                    if (stack.X != stack.Y)
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_X_EXCHANGE_I:
                    double i = memory.Recall (Memory.LetterRegister.I);
                    memory.Store (stack.X, Memory.LetterRegister.I);
                    stack.X = i;
                    break;
                case SymbolConstants.SYMBOL_X_EXCHANGE_Y:
                    stack.XExchangeY ();
                    break;
                case SymbolConstants.SYMBOL_X_GT_0:
                    if (stack.X <= 0.0)
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_X_GT_Y:
                    if (stack.X <= stack.Y)
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_X_LE_Y:
                    if (stack.X > stack.Y)
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_X_LT_0:
                    if (stack.X >= 0.0)
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_X_NE_0:
                    if (stack.X == 0.0)
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_X_NE_Y:
                    if (stack.X == stack.Y)
                    {
                        program.Skip ();
                    }
                    break;
                case SymbolConstants.SYMBOL_Y_TO_THE_XTH:
                    stack.Get (out x, out y);
                    if (y == 0.0 && x <= 0.0)
                    {
                        throw new Error ();
                    }
                    else if (y < 0 && x != Math.Floor (x))
                    {
                        throw new Error ();
                    }
                    else
                    {
                        stack.X = Math.Pow (y, x);
                    }
                    break;
                default:
                    throw new Error ();
            }

            // Set the stack lift as specified in Appendix D of the Programming Guide.
            switch ((SymbolConstants) instruction.Symbol.Id)
            {
                case SymbolConstants.SYMBOL_SST:
                    // Don't change the stack lift, not even to neutral: the necessary changes have
                    // been done by the instruction called by SST.
                    stepping = true;
                    break;
                case SymbolConstants.SYMBOL_CLX:
                case SymbolConstants.SYMBOL_ENTER:
                case SymbolConstants.SYMBOL_SIGMA_MINUS:
                case SymbolConstants.SYMBOL_SIGMA_PLUS:
                    stackLift = false;
                    stepping = false;
                    break;
                case SymbolConstants.SYMBOL_CL_PRGM:
                case SymbolConstants.SYMBOL_DEL:
                case SymbolConstants.SYMBOL_DISPLAY_X:
                case SymbolConstants.SYMBOL_DSP:
                case SymbolConstants.SYMBOL_ENG:
                case SymbolConstants.SYMBOL_FIX:
                case SymbolConstants.SYMBOL_MERGE:
                case SymbolConstants.SYMBOL_REG:
                case SymbolConstants.SYMBOL_SCI:
                case SymbolConstants.SYMBOL_SPACE:
                case SymbolConstants.SYMBOL_STK:
                    stackLift = neutral;
                    stepping = false;
                    break;
                default:
                    stackLift = true;
                    stepping = false;
                    break;
            }

            // Now check if some key was typed while we were executing the instruction.  If it was,
            // stop the computation.  Note that this is done synchronously to make sure that we can
            // resume execution with the proper state if the user types R/S again.
            if (WaitForKeystroke (0))
            {
                throw new Interrupt ();
            }
        }

        public void ExecuteSequence (Instruction instruction)
        {
            try
            {
                Trace.Assert (!running);
                for (; ; )
                {
                    Execute (instruction);
                    if (!running && !stepping)
                    {
                        break;
                    }
                    instruction = program.Instruction;
                    if (enableBlur)
                    {

                        // The display mode will be reset at the end of the execution of the
                        // program, so we can freely change it here.
                        display.ShowBlur ();
                    }
                }
            }
            catch (ApplicationException e)
            {
                Trace.WriteLineIf (classTraceSwitch.TraceInfo,
                    "Process: Exception " + e.ToString (),
                    classTraceSwitch.DisplayName);
                throw;
            }
            finally
            {
                running = false;
            }
        }

        public void Process (Instruction instruction, KeystrokeMotion motion)
        {
            Trace.WriteLineIf (classTraceSwitch.TraceInfo,
                "Process: " + motion.ToString () + " " +
                instruction.Symbol.Name + " " + instruction.ToString (),
                classTraceSwitch.DisplayName);

            switch (mode)
            {
                case EngineMode.Run:
                    switch (motion)
                    {
                        case KeystrokeMotion.Down:
                            switch ((SymbolConstants) instruction.Symbol.Id)
                            {
                                case SymbolConstants.SYMBOL_BST:
                                    program.GotoRelative (-1);
                                    display.Mode = DisplayMode.Instruction;
                                    program.PreviewInstruction ();
                                    break;
                                case SymbolConstants.SYMBOL_R_S:
                                case SymbolConstants.SYMBOL_SST:

                                    // The display mode will be reset by EnableOpenOrSave after
                                    // execution of the next instruction (i.e., when the key goes
                                    // up).
                                    display.Mode = DisplayMode.Instruction;
                                    program.PreviewInstruction ();
                                    break;
                                default:
                                    ExecuteSequence (instruction);
                                    break;
                            };
                            break;
                        case KeystrokeMotion.Up:
                            switch ((SymbolConstants) instruction.Symbol.Id)
                            {
                                case SymbolConstants.SYMBOL_BST:
                                case SymbolConstants.SYMBOL_R_S:
                                case SymbolConstants.SYMBOL_SST:
                                    ExecuteSequence (instruction);
                                    break;
                                default:
                                    break;
                            }
                            break;
                    }
                    break;

                case EngineMode.WriteProgram:
                    switch (motion)
                    {
                        case KeystrokeMotion.Down:
                            switch ((SymbolConstants) instruction.Symbol.Id)
                            {
                                case SymbolConstants.SYMBOL_BST:
                                    program.GotoRelative (-1);
                                    break;
                                case SymbolConstants.SYMBOL_CL_PRGM:
                                    program.Clear ();
                                    break;
                                case SymbolConstants.SYMBOL_DEL:
                                    program.Delete ();
                                    break;
                                case SymbolConstants.SYMBOL_GTO_PERIOD:
                                    Execute (instruction);
                                    break;
                                case SymbolConstants.SYMBOL_SST:
                                    program.GotoRelative (+1);
                                    break;
                                default:
                                    program.Insert (instruction);
                                    break;
                            }
                            break;
                        case KeystrokeMotion.Up:
                            break;
                    }
                    break;
            }
        }

        #endregion

    }

}