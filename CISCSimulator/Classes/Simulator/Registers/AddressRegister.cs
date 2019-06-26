using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class AddressRegister : Register
    {
        public Int16 Bits
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
    }
}
