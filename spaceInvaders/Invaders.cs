using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceInvaders
{
    internal class Invaders
    {
        public int width = 50;
        public int height = 20;
        public int xspeed = 2, yspeed = 2;
        public int x, y;

        public Invaders (int _x, int _y, int _xspeed, int _yspeed)
       {
            x = _x;
            y = _y;

            xspeed = _xspeed;
            yspeed = _yspeed;
       }
        public void Move(Size screenSize)
        {
            x += xspeed;
            y += yspeed;

           
            if (x > screenSize.Width - width || x < 0)
            {
                xspeed *= -1;
            }

        
            if (y > screenSize.Height - height || y < 0)
            {
                yspeed *= -1;

            }
        }
    }
}
