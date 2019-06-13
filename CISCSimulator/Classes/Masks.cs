using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator
{
    [Flags]
    public enum Masks : UInt16
    {
        BIT15 = 0x8000,
        BIT14 = 0x4000,
        BIT13 = 0x2000,
        OFFSET = 0x00FF
    }
}
