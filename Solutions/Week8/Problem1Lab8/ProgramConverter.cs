using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1Lab8
{
    public class ProgramConverter : IConvertible
    {
        string IConvertible.ConvertToCSharp(string code)
         => $"IConvertible.ConvertToCSharp from ProgramConverter + {code}";

        string IConvertible.ConvertToVB2015(string code)
        => $"IConvertible.ConvertToVB2015 from ProgramConverter + {code}";
    }
}
