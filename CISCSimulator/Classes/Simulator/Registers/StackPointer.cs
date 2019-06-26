﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class StackPointer : Register
    {
        public void incSP()
        {
            bits = bits++;
        }

        public void decSP()
        {
            bits = bits--;
        }
    }
}
