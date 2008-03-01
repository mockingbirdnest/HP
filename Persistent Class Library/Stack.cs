using System;

namespace Mockingbird.HP.Class_Library
{
    /// <summary>
    /// Evaluation stack of an HP calculator.
    /// </summary>
    public class Stack
    {

        public enum Position
        {
            x = 0,
            y = 1,
            z = 2,
            t = 3
        }

        #region Private Data

        private IDisplay display;
        private Number lastX;
        private IPrinter printer;
        private Number [] stack;

        private Number.Validater validater;

        #endregion

        #region Contructors & Destructors

        public Stack (IDisplay display, IPrinter printer, Number.Validater validater)
        {
            this.display = display;
            this.printer = printer;
            this.validater = validater;
            this.validater.NumberDone += new Number.ChangeEvent (UpdateXFromValidater);

            stack = new Number [Position.t - Position.x + 1];
            lastX = 0.0M;

            for (int i = 0; i < stack.Length; i++)
            {
                stack [i] = 0.0M;
            }
        }

        #endregion

        #region Private Operations

        private Number this [Position p]
        {
            get
            {

                // Reading x always causes any number entry to be terminated.  This is done by
                // calling DoneEntering.  If a number entry was in progress, this will cause
                // UpdateXFromValidater to be called, thereby loading x from the validater. 
                // Otherwise, it is a no-op, and x is unaffected.
                if (p == Position.x)
                {
                    validater.DoneEntering ();
                }
                return stack [(int) p];
            }
            set
            {

                // Writing x only causes the display to be modified for a top-level call, see
                // property X.  We don't want all the stack management operation to trigger printer
                // tracing.
                stack [(int) p] = value;
            }
        }

        private void UpdateXFromValidater (string mantissa, string exponent, Number value)
        {
            stack [(int) Position.x] = value;
        }

        #endregion

        #region Public Properties

        public Number LastX
        {
            get
            {
                return lastX;
            }
        }

        public Number X
        {
            get
            {
                return this [Position.x];
            }
            set
            {
                this [Position.x] = value;

                // Update the display formatter.  This may in turn trigger printer tracing.
                display.Formatter.Value = value;
            }
        }

        public Number Y
        {
            get
            {
                return this [Position.y];
            }
            set
            {
                this [Position.y] = value;
            }
        }
        public Number Z
        {
            get
            {
                return this[Position.z];
            }
            set
            {
                this[Position.z] = value;
            }
        }
        public Number T
        {
            get
            {
                return this[Position.t];
            }
            set
            {
                this[Position.t] = value;
            }
        }

        #endregion

        #region Public Operations

        public void Enter ()
        {
            for (Position i = Position.t; i > Position.x; i--)
            {
                this [i] = this [i - 1];
            }
        }

        public void Display ()
        {
            for (Position p = Position.x; p <= Position.t; p++)
            {
                RollUp ();
                display.Pause (500);
            }
        }

        public void Get (out Number X)
        {
            X = this [Position.x];
            lastX = this [Position.x];
        }

        public void Get (out Number X, out Number Y)
        {
            X = this [Position.x];
            Y = this [Position.y];
            lastX = this [Position.x];
            for (Position i = Position.x; i < Position.t; i++)
            {
                this [i] = this [i + 1];
            }
        }

        public void Print ()
        {
            for (Position p = Position.t; p >= Position.x; p--)
            {
                printer.Formatter.Value = this [p];
                printer.PrintNumeric ();
                
                printer.PrintAddress (p);
            }
        }

        public void RollDown ()
        {
            Number temp;
            temp = this [Position.x];
            for (Position i = Position.x; i < Position.t; i++)
            {
                this [i] = this [i + 1];
            }
            this [Position.t] = temp;
            X = this [Position.x]; // Assign to X to force tracing.
        }

        public void RollUp ()
        {
            Number temp;
            temp = this [Position.t];
            for (Position i = Position.t; i > Position.x; i--)
            {
                this [i] = this [i - 1];
            }
            X = temp; // Assign to X, not this [x], to force tracing.
        }

        public void XExchangeY ()
        {
            Number temp;
            temp = this [Position.x];
            X = this [Position.y]; // Assign to X, not this [x], to force tracing.
            this [Position.y] = temp;
        }

        #endregion

    }
}
