using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class StackPointer : Register
    {
        public void DncSP()
        {
            bits = bits++;
        }

        public void DecSP()
        {
            bits = bits--;
        }
    }
}
