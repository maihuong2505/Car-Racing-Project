using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CR.Interface
{
    public partial class frmWelcome : Form
    {
        private string playerName;

        public string PlayerName { get => playerName; set => playerName = value; }

        public frmWelcome()
        {
            InitializeComponent();
        }

        private void FrmWelcome_Load(object sender, EventArgs e)
        {
            locateLabel();
        }

        private void locateLabel()
        {
            lblWelcome.Text += PlayerName + "!";
            lblWelcome.Location = new Point(lblWelcome.Location.X - PlayerName.Length * 8 - 5, lblWelcome.Location.Y);
        }

        private void BtnPlayNow_Click(object sender, EventArgs e)
        {
            frmPlay frmPlay = new frmPlay();
            frmPlay.PlayerName = PlayerName;
            frmPlay.ShowDialog();            
        }

        private void BtnChangePlayer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Keep your car right ahead, collect coins and stay away from other cars!");
        }
    }
}
