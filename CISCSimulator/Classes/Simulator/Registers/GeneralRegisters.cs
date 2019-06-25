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
        InstructionRegister instructionRegister;

        public Register SelectedRegister
        {
            get
            {
                return RG[instructionRegister.Offset];
            }
        }

        public void SetDBUS(Bus DBUS)
        {
            this.DBUS = DBUS;
        }

        public void SetInstructionRegister(InstructionRegister instructionRegister)
        {
            this.instructionRegister = instructionRegister;
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
