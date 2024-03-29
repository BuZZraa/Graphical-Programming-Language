﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private int width;
        
        /// <summary>
        /// Variable to store the breadth of the rectangle.
        /// </summary>
        private int height;

        /// <summary>
        /// Parameterized constructor Rectangle which initializes an instance of the class Rectangle with specified parameters. 
        /// The color, fill, x and y parameters are passed to base class Shape constructor.
        /// </summary>
        /// <param name="colour">Colour of the rectangle.</param>
        /// <param name="fill">For rectangle to be filled or not.</param>
        /// <param name="x">X coordinate from where the rectangle will be drawn.</param>
        /// <param name="y">Y coordinate from where the rectangle will be drawn.</param>
        /// <param name="rotationAngle">Angle for rectangle to be rotated.</param>
        /// <param name="width">Width for the length of the rectangle.</param>
        /// <param name="height">Height for the breadth of the rectangle.</param>
        public Rectangle(Color colour, bool fill, int x, int y, float rotationAngle, int width, int height) : base(colour, fill, x, y, rotationAngle)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Abstract method draw inherited from base class to be overriden in derived class Rectangle to draw rectangle on the graphics.
        /// </summary>
        /// <param name="g">Graphics object on which the rectangle will be drawn.</param>
        public override void Draw(Graphics g)
        {
            //To rotate the rectangle shape before being drawn.
            Point center = new Point(x + width / 2, y + height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(rotationAngle);
            g.TranslateTransform(-center.X, -center.Y);

            //If fill is true rectangle is filled and drawn and if false drawn without fill.
            if (fill)
            {
                SolidBrush b = new SolidBrush(colour);
                g.FillRectangle(b, x, y, width, height);
            }

            else
            {
                Pen p = new Pen(colour, penSize);
                g.DrawRectangle(p, x, y, width, height);
            }
            g.ResetTransform();
        }
    }
}

