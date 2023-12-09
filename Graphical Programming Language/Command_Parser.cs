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
        private int xPos = 0, yPos = 0;
        private string commandName;
        private string commandStringValue;
        private Boolean isValidCommand = false;
        private Boolean isValidParameters = false;
        private Boolean fill = false;
        private Color color = Color.Black;

        public Command_Parser() { }

        public string[] Command
        {
            set { command = value; }
            get { return command; }
        }

        public Boolean IsValidCommand
        {
            get { return isValidCommand; }
        }

        public Boolean IsValidParameters
        {
            get { return isValidParameters; }
        }

        public Boolean ValidateCommandName()
        {
            isValidCommand = false;
            try
            {
                if (!string.IsNullOrEmpty(command[0]))
                {
                    commandName = command[0];
                    for (int i = 0; i < validCommands.Length; i++)
                    {

                        if (validCommands[i].Equals(commandName))
                        {
                            isValidCommand = true;
                            break;
                        }
                    }

                    if (!isValidCommand)
                    {
                        throw new Exception($"Please enter a valid command instead of {commandName}.");
                    }
                }      
                
                else
                {
                    throw new Exception("Please enter a command.");
                }
            }

            catch (Exception err1)
            {
                MessageBox.Show(err1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValidCommand;
        }

        public Boolean ValidateParameters()
        {
            isValidParameters = false;
            try
            {

                if (isValidCommand)
                {             
                    if (commandName.Equals("clear") || commandName.Equals("reset"))
                    {

                        if (command.Length == 1)
                        {
                            isValidParameters = true;
                        }

                        else
                        {
                            throw new Exception($"Please remove parameters for {commandName} command.");
                        }
                    }

                    else if (commandName.Equals("pen") || commandName.Equals("fill"))
                    {

                        if (command.Length == 2)
                        {
                            commandStringValue = command[1];
                            if (commandName.Equals("pen") && (commandStringValue.Equals("red") || commandStringValue.Equals("blue") || commandStringValue.Equals("green")))
                            {
                                isValidParameters = true;
                            }

                            else if (commandName.Equals("fill") && (commandStringValue.Equals("on") || commandStringValue.Equals("off")))
                            {
                                isValidParameters = true;
                            }

                            else
                            {
                                throw new Exception($"Please enter a valid parameter for {commandName} command.");
                            }
                        }

                        else
                        {
                            throw new Exception($"Please enter a single parameter for {commandName} command.");
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
                                if (value <= 0)
                                {
                                    throw new Exception();
                                }

                                else
                                {
                                    commandValues.Add(value);
                                }
                            }
                        
                        }

                        catch (Exception)
                        {
                            MessageBox.Show($"Please enter positive integer parameter for {commandName} command." , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                           
                        }

                        try
                        {

                            if (commandName.Equals("circle"))
                            {

                                if (commandValues.Count() == 1)
                                {
                                    isValidParameters = true;
                                    MessageBox.Show(""+isValidParameters);
                                }

                                else
                                {
                                    throw new Exception($"Please enter a single parameter for {commandName} command.");
                                }
                            }

                            else if (commandName.Equals("moveto") || commandName.Equals("drawto") || commandName.Equals("rectangle") || commandName.Equals("triangle"))
                            {

                                if (commandValues.Count() == 2)
                                {
                                    isValidParameters = true;
                                }

                                else
                                {
                                    throw new Exception($"Please enter two parameters for {commandName} command.");
                                }
                            }
                        }

                        catch (Exception err3)
                        {
                            MessageBox.Show(err3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            catch (Exception err4)
            {
                MessageBox.Show(err4.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValidParameters;
        }

        public void RunCommand(Graphics g)
        {

            if (isValidCommand && isValidParameters)
            {

                switch (commandName)
                {
                    case "rectangle":
                        Shape rectangle = new Rectangle(color, fill, xPos, yPos, commandValues[0], commandValues[1]);
                        rectangle.Draw(g);
                        break;

                    case "circle":
                        Shape circle = new Circle(color, fill, xPos, yPos, commandValues[0]);
                        circle.Draw(g);
                        break;

                    case "triangle":
                        Shape triangle = new Triangle(color, fill, xPos, yPos, commandValues[0], commandValues[1]);
                        triangle.Draw(g);
                        break;

                    case "clear":
                        g.Clear(SystemColors.ActiveBorder);
                        color = Color.Black;
                        break;

                    case "reset":
                        xPos = 0; yPos = 0;
                        color = Color.Black;
                        break;

                    case "pen":
                        color = Color.FromName(command[1]);
                        break;

                    case "moveto":
                        xPos = commandValues[0];
                        yPos = commandValues[1];
                        break;

                    case "drawto":
                        Pen p = new Pen(color, 1);
                        g.DrawLine(p, xPos, yPos, commandValues[0], commandValues[1]);
                        break;

                    case "fill":
                        if (command[1].Equals("on"))
                        {
                            fill = true;
                        }

                        else
                        {
                            fill = false;
                        }
                        break;

                    default:
                        MessageBox.Show("Command provided is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }

            isValidCommand = false;
            isValidParameters = false;
        }
    }
}