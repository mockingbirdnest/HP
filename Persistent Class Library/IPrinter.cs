using System;
namespace Mockingbird.HP.Class_Library
{
    // The purpose of this interface is to reduce the coupling between Persistent Class Library
    // and Control_Library.
    public interface IPrinter
    {
        void PrintAddress (Argument address);
        void PrintAddress (string address); //TODO: Groan, untyped.
        void PrintInstruction (Instruction instruction, bool showKeycodes);
        void PrintNumeric ();
        void PrintStep (int step);
        Number.Formatter Formatter
        {
            get;
        }
    }
}
