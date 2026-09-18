using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2Lab7
{
    public class Parallelepiped : Rectangle
    {
        double height;

        #region Constructors
        public Parallelepiped(Rectangle rectangle, double height)
            : base(rectangle)
        {
            Height = height;
        }

        public Parallelepiped() : this(new Rectangle(), 0)
        {

        }

        public Parallelepiped(Parallelepiped p) : this(p.BaseSide, p.height)
        {

        }
        #endregion

        #region Properties
        public double Height
        {
            get => height;
            set => height = value >= 0 ? value : 0;
        }

        public Rectangle BaseSide
        {
            get => new Rectangle(this);
            set => (LowerRightPoint, UpperLeftPoint) = value != null ? new Rectangle(value) : new Rectangle();
        }
        #endregion

        public override double Area()
        {
            var (lower, upper) = this; // use deconstruct in rectangle

            var sideA = height * Math.Abs(lower[0] - upper[0]);
            var sideB = height * Math.Abs(lower[1] - upper[1]);
  
            return 2 * base.Area() + 2 * sideA + 2 * sideB; 
        }

        public override string ToString()
         => $"Base: {base.ToString()} H: {height}";
      
    }
}
