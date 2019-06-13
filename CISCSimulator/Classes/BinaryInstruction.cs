using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator
{
    class BinaryInstruction
    {
        UInt16 bits;
        public int GetClass()
        {
            int c0, c1, b15, b14, b13;

            b15 = (bits & (UInt16)Masks.BIT15) >> 15;
            b14 = (bits & (UInt16)Masks.BIT14) >> 14;
            b13 = (bits & (UInt16)Masks.BIT13) >> 13;

            c0 = b15 & (~(~b14 & b13));
            c1 = b15 & (b14 ^ b13);

            int instructionClass = c0 + c1 << 1; 
            return instructionClass;
        }

        int GetSourceAddressingMode()
        {
            return -1;
        }

        int GetDestinationAddressingMode()
        {
            return -1;
        }

        int GetSourceRegister()
        {
            return -1;
        }

        int GetDestinationRegister()
        {
            return -1;
        }

        int GetOpcode()
        {
            return -1;
        }

        public BinaryInstruction(UInt16 bits)
        {
            this.bits = bits;
            switch (GetClass())
            {
                case 0:
                    GetSourceAddressingMode();
                    GetSourceRegister();
                    GetDestinationAddressingMode();
                    GetDestinationRegister();
                    break;
                case 1: break;
                case 2: break;
                case 3: break;
            }
        }
    }
}
