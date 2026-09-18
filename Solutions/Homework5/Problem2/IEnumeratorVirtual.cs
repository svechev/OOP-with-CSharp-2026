using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    /// <summary>
    /// Problem 2c
    /// </summary>
    public interface IEnumeratorVirtual
    {
        bool MoveNext();
        object Current { get; }
        void Reset();

        public class Countdown : IEnumeratorVirtual
        {
            int startValue = 16;

            public virtual object Current => startValue;
            public virtual bool MoveNext() => startValue-- > 0;   
            public virtual void Reset() => startValue = 17;


        }
    }
}
