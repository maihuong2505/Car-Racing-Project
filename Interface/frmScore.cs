using CR.BS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CR.Interface
{
    public partial class frmScore : Form
    {
        private DataTable dataTableScore = null;
        private BLScore playerScore = new BLScore();
        private string coins;
        private string time;
        private string playerName;

        public DataTable DataTableScore { get => dataTableScore; set => dataTableScore = value; }
        public BLScore PlayerScore { get => playerScore; set => playerScore = value; }
        public string Coins { get => coins; set => coins = value; }
        public string Time { get => time; set => time = value; }
        public string PlayerName { get => playerName; set => playerName = value; }

        public frmScore()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            try
            {
                DataTableScore = new DataTable();
                DataTableScore.Clear();
                
                DataSet dataSet = PlayerScore.getPlayerScore();

                DataTableScore = dataSet.Tables[0];
                dgvScore.DataSource = DataTableScore;
            }
            catch (SqlException)
            {
                MessageBox.Show("Can't get information from the PlayerScore table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int getTime()
        {
            int minute = Int32.Parse(Time.Substring(0, 2));
            int second = Int32.Parse(Time.Substring(3, 2));
            return 60 * minute + second;
        }

        private void updateTable()
        {
            int n;
            bool canExecute = PlayerScore.getPlayerName(PlayerName, out n);

            if (canExecute)
            {
                if (n > 0)
                    PlayerScore.updatePlayerScore(PlayerName, Int32.Parse(Coins), Time, getTime());
                else
                    PlayerScore.insertPlayerScore(PlayerName, Int32.Parse(Coins), Time, getTime());
            }
            else
                MessageBox.Show("Error occurred!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool isHighScore()
        {
            string name;
            bool canExecute = PlayerScore.getTopOnePlayer(out name);

            if (canExecute)
                return PlayerName == name;

            MessageBox.Show("Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void FrmScore_Load(object sender, EventArgs e)
        {
            lblCoins.Text = Coins;
            lblTime.Text = Time;

            updateTable();
            loadData();

            if (isHighScore())
            {
                lblHighScore.Visible = true;
                lblGoodluck.Visible = false;
            }
            else
            {
                lblHighScore.Visible = false;
                lblGoodluck.Visible = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
