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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text;
            User user = DbSelected.user(username);
            MailSend.ForgotPassword(user);
            MessageBox.Show("Your password has been sent to an e-mail.");
        }
    }
}
