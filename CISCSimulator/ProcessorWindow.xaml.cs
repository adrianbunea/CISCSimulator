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
using System.Windows.Shapes;
using CISCSimulator.Classes.Simulator;

namespace CISCSimulator
{
    /// <summary>
    /// Interaction logic for ProcessorWindow.xaml
    /// </summary>
    public partial class ProcessorWindow : Window
    {
        Processor processor;
        public ProcessorWindow()
        {
            InitializeComponent();
            processor = new Processor();
        }
    }
}
