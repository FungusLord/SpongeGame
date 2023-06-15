using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yoinkySploinky
{
    public partial class game : Form
    {
        Rectangle player = new Rectangle(640, 360, 60, 75);
        Rectangle killZone = new Rectangle(600, 320, 80 + 60, 80 + 75);
        List<Rectangle> enemies = new List<Rectangle>();
        Image playerImage = Properties.Resources.spunchBop;
        Image enemyImage = Properties.Resources.jellyfish;
        Image attackImage = Properties.Resources.bubbles;
        Random random = new Random();
        double time;
        int enemyLimit;
        int kills;
        int playerSpeed;
        int enemySpeed = 3;
        string playerState = "idle";
        int cooldown;
        int attackDuration;
        int attackCounter = 0;
        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool m1Down = false;
        Brush clearBrush = new SolidBrush(Color.Transparent);
        public game()
        {
            InitializeComponent();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            time++;
            //attack cooldown
            cooldown++;
            changeState();
            if (playerState == "attack")
            {
                attackCounter++;
                if(attackCounter > attackDuration)
                {
                    playerState = "idle";
                    cooldown = 0;
                    attackCounter = 0;
                }
            }
            //spawn 5 enemies max
            if (enemies.Count < enemyLimit)
            {
                spawnEnemies();
            }
            move();
            //kill enemies
            for (int i = 0; i < enemies.Count; i++)
            {
               if (killZone.IntersectsWith(enemies[i]) && playerState == "attack")
                {
                    enemies.RemoveAt(i);
                }
            }
            //update time label
            timeLabel.Text = $"Time: " + Convert.ToString(time / 25);
            //update kills
            killsLabel.Text = $"Kills: " + (kills - enemyLimit);
            //kill player if enemies touch
            for (int i = 0; i < enemies.Count; i++)
            {
                if (player.IntersectsWith(enemies[i]))
                {
                    gameTimer.Stop();
                    gameOver.Enabled = true;
                    gameOver.Visible = true;
                    sadPlayer.Enabled = true;
                    sadPlayer.Visible = true;
                }
            }
            //refresh
            Refresh();
        }
        void changeState()
        {
            if (m1Down == true && cooldown > 50)
            {
                playerState = "attack";
            }
        }
        void move()
        {
            //move player (and kill zone)
            if (wDown == true && player.Y > 0)
            {
                player.Y -= playerSpeed;
                killZone.Y -= playerSpeed;
            }
            if (aDown == true && player.X > 0)
            {
                player.X -= playerSpeed;
                killZone.X -= playerSpeed;
            }
            if (sDown == true && player.Y < this.Height - player.Height)
            {
                player.Y += playerSpeed;
                killZone.Y += playerSpeed;
            }
            if (dDown == true && player.X < this.Width - player.Width)
            {
                player.X += playerSpeed;
                killZone.X += playerSpeed;
            }
            //move enemies
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].X < this.Width + enemies[i].Width)
                {
                    int x = enemies[i].X;
                    if (x - (player.X + player.Width / 2) < 0)
                    {
                        x += enemySpeed;
                        enemies[i] = new Rectangle(x, enemies[i].Y, enemies[i].Width, enemies[i].Height);
                    }
                    else if (x - (player.X + player.Width / 2) > 0)
                    {
                        x -= enemySpeed;
                        enemies[i] = new Rectangle(x, enemies[i].Y, enemies[i].Width, enemies[i].Height);
                    }

                }
                if (enemies[i].Y < this.Height + enemies[i].Height)
                {
                    int y = enemies[i].Y;
                    if (y - (player.Y + player.Height / 2) < 0)
                    {
                        y += enemySpeed;
                        enemies[i] = new Rectangle(enemies[i].X, y, enemies[i].Width, enemies[i].Height);
                    }
                    else if (y - (player.Y + player.Height / 2) > 0)
                    {
                        y -= enemySpeed;
                        enemies[i] = new Rectangle(enemies[i].X, y, enemies[i].Width, enemies[i].Height);
                    }
                }
            }
        }
        void spawnEnemies()
        {
            int randomX;
            int randomY;
            randomX = random.Next(0, this.Width);
            randomY = random.Next(0, this.Height);
            enemies.Add(new Rectangle(randomX, randomY - 250, 50, 50));
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].IntersectsWith(killZone))
                {
                    enemies.RemoveAt(i);
                }
            }
            kills++;
        }
        private void game_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    m1Down = true;
                    break;
            }
        }
        private void game_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    m1Down = false;
                    break;
            }
        }
        private void game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.R:
                    Application.Restart();
                    break;
            }
        }
        private void game_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
            }
        }

        private void game_Paint(object sender, PaintEventArgs e)
        {
            //draw attack image
            if (playerState == "attack")
            {
                e.Graphics.DrawImage(attackImage, killZone);
            }
            else
            {
                e.Graphics.FillRectangle(clearBrush, killZone);
            }
            //draw player
            if (gameTimer.Enabled == true)
            {
                e.Graphics.DrawImage(playerImage, player);
            }
            //draw enemies
            if (gameTimer.Enabled == true)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    e.Graphics.DrawImage(enemyImage, enemies[i]);
                }
            }
        }
        private void easyButton_Click(object sender, EventArgs e)
        {
            easyButton.Enabled = false;
            easyButton.Visible = false;
            hardButton.Enabled = false;
            hardButton.Visible = false;
            title.Enabled = false;
            title.Visible = false;
            enemyLimit = 4;
            playerSpeed = 6;
            cooldown = 30;
            attackDuration = 35;
            gameTimer.Enabled = true;
        }
        private void hardButton_Click(object sender, EventArgs e)
        {
            easyButton.Enabled = false;
            easyButton.Visible = false;
            hardButton.Enabled = false;
            hardButton.Visible = false;
            title.Enabled = false;
            title.Visible = false;
            enemyLimit = 6;
            playerSpeed = 5;
            cooldown = 50;
            attackDuration = 20;
            gameTimer.Enabled = true;
        }
    }
}