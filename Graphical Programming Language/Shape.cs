using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    abstract class Shape
    {

        protected Color colour;
        protected int x, y;
        protected Boolean fill;

        public Shape(Color colour, bool fill, int x, int y)
        {

            this.colour = colour;
            this.fill = fill;
            this.x = x;
            this.y = y;
        }

        public abstract void Draw(Graphics g);
    }
}
