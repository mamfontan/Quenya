using Quenya.Common.interfaces;
using Quenya.Domain;
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

        public StatusMessage SendMessaqe(string subject, string body, string toAddress)
        {
            var result = new StatusMessage();

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

                result = new StatusMessage(MSG_TYPE.SUCCESS, "Correo enviado correctamente");
            }
            catch (Exception error)
            {
                result = new StatusMessage(MSG_TYPE.ERROR, "No se puede acceder al servidor" + Environment.NewLine + error.Message);
            }

            return result;
        }
    }
}
