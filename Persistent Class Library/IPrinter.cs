using System;
namespace Mockingbird.HP.Class_Library
{
    // The purpose of this interface is to reduce the coupling between Persistent Class Library
    // and Control_Library.
    public interface IPrinter
    {
        void PrintInstruction (Instruction instruction, bool showKeycodes);
        void PrintStep (int step);
    }
}
