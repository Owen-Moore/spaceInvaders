using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spaceInvaders
{
    public partial class gameScreen : UserControl
    {
        int x = 20;
        int y = 30;
        int xspeed = 2;
        int yspeed = 0;

        int invadershot = 20;
       
        Player player;
       
        Size screenSize;
        Random randGen = new Random();
        List<Invaders> invaders = new List<Invaders>();
        List<bullet>  bullets = new List<bullet>();

        public static bool upArrowDown = false;
        public static bool downArrowDown = false;
        public static bool leftArrowDown = false;
        public static bool rightArrowDown = false;
        public gameScreen()
        {
            InitializeComponent();
            InitializegameScreen();
        }
        public void InitializegameScreen()
        {
            screenSize = new Size(this.Width, this.Height);


            int x = this.Width / 2;
            int y = this.Height - 50;
            player = new Player(x, y);

            Invader();
            Bullet();
        }

        public void Invader()
        {
         
          if (invaders.Count() < 1)
            {
               Invaders i = new Invaders(x, y, xspeed, yspeed);
               invaders.Add(i);
            }
            
            
        }
        
        public void Bullet()
        {
            int bx = x; 
            int by = y;
            int bxspeed = 0;
            int byspeed = 10;

            if (invadershot == 10)
            {
                bullet b = new bullet(bx, by, bxspeed, byspeed);
                bullets.Add(b);
            }
        }

        private void gameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;

            }

        }

        private void gameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            invadershot --;

            if (leftArrowDown == true)
            {
                player.Move("left", screenSize);
            }

            if (rightArrowDown == true)
            {
                player.Move("right", screenSize);
            }

            if (upArrowDown == true)
            {
                player.Move("up", screenSize);
            }

            if (downArrowDown == true)
            {
                player.Move("down", screenSize);
            }
            foreach (Invaders i in invaders)
            {
                i.Move(screenSize);
            }
            foreach (bullet b in bullets)
            {
                b.Move(screenSize);
               
            }
            Refresh();
        }
        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, player.x, player.y, player.width, player.height);

            foreach (Invaders i in invaders)
            {
                    e.Graphics.FillRectangle(Brushes.Red, i.x, i.y, i.width, i.height);
            }
            foreach (bullet b in bullets)
            {
                e.Graphics.FillRectangle(Brushes.Red, b.x, b.y, b.size, b.size);
            }
        }
    }
}
