using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Services
{
    
        public interface IEmailService
        {
            void Send(string to, string subject, string html);
        }

        public class EmailService : IEmailService
        {


            public void Send(string to, string subject, string html)
            {
                
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("Wrish-Shop@yandex.com"));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = html };
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };


                using var smtp = new SmtpClient();
                smtp.Connect("smtp.yandex.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("Wrish-Shop@yandex.com", "wrish.p201");
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    
}
