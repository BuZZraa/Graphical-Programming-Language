using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Abstract class that represents shape that can be drawn on a graphics surface.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Colour variable to store the shape's color.
        /// </summary>
        protected Color colour;

        /// <summary>
        /// X coordinate from where the shape will be drawn.
        /// </summary>
        protected int x;

        /// <summary>
        /// Y coordinate from where the shape will be drawn.
        /// </summary>
        protected int y;

        /// <summary>
        /// Fill variable which sets if the shape will be drawn filled or without fill.
        /// </summary>
        protected Boolean fill;

        /// <summary>
        /// RotationAngle variable to store the angle of shape being rotated.
        /// </summary>
        protected float rotationAngle;

        /// <summary>
        /// PenSize variable to store the current pen size of the shape.
        /// </summary>
        protected int penSize;

        /// <summary>
        /// Parameterized constructor for the class which initializes an instance of the class with specified parameters.
        /// </summary>
        /// <param name="colour">Color of the shape. </param>
        /// <param name="fill">For shape to be filled or not. </param>
        /// <param name="x">X-coordinate for the shape.</param>
        /// <param name="y">Y-coordinate for the shape.</param>
        /// <param name="rotationAngle">Angle for shape to be rotated.</param>
        public Shape(Color colour, bool fill, int x, int y, float rotationAngle)
        {
            this.colour = colour;
            this.fill = fill;
            this.x = x;
            this.y = y;
            this.rotationAngle = rotationAngle;
        }

        /// <summary>
        /// Abstract method draw to be overriden by derived classes to be drawn on graphics according to the shape of the derived class.
        /// </summary>
        /// <param name="g">Graphics object on which the shape will be drawn.</param>
        public abstract void Draw(Graphics g);

        /// <summary>
        /// Getter and setter method to set or get the pen size value.
        /// </summary>
        public int PenSize
        {
            set { penSize = value; }
            get { return penSize; }
        } 
    }
}
