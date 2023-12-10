using Graphical_Programming_Language;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace Graphical_Programming_Language_Unit_Test
{
    [TestClass]
    public class Command_ParserUnitTest : IMessageDisplayer
    {
        public string _displayedMessage;
        public string DisplayedMessage
        {
            get { return _displayedMessage;  }
        }
        public void DisplayMessage(string message)
        {
            _displayedMessage = message;
        }

        [TestMethod]
        public void IsCommandStoredTest()
        {
            //Arrange 
            Command_ParserUnitTest stringErrorMessage = new Command_ParserUnitTest();
            Command_Parser command = new Command_Parser(stringErrorMessage);
            string[] expectedCommandArray = {"rectangle", "100", "100"};

            //Act
            command.Command = expectedCommandArray;

            //Assert
            Assert.AreEqual(expectedCommandArray, command.Command);
        }

        [TestMethod]
        public void IsValidCommandName()
        {
            //Arrange
            Command_ParserUnitTest stringErrorMessage = new Command_ParserUnitTest();
            Command_Parser command = new Command_Parser(stringErrorMessage);
            string [] expectedCommand = { "rectangle", "100", "100"};

            //Act
            command.Command = expectedCommand;

            //Assert
            Assert.IsTrue(command.ValidateCommandName());
        }

        [TestMethod]
        public void IsInvalidCommandName()
        {
            //Arrange
            Command_ParserUnitTest stringErrorMessage = new Command_ParserUnitTest();
            Command_Parser command = new Command_Parser(stringErrorMessage);
            string[] expectedCommand = { "abcde", "100", "100" };

            //Act
            command.Command = expectedCommand;

            //Assert
            Assert.IsFalse(command.ValidateCommandName());
        }

        [TestMethod]
        public void IsEmptyCommand()
        {
            //Arrange
            Command_ParserUnitTest stringErrorMessage = new Command_ParserUnitTest();
            Command_Parser command = new Command_Parser(stringErrorMessage);
            string[] expectedCommand = {};

            //Act
            command.Command = expectedCommand;

            //Assert
            Assert.IsFalse(command.ValidateCommandName());
        }

        [TestMethod]
        public void IsNullCommand()
        {
            //Arrange
            Command_ParserUnitTest stringErrorMessage = new Command_ParserUnitTest();
            Command_Parser command = new Command_Parser(stringErrorMessage);
            string[] expectedCommand = { null };

            //Act
            command.Command = expectedCommand;

            //Assert
            Assert.IsFalse(command.ValidateCommandName());
        }

        [TestMethod]
        public void IsValidParameters()
        {
            //Arrange
            Command_ParserUnitTest stringErrorMessage = new Command_ParserUnitTest();
            Command_Parser command = new Command_Parser(stringErrorMessage);
            string[] expectedCommand = { "rectangle", "100", "100" };

            // Act
            command.Command = expectedCommand;
            command.ValidateCommandName();

            // Assert
            Assert.IsTrue(command.ValidateParameters());
        }

        [TestMethod]
        public void IsInvalidParameters()
        {
            //Arrange
            Command_ParserUnitTest stringErrorMessage = new Command_ParserUnitTest();
            Command_Parser command = new Command_Parser(stringErrorMessage);
            string[] expectedCommand = { "rectangle", "fifty", "fifty" };

            // Act
            command.Command = expectedCommand;
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        [TestMethod]
        public void IsEmptyParameters()
        {
            //Arrange
            Command_ParserUnitTest stringErrorMessage = new Command_ParserUnitTest();
            Command_Parser command = new Command_Parser(stringErrorMessage);
            string[] expectedCommand = { "rectangle" };

            // Act
            command.Command = expectedCommand;
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        [TestMethod]
        public void IsNegativeParameters()
        {
            //Arrange
            Command_ParserUnitTest stringErrorMessage = new Command_ParserUnitTest();
            Command_Parser command = new Command_Parser(stringErrorMessage);
            string[] expectedCommand = { "rectangle", "-100", "-100"};

            // Act
            command.Command = expectedCommand;
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }
        [TestMethod]
        public void IsNullParameters()
        {
            //Arrange
            Command_ParserUnitTest stringErrorMessage = new Command_ParserUnitTest();
            Command_Parser command = new Command_Parser(stringErrorMessage);
            string[] expectedCommand = { "rectangle", null, null };

            // Act
            command.Command = expectedCommand;
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }

        [TestMethod]
        public void IsMissingParameter()
        {
            //Arrange
            Command_ParserUnitTest stringErrorMessage = new Command_ParserUnitTest();
            Command_Parser command = new Command_Parser(stringErrorMessage);
            string[] expectedCommand = { "rectangle", "100"};

            // Act
            command.Command = expectedCommand;
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }     
    }
}
