using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Threading;
using TradeServices;

namespace TradeSoapService.BusinessLogic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrderWService
    {

        [OperationContract]
        Product[] Retrieve();

        [OperationContract]
        void Update(string sender, string productID, int qty);
    }

    // [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TradeProducts : IOrderWService
    {
        private Dictionary<string, Product> products = [];

        public TradeProducts()
        {
            Random rand = new Random();

            int numProducts = rand.Next(6, 12);
            Category category = (Category)rand.Next(0, 3);
            int preorderLevel = rand.Next(6, 13);
            for (int i = 0; i < numProducts; i++)
            {
                Product prod = new(category, 12, preorderLevel);
                products.Add(prod.ID, prod);
            }

            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    foreach (var key in products.Keys)
                    {
                        lock (this)
                        {
                            foreach (var product in products.Values)
                            {
                                if (product.Qty < product.ReorderLevel)
                                {
                                    product.Qty += rand.Next(
                                        product.ReorderLevel,
                                        product.ReorderLevel + 12);
                                }
                            }
                        }
                        int qtyToAdd = rand.Next(preorderLevel, preorderLevel + 12);
                    }

                    Thread.Sleep(1000);
                }
            });
            thread.Start();

        }

        private void UpdateProducts(object? obj)
        {
            // some file stuff
        }

        public Product[] Retrieve()
        {
            lock (this)
            {
                return products.Values.ToArray();
            }
        }

        public void Update(string sender, string productID, int qty)
        {
            // save in text file

        }
    }

}
