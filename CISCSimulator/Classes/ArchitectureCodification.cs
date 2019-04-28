using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator
{
    public class ArchitectureCodification
    {
        private readonly int INSTRUCTIONS = 0;
        private readonly int ADDRESSING_MODES = 1;
        private readonly int GENERAL_REGISTERS = 2;

        InstructionSetCodification instructionSetCodifications;
        AddressingModesCodification addressingModesCodifications;
        GeneralRegistersCodification generalRegistersCodifications;

        public void ParseArchitecture(string[] filepaths)
        {
            string[] architectureCodificationFiles = ReadArchitectureCodificationFiles(filepaths);
            instructionSetCodifications = new InstructionSetCodification(architectureCodificationFiles[INSTRUCTIONS]);
            addressingModesCodifications = new AddressingModesCodification(architectureCodificationFiles[ADDRESSING_MODES]);
            generalRegistersCodifications = new GeneralRegistersCodification(architectureCodificationFiles[GENERAL_REGISTERS]);
        }

        private string[] ReadArchitectureCodificationFiles(string[] filepaths)
        {
            string[] architectureFiles = new string[3];
            architectureFiles[INSTRUCTIONS] = File.ReadAllText(filepaths[INSTRUCTIONS]);
            architectureFiles[ADDRESSING_MODES] = File.ReadAllText(filepaths[ADDRESSING_MODES]);
            architectureFiles[GENERAL_REGISTERS] = File.ReadAllText(filepaths[GENERAL_REGISTERS]);
            return architectureFiles;
        }
    }
}