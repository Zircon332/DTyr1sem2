using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class GameWindow : Form
    {
        /// private System.Drawing.Graphics formGraphics;
        private MainButton StartButton;
        private MainButton QuitButton;
        private Size screenSize = new Size(640,480);

        public GameWindow()
        {
            InitializeComponent();
            this.Size = screenSize; 
            
            LoadMainMenu();
        }


        public void LoadMainMenu()
        {
            this.BackColor = Color.Azure;

            StartButton = new MainButton("Start", screenSize, 100, Color.LimeGreen);
            QuitButton = new MainButton("Quit", screenSize, 200, Color.OrangeRed);

            StartButton.Button.Click += new EventHandler(MainMenuButton_Click);
            QuitButton.Button.Click += new EventHandler(MainMenuButton_Click);

            this.Controls.Add(StartButton.Button);
            this.Controls.Add(QuitButton.Button);
        }


        public void MainMenuButton_Click(object sender, System.EventArgs e)
        {
            if (sender == StartButton.Button)
            {
                StartButton.Button.Dispose();
                QuitButton.Button.Dispose();
                LoadGame();
            }
            else if (sender == QuitButton.Button)
            {
                this.Close();
            }
        }


        public void LoadGame()
        {
            int _health = 100;

            // 60 fps timer
            Timer timer = new Timer();
            timer.Interval = 16;
            timer.Start();
            timer.Tick += new EventHandler(GameUpdate);

            Panel TopUI = new Panel
            {
                BackColor = Color.Wheat,
                Size = new Size(screenSize.Width, 30),
                Location = new Point(0,0),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(TopUI);

            TextBox healthText = new TextBox();
            healthText.Text = "Health: " + _health;
            healthText.Enabled = false;
            healthText.BackColor = Color.Red;
            healthText.BorderStyle = BorderStyle.None;
            healthText.Location = new Point(10, 10);
            TopUI.Controls.Add(healthText);

            TextBox pointText = new TextBox();
            pointText.Text = "Points: " + _health;
            pointText.Enabled = false;
            pointText.BackColor = Color.Yellow;
            pointText.Location = new Point(200, 10);
            pointText.BorderStyle = BorderStyle.None;
            TopUI.Controls.Add(pointText);


            Panel BottomUI = new Panel
            {
                BackColor = Color.Wheat,
                Size = new Size(screenSize.Width, 150),
                Location = new Point(0, screenSize.Height - 150),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(BottomUI);


            //formGraphics = this.CreateGraphics();
        }


        private void GameUpdate(object source, EventArgs e)
        {
            
            //TextRenderer.DrawText(formGraphics, "Health", this.Font, new Point(20, 20), Color.Black);
        }


        private void GameWindow_Load(object sender, EventArgs e)
        {
        }
    }
}
