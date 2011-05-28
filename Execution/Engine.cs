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

    public struct EngineModes
    {
        public enum Execution
        {
            Run,
            WriteProgram
        }
        public enum Tracing
        {
            Manual,
            Trace,
            Normal
        }
        public Execution execution;
        public Tracing tracing;
    }

    public class Engine
    {

        #region Private Data

        private static TraceSwitch classTraceSwitch =
            new TraceSwitch ("Mockingbird.HP.Execution.Engine", "Execution engine");

        private const decimal degreeToRadian = Number.π / 180.0M;
        private const decimal gradeToRadian = Number.π / 200.0M;
        private const decimal radianToDegree = 180.0M / Number.π;
        private const decimal radianToGrade = 200.0M / Number.π;

        private bool doWeirdCHS = false;
        private bool enableBlur;
        private bool inDisplayX = false;
        private bool inNumberDone = false;
        private EngineModes modes;
        private SymbolConstants previousSymbol = SymbolConstants.SYMBOL_EOF;
        private bool running = false;
        private bool stackLift = false;
        private bool stepping = false;

        private bool [] flags;
        private AngleUnit unit = AngleUnit.Degree;

        private Display display;
        private Memory memory;
        private Printer printer;
        private Program program;
        private Reader reader;
        private Stack stack;
        private Number.Validater validater;

        #endregion

        #region Event Definitions

        public delegate bool TimedKeystrokeEvent (int ms);

        public event TimedKeystrokeEvent WaitForKeystroke;

        #endregion

        #region Constructors & Destructors

        public Engine (Display display,
                       Memory memory,
                       Printer printer,
                       Program program,
                       Reader reader,
                       Stack stack,
                       Number.Validater validater)
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
            this.display = display;
            this.validater = validater;
            this.memory = memory;
            this.printer = printer;
            this.program = program;
            this.reader = reader;
            this.stack = stack;
            this.display.Formatter.FormattingChanged +=
                new Number.ChangeEvent (DisplayFormattingChanged);
            this.validater.ExponentChanged += new Number.ChangeEvent (ExponentChanged);
            this.validater.MantissaChanged += new Number.ChangeEvent (MantissaChanged);
            this.validater.NumberCancelled += new Number.SimpleEvent (NumberCancelled);
            this.validater.NumberDone += new Number.ChangeEvent (NumberDone);
            this.validater.NumberPeek += new Number.ChangeEvent (NumberPeek);
            this.validater.NumberStarted += new Number.SimpleEvent (NumberStarted);
            Card.ReadFromDataset += new Card.DatasetImporterDelegate (ReadFromDataset);
            Card.WriteToDataset += new Card.DatasetExporterDelegate (WriteToDataset);

            // Now initialize the validater.  This will cause the delegates of the validater to be
            // notified of the current value (zero).  This is necessary in case someone wants to
            // peek at the current value before any digit has been entered.
            validater.EnterDigit (0);
            validater.DoneEntering ();
        }

        #endregion

        #region Event Handlers

        private void DisplayFormattingChanged (string mantissa, string exponent, Number value)
        {
            if (printer != null)
            {
                printer.Formatter.Value = value;

                // NumberDone does its one tracing because it needs the raw input.
                if (!inNumberDone && modes.tracing == EngineModes.Tracing.Trace)
                {
                    printer.PrintNumeric ();
                    printer.PrintEndMarker ();
                }
            }
        }

        private void ExponentChanged (string mantissa, string exponent, Number value)
        {
            display.ShowNumeric (mantissa, exponent);
        }

        private void MantissaChanged (string mantissa, string exponent, Number value)
        {
            display.ShowNumeric (mantissa, exponent);
        }

        private void NumberCancelled ()
        {
            display.Formatter.Value = 0.0M;
        }

        private void NumberDone (string mantissa, string exponent, Number value)
        {

            // Note that the stack also handles this event, but as far as I can tell the order of
            // notification doesn't matter.
            try
            {
                inNumberDone = true;
                display.Formatter.Value = value;

                if (MustTrace)
                {

                    // This code implements the special case described on page 41 of the
                    // documentation: in Fixed format if no exponent was typed and no truncation
                    // happened but the decimal point does not align, then add trailing zeros if
                    // necessary.  This is *not* printing using the fixed format, though, as no
                    // leading zero is added if the input started with a period.
                    // Otherwise print the raw input.  Note that DISPLAY_X always prints the raw
                    // input.

                    bool hasExponent = exponent != new string (' ', exponent.Length);
                    int mantissaAft = mantissa.TrimEnd ().Length - mantissa.IndexOf ('.') - 1;

                    if (!inDisplayX &&
                        printer.Formatter.Format == Number.DisplayFormat.Fixed &&
                        !hasExponent &&
                        printer.Formatter.Digits > mantissaAft)
                    {
                        printer.PrintNumeric(mantissa.TrimEnd() + 
                                             new String('0', printer.Formatter.Digits - mantissaAft), 
                                             exponent);
                    }
                    else
                    {
                        printer.PrintNumeric(mantissa.TrimEnd(), exponent);
                    }
                }
            }
            finally
            {
                inNumberDone = false;
            }
        }

        private void NumberPeek (string mantissa, string exponent, Number value)
        {
            printer.PrintNumeric ();
        }

        private void NumberStarted ()
        {
            // The HP-35 allows the user to press the CHS sign before or during number entry.  If a
            // number is in the display as a result of something other than digit entry, pressing
            // CHS negates it, but if the CHS key is then followed by a digit, the calculator
            // assumes the CHS was actually meant for the following entry.  Thus the previous number
            // displayed is pushed onto the stack without the (already displayed) sign change.  (See
            // Museum of HP Calculators.)
            doWeirdCHS = reader.Model == CalculatorModel.HP35 &&
                         previousSymbol == SymbolConstants.SYMBOL_CHS;
            if (doWeirdCHS)
            {
                // Undo the "normal" CHS.
                stack.X = -stack.X;
            }
            EnterIfNeeded ();
        }

        private void ReadFromDataset (CardDataset cds, Reader reader)
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

        private void WriteToDataset (CardDataset cds, CardPart part)
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

        private void ClobberTIf (bool needed)
        {
            // The HP-35 uses the T register to compute the trigonometric functions (see Operating
            // Manual p. 17).
            if (needed)
            {
                stack.T = stack.Z;
            }
        }

        private void EnterIfNeeded ()
        {
            if (stackLift)
            {
                stack.Enter ();
            }
        }

        private Number Factorial (Number n)
        {
            Number factorial;
            for (factorial = 1.0M; n > 1; n--)
            {
                factorial = factorial * n;
            }
            return factorial;
        }

        private Number FromRadian (Number angle)
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
                    return 0.0M;
            }
        }

        private Number ToH (Number x)
        {
            Number absX = Number.Abs (x);
            int h = Number.Floor (absX);
            int m = Number.Floor ((absX - h) * 100.0M);
            Number s = (absX - h - m / 100.0M) * 10000.0M;
            if (x < 0.0M)
            {
                return -h - m / 60.0M - s / 3600.0M;
            }
            else
            {
                return h + m / 60.0M + s / 3600.0M;
            }
        }

        private Number ToHMS (Number x)
        {
            Number absX = Number.Abs (x);
            int h = Number.Floor (absX);
            int m = Number.Floor ((absX - h) * 60.0M);
            Number s = (absX - h - m / 60.0M) * 3600.0M;
            if (x < 0.0M)
            {
                return -h - m / 100.0M - s / 10000.0M;
            }
            else
            {
                return h + m / 100.0M + s / 10000.0M;
            }
        }

        private Number ToRadian (Number angle)
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
                    return 0.0M;
            }
        }

        #endregion

        #region Public Properties

        public bool MustTrace
        {
            get
            {
                return printer != null &&
                       (inDisplayX ||
                        (modes.tracing != EngineModes.Tracing.Manual &&
                         !(running && modes.tracing == EngineModes.Tracing.Normal)));
            }
        }

        #endregion

        #region Public Operations

        public EngineModes.Execution ExecutionMode
        {
            set
            {
                modes.execution = value;
                switch (modes.execution)
                {
                    case EngineModes.Execution.Run:
                        display.Mode = DisplayMode.Numeric;
                        break;
                    case EngineModes.Execution.WriteProgram:
                        display.Mode = DisplayMode.Instruction;
                        break;
                }
            }
        }

        public EngineModes.Tracing TracingMode
        {
            set
            {
                modes.tracing = value;
            }
        }

        public void Execute (Instruction instruction)
        {
            try
            {
                bool neutral = stackLift;
                Number x, y;

                Trace.WriteLineIf (classTraceSwitch.TraceInfo,
                    "Execute: " + instruction.PrintableText,
                    classTraceSwitch.DisplayName);

                // Most operations terminate digit entry.  The only ones that don't are those that
                // are used to construct digits, and SST which does not change the state of the
                // engine at all.
                switch ((SymbolConstants) instruction.Symbol.Id)
                {
                    case SymbolConstants.SYMBOL_CL_PRGM:
                    case SymbolConstants.SYMBOL_DEL:
                    case SymbolConstants.SYMBOL_DIGIT:
                    case SymbolConstants.SYMBOL_EEX:
                    case SymbolConstants.SYMBOL_MERGE:
                    case SymbolConstants.SYMBOL_PERIOD:
                    case SymbolConstants.SYMBOL_SPACE:
                    case SymbolConstants.SYMBOL_SST:
                        // These functions do not interrupt digit entry (they are a subset of those
                        // documented as "not affecting the stack" on page 293 of the HP-97 manual). 
                        // Their list was determined experimentally on the HP-67 calculator.
                        //TODO: It seems that we should be tracing the instruction when running/
                        // stepping.
                        break;
                    case SymbolConstants.SYMBOL_CHS:
                    case SymbolConstants.SYMBOL_CLX:
                        // These functions do not trace when they happen as part of digit entry.
                        // In all cases, they don't trace the number.
                        if (MustTrace && !validater.EnteringNumber)
                        {
                            if (running || stepping)
                            {
                                program.PrintStep ();
                            }
                            printer.PrintInstruction (instruction, /*showKeycodes*/ false);
                        }
                        break;
                    case SymbolConstants.SYMBOL_GTO_PERIOD:
                    case SymbolConstants.SYMBOL_PRINT_PRGM:
                        // Do not trace those.
                        validater.DoneEntering ();
                        break;
                    case SymbolConstants.SYMBOL_DISPLAY_X:
                        // This one traces the contents of X in raw mode.  So it will only terminate
                        // digit entry later.  Also, it only prints the instruction if executing.
                        if (MustTrace && (running || stepping))
                        {
                            program.PrintStep ();
                            printer.PrintInstruction (instruction, /*showKeycodes*/ false);
                        }
                        break;
                    default:
                        validater.DoneEntering ();
                        if (MustTrace)
                        {
                            if (running || stepping)
                            {
                                program.PrintStep ();
                            }
                            printer.PrintInstruction (instruction, /*showKeycodes*/ false);
                        }
                        break;
                }

                switch ((SymbolConstants) instruction.Symbol.Id)
                {
                    case SymbolConstants.SYMBOL_ABS:
                        stack.Get (out x);
                        stack.X = Number.Abs (x);
                        break;
                    case SymbolConstants.SYMBOL_ADDITION:
                        stack.Get (out x, out y);
                        stack.X = y + x;
                        break;
                    case SymbolConstants.SYMBOL_ARCCOS:
                        stack.Get (out x);
                        if (Number.Abs (x) > 1.0M)
                        {
                            throw new Error ();
                        }
                        else
                        {
                            stack.X = FromRadian (Number.Acos (x));
                            ClobberTIf (reader.Model == CalculatorModel.HP35);
                        }
                        break;
                    case SymbolConstants.SYMBOL_ARCSIN:
                        stack.Get (out x);
                        if (Number.Abs (x) > 1.0M)
                        {
                            throw new Error ();
                        }
                        else
                        {
                            stack.X = FromRadian (Number.Asin (x));
                            ClobberTIf (reader.Model == CalculatorModel.HP35);
                        }
                        break;
                    case SymbolConstants.SYMBOL_ARCTAN:
                        stack.Get (out x);
                        stack.X = FromRadian (Number.Atan (x));
                        ClobberTIf (reader.Model == CalculatorModel.HP35);
                        break;
                    case SymbolConstants.SYMBOL_BST:
                        // Does nothing, moved backward on MouseDown.
                        break;
                    case SymbolConstants.SYMBOL_CF:
                        flags [((Digit) instruction.Arguments [0]).Value] = false;
                        break;
                    case SymbolConstants.SYMBOL_CHS:
                        if (validater.EnteringNumber)
                        {
                            validater.ChangeSign ();
                        }
                        else
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
                    case SymbolConstants.SYMBOL_CLR:
                        stack.X = 0.0M;
                        stack.Enter ();
                        stack.Enter ();
                        stack.Enter ();
                        memory.Clear ();
                        break;
                    case SymbolConstants.SYMBOL_CLX:
                        if (validater.EnteringNumber)
                        {
                            validater.Cancel ();
                        }
                        else
                        {
                            stack.X = 0.0M;
                        }
                        break;
                    case SymbolConstants.SYMBOL_COS:
                        stack.Get (out x);
                        stack.X = Number.Cos (ToRadian (x));
                        ClobberTIf (reader.Model == CalculatorModel.HP35);
                        break;
                    case SymbolConstants.SYMBOL_DEG:
                        unit = AngleUnit.Degree;
                        break;
                    case SymbolConstants.SYMBOL_DEL:
                        // Cancel the h key.
                        break;
                    case SymbolConstants.SYMBOL_DIGIT:
                        validater.EnterDigit (((Digit) instruction.Arguments [0]).Value);
                        if (!running)
                        {
                            // Flag 3 is the data entry flag.
                            flags [3] = true;
                        }
                        break;
                    case SymbolConstants.SYMBOL_DISPLAY_X:
                        try
                        {
                            inDisplayX = true;
                            switch (reader.Model)
                            {
                                case CalculatorModel.HP67:
                                    display.PauseAndBlink (/* count */ 8,
                                        /* msPeriod */ 5000 / 8);
                                    break;
                                case CalculatorModel.HP97:
                                    validater.DoneEnteringOrPeek ();
                                    printer.PrintEndMarker ();
                                    break;
                            }
                        }
                        finally
                        {
                            inDisplayX = false;
                        }
                        break;
                    case SymbolConstants.SYMBOL_DIVISION:
                        stack.Get (out x, out y);
                        if (x == 0.0M)
                        {
                            throw new Error ();
                        }
                        else
                        {
                            stack.X = y / x;
                        }
                        break;
                    case SymbolConstants.SYMBOL_DSP:
                        IDigits argument = ((IDigits) instruction.Arguments [0]);

                        // Change the printer first because the display will trigger reprint.
                        if (printer != null)
                        {
                            argument.SetDigits (memory, printer.Formatter);
                        }
                        argument.SetDigits (memory, display.Formatter);
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
                        validater.EnterExponent ();
                        break;
                    case SymbolConstants.SYMBOL_ENG:

                        // Change the printer first because the display will trigger reprint.
                        if (printer != null)
                        {
                            printer.Formatter.Format = Number.DisplayFormat.Engineering;
                        }
                        display.Formatter.Format = Number.DisplayFormat.Engineering;
                        break;
                    case SymbolConstants.SYMBOL_ENTER:
                        stack.Enter ();
                        break;
                    case SymbolConstants.SYMBOL_EXP:
                        stack.Get (out x);
                        stack.X = Number.Exp (x);
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
                        if (x >= 0.0M && x == Number.Floor (x))
                        {
                            stack.X = Factorial (x);
                        }
                        else
                        {
                            throw new Error ();
                        }
                        break;
                    case SymbolConstants.SYMBOL_FIX:

                        // Change the printer first because the display will trigger reprint.
                        if (printer != null)
                        {
                            printer.Formatter.Format = Number.DisplayFormat.Fixed;
                        }
                        display.Formatter.Format = Number.DisplayFormat.Fixed;
                        break;
                    case SymbolConstants.SYMBOL_FRAC:
                        stack.Get (out x);
                        if (x < 0.0M)
                        {
                            stack.X = x + Number.Floor (-x);
                        }
                        else
                        {
                            stack.X = x - Number.Floor (x);
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
                        if (x < 0.0M)
                        {
                            stack.X = -Number.Floor (-x);
                        }
                        else
                        {
                            stack.X = Number.Floor (x);
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
                        if (x <= 0.0M)
                        {
                            throw new Error ();
                        }
                        else
                        {
                            stack.X = Number.Log (x);
                        }
                        break;
                    case SymbolConstants.SYMBOL_LOG:
                        stack.Get (out x);
                        if (x <= 0.0M)
                        {
                            throw new Error ();
                        }
                        else
                        {
                            stack.X = Number.Log10 (x);
                        }
                        break;
                    case SymbolConstants.SYMBOL_LST_X:
                        stack.Enter ();
                        stack.X = stack.LastX;
                        break;
                    case SymbolConstants.SYMBOL_MERGE:
                        {
                            ProgrammableCalculator form =
                                (ProgrammableCalculator) display.TopLevelControl;
                            FileStream stream = (FileStream) form.Invoke
                                (new Execution.Thread.CrossThreadFileOperation
                                    (form.CrossThreadOpen));
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
                        stack.X = stack.Y * x / 100.0M;
                        break;
                    case SymbolConstants.SYMBOL_PERCENT_CHANGE:
                        stack.Get (out x, out y);
                        if (y == 0.0M)
                        {
                            throw new Error ();
                        }
                        else
                        {
                            stack.X = (x - y) * 100.0M / y;
                        }
                        break;
                    case SymbolConstants.SYMBOL_PERIOD:
                        validater.EnterPeriod ();
                        break;
                    case SymbolConstants.SYMBOL_PI:
                        EnterIfNeeded ();
                        stack.X = Number.π;
                        break;
                    case SymbolConstants.SYMBOL_PRINT_PRGM:
                        program.PrintProgram
                            (/*showKeycodes*/ modes.tracing == EngineModes.Tracing.Manual);
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
                    case SymbolConstants.SYMBOL_RCL:
                        EnterIfNeeded ();
                        stack.X = ((IAddress) instruction.Arguments [0]).Recall (memory);
                        break;
                    case SymbolConstants.SYMBOL_RCL_NULLARY:
                        EnterIfNeeded ();
                        // Simulated with memory 0.
                        stack.X = new Digit (0).Recall (memory);
                        break;
                    case SymbolConstants.SYMBOL_RCL_SIGMA_PLUS:
                        stack.Get (out x);
                        memory.RecallΣPlus (out x, out y);
                        stack.X = x;
                        stack.Y = y;
                        break;
                    case SymbolConstants.SYMBOL_RECIPROCAL:
                        stack.Get (out x);
                        if (x == 0.0M)
                        {
                            throw new Error ();
                        }
                        else
                        {
                            stack.X = 1.0M / x;
                        }
                        break;
                    case SymbolConstants.SYMBOL_REG:
                        switch (reader.Model)
                        {
                            case CalculatorModel.HP67:
                                memory.Display ();
                                break;
                            case CalculatorModel.HP97:
                                // The output is surrounded by spaces, see p. 210.
                                printer.Advance ();
                                memory.Print ();
                                printer.Advance ();
                                break;
                        }
                        break;
                    case SymbolConstants.SYMBOL_RND:
                        stack.Get (out x); // To set Last X.

                        // Change the printer first because the display will trigger reprint.
                        if (printer != null)
                        {
                            printer.Formatter.Value = printer.Formatter.RoundedValue;
                        }
                        stack.X = display.Formatter.RoundedValue;
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

                        // Change the printer first because the display will trigger reprint.
                        if (printer != null)
                        {
                            printer.Formatter.Format = Number.DisplayFormat.Scientific;
                        }
                        display.Formatter.Format = Number.DisplayFormat.Scientific;
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
                        stack.X = Number.Sin (ToRadian (x));
                        ClobberTIf (reader.Model == CalculatorModel.HP35);
                        break;
                    case SymbolConstants.SYMBOL_SPACE:
                        switch (reader.Model)
                        {
                            case CalculatorModel.HP67:
                                break;
                            case CalculatorModel.HP97:
                                printer.Advance ();
                                break;
                        }
                        break;
                    case SymbolConstants.SYMBOL_SQRT:
                        stack.Get (out x);
                        if (x < 0.0M)
                        {
                            throw new Error ();
                        }
                        else
                        {
                            stack.X = Number.Sqrt (x);
                        }
                        break;
                    case SymbolConstants.SYMBOL_SQUARE:
                        stack.Get (out x);
                        stack.X = x * x;
                        break;
                    case SymbolConstants.SYMBOL_SST:
                        break;
                    case SymbolConstants.SYMBOL_STK:
                        switch (reader.Model)
                        {
                            case CalculatorModel.HP67:
                                stack.Display ();
                                break;
                            case CalculatorModel.HP97:
                                // The output is surrounded by spaces, see p. 210.
                                printer.Advance ();
                                stack.Print ();
                                printer.Advance ();
                                break;
                        }
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
                    case SymbolConstants.SYMBOL_STO_NULLARY:
                        EnterIfNeeded ();
                        // Simulated with memory 0.
                        new Digit (0).Store (memory, stack.X);
                        break;
                    case SymbolConstants.SYMBOL_SUBTRACTION:
                        stack.Get (out x, out y);
                        stack.X = y - x;
                        break;
                    case SymbolConstants.SYMBOL_TAN:
                        stack.Get (out x);
                        stack.X = Number.Tan (ToRadian (x));
                        ClobberTIf (reader.Model == CalculatorModel.HP35);
                        break;
                    case SymbolConstants.SYMBOL_TEN_TO_THE_XTH:
                        stack.Get (out x);
                        stack.X = Number.Pow (10.0M, x);
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
                        stack.X = Number.Sqrt (x * x + y * y);
                        stack.Y = FromRadian (Number.Atan2 (y, x));
                        break;
                    case SymbolConstants.SYMBOL_TO_RADIANS:
                        stack.Get (out x);
                        stack.X = x * degreeToRadian;
                        break;
                    case SymbolConstants.SYMBOL_TO_RECTANGULAR:
                        Number θ = stack.Y;
                        Number r;
                        stack.Get (out r);
                        stack.X = r * Number.Cos (ToRadian (θ));
                        stack.Y = r * Number.Sin (ToRadian (θ));
                        break;
                    case SymbolConstants.SYMBOL_W_DATA:
                        {
                            ProgrammableCalculator form =
                                (ProgrammableCalculator) display.TopLevelControl;
                            FileStream stream =
                                (FileStream) form.Invoke
                                    (new Execution.Thread.CrossThreadFileOperation
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
                        }
                        break;
                    case SymbolConstants.SYMBOL_X_AVERAGE:
                        stack.Get (out x);
                        memory.X̄ (out x, out y);
                        stack.X = x;
                        stack.Y = y;
                        break;
                    case SymbolConstants.SYMBOL_X_EQ_0:
                        if (stack.X != 0.0M)
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
                        Number i = memory.Recall (Memory.LetterRegister.I);
                        memory.Store (stack.X, Memory.LetterRegister.I);
                        stack.X = i;
                        break;
                    case SymbolConstants.SYMBOL_X_EXCHANGE_Y:
                        stack.XExchangeY ();
                        break;
                    case SymbolConstants.SYMBOL_X_GT_0:
                        if (stack.X <= 0.0M)
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
                        if (stack.X >= 0.0M)
                        {
                            program.Skip ();
                        }
                        break;
                    case SymbolConstants.SYMBOL_X_NE_0:
                        if (stack.X == 0.0M)
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
                    case SymbolConstants.SYMBOL_X_TO_THE_YTH:
                        stack.Get (out x, out y);
                        if (x == 0.0M && y <= 0.0M)
                        {
                            throw new Error ();
                        }
                        else if (x < 0 && y != Number.Floor (y))
                        {
                            throw new Error ();
                        }
                        else
                        {
                            stack.X = Number.Pow (x, y);
                        }
                        break;
                    case SymbolConstants.SYMBOL_Y_TO_THE_XTH:
                        stack.Get (out x, out y);
                        if (y == 0.0M && x <= 0.0M)
                        {
                            throw new Error ();
                        }
                        else if (y < 0.0M && x != Number.Floor (x))
                        {
                            throw new Error ();
                        }
                        else
                        {
                            stack.X = Number.Pow (y, x);
                        }
                        break;
                    default:
                        throw new Error ();
                }

                // The HP-35 weird CHS.  See the comments in NumberStarted.
                if (doWeirdCHS)
                {
                    validater.ChangeSign ();
                }

                // Set the stack lift as specified in Appendix D of the Programming Guide.
                switch ((SymbolConstants) instruction.Symbol.Id)
                {
                    case SymbolConstants.SYMBOL_SST:
                        // Don't change the stack lift, not even to neutral: the necessary changes
                        // have been done by the instruction called by SST.
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

                // Now check if some key was typed while we were executing the instruction.  If it
                // was, stop the computation.  Note that this is done synchronously to make sure
                // that we can resume execution with the proper state if the user types R/S again. 
                // We don't do it if we have stopped our work, because we are going to return to the
                // main execution loop very soon anyway, and if the user types, say, two digits in
                // quick succession we do not want the second to cause an interruption.
                if ((running || stepping) && WaitForKeystroke (0))
                {
                    throw new Interrupt ();
                }
            }
            finally
            {
                doWeirdCHS = false;
                previousSymbol = (SymbolConstants) instruction.Symbol.Id;
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
                    "Process: Exception " +
                    (running ? "while running" : "") +
                    (stepping ? "while stepping" : "") + e.ToString (),
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

            switch (modes.execution)
            {
                case EngineModes.Execution.Run:
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

                case EngineModes.Execution.WriteProgram:
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
                                case SymbolConstants.SYMBOL_SST:
                                    program.GotoRelative (+1);
                                    break;
                                case SymbolConstants.SYMBOL_GTO_PERIOD:
                                case SymbolConstants.SYMBOL_PRINT_PRGM:
                                    Execute (instruction);
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