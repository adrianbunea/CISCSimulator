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

        public void SetDBUS(Bus DBUS)
        {
            this.DBUS = DBUS;
        }

        InstructionRegister instructionRegister;

        public void SetInstructionRegister(InstructionRegister instructionRegister)
        {
            this.instructionRegister = instructionRegister;
        }

        UInt16[] RG;

        public void PdRG()
        {
            DBUS.bits = RG[instructionRegister.SelectedRegister];
        }

        public void PmRG()
        {
            RG[instructionRegister.SelectedRegister] = DBUS.bits;
        }

        public GeneralRegisters()
        {
            RG = new UInt16[16];
        }
    }
}
