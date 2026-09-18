using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7Lab8
{
    public interface IEnumeratorExplicit
    {
        bool MoveNext();
        object Current { get; }
        void Reset();

        public class Countdown : IEnumeratorExplicit
        {
            int startValue = -1;

            object IEnumeratorExplicit.Current => startValue;
            bool IEnumeratorExplicit.MoveNext() => startValue++ < 16;
            void IEnumeratorExplicit.Reset() => startValue = 0;


        }
    }
}
