using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    public enum MemoryOperation
    {
        READ,
        WRITE,
        IFCH
    }

    class Memory
    {
        InstructionRegister IR;
        AddressRegister ADR;
        MemoryDataRegister MDR;
        Int16[] locations;
        public MemoryOperation memoryOperation;
        public void SetIR(InstructionRegister IR)
        {
            this.IR = IR;
        }

        public void SetAddressRegister(AddressRegister ADR)
        {
            this.ADR = ADR;
        }

        public void SetMemoryDataRegister(MemoryDataRegister MDR)
        {
            this.MDR = MDR;
        }

        public void READ()
        {
            MDR.Bits = locations[ADR.Bits];
        }

        public void WRITE()
        {
            locations[ADR.Bits] = MDR.Bits;
        }

        public void IFCH()
        {
            READ();
            MDR.PdMDR();
            IR.PmIR();
        }

        public Memory()
        {
            locations = new Int16[65536];
            memoryOperation = MemoryOperation.READ;
        }
    }
}
