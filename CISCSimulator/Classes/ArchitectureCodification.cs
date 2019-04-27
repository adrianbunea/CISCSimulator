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

        public Dictionary<string, int> instructionSetCodifications;
        public Dictionary<string, int> addressingModesCodifications;
        public Dictionary<string, int> generalRegistersCodifications;

        public void ParseArchitecture(string[] filepaths)
        {
            string[] architectureFiles = ReadArchitectureFiles(filepaths);
            ParseInstructions(architectureFiles[INSTRUCTIONS]);
            ParseAddressingModes(architectureFiles[ADDRESSING_MODES]);
            ParseGeneralRegisters(architectureFiles[GENERAL_REGISTERS]);
        }

        private string[] ReadArchitectureFiles(string[] filepaths)
        {
            string[] architectureFiles = new string[3];
            architectureFiles[INSTRUCTIONS] = File.ReadAllText(filepaths[INSTRUCTIONS]);
            architectureFiles[ADDRESSING_MODES] = File.ReadAllText(filepaths[ADDRESSING_MODES]);
            architectureFiles[GENERAL_REGISTERS] = File.ReadAllText(filepaths[GENERAL_REGISTERS]);
            return architectureFiles;
        }

        private void ParseInstructions(string instructionsFile)
        {
            List<string> instructionLines = Helper.ReadLinesFromFile(instructionsFile);
            Dictionary<string, int> instructions = CreateInstructions(instructionLines);
            instructionSetCodifications = instructions;
        }

        private Dictionary<string, int> CreateInstructions(List<string> instructionLines)
        {
            Dictionary<string, int> instructions = new Dictionary<string, int>();
            for (int i = 0; i < instructionLines.Count; i++)
            {
                List<string> splitInstructionLine = instructionLines[i].Split(' ').ToList();
                RemoveEmptyElements(ref splitInstructionLine);
                instructions.Add(InstructionName(splitInstructionLine), InstructionCodification(splitInstructionLine));
            }
            return instructions;
        }

        private int InstructionCodification(List<string> splitInstructionLine)
        {
            return int.Parse(splitInstructionLine[1].Trim(), System.Globalization.NumberStyles.HexNumber);
        }

        private string InstructionName(List<string> splitInstructionLine)
        {
            return splitInstructionLine[0].Trim();
        }

        private void RemoveEmptyElements(ref List<string> splitInstructionLine)
        {
            splitInstructionLine.RemoveAll(element => string.IsNullOrEmpty(element) || element == "\t");
        }

        private Dictionary<string, int> ParseAddressingModes(string addressingModesFile)
        {
            Dictionary<string, int> addressingModes = new Dictionary<string, int>();
            return addressingModes;
        }

        private Dictionary<string, int> ParseGeneralRegisters(string generalRegistersfile)
        {
            Dictionary<string, int> generalRegisters = new Dictionary<string, int>();
            return generalRegisters;
        }
    }
}