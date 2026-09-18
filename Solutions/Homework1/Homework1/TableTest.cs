using System;
using System.Data;

namespace Homework1
{
    public class TableTest
    {
        public static void Main()
        {
            // Declare variables
            double start;  // start of interval
            double end;    // end of interval
            int steps;     // number of discretization steps


            // Get start of the interval from user
            while (true)
            {
                Console.Write("Enter start of interval: ");
                if (double.TryParse(Console.ReadLine(), out start))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, double expected.");
                    Console.WriteLine();
                }
            }


            // Get end of the interval from user
            while (true)
            {
                Console.Write("Enter end of interval: ");
                if (double.TryParse(Console.ReadLine(), out end))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, double expected.");
                    Console.WriteLine();
                }
            }


            // Get number of discretization steps
            while (true)
            {
                Console.Write("Enter number of discretization steps: ");    
                if (int.TryParse(Console.ReadLine(), out steps))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, integer expected.");
                    Console.WriteLine();
                }
            }


            // Swap start and end if needed
            if (start > end)
            {
                (start, end) = (end, start);
            }


            // Create a table
            Table table = new Table(start, end, steps);

            // Call the MakeTable method
            table.MakeTable();
        }
    }
}
