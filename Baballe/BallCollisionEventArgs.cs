using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baballe
{
    public class BallCollisionEventArgs : EventArgs
    {
        public int ballX { get; set; }
        public int ballY { get; set; }
    }
}
