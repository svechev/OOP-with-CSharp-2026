using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2Lab7
{
    public class Point
    {
        int[] coordinates;

        #region Constructors
        public Point(int[] coordinates) => Coordinates = coordinates;
        public Point(in Point point) : this([point.coordinates[0], point.coordinates[1]])
        {
        }
        public Point() : this([0, 0])
        {

        }
        #endregion

        #region Properties
        public int[] Coordinates
        {
            get
            {
                int[] temp = [coordinates[0], coordinates[1]];
                return temp;
            }
            set
            {
                if (value != null && value.Length == 2)
                {
                    coordinates = [value[0], value[1]];
                }
                else
                {
                    coordinates = [0, 0];
                }
            }
        }

        public int this[int idx]
        {
            get
            {
                return idx switch
                {
                    0 => coordinates[0],
                    1 => coordinates[1],
                    _ => throw new ArgumentException("Wrong index")
                }; 
            }
            set
            {
                _ =  idx switch
                {
                    0 => coordinates[0] = value,
                    1 => coordinates[1] = value,
                    _ => throw new ArgumentException("Wrong index")
                };
            }
        }
        #endregion

        public void Deconstruct(out int x, out int y)
        {
            x = coordinates[0];
            y = coordinates[1];
        }

        public override string ToString()
         => $"[{string.Join(", ", coordinates)}]";
    }
}
