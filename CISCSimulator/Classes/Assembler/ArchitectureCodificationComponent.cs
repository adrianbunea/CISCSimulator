using System.Collections.Generic;
using System.Linq;

namespace CISCSimulator
{
    public static class ArchitectureCodificationComponent
    {
        public static Dictionary<string, int> CreateCodifications(List<string> architectureCodificationLines)
        {
            Dictionary<string, int> codifications = new Dictionary<string, int>();
            for (int i = 0; i < architectureCodificationLines.Count; i++)
            {
                List<string> splitCodificationLine = architectureCodificationLines[i].Split(' ').ToList();
                splitCodificationLine = Helper.RemoveEmptyParts(splitCodificationLine);
                codifications.Add(Mnemonic(splitCodificationLine), Codification(splitCodificationLine));
            }
            return codifications;
        }

        private static int Codification(List<string> splitCodificationLine)
        {
            return int.Parse(splitCodificationLine[1].Trim(), System.Globalization.NumberStyles.HexNumber);
        }

        private static string Mnemonic(List<string> splitCodificationLine)
        {
            return splitCodificationLine[0].Trim();
        }
    }
}
