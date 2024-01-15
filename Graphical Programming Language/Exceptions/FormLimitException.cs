using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Exceptions
{
    /// <summary>
    /// Form Limit Exception class to catch exception of maximum number of forms being created.
    /// </summary>
    public class FormLimitException : Exception
    {
        /// <summary>
        /// Intializes an instance of Form Limit Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public FormLimitException(string message) : base(message) { }
    }
}
