using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceInvaders
{
    internal class Player
    {
        public int width = 20;
        public int height = 8;
        public int speed = 5;
        public int x, y;

        public Player(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void Move(string direction, Size ss)
        {
            if (direction == "left")
            {
                x -= speed;

                if (x < 0)
                {
                    x = 0;
                }
            }

            if (direction == "right")
            {
                x += speed;

                if (x > ss.Width - width)
                {
                    x = ss.Width - width;
                }
            }
            if (direction == "up" == true)
            {
                y -= speed;

                if (y < 0)
                {
                    y = 0;
                }
            }

            if (direction == "down")
            {
                y += speed;

                if (y > ss.Height - height)
                {
                    y = ss.Height - height;
                }
            }
        }

     }
}
