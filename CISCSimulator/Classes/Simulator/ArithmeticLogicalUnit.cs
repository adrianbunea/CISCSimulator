using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class ArithmeticLogicalUnit
    {
        SourceBus _SBUS;
        DestinationBus _DBUS;
        ResultBus _RBUS;
        FlagsRegister _FLAGS;

        public void SetSBUS(SourceBus SBUS)
        {
            _SBUS = SBUS;
        }

        public void SetDBUS(DestinationBus DBUS)
        {
            _DBUS = DBUS;
        }

        public void SetRBUS(ResultBus RBUS)
        {
            _RBUS = RBUS;
        }

        public void SetFLAGS(FlagsRegister FLAGS)
        {
            _FLAGS = FLAGS;
        }

        public void SUM()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
        public void AND()
        {
            _RBUS.bits = (Int16)(_SBUS.bits & _DBUS.bits);
        }
        public void OR()
        {
            _RBUS.bits = (Int16)(_SBUS.bits | _DBUS.bits);
        }
        public void XOR()
        {
            _RBUS.bits = (Int16)(_SBUS.bits ^ _DBUS.bits);
        }
        public void ASL()
        {
            _RBUS.bits = (Int16)(_DBUS.bits << 1);
        }
        public void ASR()
        {
            _RBUS.bits = (Int16)(_DBUS.bits >> 1);
        }
        public void LSR()
        {
            _RBUS.bits = (Int16)((UInt16)_DBUS.bits >> 1);
        }
        public void ROL()
        {
            _RBUS.bits = (Int16)((_DBUS.bits << 1) | (_DBUS.bits >> 15));
        }
        public void ROR()
        {
            _RBUS.bits = (Int16)((_DBUS.bits >> 1) | (_DBUS.bits << 15));
        }
        public void RLC()
        {
            Int16 carryBit = (Int16)(_DBUS.bits & (int)Masks.BIT0);
            _FLAGS.C = carryBit;
            _RBUS.bits = (Int16)((_DBUS.bits << 1) | (_DBUS.bits >> 15));
        }

        public void RRC()
        {
            Int16 carryBit = (Int16)(_DBUS.bits & (int)Masks.BIT15);
            _FLAGS.C = carryBit;
            _RBUS.bits = (Int16)((_DBUS.bits >> 1) | (_DBUS.bits << 15));
        }
        public void DBUS()
        {
            _RBUS.bits = _DBUS.bits;
        }
    }
}
