using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Exceptions
{
    /// <summary>
    /// Empty Commands Exception class to catch exception of commands not being provided.
    /// </summary>
    public class EmptyCommandsException : Exception
    {
        /// <summary>
        /// Intializes an instance of Empty Commands Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public EmptyCommandsException(string message) : base(message) { }
    }
}
