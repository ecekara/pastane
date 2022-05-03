using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class MailSend
    {
        public static void ForgotPassword(User user)
        {
            string sendMailFullName = "Ekranda Görünecek İsim";
            string sendMailAddress = "gmail_adresiniz@gmail.com";
            string sendMailPassword = "gmail_sifreniz";

            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;

            sc.Credentials = new NetworkCredential(sendMailAddress, sendMailPassword);

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(sendMailAddress, sendMailFullName);

            mail.To.Add(user.EmailAddress);

            mail.Subject = "I forgot my password";
            mail.IsBodyHtml = true;
            mail.Body = String.Format("<p>Dear user,</p><p>Username: {0}</p><p>Your Password: {1}</p><p>We wish you a nice day.</p>", user.EmailAddress, user.Password);

            sc.Send(mail);
        }
    }
}
