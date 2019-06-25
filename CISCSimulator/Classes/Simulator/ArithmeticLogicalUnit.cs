using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    public enum ALUOperations
    {
        SUM,
        AND,
        OR,
        XOR,
        SBUS,
        nSBUS,
        DBUS
    }

    class ArithmeticLogicalUnit
    {
        private ALUOperations ALUOperation;
        public void SetALUOperation(ALUOperations ALUOperation)
        {
            this.ALUOperation = ALUOperation;
        }
    }
}
