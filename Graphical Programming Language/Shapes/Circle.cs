﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Derived class Circle which inherits abstract class Shape to represent circle shape being drawn on graphics.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Variable to store the radius of the circle.
        /// </summary>
        private int radius;

        /// <summary>
        /// Parameterized constructor Circle which initializes an instance of the class Circle with specified parameters. 
        /// The color, fill, x and y parameters are passed to base class Shape constructor.
        /// </summary>
        /// <param name="colour">Colour of the circle.</param>
        /// <param name="fill">For circle to be filled or not.</param>
        /// <param name="x">X coordinate from where the circle will be drawn.</param>
        /// <param name="y">Y coordinate from where the circle will be drawn.</param>
        /// <param name="rotationAngle">Angle for circle to be rotated not used but inherited from abstract class shape.</param>
        /// <param name="radius">Angle for circle to be rotated.</param>
        public Circle(Color colour, bool fill, int x, int y, float rotationAngle, int radius) : base(colour, fill, x, y, rotationAngle)
        {
            this.radius = radius;
        }

        /// <summary>
        /// Abstract method draw inherited from base class to be overriden in derived class Circle to draw circle on the graphics.
        /// </summary>
        /// <param name="g">Graphics object on which the circle will be drawn.</param>
        public override void Draw(Graphics g)
        {
            //If fill is true circle is filled and drawn and if false drawn without fill.
            if (fill)
            {
                SolidBrush b = new SolidBrush(colour);
                g.FillEllipse(b, x, y, radius * 2, radius * 2);
            }

            else
            {
                Pen p = new Pen(colour, penSize);
                g.DrawEllipse(p, x, y, radius * 2, radius * 2);
            }
        }
    }
}
