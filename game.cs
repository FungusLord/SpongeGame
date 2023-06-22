using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace yoinkySploinky
{
    public partial class game : Form
    {
        //create player hitboxes
        Rectangle player = new Rectangle(640, 360, 60, 75);
        Rectangle killZone = new Rectangle(600, 320, 80 + 60, 80 + 75);
        //create enemy list
        List<Rectangle> enemies = new List<Rectangle>();
        //define images
        Image playerImage = Properties.Resources.spunchBop;
        Image enemyImage = Properties.Resources.jellyfish;
        Image attackImage = Properties.Resources.bubbles;
        //make music
        SoundPlayer chaseMusic = new SoundPlayer(Properties.Resources.chaseMusic);
        SoundPlayer sadMusic = new SoundPlayer(Properties.Resources.sadMusic);
        //make the random generator
        Random random = new Random();
        //declare variables that will change depending on difficulty
        double time;
        int enemyLimit;
        int kills;
        int playerSpeed;
        //this one stays the same between difficulties
        int enemySpeed = 3;
        //default player state
        string playerState = "idle";
        //attack and cooldown variables
        int cooldown;
        int cooldownMax;
        int attackDuration;
        int attackCounter = 0;
        //control booleans
        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool m1Down = false;
        //used to clear bubbles when attack is over
        Brush clearBrush = new SolidBrush(Color.Transparent);
        public game()
        {
            InitializeComponent();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //variable used for ingame timer and attack cooldown
            time++;
            //attack cooldown
            cooldown++;
            //switch between idle and attack
            changeState();
            //check for attacking state
            if (playerState == "attack")
            {
                //start attacking and check attack duration
                attackCounter++;
                if(attackCounter > attackDuration)
                {
                    //stop attacking and start the cooldown again
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
            //move the player, killzone, and enemies
            move();
            //kill enemies when touching killzone and attack is active
            for (int i = 0; i < enemies.Count; i++)
            {
               if (killZone.IntersectsWith(enemies[i]) && playerState == "attack")
                {
                    enemies.RemoveAt(i);
                }
            }
            //update time label (in seconds)
            timeLabel.Text = $"Time: " + Convert.ToString(time / 25);
            //update kills label but offset by number of enemies at beginning
            killsLabel.Text = $"Kills: " + (kills - enemyLimit);
            //kill player if enemies touch
            for (int i = 0; i < enemies.Count; i++)
            {
                if (player.IntersectsWith(enemies[i]))
                {
                    //stop music
                    chaseMusic.Stop();
                    //stop the game
                    gameTimer.Stop();
                    //show game over screen
                    gameOver.Enabled = true;
                    gameOver.Visible = true;
                    sadPlayer.Enabled = true;
                    sadPlayer.Visible = true;
                    //start sad music
                    sadMusic.Play();
                }
            }
            //refresh
            Refresh();
        }
        void changeState()
        {
            //click makes player attack as long as cooldown is over
            if (m1Down == true && cooldown > cooldownMax)
            {
                playerState = "attack";
            }
        }
        void move()
        {
            //move player (and kill zone)
            if (wDown == true && player.Y > 0)
            {
                //up
                player.Y -= playerSpeed;
                killZone.Y -= playerSpeed;
            }
            if (aDown == true && player.X > 0)
            {
                //left
                player.X -= playerSpeed;
                killZone.X -= playerSpeed;
            }
            if (sDown == true && player.Y < this.Height - player.Height)
            {
                //down
                player.Y += playerSpeed;
                killZone.Y += playerSpeed;
            }
            if (dDown == true && player.X < this.Width - player.Width)
            {
                //right
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
                        //right
                        x += enemySpeed;
                        enemies[i] = new Rectangle(x, enemies[i].Y, enemies[i].Width, enemies[i].Height);
                    }
                    else if (x - (player.X + player.Width / 2) > 0)
                    {
                        //left
                        x -= enemySpeed;
                        enemies[i] = new Rectangle(x, enemies[i].Y, enemies[i].Width, enemies[i].Height);
                    }

                }
                if (enemies[i].Y < this.Height + enemies[i].Height)
                {
                    int y = enemies[i].Y;
                    if (y - (player.Y + player.Height / 2) < 0)
                    {
                        //down
                        y += enemySpeed;
                        enemies[i] = new Rectangle(enemies[i].X, y, enemies[i].Width, enemies[i].Height);
                    }
                    else if (y - (player.Y + player.Height / 2) > 0)
                    {
                        //up
                        y -= enemySpeed;
                        enemies[i] = new Rectangle(enemies[i].X, y, enemies[i].Width, enemies[i].Height);
                    }
                }
            }
        }
        void spawnEnemies()
        {
            //spawn enemies at random places on screen
            int randomX;
            int randomY;
            randomX = random.Next(0, this.Width);
            randomY = random.Next(0, this.Height);
            enemies.Add(new Rectangle(randomX, randomY - 250, 50, 50));
            for (int i = 0; i < enemies.Count; i++)
            {
                //make sure enemies don't spawn too close to player
                if (enemies[i].IntersectsWith(killZone))
                {
                    enemies.RemoveAt(i);
                }
            }
            //increase kills whenever an enemy has to respawn
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
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.A:
                    aDown = true;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.S:
                    sDown = true;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.D:
                    dDown = true;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
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
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.A:
                    aDown = false;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.S:
                    sDown = false;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.D:
                    dDown = false;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
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
            //get rid of buttons and title
            easyButton.Enabled = false;
            easyButton.Visible = false;
            hardButton.Enabled = false;
            hardButton.Visible = false;
            title.Enabled = false;
            title.Visible = false;
            //set variables to make game easier
            enemyLimit = 4;
            playerSpeed = 6;
            cooldownMax = 30;
            attackDuration = 35;
            //start game
            gameTimer.Enabled = true;
            //start music
            chaseMusic.Play();
        }
        private void hardButton_Click(object sender, EventArgs e)
        {
            //get rid of buttons and title
            easyButton.Enabled = false;
            easyButton.Visible = false;
            hardButton.Enabled = false;
            hardButton.Visible = false;
            title.Enabled = false;
            title.Visible = false;
            //set variables to make game harder
            enemyLimit = 6;
            playerSpeed = 5;
            cooldownMax = 50;
            attackDuration = 20;
            //start game
            gameTimer.Enabled = true;
            //start music
            chaseMusic.Play();
        }
    }
}