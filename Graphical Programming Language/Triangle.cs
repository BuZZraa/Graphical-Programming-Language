using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    public class Triangle : Shape
    {
        int length, height;

        public Triangle(Color colour, bool fill, int x, int y, int length, int height) : base(colour, fill, x, y)
        {
            this.length = length;
            this.height = height;
        }

        public override void Draw(Graphics g)
        {
            Point[] vertices =
            {
                new Point(x, y),
                new Point(x + length, y + height),
                new Point(x - length, y + height)
            };

            if (fill)
            {
                SolidBrush b = new SolidBrush(colour);
                g.FillPolygon(b, vertices);
            }

            else
            {
                Pen p = new Pen(colour, 1);
                g.DrawPolygon(p, vertices);
            }
        }
    }
}
