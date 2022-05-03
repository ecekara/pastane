using Database;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class PasswordChange : Form
    {
        public PasswordChange()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txbOldPassword.PasswordChar = '\0';
                txbPassword.PasswordChar = '\0';
                checkBox1.Text = "Hide password";
            }
            else
            {
                txbOldPassword.PasswordChar = '*';
                txbPassword.PasswordChar = '*';
                checkBox1.Text = "Show password";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var _userName = Properties.Settings.Default["UserName"].ToString();

            User user = DbSelected.user(_userName);

            if(user.UserId != 0)
            {
                if(user.Password == txbOldPassword.Text)
                {
                    user.Password = txbPassword.Text;
                    DbUpdate.user(user);
                    txbOldPassword.Text = null;
                    txbPassword.Text = null;
                    MessageBox.Show("Your password has been successfully changed.");
                }
                else
                {
                    MessageBox.Show("You entered your current password incorrectly.");
                }
            }
            else
            {
                MessageBox.Show("I cannot access your account.");
                Application.Exit();
            }
        }

        private void PasswordChange_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProductForm form = new ProductForm();
            form.Show();
            this.Hide();
        }
    }
}
