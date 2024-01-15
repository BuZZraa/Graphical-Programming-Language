using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Exceptions
{
    /// <summary>
    /// Invalid Value Exception class to catch exception of invalid value being provided.
    /// </summary>
    public class InvalidValueException : Exception
    {
        /// <summary>
        /// Intializes an instance of Invalid Value Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public InvalidValueException(string message) : base(message) { }
    }
}
