using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// An interface for displaying error message of commands.
    /// </summary>
    public interface IMessageDisplayer
    {
        /// <summary>
        /// Abstract void method to store the error messages of commands passed by implemented classes.
        /// </summary>
        /// <param name="message">The error message to be displayed.</param>
        void DisplayMessage(string message);
    }
}
