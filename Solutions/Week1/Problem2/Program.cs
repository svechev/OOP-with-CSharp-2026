internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Find median solution");

        int number1;  // first number
        int number2;
        int number3;

        int median;   // the median

        // Initialization
        Console.Write("Enter first number: ");
        number1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second number: ");
        number2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter third number: ");
        number3 = Convert.ToInt32(Console.ReadLine());

        median = number1 + number2 + number3 -
            Math.Min(Math.Min(number1, number2), number3) -
            Math.Max(Math.Max(number1, number2), number3);

        Console.WriteLine($"The median is {median}.");
    }
}