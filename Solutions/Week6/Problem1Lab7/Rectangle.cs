using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Problem2Lab7
{
    public class Rectangle : Point
    {
        private Point? lowerRightPoint;

        #region Constructors
        public Rectangle(Point lowerRightPoint, Point upperLeftPoint)
            : base(upperLeftPoint)
        {
            LowerRightPoint = lowerRightPoint;
        }

        public Rectangle()
            : this(new Point(), new Point())
        {

        }

        public Rectangle(Rectangle rect)
            : this(rect.LowerRightPoint, rect.UpperLeftPoint)
        {

        }

        public void Deconstruct(out Point lower, out Point upper)
        {
            lower = LowerRightPoint;
            upper = UpperLeftPoint;
        }
        #endregion

        #region Properties
        // Mind the single responsibility principle!
        public Point LowerRightPoint
        {
            get => lowerRightPoint != null ? new Point(lowerRightPoint) : new Point();
            set => lowerRightPoint = value != null ? new Point(value) : new Point();
        }

        public Point UpperLeftPoint
        {
            get => new Point(this);
            set => Coordinates = value != null ? value.Coordinates : [0, 0];
        }
        #endregion

        public virtual double Area()
        {
            var sideA = Math.Abs(this[0] - lowerRightPoint![0]);
            var sideB = Math.Abs(this[1] - lowerRightPoint![1]);
            return sideA * sideB;
        } 

        public override string ToString()
         => $"R: [{base.ToString()}, {LowerRightPoint}]";
    }

}
