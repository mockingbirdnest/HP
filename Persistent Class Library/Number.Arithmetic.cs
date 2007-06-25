using System;
using System.Collections.Generic;
using System.Text;

namespace Mockingbird.HP.Class_Library
{
    public static partial class Number
    {
        public struct Arithmetic
        {
            private Decimal mantissa;
            private Byte exponent;

            public static Arithmetic operator +(Arithmetic left, Arithmetic right)
            {
                return new Arithmetic();
            }

            public static Arithmetic operator -(Arithmetic left, Arithmetic right)
            {
                return new Arithmetic();
            }

            public static Arithmetic operator *(Arithmetic left, Arithmetic right)
            {
                return new Arithmetic();
            }

            public static Arithmetic operator /(Arithmetic left, Arithmetic right)
            {
                return new Arithmetic();
            }
        }
    }
}
