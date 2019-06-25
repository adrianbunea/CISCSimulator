using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class MemoryDataRegister : Register
    {
        public UInt16 Bits
        {
            get
            {
                return bits;
            }
            set
            {
                bits = value;
            }
        }
        Bus RBUS;

        public void SetRBUS(Bus RBUS)
        {
            this.RBUS = RBUS;
        }

        public void PdMDR()
        {
            RBUS.bits = bits;
        }

        public void PmMDR()
        {
            bits = RBUS.bits;
        }
    }
}
