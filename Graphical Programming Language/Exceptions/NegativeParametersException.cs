using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Negative Parameters Exception class to catch negative parameters being provided to the command.
    /// </summary>
    public class NegativeParametersException : Exception
    {
        /// <summary>
        /// Intializes an instance of Negative Parameters Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public NegativeParametersException(string message) : base(message) { }
    }
}
