using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// CommandParser class to parse and execute the commands to draw in graphics.
    /// </summary>
    public class CommandParser
    {
        /// <summary>
        /// Array of valid command name that can used.
        /// </summary>
        private string[] validCommands = { "moveto", "drawto", "clear", "reset", "rectangle", "circle", "triangle", "pen", "fill" };

        /// <summary>
        /// Array to store the current running command with its values.
        /// </summary>
        private string[] command;

        /// <summary>
        /// List to store only values or parameters of the command in integer datatype.
        /// </summary>
        private List<int> commandValues = new List<int>();

        /// <summary>
        /// List to store drawn shapes to persist the drawing in the panel.
        /// </summary>
        private List<Shape> Shapes = new List<Shape>();

        /// <summary>
        /// Variable to store X coordinate from where the drawing will start.
        /// Initially set to 0.
        /// </summary>
        private int xPos = 0;

        /// <summary>
        /// Variable to store X coordinate from where the drawing will start.
        /// Initially set to 0.
        /// </summary>
        private int yPos = 0;

        /// <summary>
        /// Variable to only store current running command name.
        /// </summary>
        private string commandName;

        /// <summary>
        /// Variable to store current command value in string.
        /// </summary>
        private string commandStringValue;

        /// <summary>
        /// Variable to set the flag of current command name being valid.
        /// Initially set to false.
        /// </summary>
        private Boolean isValidCommand = false;

        /// <summary>
        /// Variable to set the flag of current command value or parameters being valid.
        /// Initially set to false.
        /// </summary>
        private Boolean isValidParameters = false;

        /// <summary>
        /// Variable to set the flag of the shape being either filled or not filled.
        /// Initially set to false.
        /// </summary>
        private Boolean fill = false;

        /// <summary>
        /// Variable to store the current color used to draw.
        /// Initially set to black.
        /// </summary>
        private Color color = Color.Black;

        /// <summary>
        /// Instance of IMessageDisplayer interface created used to display error message.
        /// </summary>
        private readonly IMessageDisplayer _messageDisplayer;

        /// <summary>
        /// Parameterized constructor which initializes a new instance of the Command_Parser class that takes
        /// instance of IMessageDisplayer interface as parameter to display error messages.
        /// </summary>
        /// <param name="messageDisplayer">Instance of IMessageDisplayer interface to display error messages.</param>
        public CommandParser(IMessageDisplayer messageDisplayer) 
        { 
            _messageDisplayer = messageDisplayer;
        }

        /// <summary>
        /// Getter and setter methods for the command array to get or set the current command with its values.
        /// </summary>
        public string[] Command
        {
            set { command = value; }
            get { return command; }
        }

        /// <summary>
        /// Getter method to get boolean value of a command name being valid or not.
        /// </summary>
        public Boolean IsValidCommand
        {
            get { return isValidCommand; }
        }

        /// <summary>
        /// Getter method to get boolean value of a command parameters being valid or not.
        /// </summary>
        public Boolean IsValidParameters
        {
            get { return isValidParameters; }
        }

        /// <summary>
        /// Getter method to return list of stored drawn shapes.
        /// </summary>
        /// <returns>Return the list of drawn shapes.</returns>
        public List<Shape> GetShapes()
        {
            return Shapes;
        }

        /// <summary>
        /// Boolean method to verify if a command name is valid or not by passing it and checking if it is in the validCommands array.
        /// </summary>
        /// <returns>Returns true if command name is valid if not returns false.</returns>
        public Boolean ValidateCommandName()
        {
            isValidCommand = false;
            try
            {
                if (!string.IsNullOrEmpty(command[0]))
                {
                    commandName = command[0].ToLower();
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
                        throw new IndexOutOfRangeException($"Please enter a valid command instead of {commandName}.");
                    }
                }                     
            }

            catch (IndexOutOfRangeException err1)
            {
                _messageDisplayer.DisplayMessage(err1.Message);
            }
            return isValidCommand;
        }

        /// <summary>
        /// Boolean method to verify if command parameters are valid or not by checking for specific values 
        /// and length of the command array or commandValues array.
        /// </summary>
        /// <returns>Returns true if command parameters are valid if not returns false.</returns>
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
                            throw new RemoveParametersException($"Please remove parameters for {commandName} command.");
                        }
                    }

                    else if (commandName.Equals("pen") || commandName.Equals("fill"))
                    {

                        if (command.Length == 2)
                        {
                            commandStringValue = command[1].ToLower();
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
                                throw new InvalidParameterException($"Please enter a valid parameter for {commandName} command.");
                            }
                        }

                        else
                        {
                            throw new SingleParameterException($"Please enter a single parameter for {commandName} command.");
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
                                    throw new NegativeParametersException($"Please enter positive integer parameter for {commandName} command.");
                                }

                                else
                                {
                                    commandValues.Add(value);
                                }
                            }
                        
                        }

                        catch (Exception err1)
                        {
                            _messageDisplayer.DisplayMessage(err1.Message);                           
                        }

                        try
                        {

                            if (commandName.Equals("circle"))
                            {

                                if (commandValues.Count() == 1)
                                {
                                    isValidParameters = true;
                                }

                                else
                                {
                                    throw new SingleParameterException($"Please enter a single valid parameter for {commandName} command.");
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
                                    throw new MultipleParametersException($"Please enter two valid parameters for {commandName} command.");
                                }
                            }
                        }

                        catch (Exception err2)
                        {
                            _messageDisplayer.DisplayMessage(err2.Message);
                        }
                    }
                }
            }

            catch (Exception err3)
            {
                _messageDisplayer.DisplayMessage(err3.Message);
            }
            return isValidParameters;
        }

        /// <summary>
        /// Method to get the type of shapes and set its propeprties according to the command name. 
        /// </summary>
        /// <returns>Returns instance of inherited class of base class Shape.</returns>
        private Shape ShapeCommands(Graphics g)
        {
            switch (commandName)
            {
                case "rectangle":
                case "circle":
                case "triangle":
                case "drawto":
                    ShapeFactory shapeFactory = new ShapeFactory(); 
                    return shapeFactory.ShapeType(commandName, color, fill, xPos, yPos, commandValues);

                case "clear":
                    g.Clear(SystemColors.ActiveBorder);
                    Shapes.Clear();
                    color = Color.Black;
                    return null;

                case "reset":
                    xPos = 0; yPos = 0;
                    color = Color.Black;
                    return null;

                case "pen":
                    color = Color.FromName(command[1]);
                    return null;

                case "moveto":
                    xPos = commandValues[0];
                    yPos = commandValues[1];
                    return null;

                case "fill":
                    fill = command[1].Equals("on");
                    return null;

                default:
                    return null;
            }
        }

        /// <summary>
        /// Void method to run the commands after being verified by ValidateCommandName and ValidateParameters.
        /// Adds to Shapes list after drawing to persist the drawing.
        /// </summary>
        /// <param name="g">Graphics object taken as parameter to draw the shapes on.</param>
        public void RunCommand(Graphics g)
        {
            if (isValidCommand && isValidParameters)
            {
                Shape runCommand = ShapeCommands(g);

                if (runCommand != null)
                {
                    runCommand.Draw(g);
                    Shapes.Add(runCommand);
                }
            }

            isValidCommand = false;
            isValidParameters = false;      
        }
    }
}