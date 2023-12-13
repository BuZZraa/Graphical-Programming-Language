﻿using Graphical_Programming_Language;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommandArray = {"rectangle", "100", "100"};

            //Act
            command.Command = expectedCommandArray;

            //Assert
            Assert.AreEqual(expectedCommandArray, command.Command);
        }

        /// <summary>
        /// Test method to test the command provided being empty.
        /// </summary>
        [TestMethod]
        public void IsEmptyCommandName()
        {
            //Arrange
            CommandParserUnitTest stringErrorMessage = new CommandParserUnitTest();
            CommandParser command = new CommandParser(stringErrorMessage);
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
            CommandParser command = new CommandParser(stringErrorMessage);
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "abcde", "100", "100" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string [] expectedCommand = { "rectangle", "100", "100"};

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "RECTANGLE", "100", "100" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "rectangle", "100", "100" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "rectangle", "seventy", "seventy" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "rectangle" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "rectangle", "-100", "-100"};

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "rectangle", null, null };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "rectangle", "100"};

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "triangle", "50", "50" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "TRIANGLE", "50", "50" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "triangle", "50", "50" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "triangle", "fifty", "fifty" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "triangle" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "triangle", "-50", "-50" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "triangle", null, null };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "triangle", "50" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "circle", "75" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "CIRCLE", "75" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "circle", "75" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "circle", "thirty" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "circle" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "circle", "-75" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "circle", null };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "moveto", "100", "100" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "MOVETO", "100", "100" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "moveto", "100", "100" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "moveto", "fourty", "fourty" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "moveto" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "moveto", "-100", "-100" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "moveto", null, null };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "moveto", "100" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "drawto", "200", "200" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "DRAWTO", "200", "200" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "drawto", "200", "200" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "drawto", "seventy", "seventy" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "drawto" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "drawto", "-200", "-200" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "drawto", null, null };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "drawto", "200" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "clear" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "CLEAR"};

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "clear", "75" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "reset" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "RESET" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "reset", "75" };

            // Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "fill", "on" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "FILL", "ON" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "fill", "on" };

            //Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "fill", "off" };

            //Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "fill", "red" };

            //Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "pen", "red" };

            //Act
            command.Command = expectedCommand;

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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "pen", "red" };

            //Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "pen", "#FF00FF" };

            //Act
            command.Command = expectedCommand;
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
            CommandParser command = new CommandParser(stringErrorMessage);
            string[] expectedCommand = { "PEN", "RED" };

            //Act
            command.Command = expectedCommand;

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
            Assert.IsTrue(command.ValidateParameters());
        }
    }
}