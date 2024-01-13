using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Shape factory class for creating instances of Shape class according to the shape name.
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// Shape method which creates instance of a Shape according to the shape name.
        /// </summary>
        /// <param name="shape">Type of shape to be created.</param>
        /// <param name="color">Color of shape.</param>
        /// <param name="fill">For shape to be filled or not.</param>
        /// <param name="xPos">X coordinate from where the shape will be drawn.</param>
        /// <param name="yPos">Y coordinate from where the shape will be drawn.</param>
        /// <param name="rotationAngle">Angle for shape to be rotated.</param>
        /// <param name="commandValues">List of integer values of the shape.</param>
        /// <returns>Returns the instance of shape.</returns>
        public Shape ShapeType(string shape, Color color, bool fill, int xPos, int yPos, float rotationAngle, List<int> commandValues)
        {
            switch (shape.ToLower())
            {

                case "rectangle":
                    return new Rectangle(color, fill, xPos, yPos, rotationAngle, commandValues[0], commandValues[1]);

                case "circle":
                    return new Circle(color, fill, xPos, yPos, rotationAngle, commandValues[0]);

                case "triangle":
                    return new Triangle(color, fill, xPos + commandValues[0], yPos, rotationAngle, commandValues[0], commandValues[1]);

                case "drawto":
                    return new Line(color, fill, xPos, yPos, rotationAngle, commandValues[0], commandValues[1]);

                case "star":
                    return new Star(color, fill, xPos + commandValues[0], yPos + commandValues[0], rotationAngle, commandValues[0]);

                default:
                    throw new ArgumentException($"Please enter a valid command instead of {shape}");
            }
        }
    }
}
