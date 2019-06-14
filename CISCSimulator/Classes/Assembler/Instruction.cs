using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CISCSimulator
{
    class Instruction
    {
        private readonly Regex regexImmediateValue = new Regex(@"(?<![r\]\d])\d{1,5}(?![\[\]\d])", RegexOptions.IgnoreCase);
        private readonly Regex regexDirectValue = new Regex(@"(?<!\[r)(?<=r)\d{1,2}(?!\])", RegexOptions.IgnoreCase);
        private readonly Regex regexIndirectValue = new Regex(@"(?<!\d\[r)(?<=\[r)(\d{1,2})(?=\])(?!\]\d{1,5})", RegexOptions.IgnoreCase);
        private readonly Regex regexIndexedValue = new Regex(@"(\[r\d{1,2}\])\d{1,5}|\d{1,5}(\[r\d{1,2}\])", RegexOptions.IgnoreCase);
        private readonly Regex regexIndexedRegister = new Regex(@"(?<=\[r)\d{1,2}(?=\])", RegexOptions.IgnoreCase);
        private readonly Regex regexIndexedOffset = new Regex(@"(?<=\])\d{1,5}|\d{1,5}(?=\[)", RegexOptions.IgnoreCase);

        private readonly char[] splitTerms = { ',', ' ' };

        public static Dictionary<string, int> instructionSetCodifications;
        public static Dictionary<string, int> addressingModesCodifications;
        public static Dictionary<string, int> generalRegistersCodifications;

        private readonly string assemblyContent = "";
        private string opcode;
        private UInt16 binaryOpcode;
        private int instructionClass;

        private UInt16 sourceAddressingMode;
        private Int16 immediateSource;
        private UInt16 directSource;
        private UInt16 indirectSource;
        private UInt16 indexedSource;
        private Int16 indexedSourceOffset;

        private UInt16 destinationAddressingMode;
        private UInt16 directDestination;
        private UInt16 indirectDestination;
        private UInt16 indexedDestination;
        private Int16 indexedDestinationOffset;

        private Int16 offset;

        private void GenerateOpcode()
        {
            opcode = this.assemblyContent.Split(' ')[0].Trim();
        }

        private void GenerateBinaryOpcode()
        {
            UInt16 opcodeBits = (UInt16)instructionSetCodifications[opcode];
            int shiftCount = Convert.ToString(instructionSetCodifications[opcode], 2).Length;
            if (shiftCount < 4) shiftCount = 4;
            opcodeBits <<= 16-shiftCount;
            binaryOpcode = opcodeBits;
        }

        public void GenerateClass()
        {
            int c0, c1, b15, b14, b13;

            UInt16 bits = binaryOpcode;

            b15 = (bits & (UInt16)Masks.BIT15) >> 15;
            b14 = (bits & (UInt16)Masks.BIT14) >> 14;
            b13 = (bits & (UInt16)Masks.BIT13) >> 13;

            c0 = b15 & (~(~b14 & b13));
            c1 = b15 & (b14 ^ b13);

            instructionClass = c0 + (c1 << 1); 
            //0 - b1
            //1 - b2
            //3 - b3
            //2 - b4
        }

        public int GetSourceAddressingMode()
        {
            return sourceAddressingMode;
        }

        public int GetDestinationAddressingMode()
        {
            return destinationAddressingMode;
        }

        private void GenerateSource()
        {
            if (instructionClass == 0)
            {
                bool foundMatch = false;
                List<string> splitInstruction = assemblyContent.Split(splitTerms).ToList();
                splitInstruction = Helper.RemoveEmptyParts(splitInstruction);
                string assemblySource = splitInstruction[2];

                MatchCollection matches = regexImmediateValue.Matches(assemblySource);
                if (matches.Count > 0)
                {
                    sourceAddressingMode = 0;
                    immediateSource = Int16.Parse(matches[0].Value);
                    foundMatch = true;
                }

                matches = regexDirectValue.Matches(assemblySource);
                if (matches.Count > 0)
                {
                    sourceAddressingMode = 1;
                    directSource = UInt16.Parse(matches[0].Value);
                    foundMatch = true;
                }

                matches = regexIndirectValue.Matches(assemblySource);
                if (matches.Count > 0)
                {
                    sourceAddressingMode = 2;
                    indirectSource =  UInt16.Parse(matches[0].Value);
                    foundMatch = true;
                }

                matches = regexIndexedValue.Matches(assemblySource);
                if (matches.Count > 0)
                {
                    sourceAddressingMode = 3;
                    Match temp = matches[0];
 
                    matches = regexIndexedRegister.Matches(temp.Value);
                    indexedSource = UInt16.Parse(matches[0].Value);

                    matches = regexIndexedOffset.Matches(temp.Value);
                    indexedSourceOffset = Int16.Parse(matches[0].Value);

                    foundMatch = true;
                }

                if (foundMatch == false) throw new Exception("Unknown addressing mode!");
            }
        }

        void GenerateDestination()
        {
            bool foundMatch = false;
            List<string> splitInstruction = assemblyContent.Split(splitTerms).ToList();
            splitInstruction = Helper.RemoveEmptyParts(splitInstruction);
            string assemblyDestination;

            if (instructionClass == 0)
            {
                assemblyDestination = splitInstruction[1];

                MatchCollection matches = regexImmediateValue.Matches(assemblyDestination);
                if (matches.Count > 0)
                {
                    throw new Exception("Destination cannot be an immediate value!");
                }

                matches = regexDirectValue.Matches(assemblyDestination);
                if (matches.Count > 0)
                {
                    destinationAddressingMode = 1;
                    directDestination = UInt16.Parse(matches[0].Value);
                    foundMatch = true;
                }

                matches = regexIndirectValue.Matches(assemblyDestination);
                if (matches.Count > 0)
                {
                    destinationAddressingMode = 2;
                    indirectDestination = UInt16.Parse(matches[0].Value);
                    foundMatch = true;
                }

                matches = regexIndexedValue.Matches(assemblyDestination);
                if (matches.Count > 0)
                {
                    destinationAddressingMode = 3;
                    Match temp = matches[0];

                    matches = regexIndexedRegister.Matches(temp.Value);
                    indexedDestination = UInt16.Parse(matches[0].Value);

                    matches = regexIndexedOffset.Matches(temp.Value);
                    indexedDestinationOffset = Int16.Parse(matches[0].Value);

                    foundMatch = true;
                }

                if (foundMatch == false) throw new Exception("Unknown addressing mode!");
            }

            if (instructionClass == 1)
            {
                assemblyDestination = splitInstruction[1];

                MatchCollection matches = regexImmediateValue.Matches(assemblyDestination);
                if (matches.Count > 0)
                {
                    throw new Exception("Destination cannot be an immediate value!");
                }

                matches = regexDirectValue.Matches(assemblyDestination);
                if (matches.Count > 0)
                {
                    destinationAddressingMode = 1;
                    directDestination = UInt16.Parse(matches[0].Value);
                    foundMatch = true;
                }

                matches = regexIndirectValue.Matches(assemblyDestination);
                if (matches.Count > 0)
                {
                    destinationAddressingMode = 2;
                    indirectDestination = UInt16.Parse(matches[0].Value);
                    foundMatch = true;
                }

                matches = regexIndexedValue.Matches(assemblyDestination);
                if (matches.Count > 0)
                {
                    destinationAddressingMode = 3;
                    Match temp = matches[0];

                    matches = regexIndexedRegister.Matches(temp.Value);
                    indexedDestination = UInt16.Parse(matches[0].Value);

                    matches = regexIndexedOffset.Matches(temp.Value);
                    indexedDestinationOffset = Int16.Parse(matches[0].Value);

                    foundMatch = true;
                }

                if (foundMatch == false) throw new Exception("Unknown addressing mode!");
            }
        }

        void GenerateOffset()
        {
            if (instructionClass == 3)
            {
                List<string> splitInstruction = assemblyContent.Split(splitTerms).ToList();
                splitInstruction = Helper.RemoveEmptyParts(splitInstruction);
                string assemblyOffset = splitInstruction[1];
                offset = Int16.Parse(assemblyOffset);
            }
        }

        public List<UInt16> GenerateInstructions()
        {
            List<UInt16> instructions = new List<UInt16>();
            GenerateOpcode();
            GenerateBinaryOpcode();
            GenerateClass();
            GenerateSource();
            GenerateDestination();
            GenerateOffset();

            switch (instructionClass)
            {
                case 0:
                    instructions.AddRange(GenerateB1Instructions());
                    break;
                case 1:
                    instructions.AddRange(GenerateB2Instructions());
                    break;
                case 3:
                    instructions.Add(GenerateB3Instruction());
                    break;
                case 2:
                    instructions.Add(GenerateB4Instruction());
                    break;
                default:
                    throw new Exception("Unknown instruction class!");
            }
            return instructions;
        }

        List<UInt16> GenerateB1Instructions()
        {
            List<UInt16> instructions = new List<UInt16>();
            UInt16 opcode = binaryOpcode;

            UInt16 source;            
            UInt16 destination;

            switch(sourceAddressingMode)
            {
                case 0:
                    source = 0;
                    break;
                case 1:
                    source = directSource;
                    break;
                case 2:
                    source = indirectSource;
                    break;
                case 3:
                    source = indexedSource;
                    break;
                default:
                    throw new Exception("Unknown addressing mode!");
            }

            switch (destinationAddressingMode)
            {
                case 0:
                    throw new Exception("Destination cannot be an immediate value!");
                case 1:
                    destination = directDestination;
                    break;
                case 2:
                    destination = indirectDestination;
                    break;
                case 3:
                    destination = indexedDestination;
                    break;
                default:
                    throw new Exception("Unknown addressing mode!");
            }

            UInt16 mainInstruction = (UInt16)(opcode | (sourceAddressingMode << 10) | (source << 6) | (destinationAddressingMode << 4) | (destination));
            instructions.Add(mainInstruction);

            if (sourceAddressingMode == 0)
            {
                instructions.Add((UInt16)immediateSource);
            }

            if (sourceAddressingMode == 3)
            {
                instructions.Add((UInt16)indexedSourceOffset);
            }

            if (destinationAddressingMode == 3)
            {
                instructions.Add((UInt16)indexedDestinationOffset);
            }

            return instructions;
        }

        List<UInt16> GenerateB2Instructions()
        {
            List<UInt16> instructions = new List<UInt16>();
            UInt16 opcode = binaryOpcode;

            UInt16 destination;

            switch (destinationAddressingMode)
            {
                case 0:
                    throw new Exception("Destination cannot be an immediate value!");
                case 1:
                    destination = directDestination;
                    break;
                case 2:
                    destination = indirectDestination;
                    break;
                case 3:
                    destination = indexedDestination;
                    break;
                default:
                    throw new Exception("Unknown addressing mode!");
            }

            UInt16 mainInstruction = (UInt16)(opcode | (destinationAddressingMode << 4) | (destination));
            instructions.Add(mainInstruction);

            if (destinationAddressingMode == 3)
            {
                instructions.Add((UInt16)indexedDestinationOffset);
            }

            return instructions;
        }

        UInt16 GenerateB3Instruction()
        {
            UInt16 opcode = binaryOpcode;
            UInt16 uOffset = (UInt16)(offset & (UInt16)Masks.OFFSET);
            UInt16 instruction = (UInt16)(opcode | uOffset);
            return instruction;
        }

        UInt16 GenerateB4Instruction()
        {
            return binaryOpcode;
        }

        public Instruction(string assemblyInstruction)
        {
            this.assemblyContent = assemblyInstruction;
        }
    }
}
