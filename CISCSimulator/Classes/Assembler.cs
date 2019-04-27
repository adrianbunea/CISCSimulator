﻿using System;
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

        public void InitializeArchitecture(string[] filepaths)
        {
            architectureCodification.ParseArchitecture(filepaths);
        }
    }
}
