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
        Boolean isValidCommand = false;
        Boolean isValidParameters = false;
        Boolean fill = false;
        Color color = Color.Black;

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
                    throw new Exception($"Please enter a valid command instead of {command[0]}.");
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            throw new Exception($"Please remove parameters for {command[0]} command.");
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
                                throw new Exception($"Please enter a valid parameter for {command[0]} command.");
                            }
                        }

                        else
                        {
                            throw new Exception($"Please enter a single parameter for {command[0]} command.");
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
                                    throw new Exception($"Please enter a non negative integer for {command[0]} command.");
                                }

                                else
                                {
                                    commandValues.Add(value);
                                }
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show($"Please enter positive integer parameters for {command[0]} command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                    throw new Exception($"Please enter a single parameter for {command[0]} command.");
                                }
                            }

                            else if (command[0].Equals("moveto") || command[0].Equals("drawto") || command[0].Equals("rectangle") || command[0].Equals("triangle"))
                            {

                                if (command.Length == 3)
                                {
                                    isValidParameters = true;
                                }

                                else
                                {
                                    throw new Exception($"Please enter two parameters for {command[0]} command.");
                                }
                            }
                        }

                        catch (Exception err2)
                        {
                            MessageBox.Show(err2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            catch (Exception err3)
            {
                MessageBox.Show(err3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RunCommand(Graphics g)
        {

            if (isValidCommand && isValidParameters)
            {

                switch (command[0])
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
                        break;

                    case "reset":
                        xPos = 0; yPos = 0;
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