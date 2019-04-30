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

        private Dictionary<string, int> instructionSetCodifications = new Dictionary<string, int>();
        private Dictionary<string, int> addressingModesCodifications = new Dictionary<string, int>();
        private Dictionary<string, int> generalRegistersCodifications = new Dictionary<string, int>();

        public void ParseArchitecture(string[] filepaths)
        {
            string[] architectureCodificationFiles = ReadArchitectureCodificationFiles(filepaths);

            List<string> instructionSetCodificationLines = Helper.ReadLinesFromFile(architectureCodificationFiles[INSTRUCTIONS]);
            List<string> addressingModesCodificationLines = Helper.ReadLinesFromFile(architectureCodificationFiles[ADDRESSING_MODES]);
            List<string> generalRegistersCodificationLines = Helper.ReadLinesFromFile(architectureCodificationFiles[GENERAL_REGISTERS]);

            instructionSetCodifications = ArchitectureCodificationComponent.CreateCodifications(instructionSetCodificationLines);
            addressingModesCodifications = ArchitectureCodificationComponent.CreateCodifications(addressingModesCodificationLines);
            generalRegistersCodifications = ArchitectureCodificationComponent.CreateCodifications(generalRegistersCodificationLines);
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