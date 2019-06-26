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
        BIT0  = 0x0001,
        OFFSET = 0x00FF
    }

    [Flags]
    public enum FLAGS_Masks : UInt16
    {
        C = 0x0001,
        V = 0x0002,
        Z = 0x0004,
        N = 0x0008,
        COND = 0x000F
    }
}
