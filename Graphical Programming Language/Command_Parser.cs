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
        private string[] command;
        private List<int> commandValues = new List<int>();
        Boolean isValidCommand = false;
        Boolean isValidParameters = false;

        public Command_Parser() { }

        public string[] Command
        {
            set { command = value; }
        }

        public Boolean IsValidCommand
        {
            get { return isValidCommand; }
        }

        public Boolean IsValidParameters
        {
            get { return isValidParameters; }
        }

        public void ValidateCommandName()
        {
            isValidCommand = false;
            try
            {
                for (int i = 0; i < validCommands.Length; i++)
                {
                    if (validCommands[i].Equals(command[0]))
                    {
                        isValidCommand = true;
                        break;
                    }
                }

                if (!isValidCommand)
                {
                    throw new Exception("Please enter a valid command.");
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        public void ValidateParameters()
        {
            isValidParameters = false;
            try
            {
                if (isValidCommand)
                {
                    if (command[0].Equals("clear") || command[0].Equals("reset"))
                    {
                        if (command.Length == 1)
                        {
                            isValidParameters = true;
                        }

                        else
                        {
                            throw new Exception("Please remove parameters for this command.");
                        }
                    }

                    else if (command[0].Equals("pen") || command[0].Equals("fill"))
                    {
                        if (command.Length == 2)
                        {
                            if (command[0].Equals("pen") && (command[1].Equals("red") || command[1].Equals("blue") || command[1].Equals("green")))
                            {
                                isValidParameters = true;
                            }

                            else if (command[0].Equals("fill") && (command[1].Equals("on") || command[1].Equals("off")))
                            {
                                isValidParameters = true;
                            }

                            else
                            {
                                throw new Exception("Please enter a valid parameter for the command.");
                            }
                        }

                        else
                        {
                            throw new Exception("Please enter a single parameter for this command.");
                        }
                    }

                    else
                    {
                        try
                        {
                            commandValues.Clear();
                            for (int i = 1; i < command.Length; i++)
                            {
                                int value = int.Parse(command[i]);
                                if (value < 0)
                                {
                                    throw new Exception("Please enter a non negative integer for this command.");
                                }

                                else
                                {
                                    commandValues.Add(value);
                                }
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Please enter positive integer parameters for this command.", "Error");
                        }

                        try
                        {
                            if (command[0].Equals("circle"))
                            {
                                if (command.Length == 2)
                                {
                                    isValidParameters = true;
                                }

                                else
                                {
                                    throw new Exception("Please enter a single parameter for this command.");
                                }
                            }

                            else if (command[0].Equals("moveto") || command[0].Equals("drawto") || command[0].Equals("rectangle"))
                            {
                                if (command.Length == 3)
                                {
                                    isValidParameters = true;
                                }

                                else
                                {
                                    throw new Exception("Please enter two parameters for this command.");
                                }
                            }
                        }

                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error");
                        }
                    }
                }
            }

            catch (Exception err3)
            {
                MessageBox.Show(err3.Message, "Error");
            }
        }

        public void RunCommand(Graphics g)
        {

        }
    }
}
