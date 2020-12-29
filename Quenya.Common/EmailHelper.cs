using Quenya.Common.interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Quenya.Common
{
    public class EmailHelper : IEmailHelper
    {
        private string _smtpServer = string.Empty;
        private string _username = string.Empty;
        private string _password = string.Empty;

        public EmailHelper(string smtpServer, string username, string password)
        {
            _smtpServer = smtpServer;
            _username = username;
            _password = password;
        }

        public bool SendMessaqe(string subject, string body, string toAddress)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(_smtpServer);

                mail.From = new MailAddress("your_email_address@gmail.com");
                mail.To.Add(toAddress);
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_username, _password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
