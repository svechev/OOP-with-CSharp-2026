using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    /// <summary>
    /// Inherit methods from IEnumeratorVirtual.Countdown
    /// </summary>
    public class CountdownWithOverride : IEnumeratorVirtual.Countdown
    {
        int startValue = -1;
        public override object Current => startValue;
        public override bool MoveNext() => startValue++ < 16;
        public override void Reset() => startValue = 0;

    }
}
