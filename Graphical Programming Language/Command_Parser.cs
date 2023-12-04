using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    public class Command_Parser
    {
        private string[] validCommands = { "moveto", "drawto", "clear", "reset", "rectangle", "circle", "triangle", "pen", "fill" };
        private string[] filteredCommand;
        private string unfilteredCommand;
        private string commandName;

        public Command_Parser(string command)
        {
            unfilteredCommand = command;
        }

        public void ProcessCommand()
        {
            filteredCommand = unfilteredCommand.Trim().Split();
            commandName = filteredCommand[0];
        }

        public void ValidateCommand()
        {
            Boolean isValid = false;
            try
            {
                for (int i = 0; i < validCommands.Length; i++)
                {

                    if (validCommands[i].Equals(commandName))
                    {
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    throw new Exception("Please enter a valid command.");
                }
            }

            catch (Exception err2)
            {
                MessageBox.Show(err2.Message, "Error");
            }
        }

        public void RunCommand(Graphics g)
        {

        }
    }
}
