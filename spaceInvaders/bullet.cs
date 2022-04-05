using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Doesn't collide with anything yet, Will shoot from the invader at the player, and the player will be able to shoot the invader.
namespace spaceInvaders
{
    internal class bullet
    {
        public int width = 10;
        public int height = 10;
        public int size = 10;
        public int xSpeed, ySpeed;
        public int x, y;

        public bullet(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
           
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }

        public void Move(Size screenSize)
        {

            y += ySpeed;
            x += xSpeed;


            if (x > screenSize.Width - width || x < 0)
            {
                xSpeed *= -1;
            }


            if (y > screenSize.Height - height || y < 0)
            {
                ySpeed *= -1;

            }
        }
     

            public bool Collision(Player p)
        {
            Rectangle bulletRec = new Rectangle(x, y, size, size);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (bulletRec.IntersectsWith(playerRec))
            {
                return true;
                   
            }

            return false;
        }
    }
}
