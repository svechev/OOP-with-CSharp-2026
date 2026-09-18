// See https://aka.ms/new-console-template for more information

public class Program
{
    public static void Main()
    {
        int a;
        int b;

        do
        {
            Console.WriteLine("Enter a");
        } while (!int.TryParse(Console.ReadLine(), out a));

        do
        {
            Console.WriteLine("Enter b");
        } while (!int.TryParse(Console.ReadLine(), out b));


        Console.WriteLine($"Sum of {a} + {b} = {GetSum(a, b)}");
    }

    public static int GetSum(int a, int b)
    {
        while (b != 0)
        {
            int carry = a & b;
            a = a ^ b;
            b = (carry << 1);
        }

        return a;
    }
}

