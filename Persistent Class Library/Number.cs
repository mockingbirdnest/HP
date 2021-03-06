using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Mockingbird.HP.Class_Library
{
    public partial struct Number
    {

        #region Private Declarations

        private const short maxDecimalExponent = 28;
        private const decimal maxDecimalMantissa = 7.9228162514264337593543950335M;

        private const short overflowExponent = 99;
        private const decimal overflowMantissa = 9.999999999M;
        private const short underflowExponent = -100;
        private const decimal underflowMantissa = 10.0M;

        private const int exponentFirst = 1;
        private const int exponentLength = 2;
        private const int exponentSignFirst = 0;
        private const int exponentSignLength = 1;

        private const int mantissaFirst = 1;
        private const int mantissaLength = 11;
        private const int mantissaSignFirst = 0;
        private const int mantissaSignLength = 1;

        // The internal representation of π for angle reduction.  This is the actual value used by
        // the calculators to perform internal computations on trigonometrics.  Its value was
        // derived by computing trigonometric functions of large angles using both the HP-67 and
        // Mathematica.
        private const decimal internalπ = 3.14159265359M;
        private const short digitsInInternalπ = 12;
        private const short maxReductionExponent = maxDecimalExponent - digitsInInternalπ;

        private static char minus = NumberFormatInfo.InvariantInfo.NegativeSign [0];
        private static char period = NumberFormatInfo.InvariantInfo.NumberDecimalSeparator [0];
        private static char plus = ' '; // Not a mistake: we don't show '+'

        private sbyte sign; // -1, 0, or 1.
        private short exponent; // 0 for 0.
        private decimal mantissa; // Between 1 and 10, or 0.
        private bool overflow; // True if overflow happened.

        #endregion

        #region Public Declarations

        public const decimal π = 3.141592654M;

        #endregion

        #region Constructors & Destructors

        private Number (decimal m, int e)
        {
            // Note that here m may be negative, so we extract its sign to make sure that the
            // mantissa is nonnegative.
            int n;
            double log10;

            if (m > 0.0M)
            {
                mantissa = m;
                sign = 1;
            }
            else if (m < 0.0M)
            {
                mantissa = -m;
                sign = -1;
            }
            else /* m == 0.0M */
            {
                sign = 0;
                mantissa = 0.0M;
                exponent = 0;
                overflow = false;
                return;
            }

            log10 = Math.Log10 ((double) mantissa);
            n = (int) Math.Ceiling (log10);
            // Here we hope that:
            //    10 ** (n - 1) < m <= 10 ** n
            // but in fact the computation of log10 may have introduced rounding errors, so we have
            // to assume that:
            //    10 ** (n - 2) < m <= 10 ** (n + 1).

            mantissa *= PowerOfTen (2 - n);
            exponent = (short) (e + n - 2);
            // Here 1 < mantissa <= 1000.  We may have to refine it and to update the exponent.

            while (mantissa > 10.0M)
            {
                mantissa *= 0.1M;
                exponent++;
            }
            // Here 1 < mantissa <= 10.  This choice gives us the best precision because the type
            // decimal is not very good at representing numbers close to 0 since it cannot have a
            // negative scale.  Therefore, the choice 0.1 < mantissa <= 1 would be less precise.

            if (exponent > overflowExponent ||
                (exponent == overflowExponent && mantissa > overflowMantissa))
            {
                // Overflow.
                mantissa = overflowMantissa;
                exponent = overflowExponent;
                overflow = true;
            }
            else if (exponent < underflowExponent ||
                     (exponent == underflowExponent && mantissa < underflowMantissa))
            {
                // Underflow.
                sign = 0;
                mantissa = 0.0M;
                exponent = 0;
                overflow = false;
            }
            else
            {
                overflow = false;
            }
        }

        private static decimal ReducedAngle (Number x)
        {
            // We cannot in general compute the power of ten for the exponent of x, so we do the
            // reduction stepwise.
            decimal d = x.sign * x.mantissa;
            short e = x.exponent;
            if (e > 0)
            {
                do
                {
                    d = Decimal.Remainder (d * PowerOfTen (Math.Min (e, maxReductionExponent)),
                                           2 * internalπ);
                    e -= maxReductionExponent;
                } while (e > 0);
                return d;
            }
            else
            {
                return d * PowerOfTen (e);
            }
        }

        #endregion

        #region Event Declarations

        public delegate void SimpleEvent ();
        public delegate void ChangeEvent (string mantissa, string exponent, Number value);

        #endregion

        #region Private Operations

        private bool MayConvertToDecimal ()
        {
            return exponent <= maxDecimalExponent &&
                   (exponent != maxDecimalExponent ||
                    mantissa <= maxDecimalMantissa);
        }

        private static decimal PowerOfTen (int n)
        {
            // Knuth's algorithm A in 4.6.3.
            decimal y = 1.0M;
            decimal z;

            if (n > 0)
            {
                Trace.Assert (n <= maxDecimalExponent);
                z = 10.0M;
            }
            else
            {
                z = 0.1M;
                n = -n;
            }
            // Note that this loop does nothing if n == 0.
            for (; ; )
            {
                if (n % 2 == 1)
                {
                    y *= z;
                }
                n /= 2;
                if (n == 0)
                {
                    break;
                }
                z *= z;
            }
            return y;
        }

        #endregion

        #region Public Properties

        public bool Overflow
        {
            get
            {
                return overflow;
            }
        }

        #endregion

        #region Public Operations

        // TODO: The error cases (e.g., Sqrt (-1)) should probably be handled here, not in Engine.

        public static Number Abs (Number x)
        {
            if (x.sign >= 0)
            {
                return x;
            }
            else
            {
                return -x;
            }
        }

        public static Number Acos (Number x)
        {
            return (Number) Math.Acos ((double) x);
        }

        public static Number Asin (Number x)
        {
            return (Number) Math.Asin ((double) x);
        }

        public static Number Atan (Number x)
        {
            return (Number) Math.Atan ((double) x);
        }

        public static Number Atan2 (Number x, Number y)
        {
            return (Number) Math.Atan2 ((double) x, (double) y);
        }

        public static Number Cos (Number x)
        {
            return (Number) Math.Cos ((double) ReducedAngle (x));
        }

        public static Number Exp (Number x)
        {
            return (Number) Math.Exp ((double) x);
        }

        public static int Floor (Number x)
        {
            Trace.Assert (x.MayConvertToDecimal ());
            return (int) Math.Floor (x.sign * x.mantissa * PowerOfTen (x.exponent));
        }

        public static Number Log (Number x)
        {
            return (Number) Math.Log ((double) x);
        }

        public static Number Log10 (Number x)
        {
            if (x.mantissa == 10.0M)
            {
                return x.exponent + 1;
            }
            else
            {
                return (Number) (Math.Log10 ((double) x.mantissa) + x.exponent);
            }
        }

        public static Number Pow (Number x, Number y)
        {
            if (x == 10.0M)
            {
                // This is exact if x is 10 and y is integral.
                double yDouble = (double) y;
                double yInt = Math.Truncate (yDouble);
                double yFrac = yDouble - yInt;
                return new Number ((decimal) Math.Pow (10.0, yFrac), (short) yInt);
            }
            else
            {
                return (Number) Math.Pow ((double) x, (double) y);
            }
        }

        public static Number Sqrt (Number x)
        {
            return (Number) Math.Sqrt ((double) x);
        }

        public static Number Sin (Number x)
        {
            return (Number) Math.Sin ((double) ReducedAngle (x));
        }

        public static Number Tan (Number x)
        {
            return (Number) Math.Tan ((double) ReducedAngle (x));
        }

        public static Number ReadFromRow (CardDataset.RegisterRow rr)
        {
            // We don't want to expose the mantissa + exponent representation except for storage.
            // Note that we don't assume that the number in the row is normalized.  Among other
            // things, it helps for compatibility with version 1.8.  See Card for details.
            return new Number (rr.Mantissa, rr.Exponent);
        }

        public void WriteToRow (CardDataset.RegisterRow rr)
        {
            // We don't want to expose the mantissa + exponent representation except for storage.
            rr.Mantissa = sign * mantissa;
            rr.Exponent = (sbyte) exponent;
        }

        public override bool Equals (object o)
        {
            if (o == null)
            {
                return false;
            }
            else if (o is Number)
            {
                Number x = (Number) o;
                return sign == x.sign && mantissa == x.mantissa && exponent == x.exponent;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode ()
        {
            // 0.09 below ensures that we don't get an overflow in the computation.
            return (int) (0.09M * sign * mantissa * (decimal) int.MaxValue) + (int) exponent;
        }

        #endregion

        #region Public Operators

        public static implicit operator Number (decimal d)
        {
            return new Number (d, 0);
        }

        public static explicit operator Number (double d)
        {
            // Approximative.
            if (double.IsNegativeInfinity (d))
            {
                return new Number (-overflowMantissa, overflowExponent);
            }
            else if (double.IsPositiveInfinity (d))
            {
                return new Number (overflowMantissa, overflowExponent);
            }
            else
            {
                short n = (short) Math.Ceiling (Math.Log10 ((double) Math.Abs (d)));
                return new Number ((decimal) (d * Math.Pow (10.0, -n)), n);
            }
        }

        public static explicit operator double (Number x)
        {
            // Approximative.
            return x.sign * (double) x.mantissa * Math.Pow (10.0, (short) x.exponent);
        }

        public static Number operator + (Number right)
        {
            return right;
        }

        public static Number operator + (Number left, Number right)
        {
            if (left.exponent > right.exponent)
            {
                return new Number
                    (left.sign * left.mantissa +
                     right.sign * right.mantissa * PowerOfTen (right.exponent - left.exponent),
                     left.exponent);
            }
            else
            {
                return new Number
                    (right.sign * right.mantissa +
                     left.sign * left.mantissa * PowerOfTen (left.exponent - right.exponent),
                     right.exponent);
            }
        }

        public static Number operator ++ (Number x)
        {
            if (x.exponent > 0)
            {
                return new Number (x.sign * x.mantissa +
                                   1.0M * PowerOfTen (-x.exponent), x.exponent);
            }
            else
            {
                return x.sign * x.mantissa * PowerOfTen (x.exponent) + 1.0M;
            }
        }

        public static Number operator - (Number right)
        {
            return new Number (-right.sign * right.mantissa, right.exponent);
        }

        public static Number operator - (Number left, Number right)
        {
            if (left.exponent > right.exponent)
            {
                return new Number
                    (left.sign * left.mantissa -
                     right.sign * right.mantissa * PowerOfTen (right.exponent - left.exponent),
                     left.exponent);
            }
            else
            {
                return new Number
                    (left.sign * left.mantissa * PowerOfTen (left.exponent - right.exponent) -
                     right.sign * right.mantissa,
                     right.exponent);
            }
        }

        public static Number operator -- (Number x)
        {
            if (x.exponent > 0)
            {
                return new Number (x.sign * x.mantissa -
                                   1.0M * PowerOfTen (-x.exponent), x.exponent);
            }
            else
            {
                return x.sign * x.mantissa * PowerOfTen (x.exponent) - 1.0M;
            }
        }

        public static Number operator * (Number left, Number right)
        {
            return new Number (left.sign * left.mantissa * right.sign * right.mantissa,
                               left.exponent + right.exponent);
        }

        public static Number operator / (Number left, Number right)
        {
            // The number 10 / right.mantissa is in the range 1 .. 10, so it can be represented
            // without losing accuracy.  A simple minded division of the mantissas could lead to
            // a number as small as 0.1.
            return new Number (left.sign * left.mantissa * (10.0M / (right.sign * right.mantissa)),
                               left.exponent - right.exponent - 1);
        }

        public static bool operator < (Number left, Number right)
        {
            // Lexicographic ordering.  Only works for normalized numbers.
            if (left.sign == right.sign)
            {
                if (left.exponent < right.exponent)
                {
                    return left.sign > 0;
                }
                else if (left.exponent == right.exponent)
                {
                    return left.mantissa < right.mantissa;
                }
                else
                {
                    return left.sign < 0;
                }
            }
            else
            {
                return left.sign < right.sign;
            }
        }

        public static bool operator < (Number left, decimal right)
        {
            if (left.MayConvertToDecimal ())
            {
                return left.sign * left.mantissa * PowerOfTen (left.exponent) < right;
            }
            else
            {
                return left.sign < 0;
            }
        }

        public static bool operator <= (Number left, Number right)
        {
            return !(left > right);
        }

        public static bool operator <= (Number left, decimal right)
        {
            return !(left > right);
        }

        public static bool operator == (Number left, Number right)
        {
            return left.sign == right.sign &&
                   left.mantissa == right.mantissa &&
                   left.exponent == right.exponent;
        }

        public static bool operator == (Number left, decimal right)
        {
            if (left.MayConvertToDecimal ())
            {
                return left.sign * left.mantissa * PowerOfTen (left.exponent) == right;
            }
            else
            {
                return false;
            }
        }

        public static bool operator != (Number left, Number right)
        {
            return left.sign != right.sign ||
                   left.mantissa != right.mantissa ||
                   left.exponent != right.exponent;
        }

        public static bool operator != (Number left, decimal right)
        {
            if (left.MayConvertToDecimal ())
            {
                return left.mantissa * PowerOfTen (left.exponent) != right;
            }
            else
            {
                return true;
            }
        }

        public static bool operator >= (Number left, Number right)
        {
            return !(left < right);
        }

        public static bool operator >= (Number left, decimal right)
        {
            return !(left < right);
        }

        public static bool operator > (Number left, Number right)
        {
            // Lexicographic ordering.  Only works for normalized numbers.
            if (left.sign == right.sign)
            {
                if (left.exponent > right.exponent)
                {
                    return left.sign > 0;
                }
                else if (left.exponent == right.exponent)
                {
                    return left.mantissa > right.mantissa;
                }
                else
                {
                    return left.sign < 0;
                }
            }
            else
            {
                return left.sign > right.sign;
            }
        }

        public static bool operator > (Number left, decimal right)
        {
            if (left.MayConvertToDecimal ())
            {
                return left.mantissa * PowerOfTen (left.exponent) > right;
            }
            else
            {
                return left.sign > 0;
            }
        }

        #endregion
    }
}
