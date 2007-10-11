using System;
namespace Mockingbird.HP.Class_Library
{
    // The purpose of this interface is to reduce the coupling between Persistent Class Library
    // and Control_Library.
    public interface IDisplay
    {
        void Pause (int ms);
        void ShowInstruction (Instruction instruction, int step, bool setMode);
        void ShowMemory (int address, double register, int ms);
        Number.Formatter Formatter
        {
            get;
        }
    }
}
