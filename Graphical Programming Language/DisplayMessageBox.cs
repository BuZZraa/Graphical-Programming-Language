using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Class that implements IMessageDisplayer to display the error message in MessageBox.
    /// </summary>
    public class DisplayMessageBox : IMessageDisplayer
    {
        /// <summary>
        /// Implementing method from IMessageDisplayer interface to show the error messages in MessageBox.
        /// </summary>
        /// <param name="message">The error message to be displayed in the MessageBox.</param>
        public void DisplayMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
