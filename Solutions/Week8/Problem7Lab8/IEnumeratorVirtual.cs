using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7Lab8
{
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

    public class CountdownWithOverride : IEnumeratorVirtual.Countdown
    {
        int startValue = 0;
        public override object Current => startValue;

        public override bool MoveNext() => startValue++ < 17;

        public override void Reset() => startValue = -1;
    }
}
