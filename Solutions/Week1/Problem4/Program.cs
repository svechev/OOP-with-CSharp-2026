
internal class Program
{
    private static void Main(string[] args)
    {
        // Get input
        Console.Write("Enter a five digit number: ");
        int input = Convert.ToInt32(Console.ReadLine());

        // Initialize the digits
        int d1;
        int d2;
        int d3;
        int d4;
        int d5;

        // Get the digits and print them
        d1 = input / 10000;
        Console.Write($"{d1}   ");
        input %= 10000;

        d2 = input / 1000;
        Console.Write($"{d2}   ");
        input %= 1000;

        d3 = input / 100;
        Console.Write($"{d3}   ");
        input %= 100;

        d4 = input / 10;
        Console.Write($"{d4}   ");
        input %= 10;

        d5 = input;
        Console.Write($"{d5}");
    }
}