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
    /// Derived class Rectangle which inherits abstract class Shape to represent rectangle shape being drawn on graphics.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Variable to store the length of the rectangle.
        /// </summary>
        int width;
        
        /// <summary>
        /// Variable to store the breadth of the rectangle.
        /// </summary>
        int height;

        /// <summary>
        /// Parameterized constructor Rectangle which initializes an instance of the class circle with specified parameters. 
        /// The color, fill, and x, y coodinates are passed to base class Shape constructor.
        /// </summary>
        /// <param name="colour">Colour of the rectangle.</param>
        /// <param name="fill">For rectangle to be filled or not.</param>
        /// <param name="x">X coordinate from where the rectangle will be drawn.</param>
        /// <param name="y">X coordinate from where the rectangle will be drawn.</param>
        /// <param name="width">Width for the length of the rectangle.</param>
        /// <param name="height">Height for the breadth of the rectangle.</param>
        public Rectangle(Color colour, bool fill, int x, int y, int width, int height) : base(colour, fill, x, y)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Abstract method draw inherited from base class to be overriden in derived class rectangle to draw rectangle on the graphics.
        /// </summary>
        /// <param name="g">Instance of graphics class on which the rectangle will be drawn.</param>
        public override void Draw(Graphics g)
        {
            if (fill)
            {
                SolidBrush b = new SolidBrush(colour);
                g.FillRectangle(b, x, y, width, height);
            }

            else
            {
                Pen p = new Pen(colour, 1);
                g.DrawRectangle(p, x, y, width, height);
            }
        }
    }
}

