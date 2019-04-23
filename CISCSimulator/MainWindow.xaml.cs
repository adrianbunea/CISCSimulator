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

namespace CISCSimulator
{
    public partial class MainWindow : Window
    {
        Assembler assembler;
        string sourceCode;
        string filepath;

        public MainWindow()
        {
            InitializeComponent();
            assembler = new Assembler();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                filepath = openFileDialog.FileName;
                sourceCode = File.ReadAllText(filepath);
                codeTextBox.Text = sourceCode;
            }
        }

        private void ParseCode(object sender, RoutedEventArgs e)
        {
            tokensListView.Items.Clear();
            List<string> foundTokens = assembler.ParseCode(sourceCode);

            foreach (string token in foundTokens)
            {
                tokensListView.Items.Add(token);
            }
        }
    }
}
