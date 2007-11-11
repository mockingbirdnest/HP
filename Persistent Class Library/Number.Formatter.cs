using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Mockingbird.HP.Class_Library
{
    public partial struct Number
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

            private char [] decimalDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            private const sbyte overflowExponent = 99;
            private const decimal overflowMantissa = 9.999999999M;
            private const sbyte underflowExponent = -99;
            private const decimal underflowMantissa = 1.0M;

            private const string exponentMetaTemplate = "*00;-00";
            private const string fixUnderflowOverflowMantissaTemplate = " 0.000000000;-0.000000000";

            private string engMantissaTemplate1;
            private string engMantissaTemplate10;
            private string engMantissaTemplate100;
            private string exponentTemplate;
            private string fixMantissaTemplateD;
            private string fixMantissaTemplateDPlus1;
            private string sciMantissaTemplate;

            private byte digits;
            private sbyte fixedUnderflowExponentThreshold;
            private DisplayFormat format;
            private bool hasExtraDigitBetween0And1;
            private bool padMantissa;
            private bool stripZeros;

            private bool fixedUnderflowOverflow;
            private bool overflows;

            private Number formatted; // Beware!  Not normalized!

            #endregion

            #region Event Declarations

            public event ChangeEvent FormattingChanged;

            #endregion

            #region Constructors & Destructors

            public Formatter (byte digits,
                            DisplayFormat format,
                            sbyte fixedUnderflowExponentThreshold,
                            bool hasExtraDigitBetween0And1,
                            bool padMantissa,
                            bool showPlusSignInExponent,
                            bool stripZeros)
            {
                // Assign *before* calling Digits/Format below.
                this.fixedUnderflowExponentThreshold = fixedUnderflowExponentThreshold;
                this.hasExtraDigitBetween0And1 = hasExtraDigitBetween0And1;
                this.padMantissa = padMantissa;
                this.stripZeros = stripZeros;
                if (showPlusSignInExponent)
                {
                    exponentTemplate = "+" + exponentMetaTemplate.Substring (1);
                }
                else
                {
                    exponentTemplate = " " + exponentMetaTemplate.Substring (1);
                }
                formatted = 0.0M;
                Digits    = digits;
                Format    = format;
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

            private void Split (Number x)
            {
                Number absX  = Abs (x);
                Number large = new Number (overflowMantissa, overflowExponent);
                Number small = new Number (underflowMantissa, underflowExponent);

                // Deal with possible underflow or overflow.
                fixedUnderflowOverflow = false;
                overflows = false;
                if (absX > large)
                {
                    if (x > 0.0M)
                    {
                        formatted = large;
                    }
                    else
                    {
                        formatted = -large;
                    }
                    overflows = true;
                    return;
                }

                if (absX < small)
                {
                    formatted = 0.0M;
                    return;
                }
                else
                {

                    // The exponent is such that the mantissa has one digit before the decimal point.
                    formatted.exponent = x.exponent;
                    if (x.mantissa == 10.0M)
                    {
                        formatted.exponent++;
                    }
                    formatted.sign = x.sign;
                }

                // Adjust the computed exponent based on the display format, and determine if the
                // fixed format underflows or overflows.
                switch (format)
                {
                    case DisplayFormat.Engineering:
                        {
                            if (formatted.exponent % 3 != 0)
                            {
                                formatted.exponent =
                                    (sbyte) (formatted.exponent - (formatted.exponent % 3) -
                                             (formatted.exponent >= 0 ? 0 : 3));
                            }
                            break;
                        }
                    case DisplayFormat.Fixed:
                        {
                            if ((formatted.exponent == fixedUnderflowExponentThreshold - 1 &&
                                 formatted.mantissa != 10.0M) ||
                                 formatted.exponent < fixedUnderflowExponentThreshold - 1)
                            {
                                fixedUnderflowOverflow = true;
                            }
                            else if (formatted.exponent < -digits - 1 ||
                                     formatted.exponent > 9)
                            {
                                fixedUnderflowOverflow = true;
                            }
                            else if (formatted.exponent == -digits - 1)
                            {
                                // A subtlety here.  If digits is, say, 2, the values ±0.005 round to
                                // ±0.01, but the values ±0.004 underflow.
                                if (absX < 0.5M * PowerOfTen (-digits))
                                {
                                    fixedUnderflowOverflow = true;
                                }
                            }
                            if (!fixedUnderflowOverflow)
                            {
                                formatted.exponent = 0;
                            }
                            break;
                        }
                    case DisplayFormat.Scientific:
                        {
                            break;
                        }
                }
                formatted.mantissa = x.mantissa * PowerOfTen (x.exponent - formatted.exponent);
            }

            private string StripIfNeeded (string mantissa)
            {
                if (stripZeros)
                {
                    // First, find any zeros to the right of the decimal point.
                    int lastDigit = mantissa.LastIndexOfAny (decimalDigits);
                    int lastZero = mantissa.LastIndexOf ('0');
                    if (lastZero >= 0)
                    {
                        int period = mantissa.IndexOf ('.');
                        Trace.Assert (period >= 0);
                        int firstZero = mantissa.Length; // A value that works if there are no 0s.
                        if (period < lastZero && lastDigit == lastZero)
                        {
                            for (int i = lastZero; i > period; i--)
                            {
                                if (mantissa [i] == '0')
                                {
                                    firstZero = i;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        return mantissa.Substring (0, firstZero) +
                               mantissa.Substring (firstZero).Replace ('0', ' ');
                    }
                    else
                    {
                        return mantissa;
                    }
                }
                else
                {
                    return mantissa;
                }
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
                    else if (formatted.exponent == 0 && format == DisplayFormat.Fixed)
                    {
                        return new String (' ', exponentSignLength + exponentLength);
                    }
                    else
                    {
                        return formatted.exponent.ToString
                                (exponentTemplate, NumberFormatInfo.InvariantInfo);
                    }
                }
            }

            private string Mantissa
            {
                get
                {
                    if (overflows)
                    {
                        if (formatted.mantissa > 0.0M)
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
                                    // Note that we have to do rounding explicitly here, we cannot
                                    // just let the formatter do it.  The reason is that we want to
                                    // get zeros *before* the decimal point if the number of digits
                                    // is very small.
                                    decimal absMantissa = Math.Abs (formatted.mantissa);
                                    decimal formattableMantissa;

                                    if (absMantissa < 10.0M)
                                    {
                                        formattableMantissa =
                                            Math.Round (formatted.mantissa, digits,
                                                        MidpointRounding.AwayFromZero);
                                        return formattableMantissa.ToString
                                            (engMantissaTemplate1, NumberFormatInfo.InvariantInfo);
                                    }
                                    else if (absMantissa < 100.0M)
                                    {
                                        formattableMantissa = 10.0M *
                                            Math.Round (formatted.mantissa / 10.0M, digits,
                                                        MidpointRounding.AwayFromZero);
                                        return formattableMantissa.ToString
                                            (engMantissaTemplate10, NumberFormatInfo.InvariantInfo);
                                    }
                                    else
                                    {
                                        Trace.Assert (absMantissa < 1000.0M);
                                        formattableMantissa = 100.0M *
                                            Math.Round (formatted.mantissa / 100.0M, digits,
                                                        MidpointRounding.AwayFromZero);
                                        return formattableMantissa.ToString
                                            (engMantissaTemplate100, NumberFormatInfo.InvariantInfo);
                                    }
                                }
                            case DisplayFormat.Fixed:
                                {
                                    if (fixedUnderflowOverflow)
                                    {
                                        return StripIfNeeded 
                                                (formatted.mantissa.ToString
                                                    (fixUnderflowOverflowMantissaTemplate,
                                                     NumberFormatInfo.InvariantInfo));
                                    }
                                    else
                                    {
                                        string m = "";
                                        if (hasExtraDigitBetween0And1 &&
                                            formatted.mantissa > -1.0M &&
                                            formatted.mantissa < 1.0M)
                                        {
                                            m = formatted.mantissa.ToString
                                                    (fixMantissaTemplateDPlus1,
                                                     NumberFormatInfo.InvariantInfo);
                                        }
                                        else
                                        {
                                            m = formatted.mantissa.ToString
                                                    (fixMantissaTemplateD,
                                                     NumberFormatInfo.InvariantInfo);
                                        }
                                        m = StripIfNeeded (m);
                                        return m.Substring
                                            (mantissaSignFirst,
                                             Math.Min (m.Length,
                                                       mantissaSignLength + mantissaLength));
                                    }
                                }
                            case DisplayFormat.Scientific:
                                {
                                    return formatted.mantissa.ToString
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

            public void Round (Number x)
            {
                Split (x);
                if (FormattingChanged != null)
                {
                    FormattingChanged (Mantissa, Exponent, Value); // Probably unnecessary, but...
                }
            }

            #endregion

            #region Public Properties

            public byte Digits
            {
                get
                {
                    return digits;
                }
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
                        fixMantissaTemplateD = " 0\\." + blanks + ";-0\\." + blanks;
                        fixMantissaTemplateDPlus1 = " #.0" + blanks +
                                                    ";-#.0" + blanks +
                                                    "; 0\\." + blanks;
                    }
                    else
                    {
                        zeros = new String ('0', value);
                        fixMantissaTemplateD = " 0." + zeros + blanks + ";-0." + zeros + blanks;
                        fixMantissaTemplateDPlus1 = " #.0" + zeros + blanks + 
                                                    ";-#.0" + zeros + blanks +
                                                    "; 0." + zeros + blanks;
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

                    engMantissaTemplate1 = fixMantissaTemplateD;
                    sciMantissaTemplate = fixMantissaTemplateD;

                    Value = Value;
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
                }
            }

            public bool MustUseRaw
            {
                get
                {

                    // This gives a number of conditions under which the raw input (as opposed to:
                    // the formatted input) must be echoed by the printer.  This is *not* complete,
                    // though: there are other conditions (no exponent entered, no truncation) that
                    // can only be checked based on the raw input given by the validater.
                    return format != Number.DisplayFormat.Fixed ||
                           overflows ||
                           formatted.exponent != 0 ||
                           fixedUnderflowOverflow;
               }
            }

            public Number Value
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
                    return new Number (formatted.mantissa, formatted.exponent);
                }
            }

            #endregion
        }
    }
}
