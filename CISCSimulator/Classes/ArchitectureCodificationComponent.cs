using System.Collections.Generic;
using System.Linq;

namespace CISCSimulator
{
    public abstract class ArchitectureCodificationComponent
    {
        public Dictionary<string, int> codifications;

        public ArchitectureCodificationComponent()
        {
            codifications = new Dictionary<string, int>();
        }
        public abstract void Parse(string architectureCodificationFile);
        protected void CreateCodifications(List<string> architectureCodificationLines)
        {
            for (int i = 0; i < architectureCodificationLines.Count; i++)
            {
                List<string> splitCodificationLine = architectureCodificationLines[i].Split(' ').ToList();
                Helper.RemoveEmptyParts(ref splitCodificationLine);
                codifications.Add(Mnemonic(splitCodificationLine), Codification(splitCodificationLine));
            }
        }

        private int Codification(List<string> splitCodificationLine)
        {
            return int.Parse(splitCodificationLine[1].Trim(), System.Globalization.NumberStyles.HexNumber);
        }

        private string Mnemonic(List<string> splitCodificationLine)
        {
            return splitCodificationLine[0].Trim();
        }
    }

    public class InstructionSetCodification : ArchitectureCodificationComponent
    {
        public override void Parse(string instructionsCodificationFile)
        {
            List<string> instructionLines = Helper.ReadLinesFromFile(instructionsCodificationFile);
            CreateCodifications(instructionLines);
        }

        public InstructionSetCodification(string instructionsCodificationFile)
        {
            Parse(instructionsCodificationFile);
        }
    }

    public class AddressingModesCodification : ArchitectureCodificationComponent
    {
        public override void Parse(string addressingModesCodificationFile)
        {
            List<string> addressingModesLines = Helper.ReadLinesFromFile(addressingModesCodificationFile);
            CreateCodifications(addressingModesLines);
        }

        public AddressingModesCodification(string addressingModesCodificationFile)
        {
            Parse(addressingModesCodificationFile);
        }
    }

    public class GeneralRegistersCodification : ArchitectureCodificationComponent
    {
        public override void Parse(string generalRegistersCodificationFile)
        {
            List<string> generalRegistersLines = Helper.ReadLinesFromFile(generalRegistersCodificationFile);
            CreateCodifications(generalRegistersLines);
        }

        public GeneralRegistersCodification(string generalRegistersCodificationFile)
        {
            Parse(generalRegistersCodificationFile);
        }
    }
}
