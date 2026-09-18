using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class RotateArray
    {
        // Enum for rotation direction
        public enum Direction { 
            LEFT, 
            RIGHT 
        };

        /// Method that rotates the array by k posititon in the direction dir
        public static void Rotate(int[] arr, int k, Direction dir)
        {
            k %= arr.Length;  // k needs to be a valid index

            // Rotating to the right by k positions is the same
            // as rotating to the left by arr.length - k positions
            if (dir == Direction.LEFT)
            {
                k = arr.Length - k;
            }

            // Reverse the entire array
            Span<int> fullSpan = arr;
            fullSpan.Reverse();

            // Reverse the first k elements
            Span<int> leftSpan = fullSpan.Slice(start: 0, length: k);
            leftSpan.Reverse();

            // Reverse the last n-k elements
            Span<int> rightSpan = fullSpan.Slice(start: k);
            rightSpan.Reverse();
        }
    }
}
