using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class FlagsRegister : Register
    {
        public Int16 C
        {
            get
            {
                return (Int16)(bits & (int)FLAGS_Masks.C);
            }

            set
            {
                if (value == 1)
                {
                    bits = (Int16)(bits | 1 << (int)FLAGS_SHIFTS.C);
                }
                    

                if (value == 0)
                {
                    bits = (Int16)(bits & ~(1 << (int)FLAGS_SHIFTS.C));
                }
            }
        }

        public Int16 V
        {
            get
            {
                return (Int16)(bits & (int)FLAGS_Masks.V;
            }

            set
            {
                if (value == 1)
                {
                    bits = (Int16)(bits | 1 << (int)FLAGS_SHIFTS.V);
                }


                if (value == 0)
                {
                    bits = (Int16)(bits & ~(1 << (int)FLAGS_SHIFTS.V));
                }
            }
        }

        public Int16 Z
        {
            get
            {
                return (Int16)(bits & (int)FLAGS_Masks.Z);
            }

            set
            {
                if (value == 1)
                {
                    bits = (Int16)(bits | 1 << (int)FLAGS_SHIFTS.Z);
                }


                if (value == 0)
                {
                    bits = (Int16)(bits & ~(1 << (int)FLAGS_SHIFTS.Z));
                }
            }
        }

        public Int16 N
        {
            get
            {
                return (Int16)(bits & (int)FLAGS_Masks.N);
            }

            set
            {
                if (value == 1)
                {
                    bits = (Int16)(bits | 1 << (int)FLAGS_SHIFTS.N);
                }


                if (value == 0)
                {
                    bits = (Int16)(bits & ~(1 << (int)FLAGS_SHIFTS.N));
                }
            }
        }
    }
}
