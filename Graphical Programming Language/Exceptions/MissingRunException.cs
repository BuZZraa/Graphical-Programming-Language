using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Exceptions
{
    /// <summary>
    /// Missing Run Exception class to catch run not being provided for multline commands.
    /// </summary>
    public class MissingRunException : Exception
    {
        /// <summary>
        /// Intializes an instance of Missing Run Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public MissingRunException(string message) : base(message) { }
    }
}
