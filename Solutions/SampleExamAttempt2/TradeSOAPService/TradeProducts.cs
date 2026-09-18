using System.Runtime.Serialization;
using System.ServiceModel;
using TradeServices;

namespace TradeSOAPService.Business_logic
{
    [ServiceContract]
    public interface IOrderWService
    {

        [OperationContract]
        Product[] Retrieve();

        [OperationContract]
        void Update(string sender, string productID, int qty);

    }

    public class TradeProducts : IOrderWService
    {
        // private readonly object syncRoot = new();
        private Dictionary<string, Product> products;
        private Random rand = new Random();

        public Product[] Retrieve()
        {
            lock (this)
            {
                return products.Values.ToArray();
            }
        }

        public void Update(string sender, string productID, int qty)
        {

            lock (this)
            {
                try
                {
                    using var file = File.Open("reorder.txt", FileMode.OpenOrCreate);
                    using var writer = new StreamWriter(file);
                    var product = products[productID];
                    writer.WriteLine($"{sender}: {product}, asked qty: {qty}");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid product ID!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error!");
                }
            }
        }

        public TradeProducts()
        {
            products = new Dictionary<string, Product>();

            int productCount = rand.Next(6, 12);
            for (int i = 0; i < productCount; i++)
            {
                int reorderLvl = rand.Next(6, 13);
                Category category = (Category)rand.Next(0, 3);
                Product newProduct = new(category, 12, reorderLvl);
                products!.Add(newProduct.ID, newProduct);
            }

            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    lock (this)
                    {
                        foreach (Product product in products.Values)
                        {
                            if (product.Qty < product.ReorderLvl)
                            {
                                int toAdd = rand.Next(product.ReorderLvl, product.ReorderLvl + 12);
                                product.Qty += toAdd;
                            }
                        }
                    }

                    Thread.Sleep(1000);
                }
            });
            thread.Start();


        }
    }

}
