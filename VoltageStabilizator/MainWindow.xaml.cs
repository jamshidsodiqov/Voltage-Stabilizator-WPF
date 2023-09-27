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
using Voltage_Stablizer;

namespace VoltageStabilizator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Methods method = new Methods();
        private void Enter_parameters_click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EnterParams();
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            method.Writer();
            this.Close();
        }
    }
}
