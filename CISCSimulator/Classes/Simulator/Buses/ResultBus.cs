using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class ResultBus : Bus
    {
        FlagsRegister FLAGS;
        StackPointer SP;
        BufferRegister T;
        InterruptVectorRegister IVR;
        AddressRegister ADR;
        MemoryDataRegister MDR;
        GeneralRegisters RG;

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

        public void PmFLAG()
        {
            FLAGS.bits = bits;
        }

        public void PmSP()
        {
            SP.bits = bits;
        }

        public void PmT()
        {
            T.bits = bits;
        }

        public void PmIVR()
        {
            IVR.bits = bits;
        }

        public void PmADR()
        {
            ADR.bits = bits;
        }

        public void PmMDR()
        {
            MDR.bits = bits;
        }

        public void PmRG()
        {
            RG.SelectedRegister.bits = bits;
        }
    }
}
