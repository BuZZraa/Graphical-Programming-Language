using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Single Parameters Exception class to catch the error of command where a single parameter is required.
    /// </summary>
    public class SingleParameterException : Exception
    {
        /// <summary>
        /// Intializes an instance of Single Parameter Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public SingleParameterException(string message) : base(message) { }      
    }
}
