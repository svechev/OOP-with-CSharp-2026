using System;


namespace Homework1
{
    public class Table
    {
        #region Data members
        private double _start;
        private double _end;
        private int _steps;
        #endregion

        #region Constructors
        public Table(double start, double end, int steps)
        {
            _start = start;
            _end = end;
            _steps = steps;
        }
        #endregion

        #region Properties
        // Properties with only "get" implemented
        public double Start => _start;
        public double End => _end;
        public int Steps => _steps;
        #endregion

        #region Utility methods
        
        // Helper to calculate F
        private double CalculateF(double x)
        {
            // Get the numerator and denominator separately
            double numer = Math.Pow(Math.Abs(x - 2), 2);
            double denum = Math.Pow(x, 2) + 1;

            // Combine the numerator and denominator
            return numer / denum;
        }


        // Make table method
        public void MakeTable()
        {
            // Necessary variables
            double FStart = CalculateF(Start);  // f(start)
            double FEnd = CalculateF(End);    // f(end)
            double xStep = Start;   // x for the current step
            double FXStep;   // f(x) for the current step
            double stepDifference = (End - Start) / (Steps + 1); // difference between each x
            string? input;


            // Print column row
            Console.WriteLine("{0,10} {1,13}", "x", "f(x)");

            // Print start row
            Console.WriteLine("{0,10:0.####} {1,13:0.####}", Start, FStart);


            // Loop for printing the steps
            for (int step = 1; step <= Steps; step++)
            {

                // Calculate x and F(x) for the current step
                xStep += stepDifference;
                FXStep = CalculateF(xStep);

                // Print row for the current step
                Console.WriteLine("{0,10:0.####} {1,13:0.####}", xStep, FXStep);

                // Loop that waits input after 20 steps
                if (step % 20 == 0)
                {
                    do
                    {
                        // Get the input
                        Console.WriteLine("Press return to continue...");
                        input = Console.ReadLine() ?? "";

                    } while (input.ToLower() != "return");

                    // Print the column row again for visibility
                    Console.WriteLine("{0,10} {1,13}", "x", "f(x)");
                }

            }

            // Print end row
            Console.WriteLine("{0,10:0.####} {1,13:0.####}", End, FEnd);
        } 
        #endregion
    }
}
