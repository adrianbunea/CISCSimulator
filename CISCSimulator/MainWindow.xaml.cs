using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using Path = System.IO.Path;

namespace CISCSimulator
{
    public partial class MainWindow : Window
    {
        Assembler assembler = new Assembler();
        string sourceCode;
        bool[] parseLocks = new bool[2] { false, false };
        int previousBase = 16;
        int currentBase = 16;

        public MainWindow()
        {
            InitializeComponent();
            assembler = new Assembler();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.GetFullPath(Path.Combine(path, @"..\..\"));
            path += "Assembly Code Files";

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = path
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filepath = openFileDialog.FileName;
                sourceCode = File.ReadAllText(filepath);
                codeTextBox.Text = sourceCode;
            }
            parseLocks[0] = true;
            parseCodeButton.IsEnabled = parseLocks[0] && parseLocks[1];
        }

        private void ParseCode(object sender, RoutedEventArgs e)
        {
            tokensListView.Items.Clear();
            List<string> foundTokens = assembler.ParseCode(sourceCode);

            foreach (string token in foundTokens)
            {
                tokensListView.Items.Add(token);
            }

            generateMachineInstructionsButton.IsEnabled = true;
        }

        private void InitializeAssembler(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.GetFullPath(Path.Combine(path, @"..\..\"));
            path += "Architecture Files";

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = path,
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string[] filepaths = openFileDialog.FileNames;
                assembler.InitializeArchitecture(filepaths);
                parseLocks[1] = true;
                parseCodeButton.IsEnabled = parseLocks[0] && parseLocks[1];
            }
        }

        private void GenerateMachineCode(object sender, RoutedEventArgs e)
        {
            List<UInt16> machineInstructions = assembler.GenerateMachineCode(sourceCode);
            machineInstructionsListView.Items.Clear();

            foreach (UInt16 instruction in machineInstructions)
            {
                machineInstructionsListView.Items.Add(Convert.ToString(instruction, currentBase).PadLeft(4, '0').ToUpper());
            }
        }

        private void ChangeBase(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            previousBase = currentBase;
            currentBase = Int32.Parse(item.Header.ToString());

            int padding;
            switch (currentBase)
            {
                case 2:
                    padding = 16;
                    break;
                case 16:
                    padding = 4;
                    break;
                default:
                    padding = 0;
                    break;
            }

            List<string> instructions = new List<string>();
            foreach (string instruction in machineInstructionsListView.Items)
            {
                int base10Instruction = Convert.ToInt32(instruction, previousBase);
                instructions.Add(Convert.ToString(base10Instruction, currentBase).PadLeft(padding, '0').ToUpper());
            }

            machineInstructionsListView.Items.Clear();
            foreach (string instruction in instructions)
            {
                machineInstructionsListView.Items.Add(instruction);
            } 
        }
    }
}
