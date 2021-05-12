using CR.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CR
{
    public partial class frmPlay : Form
    {
        #region Properties
        private int speed;
        private int count;
        private int time;
        private int second;
        private int minute;
        private bool start;
        private bool pause;
        private bool end;
        private bool isAccelerating;        
        private RoadLines roadLines;
        private OurCar ourCar;
        private EnemyCars enemyCars;
        private GoldCoins goldCoins;
        private string playerName;

        public int Speed { get => speed; set => speed = value; }
        public int Time { get => time; set => time = value; }
        public int Count { get => count; set => count = value; }
        public int Second { get => second; set => second = value; }
        public int Minute { get => minute; set => minute = value; }
        public bool Start { get => start; set => start = value; }
        public bool Pause { get => pause; set => pause = value; }
        public bool End { get => end; set => end = value; }
        public bool IsAccelerating { get => isAccelerating; set => isAccelerating = value; }        
        public RoadLines RoadLines { get => roadLines; set => roadLines = value; }
        public OurCar OurCar { get => ourCar; set => ourCar = value; }
        public EnemyCars EnemyCars { get => enemyCars; set => enemyCars = value; }
        public GoldCoins GoldCoins { get => goldCoins; set => goldCoins = value; }
        public string PlayerName { get => playerName; set => playerName = value; }
        #endregion

        #region Constructor
        public frmPlay()
        {
            InitializeComponent();
            newGame();
        }
        #endregion

        #region Methods
        private void addItems()
        {
            for (int i = 0; i < 4; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.BackColor = Color.DimGray;
                pictureBox.Image = Properties.Resources.enemy_car;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Size = new Size(50, 90);
                pictureBox.Location = EnemyCars.locateCar();
                Controls.Add(pictureBox);
                EnemyCars.Cars.Add(pictureBox);
            }
            GoldCoins.Cars = EnemyCars.Cars;

            for (int i = 0; i < 4; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.BackColor = Color.DimGray;
                pictureBox.Image = Properties.Resources.coin;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Size = new Size(30, 30);
                pictureBox.Location = GoldCoins.locateCoin();
                Controls.Add(pictureBox);
                GoldCoins.Coins.Add(pictureBox);
            }
            EnemyCars.Coins = GoldCoins.Coins;

            int y = 0;
            for (int i = 0; i < 4; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.BackColor = Color.White;
                pictureBox.Size = new Size(10, 120);
                pictureBox.Location = new Point(220, y);
                Controls.Add(pictureBox);
                RoadLines.Lines.Add(pictureBox);
                y += 165;
            }              
        }

        private void removeItems()
        {
            for (int i = 0; i < 4; i++)
                Controls.Remove(RoadLines.Lines[i]);
            for (int i = 0; i < 4; i++)
                Controls.Remove(GoldCoins.Coins[i]);
            for (int i = 0; i < 4; i++)
                Controls.Remove(EnemyCars.Cars[i]);
        }

        private void countDown()
        {
            if (Time % 60 == 0)
            {
                Count--;
                if (Count > 0)
                {
                    lblCountDown.Text = Count.ToString();
                    lblCountDown.Location = new Point(205, 135);
                }
                else if (Count == 0)
                {
                    lblCountDown.Text = "Go!";
                    lblCountDown.Location = new Point(185, 135);                    
                }
                else
                {
                    Start = true;
                    Time = 0;
                    lblCountDown.Visible = false;
                }
            }
        }

        private void showTime()
        {            
            if (Minute == 60)
                return;
            if (Time % 60 == 0)
            {
                Second++;
                if (Second == 60)
                {
                    Second = 0;
                    Minute++;
                }
            }
            lblTime.Text = "";
            if (Minute < 10)
                lblTime.Text += "0" + Minute.ToString() + ":";
            else
                lblTime.Text += Minute.ToString() + ":";
            if (Second < 10)
                lblTime.Text += "0" + Second.ToString();
            else
                lblTime.Text += Second.ToString();
            if (Minute == 60)
                lblTime.Text += "+";
        }

        private void newGame()
        {
            Speed = 2;
            Count = 4;
            Time = 0;
            Second = 0;
            Minute = 0;
            Start = false;
            Pause = false;
            End = false;
            IsAccelerating = false;

            btnPlayAgain.Visible = false;
            btnPlayAgain.Enabled = false;
            btnNext.Visible = false;
            btnNext.Enabled = false;           

            lblGameOver.Visible = false;
            lblPause.Visible = false;
            lblCountDown.Visible = true;
            timer.Enabled = true;

            lblCoins.Text = "0";
            lblTime.Text = "00:00";
            lblCountDown.Text = "Ready!";

            lblCountDown.Location = new Point(155, 135);

            OurCar = new OurCar(ptbCar, speed);
            RoadLines = new RoadLines();
            GoldCoins = new GoldCoins();
            EnemyCars = new EnemyCars();
            
            addItems();
        }

        private void endGame()
        {
            if (OurCar.crash(EnemyCars))
            {
                lblGameOver.Visible = true;
                Start = false;
                End = true;
            }
        }
        #endregion

        #region Events
        private void timer_Tick(object sender, EventArgs e)
        {            
            if (!Start)
            {
                if (!End)
                {
                    Time++;
                    countDown();
                }
                else
                {
                    Count++;
                    if (Count == 120)
                    {
                        btnPlayAgain.Visible = true;
                        btnPlayAgain.Enabled = true;
                        btnNext.Visible = true;
                        btnNext.Enabled = true;
                        timer.Enabled = false;
                    }
                }
            }
            else
            {
                if (Pause)
                {
                    Count++;
                    if (Count % 45 == 0)
                        lblPause.Visible = !lblPause.Visible;
                }
                else
                {
                    Time++;
                    RoadLines.moveLine(speed);
                    EnemyCars.moveEnemyCar(speed);
                    GoldCoins.moveCoin(speed);
                    OurCar.collectCoins(GoldCoins, lblCoins);
                    showTime();
                    endGame();
                }
            }
        }
        
        private void frmPlay_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Start)
                return;
            if (e.KeyCode == Keys.Up)
            {
                IsAccelerating = true;
                OurCar.accelarate();
                Speed = OurCar.CurrentSpeed;
            }
            else if (e.KeyCode == Keys.Space)
            {
                Count = 0;
                if (Pause)
                {                    
                    Pause = false;
                    lblPause.Visible = false;
                }
                else
                {                    
                    Pause = true;
                    lblPause.Visible = true;                    
                }
            }
            else
            {
                if (!Pause)
                    OurCar.moveCar(e);
            }
        }

        private void FrmPlay_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsAccelerating)
            {
                IsAccelerating = false;
                OurCar.brake();
                Speed = OurCar.CurrentSpeed;
            }
        }

        private void BtnPlayAgain_Click(object sender, EventArgs e)
        {
            removeItems();
            newGame();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            frmScore frmScore = new frmScore();
            frmScore.Coins = lblCoins.Text;
            frmScore.Time = lblTime.Text;
            frmScore.PlayerName = PlayerName;
            frmScore.ShowDialog();
        }
        #endregion
    }
}
