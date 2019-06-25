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

        public void SUM()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
        public void AND()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
        public void OR()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
        public void XOR()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
        public void ASL()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
        public void ASR()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
        public void LSR()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
        public void ROL()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
        public void ROR()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
        public void RLC()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }

        public void RRC()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
        public void DBUS()
        {
            _RBUS.bits = (Int16)(_SBUS.bits + _DBUS.bits);
        }
    }
}
