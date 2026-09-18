using Problem4Lab6;

namespace Problem4Lab6App
{
    public class Program
    {
        public static void Main()
        {
            Rational r1 = new Rational(2, 4);
            Rational r2 = new Rational(3, 18);
            Console.WriteLine($"rat1: {r1}");
            Console.WriteLine($"rat2: {r2}");
            Console.WriteLine($"rat1+rat2: {r1+r2}");
            Console.WriteLine($"rat1-rat2: {r1-r2}");
            Console.WriteLine($"rat1*rat2: {r1*r2}");
            Console.WriteLine($"rat1/rat2: {r1/r2}");

        }
    }
}