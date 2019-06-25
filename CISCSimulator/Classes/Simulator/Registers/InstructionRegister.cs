using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class InstructionRegister : Register
    {
        public Int16 Offset
        {
            get
            {
                return 0;
            }
        }
        public int Opcode
        {
            get
            {
                return 0;
            }
        }

        public InstructionRegister()
        {
            bits = 0;
        }
    }
}
