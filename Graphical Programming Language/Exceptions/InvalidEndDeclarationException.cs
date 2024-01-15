using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Exceptions
{
    /// <summary>
    /// Invalid End Declaration Exception class to catch the exception of invalid end statements.
    /// </summary>
    public class InvalidEndDeclarationException : Exception
    {
        /// <summary>
        /// Intializes an instance of Invalid End Declaration Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public InvalidEndDeclarationException(string message) : base(message) { }
    }
}
