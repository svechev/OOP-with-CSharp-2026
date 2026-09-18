using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Data Members
        double firstNumber;   // stores the first operand
        double secondNumber;  // stores the second operand
        double result;        // stores the computed result
       

        // Enum for every mathematical operation
        enum Operation { NO_OPERATION, ADDITION, SUBSTRACTION, DIVISION,MULTIPLICATION };
        Operation operation;
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            operation = Operation.NO_OPERATION;

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
            if (!double.TryParse(txtInput.Text, CultureInfo.InvariantCulture, out firstNumber))
            {
                MessageBox.Show("Wrong number input. Double value expacted.");
                txtInput.Text = "0";
                return;
            }

            // Initialize the data member "operation" with the correct operation
            _ = opCode switch
            {
                "+" => operation = Operation.ADDITION,
                "-" => operation = Operation.SUBSTRACTION,
                "/" => operation = Operation.DIVISION,
                "*" => operation = Operation.MULTIPLICATION,
                _ => throw new ArgumentException($"{nameof(operation)} is not supported.")
            };

            // Clear the input text box
            txtInput.Text = "0";

        }

        // Method for clicking the button "="
        private void Compute_Click(object sender, RoutedEventArgs e)
        {
            // No operation is specified
            if (operation == Operation.NO_OPERATION) return;

            // Check if the input text box contains a valid number
            if (!double.TryParse(txtInput.Text, CultureInfo.InvariantCulture, out secondNumber))
            {
                MessageBox.Show("Wrong number input. Double value expacted.");
                txtInput.Text = "0";
                return;
            }

            // Compute the result
            result = operation switch
            {
                Operation.ADDITION => firstNumber + secondNumber,
                Operation.SUBSTRACTION => firstNumber - secondNumber,
                Operation.DIVISION => firstNumber / secondNumber,
                Operation.MULTIPLICATION => firstNumber * secondNumber,
                _ => throw new ArgumentException($"{nameof(operation)} is not supported.")
            };

            // Display the result in the text box
            txtInput.Text = "" + result;

            // Clear the operation
            operation = Operation.NO_OPERATION;

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
            operation = Operation.NO_OPERATION;

        }

        // Method for clicking a mathematical function button
        private void Function_Click(object sender, RoutedEventArgs e)
        {
            // Get the name of the function
            string? funcName = ((Button)sender).Content.ToString();

            // // Check if the input text box contains a valid number
            if (!double.TryParse(txtInput.Text, CultureInfo.InvariantCulture, out firstNumber))
            {
                MessageBox.Show("Wrong number input. Double value expacted.");
                txtInput.Text = "0";
                return;
            }

            // Compute the result
            result = funcName switch
            {
                "e^x" => Math.Exp(firstNumber),
                "sin" => Math.Sin(firstNumber),
                "cos" => Math.Cos(firstNumber),
                "sqrt" => Math.Sqrt(firstNumber),
                "log" => Math.Log(firstNumber),
                "1/x" => 1 / firstNumber,
                _ => throw new ArgumentException($"Function {nameof(funcName)} is not supported.")
            };

            // Display the result in the text box
            txtInput.Text = "" + result;

            // Clear the operation
            operation = Operation.NO_OPERATION;
        } 
        #endregion
    }
}
