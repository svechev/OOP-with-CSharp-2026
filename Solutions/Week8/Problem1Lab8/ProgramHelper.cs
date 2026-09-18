using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1Lab8
{
    public class ProgramHelper : ProgramConverter, IConvertible, ICodeChecker
    {
        // Prefer explicit over implicit! (Implicit can be done only once)
        public string ConvertToCSharp(string code)
         => $"Implicit implementation from ProgramHelper ConvertToCSharp + {code}";

        public string ConvertToVB2015(string code)
         => $"Implicit implementation from ProgramHelper ConvertToVB2015 + {code}";

        bool ICodeChecker.CodeCheckSyntax(string codeToCheck, string language)
        {
            Console.WriteLine($"ICodeChecker.CodeCheckSyntax + {codeToCheck} + {language}");
            return codeToCheck.Equals(language);
        }

        // We can explicitly implement because we directly implemented the interface!
        string IConvertible.ConvertToCSharp(string code)
         => $"IConvertible.ConvertToCSharp from ProgramHelper + {code}";

        string IConvertible.ConvertToVB2015(string code)
        => $"IConvertible.ConvertToVB2015 from ProgramHelper + {code}";

    }
}
