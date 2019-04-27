using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace CISCSimulator
{ 
    class Assembler
    {
        private Dictionary<string, int>[] architecture = new Dictionary<string, int>[3];

        private readonly char commentSymbol = ';';
        private readonly char[] symbols = { ':', ',', ' ', '(', ')' };

        private List<string> foundTokens = new List<string>();

        public List<string> ParseCode(string sourceCode)
        {
            foundTokens.Clear();
            List<string> sourceCodeLines = ReadLinesFromFile(sourceCode);
            RemoveComments(ref sourceCodeLines);
            FindTokens(sourceCodeLines);

            return foundTokens;
        }

        private void FindTokens(List<string> sourceCodeLines)
        {
            foreach (string line in sourceCodeLines)
            {
                List<string> splitLine = line.Split(symbols).ToList();
                splitLine.RemoveAll(element => string.IsNullOrEmpty(element));
                foundTokens.AddRange(splitLine);
            }

            CheckIfFileWasEmpty();
        }

        private void CheckIfFileWasEmpty()
        {
            if (foundTokens.Count == 0)
            {
                Exception exception = new Exception("The ASM file is empty!");
                throw exception;
            }
        }

        private List<string> RemoveComments(ref List<string> sourceCodeLines)
        {
            for (int i = 0; i < sourceCodeLines.Count; i++)
            {
                string[] lineParts = sourceCodeLines[i].Split(commentSymbol);
                sourceCodeLines[i] = lineParts[0];
            }
            return sourceCodeLines;
        }

        public void ParseArchitecture(string[] filepaths)
        {
            string[] architectureFiles = ReadArchitectureFiles(filepaths);
            ParseInstructions(architectureFiles[Constants.INSTRUCTIONS]);
            ParseAddressingModes(architectureFiles[Constants.ADDRESSING_MODES]);
            ParseGeneralRegisters(architectureFiles[Constants.REGISTERS]);
        }

        private static string[] ReadArchitectureFiles(string[] filepaths)
        {
            string[] architectureFiles = new string[3];
            architectureFiles[Constants.INSTRUCTIONS] = File.ReadAllText(filepaths[Constants.INSTRUCTIONS]);
            architectureFiles[Constants.ADDRESSING_MODES] = File.ReadAllText(filepaths[Constants.ADDRESSING_MODES]);
            architectureFiles[Constants.REGISTERS] = File.ReadAllText(filepaths[Constants.REGISTERS]);
            return architectureFiles;
        }

        private void ParseInstructions(string instructionsFile)
        {
            List<string> instructionLines = ReadLinesFromFile(instructionsFile);
            Dictionary<string, int> instructions = CreateInstructions(instructionLines);
            architecture[Constants.INSTRUCTIONS] = instructions;
        }

        private static List<string> ReadLinesFromFile(string file)
        {
            List<string> lines = new List<string>();

            using (StringReader stringReader = new StringReader(file))
            {
                string line;
                while ((line = stringReader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
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
