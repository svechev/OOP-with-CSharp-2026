namespace Homework6
{
    public class Program
    {
        // Define different lists of products
        private static List<Product> products1 = new List<Product> { 
            new Product("Monitor", 2),
            new Product("Chainsaw", 1)
        };
        private static List<Product> products2 = new List<Product> {
            new Product("Hair dryer", 21)
        };
        private static List<Product> products3 = new List<Product> {
            new Product("Desk", 2),
            new Product("Keyboard", 4),
            new Product("Chair", 7)
        };

        private static void Main()
        {
            // Create a store
            Console.WriteLine("Create a store...");
            Store store1 = new Store();
            store1.ListOfProducts = products1;

            // Show products in store
            Console.WriteLine("\nShow products in store...");
            Console.WriteLine(store1);

            // Create employees
            Console.WriteLine("\nCreate employees...");
            Employee e1 = new Employee("Mahiro");
            Employee e2 = new Employee("Momiji");

            Manager m1 = new Manager("Mihari");
            Manager m2 = new Manager("Kaede");

            // Create a second store
            Console.WriteLine("\nCreate a second store...");
            Store store2 = new Store(); 

            // Test appointment
            Console.WriteLine("\nTest appointment...");
            store1.OnAppointment(e1);
            store1.OnAppointment(m1);

            store2.OnAppointment(e2);
            store2.OnAppointment(m2);

            // Test change in product list
            Console.WriteLine("\nTest change in product list...");
            store2.ListOfProducts = products2;
           
            // Show products in store
            Console.WriteLine("\nShow products in store...");
            Console.WriteLine(store2);

            // Test quantity updates
            Console.WriteLine("\nTest quantity updates...");

            store1.Worker.ManageQty(store1.ListOfProducts[1], 35);
            Console.WriteLine(store1);

            store2.Worker.ManageQty(store2.ListOfProducts[0], 2);
            Console.WriteLine(store2);


        }
    }
}