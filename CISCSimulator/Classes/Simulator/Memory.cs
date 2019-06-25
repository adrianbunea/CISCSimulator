using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    public enum MemoryOperation
    {
        READ,
        WRITE
    }

    class Memory
    {
        AddressRegister addressRegister;
        MemoryDataRegister memoryDataRegister;

        public void SetAddressRegister(AddressRegister addressRegister)
        {
            this.addressRegister = addressRegister;
        }

        public void SetMemoryDataRegister(MemoryDataRegister memoryDataRegister)
        {
            this.memoryDataRegister = memoryDataRegister;
        }

        UInt16[] locations;
        public MemoryOperation memoryOperation;

        public void READ()
        {
            memoryDataRegister.Bits = locations[addressRegister.Bits];
        }

        public void WRITE()
        {
            locations[addressRegister.Bits] = memoryDataRegister.Bits;
        }

        public Memory()
        {
            locations = new UInt16[65536];
            memoryOperation = MemoryOperation.READ;
        }
    }
}
