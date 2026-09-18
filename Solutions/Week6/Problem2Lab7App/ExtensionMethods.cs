using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem2Lab7;

namespace Problem2Lab7App
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Compute volume of parallelepiped
        /// </summary>
        /// <param name="parallelepiped"></param>
        /// <returns>volume of p</returns>
        public static double Volume(this Parallelepiped parallelepiped)
         => parallelepiped.BaseSide.Area() * parallelepiped.Height;

        /// <summary>
        /// Compute perimeter of a rectangle
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static double Perimeter(this Rectangle rect)
        {
            var (lower, upper) = rect;

            return 2 * (Math.Abs(lower[0] - upper[0]) + 
                        Math.Abs(lower[1] - upper[1]));
        }
    }
}
