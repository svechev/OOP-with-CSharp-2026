using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1Lab8
{
    /// <summary>
    /// /// <summary>
    /// Convert a string to C# or VB2015
    /// </summary>
    public interface IConvertible
    {
        /// <summary>
        /// Convert a string to C# default implementation
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Converted code to C# syntax</returns>
        string ConvertToCSharp(string code) => "Same code as usual";
        string ConvertToVB2015(string code);
    }
}