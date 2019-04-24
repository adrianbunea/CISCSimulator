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
        private Dictionary<string, int>[] architecture;

        private readonly char commentSymbol = ';';
        private readonly char[] symbols = { ':', ',', ' ', '(', ')' };

        private List<string> foundTokens = new List<string>();

        public List<string> ParseCode(string sourceCode)
        {
            int lineCounter = 0;
            foundTokens.Clear();

            List<string> sourceCodeWithoutComments = RemoveComments(sourceCode);

            foreach (string line in sourceCodeWithoutComments)
            {
                List<string> splitLine = line.Split(symbols).ToList();
                splitLine.RemoveAll(element => string.IsNullOrEmpty(element));
                foundTokens.AddRange(splitLine);
                lineCounter++;
            }

            if (lineCounter == 0)
            {
                Exception exception = new Exception("The ASM file is empty!");
                throw exception;
            }

            return foundTokens;
        }

        private List<string> RemoveComments(string sourceCode)
        {
            List<string> sourceCodeLines = new List<string>();
            using (StringReader stringReader = new StringReader(sourceCode))
            {
                string line;
                while ((line = stringReader.ReadLine()) != null)
                {
                    sourceCodeLines.Add(line);
                }
            }

            for (int i = 0; i < sourceCodeLines.Count; i++)
            {
                string[] lineParts = sourceCodeLines[i].Split(commentSymbol);
                sourceCodeLines[i] = lineParts[0];
            }
            return sourceCodeLines;
        }

        public void ParseArchitecture(string[] filepaths)
        {
            string instructionsFile = File.ReadAllText(filepaths[Constants.INSTRUCTIONS]);
            string addressingModesFile = File.ReadAllText(filepaths[Constants.ADDRESSING_MODES]);
            string generalRegistersFile = File.ReadAllText(filepaths[Constants.REGISTERS]);

            Dictionary<string, int> instructions = ParseInstructions(instructionsFile);
            Dictionary<string, int> addressingModes = ParseAddressingModes(addressingModesFile);
            Dictionary<string, int> generalRegisters = ParseGeneralRegisters(generalRegistersFile);

            architecture = new Dictionary<string, int>[]
            {
                instructions, addressingModes, generalRegisters
            };
        }

        private Dictionary<string, int> ParseInstructions(string instructionsFile)
        {
            Dictionary<string, int> instructions = new Dictionary<string, int>();
            return instructions;
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
