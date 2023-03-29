using MailKit.Net.Smtp;
using MimeKit;
using PotentialForAfrica.Exception;
using PotentialForAfrica.Helpers;
using PotentialForAfrica.Interfaces;

namespace PotentialForAfrica.Services
{
    public class MailSenderService : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        public MailSenderService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public void SendEmail(Message message)
        {
            try
            {
                var emailMessage = CreateEmailMessage(message);
                Send(emailMessage);
            }
            catch (System.Exception Excep)
            {
                throw new EmailSenderException($"Erreur dans l'envoie de mail {Excep.Message}", innerException: Excep.InnerException);
            }
        }
        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.UserName, _emailConfig.From));
            emailMessage.To.Add(message.Receiver);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }
        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch (System.Exception Excep)
                {
                    throw new EmailSenderException($"Erreur dans l'envoie de mail {Excep.Message}", innerException: Excep.InnerException);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
