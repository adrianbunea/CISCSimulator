using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISCSimulator
{
    public static class Helper
    {
        public static List<string> ReadLinesFromFile(string file)
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


        public static List<string> RemoveEmptyParts(List<string> splitLine)
        {
            List<string> splitLineCopy = splitLine;
            splitLineCopy.RemoveAll(element => string.IsNullOrEmpty(element) || element == "\t");
            return splitLine;
        }
    }
}
