using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Exceptions
{
    /// <summary>
    /// Invalid Operator Exception class to catch exception of invalid operator being provided.
    /// </summary>
    public class InvalidOperatorException : Exception
    {
        /// <summary>
        /// Intializes an instance of Invalid Operator Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public InvalidOperatorException(string message) : base(message) { }
    }
}
