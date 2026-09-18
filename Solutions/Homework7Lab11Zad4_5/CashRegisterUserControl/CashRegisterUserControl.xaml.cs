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

namespace CashRegisterUserControl
{
    /// <summary>
    /// Interaction logic for CashRegisterUserControl.xaml
    /// </summary>
    public partial class CashRegisterUserControl : UserControl
    {
        #region Data members
        const decimal TAX_RATE = 0.05M;
        List<decimal> prices = new List<decimal>();
        #endregion

        #region Constructor
        public CashRegisterUserControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Utility methods
        // method for clicking a number button
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
                // Digit was clicked
                if (buttonText != ".")
                {
                    // Allow only 2 digits after floating point
                    if (txtInput.Text.Contains("."))
                    {
                        int digitsAfterPoint = txtInput.Text.Substring(txtInput.Text.IndexOf('.') + 1).Length;
                        if (digitsAfterPoint < 2)
                        {
                            txtInput.Text = $"{txtInput.Text}{buttonText}";
                        }
                    }

                    // No floating point
                    else
                    {
                        txtInput.Text = $"{txtInput.Text}{buttonText}";
                    }
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

        // method for clicking enter button
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            // get input and validate it
            string? input = txtInput.Text;
            ValidateInput(input, out var price);

            // add it to the list of prices, clear current input
            prices.Add(price);
            txtInput.Text = "";
        }

        // method for clicking total button
        private void btnTotal_Click(object sender, RoutedEventArgs e)
        {
            // display subtotal
            decimal subtotal = prices.Sum();
            txtSubtotal.Text = $"{subtotal:F2}";

            // display tax
            decimal tax = subtotal * TAX_RATE;
            txtTax.Text = $"{tax:F2}";

            // display total
            decimal total = subtotal + tax;
            txtTotal.Text = $"{total:F2}";

            // clear previous prices
            prices.Clear();
        }

        // method for clicking delete button
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
        }

        // method for clicking clear button
        private void btnClr_Click(object sender, RoutedEventArgs e)
        {
            // clear every textbox, remove current prices
            txtInput.Text = "";
            txtSubtotal.Text = "";
            txtTax.Text = "";
            txtTotal.Text = "";
            prices.Clear();
        }

        // helper method for validating input
        private bool ValidateInput(string input, out decimal res)
        {
            if (!decimal.TryParse(txtInput.Text, CultureInfo.InvariantCulture, out res))
            { // error
                MessageBox.Show("Wrong number input. Decimal value expected.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtInput.Text = input;
                return false;
            }

            // check for digits after floating point
            if (decimal.Round(res, 2) != res)
            {
                MessageBox.Show("Only 2 digits after floating point allowed.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // valid
            else
            {
                return true;
            }
        } 
        #endregion
    }
}

