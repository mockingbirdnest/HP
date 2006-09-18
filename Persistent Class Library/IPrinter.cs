﻿using System;
namespace Mockingbird.HP.Class_Library
{
    // The purpose of this interface is to reduce the coupling between Persistent Class Library
    // and Control_Library.
    public interface IPrinter
    {
        void PrintAddress (int address);
        void PrintAddress (Memory.LetterRegister address);
        void PrintInstruction (Instruction instruction, bool showKeycodes);
        void PrintNumeric ();
        void PrintStep (int step);
        Number.Formatter Formatter
        {
            get;
        }
    }
}
