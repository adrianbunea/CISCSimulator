using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class GeneralRegisters
    {
        Bus DBUS;
        InstructionRegister IR;

        public Register SelectedRegister
        {
            get
            {
                return RG[IR.Offset];
            }
        }

        public void SetDBUS(Bus DBUS)
        {
            this.DBUS = DBUS;
        }

        public void SetIR(InstructionRegister IR)
        {
            this.IR = IR;
        }

        Register[] RG;

        //public UInt16 SelectedRegister()
        //{
        //    return RG[instructionRegister.Offset];
        //}

        //public void PmRG()
        //{
        //    RG[instructionRegister.Offset] = DBUS.bits;
        //}

        public GeneralRegisters()
        {
            RG = new Register[16];
        }
    }
}
