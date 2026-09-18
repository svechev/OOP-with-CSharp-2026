using Problem1Lab6;
using Problem1Lab6App;

namespace Problem1Lab6App
{
    // class for testing class rectangle and point
    public class GeometryTest
    {
        // random object for generating random rectangles
        public static Random rand = new Random();

        // list of random rectangles
        public static Rectangle[] rectangles = new Rectangle[]{
            new Rectangle(rand.Next(1, 11), rand.Next(1, 11), new Point(new int[]{rand.Next(1, 11), rand.Next(1, 11)})),
            new Rectangle(rand.Next(1, 11), rand.Next(1, 11), new Point(new int[]{rand.Next(1, 11), rand.Next(1, 11)})),
            new Rectangle(rand.Next(1, 11), rand.Next(1, 11), new Point(new int[]{rand.Next(1, 11), rand.Next(1, 11)})),
            new Rectangle(rand.Next(1, 11), rand.Next(1, 11), new Point(new int[]{rand.Next(1, 11), rand.Next(1, 11) })),
        };

        // main method to call the other methods
        public static void Main(string[] args)
        {
            // display rectangles sorted by area
            DisplayByArea();

            // display rectangles sorted by diagonal descending
            Console.WriteLine();
            DisplayByDiagonalDesc();

            // display rectangles grouped by perimeter
            Console.WriteLine();
            DisplayPerimeterGroups();
        }

        // method that displays rectangles sorted by area
        public static void DisplayByArea()
        {
            var sortedRectangles = Rectangle.SortBy(rectangles.ToList(), Rectangle.Area);
            var sortedByArea =
                from rect in sortedRectangles
                select new
                {
                    Rectangle = rect,
                    Area = Rectangle.Area(rect)
                };

            Console.WriteLine("Rectangles sorted by area:");
            foreach (var rect in sortedByArea)
            {
                Console.WriteLine("{0,-35}{1,8}: {2}", rect.Rectangle, "Area", rect.Area);
            }
        }

        // method that displays rectangles sorted by diagonal in descanding order
        public static void DisplayByDiagonalDesc()
        {
            var sortedByDiagonalDesc =
                from rect in rectangles
                let diagonal = Rectangle.Diagonal(rect)
                orderby diagonal descending
                select new
                {
                    Rectangle = rect,
                    Diagonal = diagonal
                };

            Console.WriteLine("Rectangles sorted by diagonal (descending):");
            foreach (var rect in sortedByDiagonalDesc)
            {
                Console.WriteLine("{0,-35}{1,11}: {2:F2}", rect.Rectangle, "Diagonal", rect.Diagonal);
            }
        }
    

        // method that displays rectangles grouped by perimeter above or below 20
        public static void DisplayPerimeterGroups()
        {
            var perimeterGroups = rectangles
                .GroupBy(rect => PerimeterGroupName(rect))
                .Select(group => new
                {
                    Name = group.Key,
                    Rectangles = group
                        .Select(rect => new
                        { 
                            Rectangle = rect,
                            Perimeter = rect.Perimeter()
                        })
                });

            Console.WriteLine("Rectangles group by perimeter:");
            foreach (var group in perimeterGroups)
            {
                Console.WriteLine(group.Name);
                foreach (var rect in group.Rectangles)
                {
                    Console.WriteLine($"    {rect.Rectangle,-35} {"Perimeter",11}: {rect.Perimeter}");
                }
            }
        }

        // helper method that returns a group name as string based
        // on the rectangle's perimeter
        private static string PerimeterGroupName(Rectangle rect)
        {
            if (rect.Perimeter() < 20)
            {
                return "Below 20";
            }
            else
            {
                return "Above 20";
            }
        }
    }
}
