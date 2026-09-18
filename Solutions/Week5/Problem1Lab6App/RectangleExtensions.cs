using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem1Lab6;

namespace Problem1Lab6App
{
    // static class for extenstion methods of class Rectangle
    public static class RectangleExtensions
    {
        // method that returns the perimeter of a rectangle
        public static double Perimeter(this Rectangle rect)
         => rect["w"] * 2 + rect["h"] * 2;

        // method that checks if a rectangle is a square
        public static bool IsSquare(this Rectangle rect)
         => rect["w"] == rect["h"];

        // method that moves the left lower point of a rectangle to a new point
        public static void Move(this Rectangle rect, Point newPoint)
        {
            rect.LeftLowerPoint = newPoint;
        }

        // method that scales the width and length of a rectangle
        public static void Scale(this Rectangle rect, double scale)
        {
            rect.Width *= scale;
            rect.Length *= scale;
        }
    }
}
