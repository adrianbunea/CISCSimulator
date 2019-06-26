using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class InterruptVectorRegister : Register
    {
        bool BVI;

        public void A1BVI()
        {
            BVI = true;
        }

        public void A0BVI()
        {
            BVI = false;
        }
    }
}
