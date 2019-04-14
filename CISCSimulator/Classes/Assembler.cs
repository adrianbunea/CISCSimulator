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
        private readonly Dictionary<string, int> tokens = new Dictionary<string, int>
        {
            {"ADD", 0000},
        };

        private readonly string[] delimiters = { ":", ",", " ", "(", ")" };

        List<string> foundTokens = new List<string>();

        TextFieldParser parser;


        public List<string> Parse(string filepath)
        {
            int lineCounter = 0;

            parser = new TextFieldParser(filepath)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = delimiters
            };

            while (!parser.EndOfData)
            {
                string[] lineTokens = parser.ReadFields();

                foreach (string token in lineTokens)
                {
                    if (!token.Equals(""))
                    {
                        foundTokens.Add(token);
                    }
                }
                lineCounter++;
            }

            parser.Close();

            if (lineCounter == 0)
            {
                Exception exception = new Exception("The ASM file is empty!");
                throw exception;
            }

            return foundTokens;
        }

        public string[] RemoveComments(string filepath)
        {
            List<string> codeWithoutComments = new List<string>();
            string[] commentDelimiters = { ";" };
            parser = new TextFieldParser(filepath)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = commentDelimiters
            };

            while (!parser.EndOfData)
            {
                string[] elements = parser.ReadFields();

                foreach (string element in elements)
                {
                    if (!element.Equals("") && Array.IndexOf(elements, element) != 1) //Daca are index 1 inseamna ca e dupa ';'
                    {
                        codeWithoutComments.Add(element);
                    }
                }
            }

            return codeWithoutComments.ToArray<string>();
        }
    }
}
