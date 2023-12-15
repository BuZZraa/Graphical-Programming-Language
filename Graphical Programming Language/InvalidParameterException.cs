using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Invalid Parameter Exception class to catch invalid parameter being provided to the command.
    /// </summary>
    public class InvalidParameterException : Exception
    {
        /// <summary>
        /// Intializes an instance of Invalid Parameter Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public InvalidParameterException(string message) : base(message) { }
    }
}
