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

        Int16 COND;
        Int16 _Cin;

        public Int16 Cout
        {
            get
            {
                return (Int16)(COND & (int)FLAGS_Masks.C);
            }

            set
            {
                if (value == 1)
                {
                    COND = (Int16)(COND | 1 << (int)FLAGS_SHIFTS.C);
                }


                if (value == 0)
                {
                    COND = (Int16)(COND & ~(1 << (int)FLAGS_SHIFTS.C));
                }
            }
        }

        public Int16 DCR
        {
            get
            {
                return (Int16)(COND & (int)FLAGS_Masks.V);
            }

            set
            {
                if (value == 1)
                {
                    COND = (Int16)(COND | 1 << (int)FLAGS_SHIFTS.V);
                }


                if (value == 0)
                {
                    COND = (Int16)(COND & ~(1 << (int)FLAGS_SHIFTS.V));
                }
            }
        }

        public Int16 N
        {
            get
            {
                return (Int16)(COND & (int)FLAGS_Masks.N);
            }

            set
            {
                if (value == 1)
                {
                    COND = (Int16)(COND | 1 << (int)FLAGS_SHIFTS.N);
                }


                if (value == 0)
                {
                    COND = (Int16)(COND & ~(1 << (int)FLAGS_SHIFTS.N));
                }
            }
        }

        public Int16 Z
        {
            get
            {
                return (Int16)(COND & (int)FLAGS_Masks.Z);
            }

            set
            {
                if (value == 1)
                {
                    COND = (Int16)(COND | 1 << (int)FLAGS_SHIFTS.Z);
                }


                if (value == 0)
                {
                    COND = (Int16)(COND & ~(1 << (int)FLAGS_SHIFTS.Z));
                }
            }
        }

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
            Cout = (Int16)(_DBUS.bits & (int)Masks.BIT0);
            _RBUS.bits = (Int16)((_DBUS.bits << 1) | (_DBUS.bits >> 15));
        }

        public void RRC()
        {
            Cout = (Int16)(_DBUS.bits & (int)Masks.BIT15);
            _RBUS.bits = (Int16)((_DBUS.bits >> 1) | (_DBUS.bits << 15));
        }
        public void DBUS()
        {
            _RBUS.bits = _DBUS.bits;
        }

        public void PdCOND()
        {
            _FLAGS.bits = (Int16)(COND & (int)FLAGS_Masks.COND);
        }

        public void Cin()
        {
            _Cin = 1;
        }

        public void Cin_PdCOND()
        {
            Cin();
            PdCOND();
        }
    }
}
