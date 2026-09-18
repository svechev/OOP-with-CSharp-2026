using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Problem1Lab6
{
    public class Rectangle
    {
        public delegate double CompareBy(Rectangle r);
        double length;
        double width;
        Point leftLowerPoint;

        public readonly string R_ID;
        static int counter = 0;
        static string[] idxSymbols = ["w", "h", "x", "y"];

        
        #region Constructors

        // General-purpose constructor
        public Rectangle(double length, double width, Point point)
        {
            Length = length;
            Width = width;
            LeftLowerPoint = point;
            R_ID = $"R-{++counter:D06}";
        }

        // Default constructor
        public Rectangle() : this(0, 0, new Point())
        {

        }

        // Copy constructor
        public Rectangle(Rectangle rect) : this(rect.length, rect.width, rect.leftLowerPoint)
        {

        } 

        // Deconstructor
        public void Deconstruct(out double length, out double width)
        {
            length = Length;
            width = Width;
        }

        public void Deconstruct(out int x, out int y)
        {
            (x, y) = leftLowerPoint;
        }
        #endregion


        #region Properties
        public double Length
        {
            get => length;
            set => length = value > 0 ? value : 0;
        }
        public double Width
        {
            get => width;
            set => width = value > 0 ? value : 0;
        }

        public Point LeftLowerPoint
        {
            get => new(leftLowerPoint);
            set => leftLowerPoint = value != null ? new(value) : new Point();
        }
        
        // indexer
        public double this[string idx]
        {
            get
            {
                idx = idx.ToLower();
                if (idxSymbols.Contains(idx))
                {
                    return idx switch
                    {
                        "w" => width,
                        "h" => length,
                        "x" => leftLowerPoint[0],
                        "y" => leftLowerPoint[1],
                        _ => throw new ArgumentException()
                    };
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            set
            {
                idx = idx.ToLower();
                if (idxSymbols.Contains(idx))
                {
                    _ = idx switch
                    {
                        "w" => width = value,
                        "h" => length = value,
                        "x" => leftLowerPoint[0] = (int)value,
                        "y" => leftLowerPoint[1] = (int)value,
                        _ => throw new ArgumentException()
                    };
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        #endregion

        public static double Area(Rectangle rect)
         => rect.length * rect.width;

        public static int Re(Rectangle rect) => 1; 
        public static double Diagonal(Rectangle rect)
            => Math.Sqrt(rect.width * rect.width + rect.length * rect.length);

        public static IEnumerable<Rectangle> SortBy(List<Rectangle> list, CompareBy compare)
        {
            var sortedRectangle = list.OrderByDescending(rect => compare(rect));

            return sortedRectangle;
        }

        public override string ToString()
        => $"{R_ID}: L={length}, W={width}, Point={leftLowerPoint}, Diagonal={Diagonal(this):F2}";
    }

}
