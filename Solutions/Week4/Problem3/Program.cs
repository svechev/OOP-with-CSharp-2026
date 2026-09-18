using System.Collections;
using System.Security.Principal;

namespace Problem3
{
    public class Program
    {
        private static Hashtable codes = new Hashtable() {
            {1, new int[]{0, 0, 0, 1, 1 } },
            {2, new int[]{0, 0, 1, 0, 1 } },
            {3, new int[]{0, 0, 1, 1, 0 } },
            {4, new int[]{0, 1, 0, 0, 1 } },
            {5, new int[]{0, 1, 0, 1, 0 } },
            {6, new int[]{0, 1, 1, 0, 0 } },
            {7, new int[]{1, 0, 0, 0, 1 } },
            {8, new int[]{1, 0, 0, 1, 0 } },
            {9, new int[]{1, 0, 1, 0, 0 } },
            {0, new int[]{1, 1, 0, 0, 0 } },
        };

        public static void Main(string[] args)
        {
            int number;
            do
            {
                Console.Write("Enter a 3 digit number: ");
                int.TryParse(Console.ReadLine(), out number);

            } while (number < 100 || number > 999);

            Console.WriteLine($"\nYour number is {number}");
            Console.WriteLine("Code:");
            PrintCode(number);
        }

        private static void PrintCode(int code)
        {
            int[] digits = new int[3];
            digits[0] = code / 100;
            code %= 100;

            digits[1] = code / 10;
            code %= 10;

            digits[2] = code % 10;

            foreach (int digit in digits)
            {
                int[] toPrint = (int[])codes[digit]!;
                foreach (int num in toPrint)
                {
                    if (num == 0)
                    {
                        Console.Write(":");
                    }
                    else
                    {
                        Console.Write("|");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}