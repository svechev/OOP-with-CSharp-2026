using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4Lab6
{
    public class Rational
    {
        private int numer;
        private int denum;

        public Rational(int _numer, int _denum)
        {
            int gcd = GCD(_numer, _denum);
            numer = _numer / gcd;
            denum = _denum / gcd;
        }

        public Rational() : this(0, 1)
        {

        }

        public Rational(Rational other) : this(other.numer, other.denum)
        {

        }

        public Rational Add(Rational other)
        {
            return new Rational(numer * other.denum + other.numer * denum, denum * other.denum);
        }

        public Rational Subtract(Rational other)
        {
            return new Rational(numer * other.denum - other.numer * denum, denum * other.denum);
        }

        public Rational Multiply(Rational other)
        {
            return new Rational(numer * other.numer, denum * other.denum);
        }

        public Rational Divide(Rational other)
        {
            Rational reciprocical = new Rational(other.denum, other.numer);
            return Multiply(reciprocical);
        }

        public static Rational operator +(Rational left, Rational right)
        {
            return left.Add(right);
        }

        public static Rational operator -(Rational left, Rational right)
        {
            return left.Subtract(right);
        }

        public static Rational operator *(Rational left, Rational right)
        {
            return left.Multiply(right);
        }

        public static Rational operator /(Rational left, Rational right)
        {
            return left.Divide(right);
        }

        // helper
        private static int GCD(int x, int y)
        {
            if (Math.Abs(x) <= 1 || Math.Abs(y) <= 1)
            {
                return 1;
            }

            int max = x > y ? x : y;
            int min = x > y ? y : x;
            do
            {
                (min, max) = (max % min, min);
            } while (min != 0);
            return max;
        }

        public override string ToString()
        {
            if (numer == 0)
            {
                return "0";
            }
            else
            {
                if (denum == 1)
                {
                    return $"{numer}";
                }
                else
                {
                    return $"{numer}/{denum}";
                }
            }
        }
    }
}
