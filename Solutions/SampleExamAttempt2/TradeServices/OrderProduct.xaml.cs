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

namespace TradeServices
{
    /// <summary>
    /// Interaction logic for OrderProduct.xaml
    /// </summary>
    public partial class OrderProduct : UserControl
    {
        public event EventHandler<OrderEventArgs>? Order;
        public ComboBox CboProduct
        {
            get => cboProduct;
        }

        public OrderProduct()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtQty.Text = "0";
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            string prodId = cboProduct.SelectedItem?.ToString() ?? string.Empty;
            int qty = int.Parse(txtQty.Text);
            Order?.Invoke(this, new OrderEventArgs(prodId, qty));
        }
    }
}
