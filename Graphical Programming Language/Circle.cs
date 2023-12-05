using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    internal class Circle : Shape
    {
        private int radius;

        public Circle(Color colour, bool fill, int x, int y, int radius) : base(colour, fill, x, y)
        {
            this.radius = radius;
        }


        public override void Draw(Graphics g)
        {
            if (fill)
            {
                SolidBrush b = new SolidBrush(colour);
                g.FillEllipse(b, x, y, radius * 2, radius * 2);
            }

            else
            {
                Pen p = new Pen(colour, 1);
                g.DrawEllipse(p, x, y, radius * 2, radius * 2);
            }
        }
    }
}
