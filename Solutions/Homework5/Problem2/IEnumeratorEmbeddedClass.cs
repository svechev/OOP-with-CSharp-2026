using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    /// <summary>
    /// Problem 2b
    /// </summary>
    public interface IEnumeratorEmbeddedClass
    {
        bool MoveNext();
        object Current { get; }
        void Reset();

        public class Countdown : IEnumeratorEmbeddedClass
        {
            int startValue = 16;

            public object Current => startValue;

            public bool MoveNext() => startValue-- > 0;

            public void Reset() => startValue = 17;


        }
    }
}
