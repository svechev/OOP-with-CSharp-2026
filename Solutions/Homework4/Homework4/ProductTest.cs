using System.Diagnostics.Metrics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Homework4
{
    // Class to test the LINQ statements on a list of products.
    // Main method is first, it runs the methods that declare and execute LINQ statements.
    // It is followed by methods for declaring and executing LINQ statements. 
    public class ProductTest
    {
        // List of sample products
        static List<Product> products = [
        new Product("Electric sander", Type.M, new List<int>{99, 82, 81, 79}, 157.98M),
        new Product("Power saw      ", Type.M, new List<int>{99, 86, 90, 94}, 99.99M),
        new Product("Sledge hammer  ", Type.F, new List<int>{93, 92, 80, 87}, 21.50M),
        new Product("Hammer         ", Type.M, new List<int>{97, 89, 85, 82}, 11.99M),
        new Product("Lawn mower     ", Type.F, new List<int>{35, 72, 91, 70}, 139.50M),
        new Product("Screwdriver    ", Type.F, new List<int>{88, 94, 65, 91}, 56.99M),
        new Product("Jig saw        ", Type.M, new List<int>{75, 84, 91, 39}, 11.00M),
        new Product("Wrench         ", Type.F, new List<int>{97, 92, 81, 60}, 17.50M),
        new Product("Sledge hammer  ", Type.M, new List<int>{75, 84, 91, 39}, 21.50M),
        new Product("Hammer         ", Type.F, new List<int>{94, 92, 91, 91}, 11.99M),
        new Product("Lawn mower     ", Type.M, new List<int>{96, 85, 91, 60}, 179.50M),
        new Product("Screwdriver    ", Type.M, new List<int>{96, 85, 51, 30 }, 66.99M),
            ];

        // Main method that runs the methods below
        public static void Main()
        {
            Console.WriteLine("Executing LINQ statements...");
            Console.WriteLine();

            // run the methods

            // statement A
            Console.WriteLine("Statement A:");
            GroupByCategoryCountDescending();
            Console.WriteLine();

            // statement B
            Console.WriteLine("Statement B:");
            GroupByQtrAndProductPriceAvg();
            Console.WriteLine();

            // statement C
            Console.WriteLine("Statement C:");
            GroupByQtrCategoryWeeklySum();
            Console.WriteLine();

            // statement D
            Console.WriteLine("Statement D:");
            GroupByQtrCategoryAndProducts();
            Console.WriteLine();

            // statement E
            Console.WriteLine("Statement E:");
            GroupByQtrMinMaxPrice();

        }

        // Declares and executes a LINQ statement that groups by category
        // and shows the total number of all the products in each group, sorted descending
        public static void GroupByCategoryCountDescending()
        {
            // declare statement
            var byCategory = products.GroupBy(prod => prod.Category)
                .OrderByDescending(group => group.Count())
                .Select(group => new
                {
                    Category = group.Key,
                    Count = group.Count()
                });

            // execute statement
            foreach (var group in byCategory)
            {
                Console.WriteLine($"CategoryGroup: {group.Category}");
                Console.Write("               ");
                Console.WriteLine($"Number of products of type {group.Category} in this group: {group.Count}");
                Console.WriteLine();
            }
        }

        // Declares and executes a LINQ statement that groups by quarter
        // and shows average price per group
        public static void GroupByQtrAndProductPriceAvg()
        {
            // declare statement
            var byQuarterAvgPrice = products
                .GroupBy(prod => prod.Quarter)
                .OrderBy(group => group.Key)
                .Select(group => new
                {
                    Quarter = group.Key,
                    AvgPrice = group.Average(prod => prod.Price)
                });



            // execute statement
            foreach (var group in byQuarterAvgPrice)
            {
                Console.WriteLine($"QuarterGroup: {group.Quarter}");
                Console.Write("              ");
                Console.WriteLine($"Average price per Quarter: ${group.AvgPrice:F2}");
                Console.WriteLine();
            }

        }

        // Declares and executes a LINQ statement that groups products by Quarter
        // and next by Category in each Quarter
        public static void GroupByQtrCategoryWeeklySum()
        {
            // declare statement
            var byQtrCategoryWeeklySum = products
             .GroupBy(prod => prod.Quarter)
             .OrderBy(group => group.Key)
             .Select(group => new
             {
                Quarter = group.Key,
                Categories = group
                    .GroupBy(prod => prod.Category)
                    .Select(category => new
                    {
                        Category = category.Key,
                        Products = category
                        .Select(prod => (prod.Description, prod.WeeklyPurchases.Sum()))
                    })
            });

            var fourth = products.OrderBy(prod => prod.ID)
                .OrderBy(prod => prod.Quarter)
                .GroupBy(prod => prod.Quarter)
                .Select(group => new
                {
                    Quarter = group.Key,
                    Categories = group.OrderBy(prod => prod.Category)
                        .GroupBy(prod => prod.Category)
                });

            //// execute statement
            foreach (var quarter in byQtrCategoryWeeklySum)
            {
                Console.WriteLine($"Quarter: {quarter.Quarter}");
                foreach (var category in quarter.Categories)
                {
                    Console.Write("      ");
                    Console.WriteLine($"Category: {category.Category}");
                    foreach (var (desc, sum) in category.Products)
                    {
                        Console.Write("           ");
                        Console.WriteLine($"({desc},{sum})");
                    }
                }
            }
        }

        // Declares and executes a LINQ statement that groups products by Quarter
        // and next by Category in each Quarter
        public static void GroupByQtrCategoryAndProducts()
        {
            // declare statement
            var byQtrCategory = products
             .GroupBy(prod => prod.Quarter)
             .OrderBy(group => group.Key)
             .Select(group => new
             {
                 Quarter = group.Key,
                 Categories = group
                    .GroupBy(prod => prod.Category)
             });

            var fifth = products.OrderBy(prod => prod.Quarter)
                .GroupBy(prod => prod.Quarter)
                .Select(group => new
                {
                    Quarter = group.Key,
                    MinPrice = group.Select(prod => prod.Price).Min(),
                    MaxPrice = group.Select(prod => prod.Price).Max(),
                });

            // execute statement
            foreach (var quarter in byQtrCategory)
            {
                Console.WriteLine($"Quarter: {quarter.Quarter}");
                foreach (var category in quarter.Categories)
                {
                    Console.Write("      ");
                    Console.WriteLine($"Category: {category.Key}");
                    foreach (var product in category)
                    {
                        Console.Write("           ");
                        Console.WriteLine($"{product}");
                    }
                }
            }
        }

        // Declares and executes a LINQ statement that groups products by Quarter
        // and each Quarter group shows the Min and Max Price per Quarter
        public static void GroupByQtrMinMaxPrice()
        {
            // declare statement
            var byQtr = products.GroupBy(prod => prod.Quarter)
                .OrderBy(group => group.Key)
                .Select(group => new
                {
                    Quarter = group.Key,
                    MinPrice = group.Min(prod => prod.Price),
                    MaxPrice = group.Max(prod => prod.Price)
                });

            // execute statement
            foreach (var group in byQtr)
            {
                Console.WriteLine($"Quarter Group: {group.Quarter}");
                Console.Write("               ");
                Console.WriteLine($"Min price per quarter: {group.MinPrice}");
                Console.Write("               ");
                Console.WriteLine($"Max price per quarter: {group.MaxPrice}");
                Console.WriteLine();
            }
        }

    }
}