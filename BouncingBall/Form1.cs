using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Baballe;

namespace BouncingBall
{
    public partial class Form1 : Form
    {
        Task tMoveBall;
        Task tCheckCollision;
        delegate void DelRefreshDisplay();
        DelRefreshDisplay refreshDisplay; 
        Ball b = new Ball(10, 10, 30, 30);
        List<Obstacle> ObsFrame = new List<Obstacle>();
        Obstacle obsTop = new Obstacle(Obstacle.BorderTypes.top);
        Obstacle obsRight = new Obstacle(Obstacle.BorderTypes.right);
        Obstacle obsBottom = new Obstacle(Obstacle.BorderTypes.bottom);
        Obstacle obsLeft = new Obstacle(Obstacle.BorderTypes.left);

        int speedX = 5;
        int speedY = 2;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            refreshDisplay = new DelRefreshDisplay(fnRefresh);
            tMoveBall = new Task(() => MoveBall(speedX, speedY));
            ObsFrame.Add(obsTop);
            ObsFrame.Add(obsRight);
            ObsFrame.Add(obsBottom);
            ObsFrame.Add(obsRight);
            tCheckCollision = new Task(() => CheckCollision(b, ObsFrame));
            tMoveBall.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            b.DrawMe(e.Graphics);
            b.Location = new Point(b.x, b.y);
            DrawObsFrame(e.Graphics);
            base.OnPaint(e);
        }

        private void DrawObsFrame(Graphics g)
        {
            obsTop.DrawMe(0, 0, this.Width, g);
            obsRight.DrawMe(this.Width, 0, this.Height, g);
            obsBottom.DrawMe(0, this.Height, this.Width, g);
            obsLeft.DrawMe(0, 0, this.Height, g);
        }

        private void MoveBall(int speedX, int speedY)
        {
            while (true)
            {
                b.x += speedX;
                b.y += speedY;

                if (InvokeRequired)
                {
                    Invoke(refreshDisplay);
                    tMoveBall.Wait(50);
                }
            }
        }

        private void CheckCollision(Ball b, List<Obstacle> ObsFrame)
        {
            while (true)
            {

            }
        }

        private void fnRefresh()
        {
            b.Location = new Point(b.x, b.y);
            this.Refresh();
        }
    }
}
