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
    public partial class frmNewAccount : Form
    {
        private BLPlayer player;

        public BLPlayer Player { get => player; set => player = value; }

        public frmNewAccount()
        {
            InitializeComponent();
            Player = new BLPlayer();
        }

        private bool isValidName()
        {
            if (txtPlayerName.TextLength == 0)
            {
                MessageBox.Show("You must enter a name!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPlayerName.Focus();
                return false;
            }

            if (txtPlayerName.TextLength > 10)
            {
                MessageBox.Show("The player name's length is not greater than 10!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPlayerName.Focus();
                return false;
            }

            int n;
            bool canExecute = Player.getPlayerName(txtPlayerName.Text, out n);
            if (canExecute)
            {
                if (n > 0)
                {
                    MessageBox.Show("This name has existed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPlayerName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Error occurred!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPlayerName.Focus();
                return false;
            }

            return true;
        }

        private bool isValidPassword()
        {
            if (txtPassword.TextLength == 0)
            {
                MessageBox.Show("You must enter a password!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.TextLength > 10)
            {
                MessageBox.Show("The password's length is not greater than 10!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                return false;
            }

            return true;
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
                txtConfirmPassword.Focus();
        }

        private void TxtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
                e.Handled = true;
            else if (e.KeyChar != 13)
                e.Handled = false;
            else
                btnCreate.PerformClick();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!isValidName())
                return;

            if (!isValidPassword())
                return;

            if (!txtConfirmPassword.Text.Equals(txtPassword.Text))
            {
                MessageBox.Show("These passwords don't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();                
                txtConfirmPassword.Clear();
                txtPassword.Focus();
            }
            else
            {
                bool canExecute = Player.insertPlayer(txtPlayerName.Text, txtPassword.Text);
                if (canExecute)
                {
                    MessageBox.Show("Your account have been created successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Error occurred!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtPlayerName.Clear();
                    txtPassword.Clear();
                    txtConfirmPassword.Clear();

                    txtPlayerName.Focus();
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
