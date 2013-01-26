using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Baballe
{
    public class Ball : System.Windows.Forms.Control
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; private set; }
        public int height { get; private set; }

        public Ball(int posX, int posY, int sizeX, int sizeY)
        {
            this.x = posX;
            this.y = posY;
            this.width = sizeX;
            this.height = sizeY;
        }

        public void DrawMe(Graphics g)
        {
            Rectangle r = new Rectangle(new Point(this.x, this.y), new Size(new Point(this.width, this.height)));
            g.FillEllipse (new SolidBrush(Color.DarkRed), r);
        }
    }
}
