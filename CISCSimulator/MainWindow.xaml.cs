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
                machineInstructionsListView.Items.Add(Convert.ToString(instruction, 16).ToUpper());
            }
        }
    }
}
