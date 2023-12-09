using Graphical_Programming_Language;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Graphical_Programming_Language_Unit_Test
{
    [TestClass]
    public class Command_ParserUnitTest
    {
        [TestMethod]
        public void IsCommandStoredTest()
        {
            //Arrange 
            string[] expectedCommandArray = {"rectangle", "100", "100"};
            Command_Parser command = new Command_Parser();

            //Act
            command.Command = expectedCommandArray;

            //Assert
            Assert.AreEqual(expectedCommandArray, command.Command);
        }

        [TestMethod]
        public void IsValidCommandName()
        {
            //Arrange
            Command_Parser command = new Command_Parser();
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
            Command_Parser command = new Command_Parser();
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
            Command_Parser command = new Command_Parser();
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
            Command_Parser command = new Command_Parser();
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
            Command_Parser command = new Command_Parser();
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
            Command_Parser command = new Command_Parser();
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
            Command_Parser command = new Command_Parser();
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
            Command_Parser command = new Command_Parser();
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
            Command_Parser command = new Command_Parser();
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
            Command_Parser command = new Command_Parser();
            string[] expectedCommand = { "rectangle", "100"};

            // Act
            command.Command = expectedCommand;
            command.ValidateCommandName();

            // Assert
            Assert.IsFalse(command.ValidateParameters());
        }
    }
}
