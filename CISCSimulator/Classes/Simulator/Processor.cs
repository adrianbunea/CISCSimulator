using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class Processor
    {
        UInt16 sBUS, dBUS, rBUS;
        GeneralRegisters RG;
        InstructionRegister IR;
        ArithmeticLogicalUnit ALU;
    }
}
