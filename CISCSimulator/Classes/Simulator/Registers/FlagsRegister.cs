using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class FlagsRegister : Register
    {
        Bus RBUS;
        Bus DBUS;
        public void SetRBUS(Bus RBUS)
        {
            this.RBUS = RBUS;
        }

        public void SetDBUS(Bus DBUS)
        {
            this.DBUS = DBUS;
        }

        public void PdFLAGS()
        {
            DBUS.bits = bits;
        }

        public void PmFLAGS()
        {
            bits = RBUS.bits;
        }

        public FlagsRegister()
        {
            bits = 0;
        }
    }
}
