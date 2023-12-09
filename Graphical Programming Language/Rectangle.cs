using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    public class Rectangle : Shape
    {
        int width, height;

        public Rectangle(Color colour, bool fill, int x, int y, int width, int height) : base(colour, fill, x, y)
        {
            this.width = width;
            this.height = height;
        }


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

