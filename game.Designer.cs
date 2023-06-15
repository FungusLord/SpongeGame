namespace yoinkySploinky
{
    partial class game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.killsLabel = new System.Windows.Forms.Label();
            this.easyButton = new System.Windows.Forms.Button();
            this.hardButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.gameOver = new System.Windows.Forms.Label();
            this.sadPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.sadPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Spongeboy Me Bob", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(12, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 32);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // killsLabel
            // 
            this.killsLabel.AutoSize = true;
            this.killsLabel.BackColor = System.Drawing.Color.Transparent;
            this.killsLabel.Font = new System.Drawing.Font("Spongeboy Me Bob", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.killsLabel.Location = new System.Drawing.Point(12, 41);
            this.killsLabel.Name = "killsLabel";
            this.killsLabel.Size = new System.Drawing.Size(0, 32);
            this.killsLabel.TabIndex = 1;
            this.killsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // easyButton
            // 
            this.easyButton.BackColor = System.Drawing.Color.Yellow;
            this.easyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.easyButton.Font = new System.Drawing.Font("Spongeboy Me Bob", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyButton.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.easyButton.Location = new System.Drawing.Point(12, 458);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(600, 250);
            this.easyButton.TabIndex = 2;
            this.easyButton.Text = "EASY";
            this.easyButton.UseVisualStyleBackColor = false;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // hardButton
            // 
            this.hardButton.BackColor = System.Drawing.Color.Yellow;
            this.hardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hardButton.Font = new System.Drawing.Font("Spongeboy Me Bob", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardButton.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.hardButton.Location = new System.Drawing.Point(668, 458);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(600, 250);
            this.hardButton.TabIndex = 3;
            this.hardButton.Text = "HARD";
            this.hardButton.UseVisualStyleBackColor = false;
            this.hardButton.Click += new System.EventHandler(this.hardButton_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Spongeboy Me Bob", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.ForestGreen;
            this.title.Location = new System.Drawing.Point(240, 116);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(852, 339);
            this.title.TabIndex = 4;
            this.title.Text = "Gone Jellyfishin\'\r\n\r\n(by Liam Carter)";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameOver
            // 
            this.gameOver.AutoSize = true;
            this.gameOver.BackColor = System.Drawing.Color.Transparent;
            this.gameOver.Enabled = false;
            this.gameOver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameOver.Font = new System.Drawing.Font("Spongeboy Me Bob", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOver.ForeColor = System.Drawing.Color.ForestGreen;
            this.gameOver.Location = new System.Drawing.Point(400, 230);
            this.gameOver.Name = "gameOver";
            this.gameOver.Size = new System.Drawing.Size(491, 225);
            this.gameOver.TabIndex = 5;
            this.gameOver.Text = "Game Over!\r\n\"R\" to Restart\r\n\"Esc\" to Close";
            this.gameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gameOver.Visible = false;
            // 
            // sadPlayer
            // 
            this.sadPlayer.BackColor = System.Drawing.Color.Transparent;
            this.sadPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sadPlayer.Enabled = false;
            this.sadPlayer.Image = global::yoinkySploinky.Properties.Resources.sadSpunchBop;
            this.sadPlayer.Location = new System.Drawing.Point(12, 458);
            this.sadPlayer.Name = "sadPlayer";
            this.sadPlayer.Size = new System.Drawing.Size(1256, 250);
            this.sadPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sadPlayer.TabIndex = 6;
            this.sadPlayer.TabStop = false;
            this.sadPlayer.Visible = false;
            // 
            // game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.sadPlayer);
            this.Controls.Add(this.gameOver);
            this.Controls.Add(this.title);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.easyButton);
            this.Controls.Add(this.killsLabel);
            this.Controls.Add(this.timeLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "game";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.game_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.game_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.game_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.game_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.sadPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label killsLabel;
        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button hardButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label gameOver;
        private System.Windows.Forms.PictureBox sadPlayer;
    }
}

