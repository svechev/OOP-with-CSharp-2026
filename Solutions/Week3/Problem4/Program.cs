namespace Problem4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Pythagorean triplets:");
            for (int i = 1; i <= 30; i++)
            {
                for (int j = i; j <= 30; j++)
                {
                    for (int k = j; k <= 30; k++)
                    {
                        if (i * i + j * j == k * k)
                        {
                            Console.WriteLine($"{i}, {j}, {k}");
                        }
                    }
                }
            }
        }
    }
}