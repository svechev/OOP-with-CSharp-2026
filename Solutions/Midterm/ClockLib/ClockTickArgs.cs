using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockLib
{
    public class ClockTickArgs : EventArgs
    {
        public (int hour, int minute, int second) ClockTick
        {
            get; set; 
        }

        public ClockTickArgs(int _hour, int _minute, int _second)
        {
            ClockTick = (_hour, _minute, _second);
        }
    }
}
