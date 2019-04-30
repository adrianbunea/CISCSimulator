using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace CISCSimulator
{
    class Assembler
    {
        private ArchitectureCodification architectureCodification;

        private readonly char commentSymbol = ';';
        private readonly char[] symbols = { ':', ',', ' ', '(', ')' };

        private List<string> foundTokens = new List<string>();

        public List<string> ParseCode(string sourceCode)
        {
            foundTokens.Clear();
            List<string> sourceCodeLines = Helper.ReadLinesFromFile(sourceCode);
            sourceCodeLines = RemoveComments(sourceCodeLines);
            FindTokens(sourceCodeLines);

            return foundTokens;
        }

        private void FindTokens(List<string> sourceCodeLines)
        {
            foreach (string line in sourceCodeLines)
            {
                List<string> splitLine = SplitSourceCodeLine(line);
                foundTokens.AddRange(Helper.RemoveEmptyParts(splitLine));
            }

            CheckIfFileWasEmpty();
        }

        private List<string> SplitSourceCodeLine(string line)
        {
            return line.Split(symbols).ToList();
        }

        private void CheckIfFileWasEmpty()
        {
            if (foundTokens.Count == 0)
            {
                throw new Exception("The ASM file is empty!");
            }
        }

        private List<string> RemoveComments(List<string> sourceCodeLines)
        {
            for (int i = 0; i < sourceCodeLines.Count; i++)
            {
                string[] lineParts = sourceCodeLines[i].Split(commentSymbol);
                sourceCodeLines[i] = lineParts[0];
            }
            return sourceCodeLines;
        }

        public void InitializeArchitecture(string[] filepaths)
        {
            architectureCodification.ParseArchitecture(filepaths);
        }

        public Assembler()
        {
            architectureCodification = new ArchitectureCodification();
        }
    }
}
