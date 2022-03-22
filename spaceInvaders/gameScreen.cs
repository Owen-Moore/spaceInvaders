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
        Player player;
        Invaders invaders;
        Size screenSize;
        Random randGen = new Random();

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


            int x = randGen.Next(40, screenSize.Width - 40);
            int y = randGen.Next(40, screenSize.Height - 40);
            player = new Player(x, y);
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
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (leftArrowDown == true)
            {
                player.Move("left", screenSize);
            }

            if (rightArrowDown == true)
            {
                player.Move("right", screenSize);
            }
            Refresh();
        }
        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, player.x, player.y, player.width, player.height);
        }
    }
}
