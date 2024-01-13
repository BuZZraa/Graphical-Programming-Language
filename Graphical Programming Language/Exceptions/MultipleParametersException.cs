using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Multiple Parameters Exception class to catch the exception of not enough parameter being provided to the command.
    /// </summary>
    public class MultipleParametersException : Exception
    {
        /// <summary>
        /// Intializes an instance of Multiple Parameters Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public MultipleParametersException(string message) : base(message) { }       
    }
}
