using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for CalculatorUserControl.xaml
    /// </summary>
    public partial class CalculatorUserControl : UserControl
    {
        #region Data Members
        // enum for the operation symbol
        public enum Operation { NO_OPERATION, ADDITION, SUBTRACTION, DIVISION, MULTIPLICATION };

        // Enum for every mathematical operation
        #endregion

        #region Properties
        public double FirstNumber { set; get; }
        public double SecondNumber { set; get; }
        public double MemoryNumber { set; get; }
        public double Result { private set; get; }
        public Operation CurrentOperation { get; set; } = Operation.NO_OPERATION;
        #endregion


        #region Constructors
        public CalculatorUserControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Functions
        // Method for clicking button OFF, closes the calculator
        private void BtnOff_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        // Method for clicking a number
        private void Digital_Click(object sender, RoutedEventArgs e)
        {
            // Get the value of the clicked button
            string? buttonText = ((Button)sender).Content.ToString();

            // Add the new number in the input text box
            if (txtInput.Text == "0")
            {
                txtInput.Text = buttonText;
            }
            else
            {
                if (buttonText != ".")
                {
                    txtInput.Text = $"{txtInput.Text}{buttonText}";
                }

                // This code prevents adding more than one decimal point
                else
                {
                    if (buttonText == "." && !txtInput.Text.Contains("."))
                    {
                        txtInput.Text = $"{txtInput.Text}{buttonText}";
                    }
                }
            }
        }

        // Method for clicking an operation
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            // Get the sign of the clicked operation
            string? opCode = ((Button)sender).Content.ToString();

            // Check if the input text box contains a valid number
            if (ValidateInput(txtInput.Text, out double res))
            {
                FirstNumber = res;
            }
            else return;

            // Initialize the data member "operation" with the correct operation
            _ = opCode switch
            {
                "+" => CurrentOperation = Operation.ADDITION,
                "-" => CurrentOperation = Operation.SUBTRACTION,
                "/" => CurrentOperation = Operation.DIVISION,
                "*" => CurrentOperation = Operation.MULTIPLICATION,
                _ => throw new ArgumentException($"{nameof(CurrentOperation)} is not supported.")
            };

            // Clear the input text box
            txtInput.Text = "0";

        }

        // Method for clicking the button "="
        private void Compute_Click(object sender, RoutedEventArgs e)
        {
            // No operation is specified
            if (CurrentOperation == Operation.NO_OPERATION) return;

            // Check if the input text box contains a valid number
            if (ValidateInput(txtInput.Text, out double res))
            {
                SecondNumber = res;
            }
            else return;

            // compute result
            try
            {
                ComputeResult();
            }
            catch (DivideByZeroException) // catch division by zero
            {
                MessageBox.Show("Error! Division by zero.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Display the result in the text box
            txtInput.Text = "" + Result;

            // Clear the operation
            CurrentOperation = Operation.NO_OPERATION;

        }

        // Method for clicking Clear button
        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "0";
        }

        // Method for clicking Clear All button
        private void btnCA_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "0";
            CurrentOperation = Operation.NO_OPERATION;

        }

        // Method for clicking memory store button
        private void btnM_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput(txtInput.Text, out double res))
            {
                MemoryNumber = res;
            }
        }

        // Method for calculation with a memory number button
        private void btnMOp_Click(object sender, RoutedEventArgs e)
        {
            string? opCode = ((Button)sender).Content.ToString()?.Substring(1);

            // Get the correct operation
            Operation op = opCode switch
            {
                "+" => Operation.ADDITION,
                "-" => Operation.SUBTRACTION,
                _ => throw new ArgumentException($"{nameof(opCode)} is not supported.")
            };

            // Get the input and calculate the result
            if (ValidateInput(txtInput.Text, out double input))
            {
                ComputeResultMemory(input, op);
                txtInput.Text = "" + Result;
            }
        }

        // Method for clicking clearing memory button
        private void btnMClear_Click(object sender, RoutedEventArgs e)
        {
            // operations are +/-, so 0 is equivalent to having nothing in memory
            MemoryNumber = 0;
        }

        // Helper method for validating input
        private bool ValidateInput(string input, out double res)
        {
            if (!double.TryParse(txtInput.Text, CultureInfo.InvariantCulture, out res))
            { // error
                MessageBox.Show("Wrong number input. Double value expected.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtInput.Text = input;
                return false;
            } // valid


            else
            {
                return true;
            }
        }

        #endregion


        #region Utility methods
        // helper method that computes the result after clicking "="
        public void ComputeResult()
        {
            // special case: division by 0
            if (CurrentOperation == Operation.DIVISION && SecondNumber == 0)
            {
                throw new DivideByZeroException();
            }

            // calculate result
            Result = CurrentOperation switch
            {
                Operation.ADDITION => FirstNumber + SecondNumber,
                Operation.SUBTRACTION => FirstNumber - SecondNumber,
                Operation.DIVISION => FirstNumber / SecondNumber,
                Operation.MULTIPLICATION => FirstNumber * SecondNumber,
                _ => throw new ArgumentException($"{nameof(CurrentOperation)} is not supported.")
            };
        }

        // helper method that calculates the result after performing an operation
        // with the number stored in memory
        public void ComputeResultMemory(double input, Operation op)
        {
            Result = op switch
            {
                Operation.ADDITION => MemoryNumber + input,
                Operation.SUBTRACTION => input - MemoryNumber,
                _ => throw new ArgumentException($"{nameof(op)} is not supported.")
            };
        }
        #endregion
    }
}
