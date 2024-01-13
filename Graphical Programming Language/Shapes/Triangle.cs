using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Derived class Triangle which inherits abstract class Shape to represent triangle shape being drawn on graphics.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Variable to store length of the triangle.
        /// </summary>
        int length;

        /// <summary>
        /// Variable to store the height of the triangle.
        /// </summary>
        int height;

        /// <summary>
        /// Parameterized constructor Triangle which initializes an instance of the class Triangle with specified parameters. 
        /// The color, fill, x and y parameters are passed to base class Shape constructor.
        /// </summary>
        /// <param name="colour">Color of the triangle.</param>
        /// <param name="fill">For triangle to be filled or not.</param>
        /// <param name="x">X coordinate from where the triangle will be drawn.</param>
        /// <param name="y">Y coordinate from where the triangle will be drawn.</param>
        /// <param name="rotationAngle">Angle for triangle to be rotated.</param>
        /// <param name="length">Length for the length of the triangle.</param>
        /// <param name="height">Height for the height of the triangle.</param>
        public Triangle(Color colour, bool fill, int x, int y, float rotationAngle, int length, int height) : base(colour, fill, x, y, rotationAngle)
        {
            this.length = length;
            this.height = height;
        }

        /// <summary>
        /// Abstract method draw inherited from base class to be overriden in derived class Triangle to draw triangle on the graphics.
        /// </summary>
        /// <param name="g">Graphics object on which the triangle will be drawn.</param>
        public override void Draw(Graphics g)
        {
            // To rotate the triangle before being drawn.
            Point center = new Point(x, y + height / 2); 
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(rotationAngle);
            g.TranslateTransform(-center.X, -center.Y);

            Point[] vertices =
            {
                new Point(x, y),
                new Point(x + length, y + height),
                new Point(x - length, y + height)
            };

            // If fill is true, triangle is filled and drawn, else it is drawn without fill.
            if (fill)
            {
                SolidBrush b = new SolidBrush(colour);
                g.FillPolygon(b, vertices);
            }
            else
            {
                Pen p = new Pen(colour, penSize);
                g.DrawPolygon(p, vertices);
            }
            g.ResetTransform();
        }
    }
}
