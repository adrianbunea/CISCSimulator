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
        private char commentSymbol = ';';
        private readonly Dictionary<string, int> tokens = new Dictionary<string, int>
        {
            {"ADD", 0000},
        };

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
    }
}
