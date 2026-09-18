using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7Lab8
{
    /// <summary>
    /// Problem 7a
    /// </summary>
    public interface IEnumerator
    {
        bool MoveNext();
        object Current { get; }
        void Reset();
    }

    public class Countdown : IEnumerator
    {
        int startValue = 16;

        public object Current => startValue;

        public bool MoveNext() => startValue-- > 0;

        public void Reset() => startValue = 17;

        
    }
}
