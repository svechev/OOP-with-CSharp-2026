namespace Problem3
{
    public class Program
    {
        public static void Main()
        {
            int x;
            int y;

            Console.Write("Enter x: ");
            int.TryParse(Console.ReadLine(), out x);

            Console.Write("Enter y: ");
            int.TryParse(Console.ReadLine(), out y);

            GCD(x, y, out int gcd);
            LCM(x, y, gcd, out int lcm);
            Console.WriteLine($"GCD of {x} and {y} is {gcd}");
            Console.WriteLine($"LCM of {x} and {y} is {lcm}");

        }

        public static void GCD(int x, int y, out int gcd)
        {
            int max = x > y ? x : y;
            int min = x > y ? y : x;
            do
            {
                (min, max) = (max % min, min);
            } while (min != 0);
            gcd = max;
        }

        public static void LCM(int x, int y, int gcd, out int lcm)
        {
            lcm = Math.Abs(x * y) / gcd;
        }
    }
}