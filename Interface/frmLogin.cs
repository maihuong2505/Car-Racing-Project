using CR.BS_Layer;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void TxtPlayerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
                e.Handled = true;
            else if (e.KeyChar != 13)
                e.Handled = false;
            else
                txtPassword.Focus();
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
                e.Handled = true;
            else if (e.KeyChar != 13)
                e.Handled = false;
            else
                btnLogin.PerformClick();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            BLPlayer player = new BLPlayer();
            int n;

            bool canExecute = player.getPlayer(txtPlayerName.Text, txtPassword.Text, out n);

            if (canExecute)
            {
                if (n > 0)
                {
                    frmWelcome frmWelcome = new frmWelcome();
                    frmWelcome.PlayerName = txtPlayerName.Text;
                    frmWelcome.ShowDialog();

                    txtPlayerName.Clear();
                    txtPassword.Clear();

                    txtPlayerName.Focus();
                }
                else
                {
                    MessageBox.Show("Incorrect player name or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("Error occurred!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPlayerName.Focus();
            }
        }

        private void BtnCreateAnAccount_Click(object sender, EventArgs e)
        {            
            frmNewAccount frmNewAccount = new frmNewAccount();
            frmNewAccount.ShowDialog();

            txtPlayerName.Clear();
            txtPassword.Clear();

            txtPlayerName.Focus();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you really want to quit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
        }
    }
}
