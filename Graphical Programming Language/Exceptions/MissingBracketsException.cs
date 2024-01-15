using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Exceptions
{
    /// <summary>
    /// Missing Brackets Exception class to catch the exception of brackets not being provided.
    /// </summary>
    public class MissingBracketsException : Exception
    {
        /// <summary>
        /// Intializes an instance of Missing Brackets Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public MissingBracketsException(string message) : base(message) { }
    }
}
