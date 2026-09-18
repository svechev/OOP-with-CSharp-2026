using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ServiceReference1;

namespace ProductClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IOrderWService client;

        public MainWindow()
        {
            InitializeComponent();

            client = new OrderWServiceClient();

            LoadProducts();

            orderProduct.Order += Update;
            
        }

        public async void LoadProducts()
        {
            var client = new OrderWServiceClient();

            Product[] products = await Task.Run(() => client.RetrieveAsync());

            ComboBox cboProduct = orderProduct.CboProduct;
            foreach (Product product in products)
            {
                cboProduct.Items.Add(product);
            }
        }

        private async void Update(object? sender, TradeServices.OrderEventArgs e)
        {
            var res = client.UpdateAsync(Title, e.ProductID, e.Qty);
                //sender = Title,
                //productID = e.ProductID,
                //qty = e.Qty
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int clientNum = rand.Next(0, 1001);
            Title = "Order client " + clientNum;
        }
    }
}