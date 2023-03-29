using MimeKit;

namespace PotentialForAfrica.Helpers
{
    public class Message
    {
        public MailboxAddress Receiver { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(string receiverName,string receiversEmail, string subject, string content)
        {
            Receiver = new MailboxAddress(receiverName, receiversEmail);
            Subject = subject;
            Content = content;
        }
    }
}
