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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            User user = DbSelected.user(txbEmailAddress.Text);

            if(user.UserId == 0)
            {
                user = new User
                {
                    FirstName = txbFirstName.Text,
                    LastName = txbLastName.Text,
                    EmailAddress = txbEmailAddress.Text,
                    Password = txbPassword.Text
                };

                DbInsert.user(user);
                MessageBox.Show("Registered successfull!..");

                Login form = new Login();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Process failed. E-mail address already registered!");
            }
            
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
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
    }
}
