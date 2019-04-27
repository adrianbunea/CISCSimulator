using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator
{
    class ProcessorArchitectureCodifications
    {
        Dictionary<string, int> instructionSetCodifications;
        Dictionary<string, int> addressingModesCodifications;
        Dictionary<string, int> generalRegistersCodifications;
        public void ParseArchitecture(string[] filepaths)
        {
            string[] architectureFiles = ReadArchitectureFiles(filepaths);
            ParseInstructions(architectureFiles[Constants.INSTRUCTIONS]);
            ParseAddressingModes(architectureFiles[Constants.ADDRESSING_MODES]);
            ParseGeneralRegisters(architectureFiles[Constants.REGISTERS]);
        }

        private string[] ReadArchitectureFiles(string[] filepaths)
        {
            string[] architectureFiles = new string[3];
            architectureFiles[Constants.INSTRUCTIONS] = File.ReadAllText(filepaths[Constants.INSTRUCTIONS]);
            architectureFiles[Constants.ADDRESSING_MODES] = File.ReadAllText(filepaths[Constants.ADDRESSING_MODES]);
            architectureFiles[Constants.REGISTERS] = File.ReadAllText(filepaths[Constants.REGISTERS]);
            return architectureFiles;
        }

        private void ParseInstructions(string instructionsFile)
        {
            List<string> instructionLines = Helper.ReadLinesFromFile(instructionsFile);
            Dictionary<string, int> instructions = CreateInstructions(instructionLines);
            architecture[Constants.INSTRUCTIONS] = instructions;
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