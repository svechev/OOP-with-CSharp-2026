using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3Lab7
{
    public class IntBits
    {
        int bits;

        public IntBits(int bits)
        {
            this.bits = bits;
        }

        public bool this[byte index]
        {
            get {
                if (index >= 0 && index < 32)
                {
                    return (bits & (1 << index)) == 0 ? false : true;
                }
                else throw new IndexOutOfRangeException("Index outside range [0, 31]");
            }
            set
            {
                if (index >= 0 && index < 32)
                {
                    bits = value? bits |= (1 << index) 
                                : bits &= ~(1 << index); 
                }
                else throw new IndexOutOfRangeException("Index outside range [0, 31]");
            }
        }

        public override string ToString()
        => $"{bits}";
    }
}
