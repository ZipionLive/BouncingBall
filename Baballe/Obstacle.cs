using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Baballe
{
    public class Obstacle : System.Windows.Forms.Control
    {
        public enum BorderTypes
        {
            top = 1,
            right = 2,
            bottom = 3,
            left = 4
        }

        public const int thickness = 5;

        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public BorderTypes border { get; set; }        

        public Obstacle(BorderTypes border)
        {
            this.border = border;
        }

        public void DrawMe(int posX, int posY, int size, Graphics g)
        {
            getMeasures(posX, posY, size);
            g.FillRectangle(new SolidBrush(Color.DarkGray), this.x, this.y, this.width, this.height);
        }

        private void getMeasures(int posX, int posY, int size)
        {
            switch (border)
            {
                case BorderTypes.top:
                    this.x = posX;
                    this.y = posY;
                    this.width = size;
                    this.height = thickness;
                    break;
                case BorderTypes.bottom:
                    this.x = posX;
                    this.y = posY - thickness-39;
                    this.width = size;
                    this.height = thickness;
                    break;
                case BorderTypes.left:
                    this.x = posX;
                    this.y = posY;
                    this.width = thickness;
                    this.height = size;
                    break;
                case BorderTypes.right:
                    this.x = posX - thickness-16;
                    this.y = posY;
                    this.width = thickness;
                    this.height = size;
                    break;
            }
        }
    }
}
