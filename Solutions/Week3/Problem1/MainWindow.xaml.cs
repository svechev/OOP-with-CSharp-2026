using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace CalculatorSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Data members
        double firstNumber;
        double secondNumber;
        double result;
        bool firstInput;

        enum Operation { NO_OPERATION, ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION };
        Operation operation; 
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            operation = Operation.NO_OPERATION;
            firstInput = false;
        }

        private void BtnOff_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void DigitalClick(object sender, RoutedEventArgs e)
        {
            string? buttonText = ((Button)sender).Content.ToString();

            if (txtInput.Text == "0")
            {
                txtInput.Text = buttonText;
            }
            else
            {
                if (buttonText != "," || !txtInput.Text.Contains(','))
                {
                    txtInput.Text = $"{txtInput.Text}{buttonText}";
                }
            }
        }

        private void OperationClick(object sender, RoutedEventArgs e)
        {
            string? opCode = ((Button)sender).Content.ToString();
            if (!double.TryParse(txtInput.Text, out firstNumber)) 
            {
                MessageBox.Show("Wrong number input! Double value expected.");
                txtInput.Text = "0";
                firstInput = false;
                return;
            }
            firstInput = true;

            _ = opCode switch
            {
                "+" => operation = Operation.ADDITION,
                "-" => operation = Operation.SUBTRACTION,
                "*" => operation = Operation.MULTIPLICATION,
                "/" => operation = Operation.DIVISION,
                _ => throw new ArgumentException($"{nameof(operation)} is not supported")
            };
            txtInput.Text = "0";
        }

        private void ComputeClick(object sender, RoutedEventArgs e)
        {
            if (!firstInput) return;

            if (!double.TryParse(txtInput.Text, out secondNumber))
            {
                MessageBox.Show("Wrong number input! Double value expected.");
                txtInput.Text = "0";
                return;
            }

            result = operation switch
            {
                Operation.ADDITION => firstNumber + secondNumber,
                Operation.SUBTRACTION => firstNumber - secondNumber,
                Operation.MULTIPLICATION => firstNumber * secondNumber,
                Operation.DIVISION => firstNumber / secondNumber,
                _ => throw new ArgumentException($"{nameof(operation)} is not supported")
            };
            txtInput.Text = "" + result;
            operation = Operation.NO_OPERATION;
            firstInput = false;
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "0";
        }

        private void btnCA_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "0";
            operation = Operation.NO_OPERATION;
        }
    }
}
