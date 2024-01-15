using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language.Exceptions
{
    /// <summary>
    /// Syntax Check Exception class to catch exception of syntax button not being clicked before run button.
    /// </summary>
    public class SyntaxCheckException : Exception
    {
        /// <summary>
        /// Intializes an instance of Syntax Check Exception class and sets the error message to the base class.
        /// </summary>
        /// <param name="message">Sets the error message.</param>
        public SyntaxCheckException(string message) : base(message) { }
    }
}
