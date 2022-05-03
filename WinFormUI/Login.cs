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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register form = new Register();
            form.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txbUsername.Text;
            var password = txbPassword.Text;

            User user = DbSelected.user(username);
            if(user.UserId != 0)
            {
                if(user.Password == password)
                {
                    Properties.Settings.Default["UserName"] = user.EmailAddress;

                    txbPassword.Text = null;
                    txbUsername.Text = null;

                    ProductForm form = new ProductForm();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Your password is incorrect.");
                    ForgotPassword form = new ForgotPassword();
                    form.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Your user record could not be found.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txbPassword.PasswordChar = '\0';
                checkBox1.Text = "Hide password";
            }
            else
            {
                txbPassword.PasswordChar = '*';
                checkBox1.Text = "Show password";
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
