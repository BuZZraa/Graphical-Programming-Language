using Graphical_Programming_Language;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace Graphical_Programming_Language_Unit_Test
{
    /// <summary>
    /// Unit Testing class to test commands and its parameters.
    /// Implements IMessageDisplayer to show message in string instead of MessageBox during Testing.
    /// </summary>
    [TestClass]
    public class CommandParserUnitTest : IMessageDisplayer
    {
        /// <summary>
        /// Variable to store current error message as a string instead of MessageBox.
        /// </summary>
        public string _displayedMessage;

        /// <summary>
        /// Getter method which returns variable that stores error messages as string.
        /// </summary>
        public string DisplayedMessage
        {
            get { return _displayedMessage;  }
        }

        /// <summary>
        /// Void method which stores current error message as a string instead of MessageBox.
        /// </summary>
        /// <param name="message"></param>
        public void DisplayMessage(string message)
        {
            _displayedMessage = message;
        }

        /// <summary>
        /// Test method to test if the current command provided is stored in CommandParser class.
        /// </summary>
        [TestMethod]
        public void IsCommandStoredTest()
        {
            //Arrange 
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "rectangle 100 100";
            string[] expectedCommandArray = {"rectangle", "100", "100"};

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            CollectionAssert.AreEqual(expectedCommandArray, command.Command);
        }

        /// <summary>
        /// Test method to test the command provided being empty.
        /// </summary>
        [TestMethod]
        public void IsEmptyCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string[] expectedCommand = { };

            //Act
            command.Command = expectedCommand;

            //Assert
            Assert.IsFalse(command.ValidateCommandName());
        }


        /// <summary>
        /// Test method to test null being passed instead of command.
        /// </summary>
        [TestMethod]
        public void IsNullCommand()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string[] expectedCommand = { null };

            //Act
            command.Command = expectedCommand;

            //Assert
            Assert.IsFalse(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test invalid command being passed.
        /// </summary>
        [TestMethod]
        public void IsInvalidCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "abcde 100,100";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsFalse(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the valid rectangle command name.
        /// </summary>
        [TestMethod]
        public void IsValidRectangleCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "rectangle 100,100";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the rectangle command name being non-case sensitive.
        /// </summary>
        [TestMethod]
        public void IsNotCaseSensitiveRectangleCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "RECTANGLE 100,100";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the rectangle parameters being valid.
        /// </summary>
        [TestMethod]
        public void IsValidRectangleParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "rectangle 100,100" ;

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsTrue(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the invalid string rectangle parameters.
        /// </summary>
        [TestMethod]
        public void IsInvalidStringRectangleParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "rectangle seventy,seventy";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the rectangle parameters being empty.
        /// </summary>
        [TestMethod]
        public void IsEmptyRectangleParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "rectangle";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }


        /// <summary>
        /// Test method to test the rectangle parameters being negative.
        /// </summary>
        [TestMethod]
        public void IsRectangleNegativeParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "rectangle -100,-100";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the rectangle parameters being null.
        /// </summary>
        [TestMethod]
        public void IsRectangleNullParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "rectangle null,null";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the rectangle command missing a parameter.
        /// </summary>
        [TestMethod]
        public void IsRectangleMissingParameter()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "rectangle 100";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the valid triangle command name.
        /// </summary>
        [TestMethod]
        public void IsValidTriangleCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "triangle 50,50";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the triangle command name being non-case sensitive.
        /// </summary>
        [TestMethod]
        public void IsNotCaseSensitiveTriangleCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "TRIANGLE 50,50";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the triangle parameters being valid.
        /// </summary>
        [TestMethod]
        public void IsValidTriangleParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "triangle 50,50";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsTrue(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the invalid string triangle parameters.
        /// </summary>
        [TestMethod]
        public void IsInvalidStringTriangleParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "triangle fifty,fifty";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the triangle parameters being empty.
        /// </summary>
        [TestMethod]
        public void IsEmptyTriangleParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "triangle";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }


        /// <summary>
        /// Test method to test the triangle parameters being negative.
        /// </summary>
        [TestMethod]
        public void IsTriangleNegativeParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "triangle -50,-50";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the triangle parameters being null.
        /// </summary>
        [TestMethod]
        public void IsTriangleNullParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "triangle null,null";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the triangle command missing a parameter.
        /// </summary>
        [TestMethod]
        public void IsTriangleMissingParameter()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "triangle 50" ;

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the valid circle command name.
        /// </summary>
        [TestMethod]
        public void IsValidCircleCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "circle 75" ;

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the circle command name being non-case sensitive.
        /// </summary>
        [TestMethod]
        public void IsNotCaseSensitiveCircleCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "CIRCLE 75";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the circle parameters being valid.
        /// </summary>
        [TestMethod]
        public void IsValidCircleParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "circle 75";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsTrue(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the invalid string circle parameters.
        /// </summary>
        [TestMethod]
        public void IsInvalidStringCircleParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "circle thirty";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the circle parameters being empty or missing parameter.
        /// </summary>
        [TestMethod]
        public void IsEmptyOrMissingCircleParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "circle";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }


        /// <summary>
        /// Test method to test the circle parameters being negative.
        /// </summary>
        [TestMethod]
        public void IsCircleNegativeParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "circle -75";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the circle parameters being null.
        /// </summary>
        [TestMethod]
        public void IsCircleNullParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "circle null";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the valid star command name.
        /// </summary>
        [TestMethod]
        public void IsValidStarCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "star 35";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the star command name being non-case sensitive.
        /// </summary>
        [TestMethod]
        public void IsNotCaseSensitiveStarCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "STAR 35";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the star parameters being valid.
        /// </summary>
        [TestMethod]
        public void IsValidStarParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "star 35";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsTrue(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the invalid string star parameters.
        /// </summary>
        [TestMethod]
        public void IsInvalidStringStarParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "star thirty";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the star parameters being empty or missing parameter.
        /// </summary>
        [TestMethod]
        public void IsEmptyOrMissingStarParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "star";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }


        /// <summary>
        /// Test method to test the star parameters being negative.
        /// </summary>
        [TestMethod]
        public void IsStarNegativeParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "star -75";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the star parameters being null.
        /// </summary>
        [TestMethod]
        public void IsStarNullParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "star null";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the valid moveto command name.
        /// </summary>
        [TestMethod]
        public void IsValidMoveToCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "moveto 100,100";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the moveto command name being non-case sensitive.
        /// </summary>
        [TestMethod]
        public void IsNotCaseSensitiveMoveToCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "MOVETO 100,100";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the moveto parameters being valid.
        /// </summary>
        [TestMethod]
        public void IsValidMoveToParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "moveto 100,100";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsTrue(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the invalid string moveto parameters.
        /// </summary>
        [TestMethod]
        public void IsInvalidStringMoveToParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "moveto fourty,fourty";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the moveto parameters being empty.
        /// </summary>
        [TestMethod]
        public void IsEmptyMoveToParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "moveto";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }


        /// <summary>
        /// Test method to test the moveto parameters being negative.
        /// </summary>
        [TestMethod]
        public void IsMoveToNegativeParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "moveto -100,-100";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the moveto parameters being null.
        /// </summary>
        [TestMethod]
        public void IsMoveToNullParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "moveto null,null";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the moveto command missing a parameter.
        /// </summary>
        [TestMethod]
        public void IsMoveToMissingParameter()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "moveto 100";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the valid drawto command name.
        /// </summary>
        [TestMethod]
        public void IsValidDrawToCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "drawto 200,200";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the drawto command name being non-case sensitive.
        /// </summary>
        [TestMethod]
        public void IsNotCaseSensitiveDrawToCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "DRAWTO 200,200";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the drawto parameters being valid.
        /// </summary>
        [TestMethod]
        public void IsValidDrawToParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "drawto 200,200";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsTrue(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the invalid string drawto parameters.
        /// </summary>
        [TestMethod]
        public void IsInvalidStringDrawToParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "drawto seventy,seventy";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the drawto parameters being empty.
        /// </summary>
        [TestMethod]
        public void IsEmptyDrawToParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "drawto";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }


        /// <summary>
        /// Test method to test the drawto parameters being negative.
        /// </summary>
        [TestMethod]
        public void IsDrawToNegativeParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "drawto -200,-200";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the drawto parameters being null.
        /// </summary>
        [TestMethod]
        public void IsDrawToNullParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "drawto null,null";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the drawto command missing a parameter.
        /// </summary>
        [TestMethod]
        public void IsDrawToMissingParameter()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "drawto 200";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the valid clear command name.
        /// </summary>
        [TestMethod]
        public void IsValidClearCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "clear";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the clear command name being non-case sensitive.
        /// </summary>
        [TestMethod]
        public void IsNotCaseSensitiveClearCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "CLEAR";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the clear command having a parameter.
        /// </summary>
        [TestMethod]
        public void DoesClearHaveParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "clear 75" ;

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the valid reset command name.
        /// </summary>
        [TestMethod]
        public void IsValidResetCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "reset";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the reset command name being non-case sensitive.
        /// </summary>
        [TestMethod]
        public void IsNotCaseSensitiveResetCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "RESET";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the reset command having a parameters.
        /// </summary>
        [TestMethod]
        public void DoesResetHaveParameters()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "reset 75";

            // Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the valid fill command name.
        /// </summary>
        [TestMethod]
        public void IsValidFillCommandName()
        {

            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "fill on";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the fill command name and its parameters being non-case sensitive.
        /// </summary>
        [TestMethod]
        public void IsNotCaseSensitiveFillCommand()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "FILL ON";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
            Assert.IsTrue(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the fill parameter being set to on.
        /// </summary>
        [TestMethod]
        public void IsValidFillOnParameter()
        {

            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "fill on";

            //Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            //Assert
            Assert.IsTrue(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the fill parameter being set to off.
        /// </summary>
        [TestMethod]
        public void IsValidFillOffParameter()
        {

            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "fill off";

            //Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            //Assert
            Assert.IsTrue(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the fill parameter being invalid.
        /// </summary>
        [TestMethod]
        public void IsInvalidFillParameter()
        {

            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "fill red";

            //Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            //Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the valid pen command name.
        /// </summary>
        [TestMethod]
        public void IsValidPenCommandName()
        {

            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "pen red";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        /// <summary>
        /// Test method to test the pen parameters being valid.
        /// </summary>
        [TestMethod]
        public void IsValidPenParameter()
        {

            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "pen red";

            //Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            //Assert
            Assert.IsTrue(command.ValidateParameters());
        }
       

        /// <summary>
        /// Test method to test the pen parameter being invalid.
        /// </summary>
        [TestMethod]
        public void IsInvalidPenParameter()
        {

            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "pen #FF00FF";

            //Act
            command.Command = form.SplitCommand(expectedCommand);
            command.ValidateCommandName();

            //Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        /// <summary>
        /// Test method to test the pen command name and its parameters being non-case sensitive.
        /// </summary>
        [TestMethod]
        public void IsNotCaseSensitivePenCommand()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "PEN RED";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
            Assert.IsTrue(command.ValidateParameters());
        }      

        /// <summary>
        /// Test method to test if the variable is created and its value is stored.
        /// </summary>
        [TestMethod]
        public void IsVariableStored()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand = "radius = 50";

            //Act
            command.Command = form.SplitCommand(expectedCommand);

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));
        }

        /// <summary>
        /// Test method to test the variable increment operation.
        /// </summary>
        [TestMethod]
        public void CheckVariableIncrementOperation()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);

            //Act - Variable Assignment
            string expectedCommand1 = "radius = 50";
            command.Command = form.SplitCommand(expectedCommand1);
            command.Is_A_Variable();     

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));


            //Arrange
            string expectedCommand2 = "radius = radius + 50";          
            int expectedValue = 100;

            //Act - Variable Increment Operation
            command.Command = form.SplitCommand(expectedCommand2);

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));
            Assert.AreEqual(expectedValue, command.VariablesAndValues[command.Command[0]]);        
        }

        /// <summary>
        /// Test method to test the variable decrement operation.
        /// </summary>
        [TestMethod]
        public void CheckVariableDecrementOperation()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);

            //Act - Variable Assignment
            string expectedCommand1 = "radius = 100";
            command.Command = form.SplitCommand(expectedCommand1);
            command.Is_A_Variable();

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));


            //Arrange
            string expectedCommand2 = "radius = radius - 50";
            int expectedValue = 50;

            //Act - Variable Decrement Operation
            command.Command = form.SplitCommand(expectedCommand2);

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));
            Assert.AreEqual(expectedValue, command.VariablesAndValues[command.Command[0]]);
        }

        /// <summary>
        /// Test method to test the variable multiplication operation.
        /// </summary>
        [TestMethod]
        public void CheckVariableMultiplicationOperation()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);

            //Act - Variable Assignment
            string expectedCommand1 = "radius = 20";
            command.Command = form.SplitCommand(expectedCommand1);
            command.Is_A_Variable();

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));


            //Arrange
            string expectedCommand2 = "radius = radius * 5";
            int expectedValue = 100;

            //Act - Variable Multiplication Operation
            command.Command = form.SplitCommand(expectedCommand2);

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));
            Assert.AreEqual(expectedValue, command.VariablesAndValues[command.Command[0]]);
        }

        /// <summary>
        /// est method to test the variable division operation.
        /// </summary>
        [TestMethod]
        public void CheckVariableDivisionOperation()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);

            //Act - Variable Assignment
            string expectedCommand1 = "radius = 200";
            command.Command = form.SplitCommand(expectedCommand1);
            command.Is_A_Variable();

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));


            //Arrange
            string expectedCommand2 = "radius = radius / 4";
            int expectedValue = 50;

            //Act - Variable Division Operation
            command.Command = form.SplitCommand(expectedCommand2);

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));
            Assert.AreEqual(expectedValue, command.VariablesAndValues[command.Command[0]]);
        }

        /// <summary>
        /// Test method to test the variable modulo operation.
        /// </summary>
        [TestMethod]
        public void CheckVariableModuloOperation()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);

            //Act - Variable Assignment
            string expectedCommand1 = "radius = 110";
            command.Command = form.SplitCommand(expectedCommand1);
            command.Is_A_Variable();

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));


            //Arrange
            string expectedCommand2 = "radius = radius % 60";
            int expectedValue = 50;

            //Act - Variable Modulo Operation
            command.Command = form.SplitCommand(expectedCommand2);

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));
            Assert.AreEqual(expectedValue, command.VariablesAndValues[command.Command[0]]);
        }

        /// <summary>
        /// Test method to check a valid if statement command.
        /// </summary>
        [TestMethod]
        public void ValidIfStatement()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);

            //Act - Variable Assignment
            string expectedCommand1 = "radius = 100" ;
            command.Command = form.SplitCommand(expectedCommand1);
            command.Is_A_Variable();

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));


            //Arrange 
            string expectedCommands2 = "if radius > 50";
            command.IsMultiLine = true;

            //Act
            command.Command = form.SplitCommand(expectedCommands2);
            command.Is_A_If_Statement();

            //Assert
            Assert.IsTrue(command.Is_A_If_Statement());       
        }

        /// <summary>
        ///  Test method to check a invalid if statement command.
        /// </summary>
        [TestMethod]
        public void InvalidIfStatement()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);

            //Act - Variable Assignment
            string expectedCommand1 = "radius = 100";
            command.Command = form.SplitCommand(expectedCommand1);
            command.Is_A_Variable();

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));


            //Arrange 
            string expectedCommands2 = "if radius = 50";
            command.IsMultiLine = true;
            command.Command = form.SplitCommand(expectedCommands2);

            //Act
            command.Is_A_If_Statement();

            //Assert
            Assert.IsFalse(command.Is_A_If_Statement());
        }

        /// <summary>
        /// Test method to check a valid endif statement command.
        /// </summary>
        [TestMethod]
        public void ValidEndIfStatement()
        {

            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);

            //Act - Variable Assignment
            string expectedCommand1 = "radius = 100";
            command.Command = form.SplitCommand(expectedCommand1);
            command.Is_A_Variable();

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));


            //Arrange 
            string expectedCommands2 = "if radius > 50";
            command.IsMultiLine = true;
            command.Command = form.SplitCommand(expectedCommands2);

            //Act - Declaring if statement
            command.Is_A_If_Statement();

            //Assert
            Assert.IsTrue(command.Is_A_If_Statement());


            //Arrange
            string expectedCommand3 = "endif";
            command.Command = form.SplitCommand(expectedCommand3);

            //Act
            command.Is_A_EndIf_Statement();

            //Assert
            Assert.IsTrue(command.Is_A_EndIf_Statement());
        }

        /// <summary>
        /// Test method to check a invalid endif statement command.
        /// </summary>
        [TestMethod]
        public void InvalidEndIfStatement()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand1 = "endif";
            command.Command = form.SplitCommand(expectedCommand1);

            //Act
            command.Is_A_EndIf_Statement();

            //Assert
            Assert.IsFalse(command.Is_A_EndIf_Statement());
        }

        /// <summary>
        /// Test method to check a valid while loop command.
        /// </summary>
        [TestMethod]
        public void ValidWhileLoop()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);

            //Act - Variable Assignment
            string expectedCommand1 = "count = 0";
            command.Command = form.SplitCommand(expectedCommand1);
            command.Is_A_Variable();

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));


            //Arrange 
            string expectedCommands2 = "while count <= 3";
            command.IsMultiLine = true;

            //Act
            command.Command = form.SplitCommand(expectedCommands2);
            command.Is_A_While_Loop();

            //Assert
            Assert.IsTrue(command.Is_A_While_Loop());
        }

        /// <summary>
        /// Test method to check a invalid while loop command.
        /// </summary>
        [TestMethod]
        public void InvalidWhileLoop()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);

            //Act - Variable Assignment
            string expectedCommand1 = "count = 1";
            command.Command = form.SplitCommand(expectedCommand1);
            command.Is_A_Variable();

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));


            //Arrange 
            string expectedCommands2 = "while count ! 3";
            command.IsMultiLine = true;

            //Act
            command.Command = form.SplitCommand(expectedCommands2);
            command.Is_A_While_Loop();

            //Assert
            Assert.IsFalse(command.Is_A_While_Loop());
        }

        /// <summary>
        /// Test method to check a valid end loop.
        /// </summary>
        [TestMethod]
        public void ValidEndLoop()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);

            //Act - Variable Assignment
            string expectedCommand1 = "count = 1";
            command.Command = form.SplitCommand(expectedCommand1);
            command.Is_A_Variable();

            //Assert
            Assert.IsTrue(command.Is_A_Variable());
            Assert.IsTrue(command.VariablesAndValues.ContainsKey(command.Command[0]));


            //Arrange 
            string expectedCommands2 = "while count <= 3";
            command.IsMultiLine = true;

            //Act - Declaring while loop
            command.Command = form.SplitCommand(expectedCommands2);
            command.Is_A_While_Loop();

            //Assert
            Assert.IsTrue(command.Is_A_While_Loop());


            //Arrange
            string expectedCommand3 = "endloop";
            command.Command = form.SplitCommand(expectedCommand3);

            //Act
            command.Is_A_End_Loop();

            //Assert
            Assert.IsTrue(command.Is_A_End_Loop());
        }

        /// <summary>
        /// Test method to check a invalid command end loop.
        /// </summary>
        [TestMethod]
        public void InvalidEndLoop()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand1 = "endloop";
            command.Command = form.SplitCommand(expectedCommand1);

            //Act
            command.Is_A_End_Loop();

            //Assert
            Assert.IsFalse(command.Is_A_End_Loop());
        }

        /// <summary>
        /// Test method to check a valid method.
        /// </summary>
        [TestMethod]
        public void ValidMethod()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            command.IsMultiLine = true;

            //Act
            string expectedCommands1 = "method createShapes ()";
            command.Command = form.SplitCommand(expectedCommands1);
            command.Is_A_Method();

            //Assert
            Assert.IsTrue(command.Is_A_Method());
        }

        /// <summary>
        /// Test method to check a invalid method command.
        /// </summary>
        [TestMethod]
        public void InvalidMethod()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            command.IsMultiLine = true;

            //Act
            string expectedCommands1 = "method createShapes";
            command.Command = form.SplitCommand(expectedCommands1);
            command.Is_A_Method();

            //Assert
            Assert.IsFalse(command.Is_A_Method());
        }

        /// <summary>
        /// Test method to check a valid end method command.
        /// </summary>
        [TestMethod]
        public void ValidEndMethod()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            command.IsMultiLine = true;

            //Act - Declaring method
            string expectedCommands1 = "method createShapes ()";
            command.Command = form.SplitCommand(expectedCommands1);
            command.Is_A_Method();

            //Assert
            Assert.IsTrue(command.Is_A_Method());


            //Arrange
            string expectedCommand2 = "endmethod";
            command.Command = form.SplitCommand(expectedCommand2);

            //Act
            command.Is_A_End_Method();

            //Assert
            Assert.IsTrue(command.Is_A_End_Method());
        }

        /// <summary>
        /// Test method to check a invalid end method command.
        /// </summary>
        [TestMethod]
        public void InvalidEndMethod()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            string expectedCommand1 = "endmethod";
            command.Command = form.SplitCommand(expectedCommand1);

            //Act
            command.Is_A_End_Method();

            //Assert
            Assert.IsFalse(command.Is_A_End_Method());
        }

        /// <summary>
        /// Test method to check a valid method call.
        /// </summary>
        [TestMethod]
        public void ValidMethodCall()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            command.IsMultiLine = true;

            //Act - Method Declaration
            string expectedCommands1 = "method createShapes ()";
            command.Command = form.SplitCommand(expectedCommands1);
            command.Is_A_Method();
            command.ValidateCommandName();
            command.ValidateParameters();

            //Assert
            Assert.IsTrue(command.Is_A_Method());


            //Arrange
            string expectedCommand2 = "endmethod";
            command.Command = form.SplitCommand(expectedCommand2);

            //Act - Method declaration ended
            command.Is_A_End_Method();

            //Assert
            Assert.IsTrue(command.Is_A_End_Method());
            

            //Arrange
            string expectedCommand3 = "createShapes ()";
            command.Command = form.SplitCommand(expectedCommand3);

            //Act
            command.Is_Method_Called();

            //Assert
            Assert.IsTrue(command.Is_Method_Called());
        }


        /// <summary>
        /// Test method to check a invalid method call.
        /// </summary>
        [TestMethod]
        public void InvalidMethodCall()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            Form_SPL form = new Form_SPL();
            CommandParser command = new CommandParser(stringErrorMessage, form);
            command.IsMultiLine = true;

            //Act - Method Declaration
            string expectedCommands1 = "method createShapes ()";
            command.Command = form.SplitCommand(expectedCommands1);
            command.Is_A_Method();
            command.ValidateCommandName();
            command.ValidateParameters();

            //Assert
            Assert.IsTrue(command.Is_A_Method());


            //Arrange
            string expectedCommand2 = "endmethod";
            command.Command = form.SplitCommand(expectedCommand2);

            //Act - Method declaration ended
            command.Is_A_End_Method();

            //Assert
            Assert.IsTrue(command.Is_A_End_Method());


            //Arrange
            string expectedCommand3 = "createShapes";
            command.Command = form.SplitCommand(expectedCommand3);

            //Act - Method declaration ended
            command.Is_Method_Called();

            //Assert
            Assert.IsFalse(command.Is_Method_Called());
        }
    }    
}