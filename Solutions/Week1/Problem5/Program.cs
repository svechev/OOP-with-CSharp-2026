internal class Program
{
    private static void Main(string[] args)
    {

        // Get input
        Console.Write("Enter a number: ");
        int input = Convert.ToInt32(Console.ReadLine());

        // Initialize the digits
        int k0;
        int k1;
        int k2;
        int k3;

        // Get the digits
        int current_power_four = Convert.ToInt32(Math.Pow(4, 3));
        k3 = input / current_power_four;
        input %= current_power_four;

        current_power_four = Convert.ToInt32(Math.Pow(4, 2));
        k2 = input / current_power_four;
        input %= current_power_four;

        current_power_four = Convert.ToInt32(Math.Pow(4, 1));
        k1 = input / current_power_four;
        input %= current_power_four;

        current_power_four = Convert.ToInt32(Math.Pow(4, 0));
        k0 = input / current_power_four;

        // Print the first letter
        if (k0 == 0)
        {
            Console.Write("A");
        }
        else if (k0 == 1)
        {
            Console.Write("C");
        }
        else if (k0 == 2)
        {
            Console.Write("G");
        }
        else
        {
            Console.Write("T");
        }

        // Print the second letter
        if (k1 == 0)
        {
            Console.Write("A");
        }
        else if (k1== 1)
        {
            Console.Write("C");
        }
        else if (k1 == 2)
        {
            Console.Write("G");
        }
        else
        {
            Console.Write("T");
        }

        // Print the third letter
        if (k2== 0)
        {
            Console.Write("A");
        }
        else if (k2 == 1)
        {
            Console.Write("C");
        }
        else if (k2 == 2)
        {
            Console.Write("G");
        }
        else
        {
            Console.Write("T");
        }

        // Print the fourth letter
        if (k3 == 0)
        {
            Console.Write("A");
        }
        else if (k3 == 1)
        {
            Console.Write("C");
        }
        else if (k3 == 2)
        {
            Console.Write("G");
        }
        else
        {
            Console.Write("T");
        }
    }
}