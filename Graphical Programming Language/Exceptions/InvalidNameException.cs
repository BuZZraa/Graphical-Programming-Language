using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Exceptions
{
    /// <summary>
    /// Invalid Name Exception class to catch the exception of invalid name being assigned.
    /// </summary>
    public class InvalidNameException : Exception
    {
        /// <summary>
        /// Intializes an instance of Invalid Name Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public InvalidNameException(string message) : base(message) { }
    }
}
