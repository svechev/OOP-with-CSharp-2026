using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeClassLibrary
{
    public class SomeClass
    {
        public string SomeProperty { get; set; }

        public SomeClass(string someProperty)
        {
            SomeProperty = someProperty;
        }
    }
}
