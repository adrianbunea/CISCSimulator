using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator.Classes.Simulator
{
    class Processor
    {
        SourceBus SBUS;
        DestinationBus DBUS;
        ResultBus RBUS;
        ProgramCounter PC;
        InstructionRegister IR;
        GeneralRegisters RG;
        ArithmeticLogicalUnit ALU;
        FlagsRegister FLAGS;
        Memory MEM;
        MemoryDataRegister MDR;
        AddressRegister ADR;
        InterruptVectorRegister IVR;
        StackPointer SP;
        BufferRegister T;
        Sequencer SEQ;

        public void SetUpProcessor()
        {
            SBUS.SetADR(ADR);
            SBUS.SetFLAGS(FLAGS);
            SBUS.SetIR(IR);
            SBUS.SetIVR(IVR);
            SBUS.SetMDR(MDR);
            SBUS.SetRG(RG);
            SBUS.SetSP(SP);
            SBUS.SetT(T);

            DBUS.SetADR(ADR);
            DBUS.SetFLAGS(FLAGS);
            DBUS.SetIR(IR);
            DBUS.SetIVR(IVR);
            DBUS.SetMDR(MDR);
            DBUS.SetRG(RG);
            DBUS.SetSP(SP);
            DBUS.SetT(T);

            RBUS.SetADR(ADR);
            RBUS.SetFLAGS(FLAGS);
            RBUS.SetIVR(IVR);
            RBUS.SetMDR(MDR);
            RBUS.SetRG(RG);
            RBUS.SetSP(SP);
            RBUS.SetT(T);

            IR.SetRBUS(RBUS);

            RG.SetDBUS(DBUS);
            RG.SetIR(IR);

            ALU.SetDBUS(DBUS);
            ALU.SetFLAGS(FLAGS);
            ALU.SetRBUS(RBUS);
            ALU.SetSBUS(SBUS);

            MEM.SetADR(ADR);
            MEM.SetIR(IR);
            MEM.SetMDR(MDR);

            MDR.SetRBUS(RBUS);
        }

        public Processor()
        {
            SBUS = new SourceBus();
            DBUS = new DestinationBus();
            RBUS = new ResultBus();
            PC = new ProgramCounter();
            IR = new InstructionRegister();
            RG = new GeneralRegisters();
            ALU = new ArithmeticLogicalUnit();
            FLAGS = new FlagsRegister();
            MEM = new Memory();
            MDR = new MemoryDataRegister();
            ADR = new AddressRegister();
            IVR = new InterruptVectorRegister();
            SP = new StackPointer();
            T = new BufferRegister();
            SEQ = new Sequencer();
        }
    }   
}
