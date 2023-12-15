using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Remove Parameters Exception class to catch parameters being provided to the command where parameters is not required.
    /// </summary>
    public class RemoveParametersException : Exception
    {
        /// <summary>
        /// Intializes an instance of Remove Parameters Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public RemoveParametersException(string message) : base(message) { }
    }
}
