using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceInvaders
{
    internal class bullet
    {
        public int size = 10;
        public int ySpeed;
        public int x, y;

        public bullet(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
           
            ySpeed = _ySpeed;
        }

        public void Move(Size screenSize)
        {
            y -= ySpeed;
            
        }

        public bool Collision(Player p)
        {
            Rectangle bulletRec = new Rectangle(x, y, size, size);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (bulletRec.IntersectsWith(playerRec))
            {
                    Form1.ChangeScreen(this, new GameOver());
                
              
            }

            return false;
        }
    }
}
