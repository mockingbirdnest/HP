using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Mockingbird.HP.Class_Library
{
    public static partial class Number
    {
        public enum DisplayFormat
        {
            Engineering,
            Fixed,
            Scientific
        }

        public class Formatter
        {

            #region Private Data

            private const sbyte overflowExponent = 99;
            private const double overflowMantissa = 9.999999999;
            private const double overflowLimit = 9.999999999E99;
            private const double underflowLimit = 1.0E-99;

            private const string exponentMetaTemplate = "*00;-00";
            private const string fixUnderflowOverflowMantissaTemplate = " 0.000000000;-0.000000000";

            private string engMantissaTemplate1;
            private string engMantissaTemplate10;
            private string engMantissaTemplate100;
            private string exponentTemplate;
            private string fixMantissaTemplate;
            private string sciMantissaTemplate;

            private byte digits;
            private DisplayFormat format;
            private bool padMantissa;

            private bool fixedUnderflowOverflow;
            private bool overflows;

            private sbyte exponent;
            private double mantissa;

            #endregion

            #region Event Declarations

            public event ChangeEvent FormattingChanged;

            #endregion

            #region Constructors & Destructors

            public Formatter
                (byte digits, DisplayFormat format, bool padMantissa, bool showPlusSignInExponent)
            {
                // Assign *before* calling Digits/Format below.
                this.padMantissa = padMantissa;
                if (showPlusSignInExponent)
                {
                    exponentTemplate = "+" + exponentMetaTemplate.Substring (1);
                }
                else
                {
                    exponentTemplate = " " + exponentMetaTemplate.Substring (1);
                }

                Digits = digits;
                Format = format;
            }

            #endregion

            #region Event Handlers

            public void WriteToDataset (CardDataset cds, CardPart part)
            {
                if (part == CardPart.Program)
                {
                    CardDataset.DisplayRow dr;

                    for (int i = 0; i < cds.Display.Count; i++)
                    {
                        cds.Display.RemoveDisplayRow (cds.Display [i]);
                    }
                    dr = cds.Display.NewDisplayRow ();
                    dr.Digits = digits;
                    dr.Format = format.ToString ();
                    dr.CardRow = cds.Card [0];
                    cds.Display.AddDisplayRow (dr);
                }
            }

            public void ReadFromDataset (CardDataset cds, Reader reader)
            {
                CardDataset.CardRow cr;
                CardDataset.DisplayRow dr;
                CardDataset.DisplayRow [] drs;

                cr = cds.Card [0];
                drs = cr.GetDisplayRows ();
                if (drs.Length > 0)
                {
                    dr = drs [0];
                    Digits = dr.Digits;
                    Format = (DisplayFormat) Enum.Parse (typeof (DisplayFormat), dr.Format);
                }
            }

            #endregion

            #region Private Operations

            private void Split (double x)
            {
                double absX = Math.Abs (x);
                double log10;

                // Deal with possible underflow or overflow.
                overflows = false;
                if (absX > overflowLimit)
                {
                    exponent = 0;
                    if (x > 0.0)
                    {
                        mantissa = double.PositiveInfinity;
                    }
                    else
                    {
                        mantissa = double.NegativeInfinity;
                    }
                    overflows = true;
                    return;
                }

                if (absX < underflowLimit)
                {
                    exponent = 0;
                    x = 0;
                }
                else
                {

                    // Compute the exponent in base 10, so that the mantissa has one digit before
                    // the decimal point.
                    log10 = Math.Log10 (absX);
                    if (log10 >= 0.0)
                    {
                        exponent = (sbyte) Math.Floor (log10);
                    }
                    else
                    {
                        exponent = (sbyte) (-Math.Ceiling (-log10));
                    }
                }

                // Adjust the computed exponent based on the display format, and determine if the
                // fixed format underflows or overflows.
                fixedUnderflowOverflow = false;
                switch (format)
                {
                    case DisplayFormat.Engineering:
                        {
                            if (exponent % 3 != 0)
                            {
                                exponent = (sbyte) (exponent - (exponent % 3) - (exponent >= 0 ? 0 : 3));
                            }
                            break;
                        }
                    case DisplayFormat.Fixed:
                        {
                            if (exponent < -digits - 1 || exponent > 9)
                            {
                                fixedUnderflowOverflow = true;
                            }
                            else if (exponent == -digits - 1)
                            {
                                // A subtlety here.  If digits is, say, 2, the values ±0.005 round to
                                // ±0.01, but the values ±0.004 underflow.
                                if (absX < 0.5 * Math.Pow (10, -digits))
                                {
                                    fixedUnderflowOverflow = true;
                                }
                            }
                            if (!fixedUnderflowOverflow)
                            {
                                exponent = 0;
                            }
                            break;
                        }
                    case DisplayFormat.Scientific:
                        {
                            break;
                        }
                }
                mantissa = x / Math.Pow (10, exponent);
            }

            #endregion

            #region Private Properties

            private string Exponent
            {
                get
                {
                    if (overflows)
                    {
                        return overflowExponent.ToString
                            (exponentTemplate, NumberFormatInfo.InvariantInfo);
                    }
                    else if (exponent == 0 && format == DisplayFormat.Fixed)
                    {
                        return new String (' ', exponentSignLength + exponentLength);
                    }
                    else
                    {
                        return exponent.ToString (exponentTemplate, NumberFormatInfo.InvariantInfo);
                    }
                }
            }

            private string Mantissa
            {
                get
                {
                    if (overflows)
                    {
                        if (mantissa > 0.0)
                        {
                            return overflowMantissa.ToString (fixUnderflowOverflowMantissaTemplate,
                                                                NumberFormatInfo.InvariantInfo);
                        }
                        else
                        {
                            return (-overflowMantissa).ToString (fixUnderflowOverflowMantissaTemplate,
                                                                NumberFormatInfo.InvariantInfo);
                        }
                    }
                    else
                    {
                        switch (format)
                        {
                            case DisplayFormat.Engineering:
                                {
                                    double absMantissa = Math.Abs (mantissa);

                                    if (absMantissa < 10.0)
                                    {
                                        return mantissa.ToString
                                            (engMantissaTemplate1, NumberFormatInfo.InvariantInfo);
                                    }
                                    else if (absMantissa < 100.0)
                                    {
                                        return mantissa.ToString
                                            (engMantissaTemplate10, NumberFormatInfo.InvariantInfo);
                                    }
                                    else
                                    {
                                        Trace.Assert (absMantissa < 1000.0);
                                        return mantissa.ToString
                                            (engMantissaTemplate100, NumberFormatInfo.InvariantInfo);
                                    }
                                }
                            case DisplayFormat.Fixed:
                                {
                                    if (fixedUnderflowOverflow)
                                    {
                                        return mantissa.ToString (fixUnderflowOverflowMantissaTemplate,
                                                                NumberFormatInfo.InvariantInfo);
                                    }
                                    else
                                    {
                                        string m = mantissa.ToString
                                            (fixMantissaTemplate, NumberFormatInfo.InvariantInfo);
                                        return m.Substring
                                            (mantissaSignFirst,
                                             Math.Min (m.Length,
                                                       mantissaSignLength + mantissaLength));
                                    }
                                }
                            case DisplayFormat.Scientific:
                                {
                                    return mantissa.ToString
                                        (sciMantissaTemplate, NumberFormatInfo.InvariantInfo);
                                }
                            default:
                                {
                                    return ""; // To make the compiler happy.
                                }
                        }
                    }
                }
            }

            #endregion

            #region Public Operations

            public void Round (double x)
            {
                Split (x);
                mantissa = double.Parse (Mantissa);
                if (FormattingChanged != null)
                {
                    FormattingChanged (Mantissa, Exponent, Value); // Probably unnecessary, but...
                }
            }

            #endregion

            #region Public Properties

            public byte Digits
            {
                set
                {
                    string zeros;
                    string blanks;

                    Trace.Assert (value <= 9);
                    digits = value;
                    if (padMantissa)
                    {
                        blanks = new String (' ', 9 - value);
                    }
                    else
                    {
                        blanks = "";
                    }

                    if (value == 0)
                    {
                        // Make sure that we don't lose the period when the count is 0.
                        fixMantissaTemplate = " 0\\." + blanks + ";-0\\." + blanks;
                    }
                    else
                    {
                        zeros = new String ('0', value);
                        fixMantissaTemplate = " 0." + zeros + blanks + ";-0." + zeros + blanks;
                    }

                    // Engineering is weird because the Digits is the total number of digits
                    // displayed minus 1, regardless of the position of the decimal point.  Produce
                    // three templates corresponding to the three orders of magnitude of the mantissa
                    // in this format.
                    if (value <= 1)
                    {
                        engMantissaTemplate10 = " 00\\." + blanks + ";-00\\." + blanks;
                    }
                    else
                    {
                        zeros = new String ('0', value - 1);
                        engMantissaTemplate10 = " 00." + zeros + blanks + ";-00." + zeros + blanks;
                    }

                    if (value <= 2)
                    {
                        engMantissaTemplate100 = " 000\\." + blanks + ";-000\\." + blanks;
                    }
                    else
                    {
                        zeros = new String ('0', value - 2);
                        engMantissaTemplate100 = " 000." + zeros + blanks + ";-000." + zeros + blanks;
                    }

                    engMantissaTemplate1 = fixMantissaTemplate;
                    sciMantissaTemplate = fixMantissaTemplate;

                    Value = Value;
                    if (FormattingChanged != null)
                    {
                        FormattingChanged (Mantissa, Exponent, Value);
                    }
                }
            }

            public DisplayFormat Format
            {
                get
                {
                    return format;
                }
                set
                {
                    format = value;
                    Value = Value;
                    if (FormattingChanged != null)
                    {
                        FormattingChanged (Mantissa, Exponent, Value);
                    }
                }
            }

            public bool MustUseRaw
            {
                get
                {

                    // TODO: The test exponent != 0 is not really equivalent to "EEX was pressed".
                    // TODO: This will lose trailing zeros.
                    return format != Number.DisplayFormat.Fixed ||
                           overflows ||
                           exponent != 0 ||
                           fixedUnderflowOverflow;
               }
            }

            public double Value
            {
                set
                {
                    Split (value);
                    if (FormattingChanged != null)
                    {
                        FormattingChanged (Mantissa, Exponent, Value);
                    }
                }
                private get
                {
                    return mantissa * Math.Pow (10.0, exponent);
                }
            }

            #endregion
        }
    }
}
