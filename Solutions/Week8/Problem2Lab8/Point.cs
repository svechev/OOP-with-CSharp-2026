using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Problem2Lab8
{
    public interface Comparable
    {
        double SizeOf();
        object this[int index] { get; set; }
    }

    public delegate bool GreaterThan(Comparable obj1, Comparable obj2);
    struct Point(double x, double y, double z)
    {
        public double X = x;
        public double Y = y;
        public double Z = z;

        public override string ToString()
        => $"X: {X}, Y: {Y}, Z: {Z}";
    }

    struct Vector(Point start, Point end)
    {
        public Point Start = start;
        public Point End = end;

        public override string ToString()
        => $"Start: {Start}, End: {End}";
    }

    struct Triangle(Vector a, Vector b)
    {
        public Vector A = a;
        public Vector B = b;

        public override string ToString()
        => $"A: {A}, B: {B}";
    }
}
