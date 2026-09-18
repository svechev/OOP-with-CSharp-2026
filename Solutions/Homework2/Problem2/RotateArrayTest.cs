using System.Security.AccessControl;

namespace Problem2
{
    public class RotateArrayTest
    {
        // Main method begins application execution
        public static void Main(string[] args)
        {
            uint arrSize;                  // size of the array
            int[] arr;                    // the array
            RotateArray.Direction dir;    // rotation direction
            int k;                        // positions of rotation
            string? dirInput;             // reads input for rotation direction


            // Get the array size from the user
            while (true)
            {
                Console.Write("Enter array size: ");

                // Successful input, exit the loop
                if (uint.TryParse(Console.ReadLine(), out arrSize))
                {
                    arr = new int[arrSize];
                    break;
                }
                // Invalid input, display message
                else
                {
                    Console.WriteLine("Invalid array size, positive integer needed!");
                }
            }

            // Get the array from the user
            while (true)
            {
                // Get a line of numbers and put them in an array
                Console.WriteLine();
                Console.WriteLine($"Input {arrSize} numbers, each separated by a space");
                string arrInput = Console.ReadLine() ?? "";
                var items = arrInput.Split(" ");

                // Check the amount of numbers input by the user
                if (items.Length != arr.Length)
                {
                    Console.WriteLine($"Invalid amount of numbers, please enter {arrSize} numbers.");
                    continue;
                }

                bool validInput = true; // boolean that indicates if every number in input is valid
                 
                // Parse every number in the input and put it in the array
                for (int i = 0; i < items.Length; i++)
                {
                    if (int.TryParse(items[i], out var number))
                    {
                        arr[i] = number;
                    }
                    else
                    {
                        validInput = false;
                        Console.WriteLine("Invalid number in input, please enter integers.");
                        break;
                    }
                }

                // Exit the loop if input was valid
                if (validInput)
                {
                    break;
                }

            }

            // Display the initial array to the user
            Console.WriteLine();
            Console.WriteLine("The array before rotation: ");
            Console.WriteLine(string.Join(' ', arr));
            Console.WriteLine();


            // Get direction from user
            while (true)
            {
                // Get input from user 
                Console.Write("Enter direction (left/right): ");
                dirInput = Console.ReadLine()?.ToLower();

                // Initialize dir and exit the loop only if input is "left" or "right"
                if (dirInput == "left")
                {
                    dir = RotateArray.Direction.LEFT;
                    break;
                }

                else if (dirInput == "right")
                {
                    dir = RotateArray.Direction.RIGHT;
                    break;
                }

                // Message for invalid input
                else
                {
                    Console.WriteLine("Invalid direction!");
                }
            }

            Console.WriteLine();

            // Get k from user
            while (true)
            {
                Console.Write("Enter rotation steps: ");

                // Succesful input, exit the loop
                if (int.TryParse(Console.ReadLine(), out k))
                {
                    break;
                }
                // Invalid input, display message
                else
                {
                    Console.WriteLine("Invalid input, integer number required!");
                }
            }

            // Perform the rotation
            RotateArray.Rotate(arr, k, dir);

            // Display the rotated array to the user
            Console.WriteLine();
            Console.WriteLine("The array after rotation: ");
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}