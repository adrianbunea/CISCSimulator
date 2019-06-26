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
                return (Int16)(bits & (int)FLAGS_Masks.V);
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

        public void A1C()
        {
            C = 1;
        }

        public void A1V()
        {
            V = 1;
        }

        public void A1Z()
        {
            Z = 1;
        }

        public void A1S()
        {
            N = 1;
        }

        public void A0C()
        {
            C = 0;
        }

        public void A0V()
        {
            V = 0;
        }

        public void A0Z()
        {
            Z = 0;
        }

        public void A0S()
        {
            N = 0;
        }

        public void A1CVZS()
        {
            C = 1;
            V = 1;
            Z = 1;
            N = 1;
        }

        public void A0CVZS()
        {
            C = 0;
            V = 0;
            Z = 0;
            N = 0;
        }
    }
}
