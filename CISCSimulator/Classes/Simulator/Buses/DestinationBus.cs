using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class DestinationBus : Bus
    {
        InstructionRegister IR;
        FlagsRegister FLAGS;
        StackPointer SP;
        BufferRegister T;
        InterruptVectorRegister IVR;
        AddressRegister ADR;
        MemoryDataRegister MDR;
        GeneralRegisters RG;

        public void SetIR(InstructionRegister IR)
        {
            this.IR = IR;
        }
        public void SetFLAGS(FlagsRegister FLAGS)
        {
            this.FLAGS = FLAGS;
        }
        public void SetSP(StackPointer SP)
        {
            this.SP = SP;
        }
        public void SetT(BufferRegister T)
        {
            this.T = T;
        }
        public void SetIVR(InterruptVectorRegister IVR)
        {
            this.IVR = IVR;
        }
        public void SetADR(AddressRegister ADR)
        {
            this.ADR = ADR;
        }
        public void SetMDR(MemoryDataRegister MDR)
        {
            this.MDR = MDR;
        }
        public void SetRG(GeneralRegisters RG)
        {
            this.RG = RG;
        }

        public void PdIROffset()
        {
            bits = IR.Offset;
        }

        public void PdFLAG()
        {
            bits = FLAGS.bits;
        }

        public void PdSP()
        {
            bits = SP.bits;
        }

        public void PdT()
        {
            bits = T.bits;
        }

        public void PdNT()
        {
            bits = (Int16)~T.bits;
        }

        public void PdIVR()
        {
            bits = IVR.bits;
        }

        public void PdADR()
        {
            bits = ADR.bits;
        }

        public void PdMDR()
        {
            bits = MDR.bits;
        }

        public void PdRG()
        {
            bits = RG.SelectedRegister.bits;
        }

        public void Pd0()
        {
            bits = 0;
        }

        public void PdMinus1()
        {
            bits = -1;
        }

        public void Pd1()
        {
            bits = 1;
        }
    }
}
