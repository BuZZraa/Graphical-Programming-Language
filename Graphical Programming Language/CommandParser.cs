using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Shapes;

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
        private string[] validCommands = { "moveto", "drawto", "clear", "reset", "rectangle", "circle", "triangle", "pen", "fill", "rotate" };

        /// <summary>
        /// 
        /// </summary>
        private string[] validRelationalOperators = { "<", ">", "==", "<=", ">=", "!=" };

        /// <summary>
        /// 
        /// </summary>
        private string[] validArithmeticOperators = { "+", "-", "/", "*", "%"};

        /// <summary>
        /// 
        /// </summary>
        private Boolean isMultiLine;

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
        /// 
        /// </summary>
        private float rotationAngle = 0;

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, int> variablesAndValues = new Dictionary<string, int>();

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
        /// 
        /// </summary>
        private string value;

        /// <summary>
        /// 
        /// </summary>
        private string oprand1;

        /// <summary>
        /// 
        /// </summary>
        private string oprand2;

        /// <summary>
        /// 
        /// </summary>
        private string operators;

        /// <summary>
        /// 
        /// </summary>
        private string equalTo;

        private Boolean isIfTriggered = false;

        /// <summary>
        /// Variable to store current command value in string.
        /// </summary>
        private string commandStringValue;

        private Boolean isVariable = false;
        private Boolean isIfStatement = false;
        private Boolean isEndIfStatement = false;
        private Boolean isConditionTrue = false;
        private int result;

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
        /// <param name="form">Instance of Form_SPL class for the use of delegate. </param>
        public CommandParser(IMessageDisplayer messageDisplayer, Form_SPL form)
        {
            _messageDisplayer = messageDisplayer;
            Form = form;
        }

        /// <summary>
        /// 
        /// </summary>
        private Form_SPL Form { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsMultiLine
        {
            set { isMultiLine = value; }
        }


        /// <summary>
        /// Getter and setter methods for the command array to get or set the current command with its values.
        /// </summary>
        public string[] Command
        {
            set { command = value; }
            get { return command; }
        }

        public Boolean IsConditionTrue
        {
            set { isConditionTrue = value; }
            get { return isConditionTrue; }
        }

        public Color Color
        {
            set { color = value; }
            get { return color; }
        }

        public Dictionary<string, int> VariablesAndValues
        {
            set { variablesAndValues = value; }
            get { return variablesAndValues; }
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
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean is_A_Variable()
        {
            isVariable = false;
           
            try
            {
                if (command.Length == 3)
                {
                    commandName = command[0];
                    equalTo = command[1];
                    value = command[2];
                    if (!int.TryParse(commandName, out result))
                    {
                        if (equalTo == "=")
                        {
                            if (int.TryParse(value, out result))
                            {
                                variablesAndValues[commandName] = Convert.ToInt32(value);
                                isVariable = true;
                            }

                            else
                            {
                                throw new Exception($"Please enter a integer value to be assigned instead of {value} in {string.Join(" ", command)}.");
                            }

                        }

                    }
                }

                else if (command.Length == 5)
                {
                    oprand1 = command[2];
                    operators = command[3];
                    oprand2 = command[4];
                    if (variablesAndValues.ContainsKey(commandName))
                    {
                        if (equalTo == "=")
                        {
                            if (int.TryParse(oprand1, out result) || variablesAndValues.ContainsKey(oprand1))
                            {
                                if (validArithmeticOperators.Contains(operators))
                                {
                                    if (int.TryParse(oprand2, out result) || variablesAndValues.ContainsKey(oprand2))
                                    {
                                        int value1 = 0, value2 = 0;
                                        if (int.TryParse(oprand1, out result))
                                        {
                                            value1 = Convert.ToInt32(command[2]);
                                        }

                                        if (!int.TryParse(oprand1, out result))
                                        {
                                            value1 = variablesAndValues[command[2]];
                                        }

                                        if (int.TryParse(oprand2, out result))
                                        {
                                            value2 = Convert.ToInt32(command[4]);
                                        }

                                        if (!int.TryParse(oprand2, out result))
                                        {
                                            value2 = variablesAndValues[command[4]];
                                        }

                                        switch (operators)
                                        {
                                            case "+":
                                                variablesAndValues[commandName] = value1 + value2;
                                                break;
                                            case "-":
                                                variablesAndValues[commandName] = value1 - value2;
                                                break;
                                            case "*":
                                                variablesAndValues[commandName] = value1 * value2;
                                                break;
                                            case "/":
                                                variablesAndValues[commandName] = value1 / value2;
                                                break;
                                            case "%":
                                                variablesAndValues[commandName] = value1 % value2;
                                                break;
                                        }

                                        isVariable = true;
                                    }

                                    else
                                    {
                                        throw new Exception($"Please enter a valid variable or value for operation instead of {command[4]} in {string.Join(" ", command)}.");
                                    }
                                }

                                else
                                {
                                    throw new Exception($"Please enter a valid arithmetic operator instead of {command[3]} in {string.Join(" ", command)}.");
                                }
                            }

                            else
                            {
                                throw new Exception($"Please enter a valid variable or value for operation instead of {command[2]} in {string.Join(" ", command)}.");
                            }
                        }
                    }
                }           
            }
            catch (Exception err)
            {
                _messageDisplayer.DisplayMessage(err.Message);
            }

            return isVariable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean is_A_If_Statement()
        {
            isIfStatement = false;
            try
            {
                if(isMultiLine)
                {
                    if (command.Length == 4)
                    {
                        commandName = command[0];
                        oprand1 = command[1];
                        operators = command[2];
                        oprand2 = command[3];
                        if (commandName == "if")
                        {
                            if (variablesAndValues.ContainsKey(oprand1) || int.TryParse(oprand1, out result))
                            {
                                if (validRelationalOperators.Contains(operators))
                                {
                                    if (variablesAndValues.ContainsKey(oprand2) || int.TryParse(oprand2, out result))
                                    {
                                        isIfStatement = true;  
                                        isIfTriggered = true;
                                    }
                                }

                                else
                                {
                                    throw new Exception($"Please enter a valid operator instead of {command[2]} in {string.Join(" ", command)}.");
                                }
                            }

                            else
                            {
                                throw new Exception($"Please enter a valid variable or number instead of {command[1]} in {string.Join(" ", command)}.");
                            }
                        }
                    }
                }                                         
            }

            catch(Exception err)
            {
                _messageDisplayer.DisplayMessage(err.Message);
            }
           
            return isIfStatement;
        }

        public Boolean is_A_EndIf_Statement()
        {
            isEndIfStatement = false;
            if(command.Length == 1)
            {
                commandName = command[0];
                if(commandName == "endif")
                {
                    if(isIfTriggered)
                    {
                        isEndIfStatement = true;
                        int value1 = 0, value2 = 0;
                        if (int.TryParse(oprand1, out result))
                        {
                            value1 = Convert.ToInt32(oprand1);
                        }

                        if (!int.TryParse(oprand1, out result))
                        {
                            value1 = variablesAndValues[oprand1];
                        }

                        if (int.TryParse(oprand2, out result))
                        {
                            value2 = Convert.ToInt32(oprand2);
                        }

                        if (!int.TryParse(oprand2, out result))
                        {
                            value2 = variablesAndValues[oprand2];
                        }

                        switch (operators)
                        {
                            case "<":
                                if (value1 < value2)
                                {
                                    isConditionTrue = true;
                                }
                                break;
                            case ">":
                                if (value1 > value2)
                                {
                                    isConditionTrue = true;
                                }
                                break;
                            case "<=":
                                if (value1 <= value2)
                                {
                                    isConditionTrue = true;
                                }
                                break;
                            case ">=":
                                if (value1 >= value2)
                                {
                                    isConditionTrue = true;
                                }
                                break;
                            case "==":
                                if (value1 == value2)
                                {
                                    isConditionTrue = true;
                                }
                                break;
                            case "!=":
                                if (value1 != value2)
                                {
                                    isConditionTrue = true;
                                }
                                break;
                        }
                    }
                }
            }
            return isEndIfStatement;
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
                if (command.Length > 0)
                {
                    commandName = command[0].ToLower();
                    if (validCommands.Contains(commandName))
                    {
                        isValidCommand = true;
                    }

                    else if(isVariable)
                    {
                        isValidCommand = true;
                    }

                    else if(isIfStatement)
                    {
                        isValidCommand = true;
                    }

                    else if (isEndIfStatement)
                    {
                        isValidCommand = true;
                    }


                    else
                    {
                        throw new Exception($"Please enter a valid command instead of {commandName} in {string.Join(" ", command)}.");
                    }
                }                     
            }

            catch (Exception err1)
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
                            throw new RemoveParametersException($"Please remove parameters for {commandName} command in {string.Join(" ", command)}.");
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
                                throw new InvalidParameterException($"Please enter a valid parameter for {commandName} command in {string.Join(" ", command)}.");
                            }
                        }

                        else
                        {
                            throw new SingleParameterException($"Please enter a single parameter for {commandName} command in {string.Join(" ", command)}.");
                        }
                    }

                    else if(isVariable)
                    {
                        isValidParameters = true;
                    }

                    else if(isIfStatement)
                    {
                        isValidParameters = true;
                    }

                    else if (isEndIfStatement)
                    {
                        isValidParameters = true;
                    }

                    else
                    {

                        try
                        {

                            commandValues.Clear();
                            for (int i = 1; i < command.Length; i++)
                            {
                                if(int.TryParse(command[i], out int result))
                                {
                                    int value = int.Parse(command[i]);
                                    if(value >= 0)
                                    {
                                        commandValues.Add(value);
                                    }

                                    else
                                    {
                                        throw new NegativeParametersException($"Please enter positive integer parameter for {commandName} commannd in {string.Join(" ", command)}.");
                                    }
                                }
                                
                               
                                else if (variablesAndValues.ContainsKey(command[i]))
                                {
                                    commandValues.Add(variablesAndValues[command[i]]);
                                }                            

                                else 
                                {
                                    throw new InvalidParameterException($"Please enter positive integer parameter for {commandName} command in {string.Join(" ", command)}.");
                                }

                            }
                        
                        }

                        catch (Exception err1)
                        {
                            _messageDisplayer.DisplayMessage(err1.Message);                           
                        }

                        try
                        {
                           
                           
                            if (commandName.Equals("circle") || commandName.Equals("rotate"))
                            {

                                if (commandValues.Count() == 1)
                                {
                                    if (commandName.Equals("rotate"))
                                    {
                                        if (commandValues[0] <= 360)
                                        {
                                            isValidParameters = true;
                                        }

                                        else
                                        {
                                            throw new Exception($"Please enter a valid value within 360 for {commandName} command in {string.Join(" ", command)}.");
                                        }
                                    }
                                    
                                    else if (commandName.Equals("circle"))
                                    {
                                        isValidParameters = true;
                                    }
                                }

                                else
                                {
                                    throw new SingleParameterException($"Please enter a single valid parameter for {commandName} command in {string.Join(" ", command)}.");
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
                                    throw new MultipleParametersException($"Please enter two valid parameters for {commandName} command in {string.Join(" ", command)}.");
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
                    Shape shape = shapeFactory.ShapeType(commandName, color, fill, xPos, yPos, rotationAngle, commandValues);
                    Shapes.Add(shape);
                    return shape;
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

                case "rotate":
                    rotationAngle = commandValues[0];
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
        /// <param name="penSize">Pen size to be set for drawing.</param>
        public void RunCommand(Graphics g, int penSize)
        {
            if (isValidCommand && isValidParameters)
            {
                Shape runCommand = ShapeCommands(g);

                if (runCommand != null)
                {
                    runCommand.PenSize = penSize;
                    Form.UpdateDrawing(runCommand);
                }
            }

            isValidCommand = false;
            isValidParameters = false;
            isIfTriggered = false;
        }
    }
}