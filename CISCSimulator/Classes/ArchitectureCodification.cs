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

        InstructionSetCodification instructionSetCodifications = new InstructionSetCodification();
        AddressingModesCodification addressingModesCodifications = new AddressingModesCodification();
        GeneralRegistersCodification generalRegistersCodifications = new GeneralRegistersCodification();

        public void ParseArchitecture(string[] filepaths)
        {
            string[] architectureCodificationFiles = ReadArchitectureCodificationFiles(filepaths);
            instructionSetCodifications.Parse(architectureCodificationFiles[INSTRUCTIONS]);
            addressingModesCodifications.Parse(architectureCodificationFiles[ADDRESSING_MODES]);
            generalRegistersCodifications.Parse(architectureCodificationFiles[GENERAL_REGISTERS]);
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