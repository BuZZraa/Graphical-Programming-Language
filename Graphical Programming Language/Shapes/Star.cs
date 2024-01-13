using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    /// <summary>
    /// Derived class Star which inherits abstract class Shape to represent star shape being drawn on graphics.
    /// </summary>
    public class Star : Shape
    {
        /// <summary>
        /// Variable to store the size of the star.
        /// </summary>
        private int size;

        /// <summary>
        /// Parameterized constructor Star which initializes an instance of the class Star with specified parameters. 
        /// The color, fill, x and y parameters are passed to base class Shape constructor.
        /// </summary>
        /// <param name="colour">Colour of the star.</param>
        /// <param name="fill">For star to be filled or not.</param>
        /// <param name="x">X coordinate from where the star will be drawn.</param>
        /// <param name="y">Y coordinate from where the star will be drawn.</param>
        /// <param name="rotationAngle">Angle for star to be rotated.</param>
        /// <param name="size">Angle for star to be rotated.</param>
        public Star(Color colour, bool fill, int x, int y, float rotationAngle, int size)
            : base(colour, fill, x, y, rotationAngle)
        {
            this.size = size;
        }

        /// <summary>
        /// Abstract method draw inherited from base class to be overriden in derived class Star to draw star on the graphics.
        /// </summary>
        /// <param name="g">Graphics object on which the star will be drawn.</param>
        public override void Draw(Graphics g)
        {
            Point[] points = new Point[10];
            double angleBetweenPoint = Math.PI / 5;
            double startingAngle = -Math.PI / 2;

            for (int i = 0; i < 10; i++)
            {
                double pointFactor;
                if (i % 2 == 0)
                {
                    pointFactor = 1;
                }
                else
                {
                    pointFactor = 0.5;
                }

                points[i] = new Point((int)(size * pointFactor * Math.Cos(startingAngle + i * angleBetweenPoint) + x), (int)(size * pointFactor * Math.Sin(startingAngle + i * angleBetweenPoint) + y));
            }


            g.TranslateTransform(x, y);
            g.RotateTransform(rotationAngle);
            g.TranslateTransform(-x, -y);

            //If fill is true star is filled and drawn and if false drawn without fill.
            if (fill)
            {
                SolidBrush b = new SolidBrush(colour);
                g.FillPolygon(b, points);
            }
            else
            {
                Pen p = new Pen(colour, penSize);
                g.DrawPolygon(p, points);
            }

            g.ResetTransform();
        }
    }
}
