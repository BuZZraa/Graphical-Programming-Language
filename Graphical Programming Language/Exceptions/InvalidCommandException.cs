using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Exceptions
{
    /// <summary>
    /// Invalid Command Exception class to catch the exception of invalid commands being passed.
    /// </summary>
    public class InvalidCommandException : Exception
    {
        /// <summary>
        /// Intializes an instance of Invalid Command Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public InvalidCommandException(string message) : base(message) { }
    }
}
