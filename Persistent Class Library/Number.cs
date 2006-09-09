using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Globalization;

namespace Mockingbird.HP.Class_Library
{
    public static partial class Number
    {
        private const int exponentFirst = 1;
        private const int exponentLength = 2;
        private const int exponentSignFirst = 0;
        private const int exponentSignLength = 1;

        private const int mantissaFirst = 1;
        private const int mantissaLength = 11;
        private const int mantissaSignFirst = 0;
        private const int mantissaSignLength = 1;

        private static char minus = NumberFormatInfo.InvariantInfo.NegativeSign [0];
        private static char period = NumberFormatInfo.InvariantInfo.NumberDecimalSeparator [0];
        private static char plus = ' '; // Not a mistake: we don't show '+'

        public delegate void ChangeEvent (string mantissa, string exponent, double value);

    }
}
