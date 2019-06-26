using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class ProgramCounter : Register
    {
        public void IncPC()
        {
            bits = bits++;
        }
    }
}
