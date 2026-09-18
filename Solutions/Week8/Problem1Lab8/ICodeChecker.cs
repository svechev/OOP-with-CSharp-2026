using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1Lab8
{
    public interface ICodeChecker : IConvertible
    {
        bool CodeCheckSyntax(string codeToCheck, string language);
    }
}