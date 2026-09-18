using Problem2Lab7;
using Problem2Lab7App;

internal class Program
{
    public static void Main(string[] args)
    {
        var pointA = new Point();
        var pointB = new Point([10, 200]);

        Console.WriteLine(pointA);
        Console.WriteLine(pointB);

        var rect1 = new Rectangle();
        var rect2 = new Rectangle(pointA, pointB);
        var rect3 = new Rectangle(rect2);
        pointB.Coordinates = [300, 300];

        Console.WriteLine();
        Console.WriteLine(rect1);
        Console.WriteLine(rect2);

        Parallelepiped parallelepiped = new(rect2, 100); // primary constructor
        Console.WriteLine(parallelepiped);
        Console.WriteLine($"Area: {parallelepiped.Area()}");


        Console.WriteLine($"Volume: {parallelepiped.Volume()}");
        Console.WriteLine($"Perimeter: {rect2.Perimeter()}");
        // same thing:
        Console.WriteLine($"Perimeter: {ExtensionMethods.Perimeter(rect2)}");
        
    }
}