using Mockingbird.HP.Parser;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Mockingbird.HP.Class_Library
{
    public partial struct Number
    {
        public class Validater
        {

            #region Private Data

            private bool enteringExponent;
            private bool enteringMantissa;
            private bool enteringNumber;
            private bool hasAPeriod;
            private bool isZero;
            private CalculatorModel model;

            // These fields include the respective signs.
            private string exponent;
            private string mantissa;

            #endregion

            #region Constructors & Destructors

            public Validater (CalculatorModel model)
            {
                this.model = model;
            }

            #endregion

            #region Event Definitions

            public event ChangeEvent ExponentChanged;
            public event ChangeEvent MantissaChanged;
            public event ChangeEvent NumberDone;
            public event ChangeEvent NumberPeek;
            public event ChangeEvent NumberStarted;

            #endregion

            #region Private Operations

            private bool IsSign (char s)
            {
                return s == minus || s == plus;
            }

            private char OtherSign (char s)
            {
                if (s == minus)
                {
                    return plus;
                }
                else if (s == plus)
                {
                    return minus;
                }
                else
                {
                    Trace.Assert (false);
                    return ' '; // To make the compiler happy.
                }
            }

            private void ReplaceExponentSign (char s)
            {
                Trace.Assert (IsSign (s));
                exponent = s + exponent.Substring (exponentFirst, exponentLength);
                if (ExponentChanged != null)
                {
                    ExponentChanged (mantissa, exponent, Value);
                }
            }

            private void ReplaceExponentWithoutSign (string e)
            {
                Trace.Assert (e.Length == exponentLength);
                exponent = exponent.Substring (exponentSignFirst, exponentSignLength) + e;
                if (ExponentChanged != null)
                {
                    ExponentChanged (mantissa, exponent, Value);
                }
            }

            private void ReplaceExponentWithSign (string e)
            {
                Trace.Assert (IsSign (e [exponentSignFirst]));
                Trace.Assert (e.Length == exponentSignLength + exponentLength);
                exponent = e;
                if (ExponentChanged != null)
                {
                    ExponentChanged (mantissa, exponent, Value);
                }
            }

            private void ReplaceMantissaSign (char s)
            {
                Trace.Assert (IsSign (s));
                mantissa = s + mantissa.Substring (mantissaFirst, mantissaLength);
                if (MantissaChanged != null)
                {
                    MantissaChanged (mantissa, exponent, Value);
                }
            }

            private void ReplaceMantissaWithoutSign (string m)
            {
                Trace.Assert (m.Length <= mantissaLength);
                mantissa = mantissa.Substring (mantissaSignFirst, mantissaSignLength) +
                            m.PadRight (mantissaLength);
                if (MantissaChanged != null)
                {
                    MantissaChanged (mantissa, exponent, Value);
                }
            }

            private void ReplaceMantissaWithSign (string m)
            {
                Trace.Assert (IsSign (m [mantissaSignFirst]));
                Trace.Assert (m.Length <= mantissaSignLength + mantissaLength);
                mantissa = m.PadRight (mantissaSignLength + mantissaLength);
                if (MantissaChanged != null)
                {
                    MantissaChanged (mantissa, exponent, Value);
                }
            }

            private void StartEnteringNumber ()
            {
                if (NumberStarted != null)
                {
                    // Notify whoever is interested that we are starting to enter a number.
                    NumberStarted (mantissa, exponent, Value);
                }
                enteringNumber = true;
                enteringMantissa = true;
                enteringExponent = false;
                hasAPeriod = false;
                isZero = true;
                ReplaceExponentWithSign (new String (' ', exponentSignLength + exponentLength));
            }

            #endregion

            #region Private Properties

            private Number Value
            {
                get
                {
                    if (enteringExponent)
                    {
                        return new Number (decimal.Parse (mantissa, NumberFormatInfo.InvariantInfo),
                                           sbyte.Parse (exponent, NumberFormatInfo.InvariantInfo));
                    }
                    else
                    {
                        try
                        {
                            return decimal.Parse (mantissa, NumberFormatInfo.InvariantInfo);
                        }
                        catch
                        {
                            // This may happen: (1) if mantissa is null or (2) if mantissa doesn't
                            // parse, e.g. because it's " .       ".
                            return 0.0M;
                        }
                    }
                }
            }

            #endregion

            #region Public Operations

            public void ChangeSign (out bool done)
            {
                char sign;

                // Apologies: this is not ideal.  The CHS key can be used either (1) when entering a
                // number, in the mantissa or the exponent or (2) when a number has been entered, as
                // a normal transformation.  This method is only concerned with entering numbers, so
                // if it detects that we are not entering a number it sets done to false to indicate
                // that it didn't do its duty.  Clients will have to cope.
                if (enteringNumber)
                {
                    // On the HP-35 the sequence period-CHS produces -. but not on the other models.
                    // See HP-35 Operating Manual, p. 14.
                    if (!isZero || (model == CalculatorModel.HP35))
                    {
                        if (enteringMantissa)
                        {
                            sign = mantissa [mantissaSignFirst];
                        }
                        else
                        {
                            Trace.Assert (enteringExponent);
                            sign = exponent [exponentSignFirst];
                        }
                        sign = OtherSign (sign);
                        if (enteringMantissa)
                        {
                            ReplaceMantissaSign (sign);
                        }
                        else
                        {
                            Trace.Assert (enteringExponent);
                            ReplaceExponentSign (sign);
                        }
                    }
                    done = true;
                }
                else
                {
                    done = false;
                }
            }

            public void DoneEntering ()
            {
                if (enteringNumber)
                {
                    enteringNumber = false;
                    if (NumberDone != null)
                    {
                        NumberDone (mantissa, exponent, Value);
                    }
                }
            }

            public void DoneEnteringOrPeek ()
            {
                if (enteringNumber)
                {
                    enteringNumber = false;
                    if (NumberDone != null)
                    {
                        NumberDone (mantissa, exponent, Value);
                    }
                }
                else
                {
                    if (NumberPeek != null)
                    {
                        NumberPeek (mantissa, exponent, Value);
                    }
                }
            }

            public void EnterDigit (byte b)
            {
                string d = b.ToString ().Trim ();

                if (enteringNumber && enteringExponent)
                {
                    string e = exponent.Substring
                                    (exponentSignFirst + exponentSignLength, exponentLength);

                    if (e.Length == exponentLength)
                    {
                        e = e.Substring (1, exponentLength - 1) + d;
                    }
                    else
                    {
                        e += d;
                    }
                    ReplaceExponentWithoutSign (e);
                }
                else
                {
                    string m;

                    if (!enteringNumber)
                    {
                        StartEnteringNumber ();
                        m = plus + d + period;
                    }
                    else
                    {
                        Trace.Assert (enteringMantissa);
                        m = mantissa.Substring
                            (mantissaSignFirst, mantissaSignLength + mantissaLength).TrimEnd (null);
                        if (m.Length == mantissaSignLength + mantissaLength)
                        {
                            // Extraneous digits are simply ignored.
                            return;
                        }
                        if (hasAPeriod)
                        {
                            m += d;
                        }
                        else
                        {
                            Trace.Assert (m [m.Length - 1] == period);
                            m = m.Substring (0, m.Length - 1) + d + period;
                        }
                    }
                    if (b != 0)
                    {
                        isZero = false;
                    }
                    ReplaceMantissaWithSign (m);
                }
            }

            public void EnterExponent ()
            {
                if (!enteringNumber)
                {
                    EnterDigit (1);
                    EnterPeriod ();
                }
                Trace.Assert (enteringNumber);
                if (!enteringExponent)
                {
                    enteringMantissa = false;
                    enteringExponent = true;
                    ReplaceExponentWithSign (plus + new String ('0', exponentLength));
                }
            }

            public void EnterPeriod ()
            {
                if (!enteringNumber)
                {
                    StartEnteringNumber ();
                    ReplaceMantissaWithSign (" " + period);
                }
                hasAPeriod = true;
            }

            #endregion
        }
    }
}
