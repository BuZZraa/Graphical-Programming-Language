using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Derived class Line which inherits abstract class Shape to represent a straight line being drawn on graphics.
    /// </summary>
    public class Line : Shape
    {
        /// <summary>
        /// Variable to store the X-coodinate of ending point of the line.
        /// </summary>
        private int endingPointX;

        /// <summary>
        /// Variable to store the Y-coodinate of ending point of the line.
        /// </summary>
        private int endingPointY;

        /// <summary>
        /// Parameterized constructor line which initializes an instance of the class Line with specified parameters. 
        /// The color, fill, x and y parameters are passed to base class Shape constructor.
        /// </summary>
        /// <param name="colour">Colour of the line.</param>
        /// <param name="fill">Fill not used but inherited from abstract class shape.</param>
        /// <param name="x">X coordinate from where the line will be drawn.</param>
        /// <param name="y">Y coordinate from where the line will be drawn.</param>
        /// <param name="rotationAngle">Angle for line to be rotated.</param>
        /// <param name="endingPointX">X-coodinate of ending point of the line.</param>
        /// <param name="endingPointY">Y-coodinate of ending point of the line.</param>
        public Line(Color colour, bool fill, int x, int y, float rotationAngle, int endingPointX, int endingPointY) : base(colour, fill, x, y, rotationAngle)
        {
            this.endingPointX = endingPointX;
            this.endingPointY = endingPointY;
        }

        /// <summary>
        /// Abstract method draw inherited from base class to be overriden in derived class Line to draw a line on the graphics.
        /// </summary>
        /// <param name="g">Graphics object on which the line will be drawn.</param>
        public override void Draw(Graphics g)
        {
            Pen p = new Pen(colour, penSize);
            g.DrawLine(p, x, y, endingPointX, endingPointY);
        }
    }
}
