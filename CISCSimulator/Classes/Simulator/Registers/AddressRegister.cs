using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class AddressRegister : Register
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

        public void PmADR()
        {
            bits = RBUS.bits;
        }

        public void PdADR()
        {
            RBUS.bits = bits;
        }
    }
}
